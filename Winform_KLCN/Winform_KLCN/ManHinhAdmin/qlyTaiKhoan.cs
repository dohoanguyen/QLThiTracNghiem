using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_KLCN.ManHinhAdmin
{
    
    public partial class qlyTaiKhoan : UserControl
    {
        private DataTable dtTaiKhoan;
        private bool isEditing = false;
        private string editingMaTK = "";
        public qlyTaiKhoan()
        {
            InitializeComponent();
            CauHinhDataGridView();
            LoadPhanQuyen();
            LoadTatCaTaiKhoan();

            btnSua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Thông báo");
                return;
            }

            isEditing = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;

            editingMaTK = dgvTaiKhoan.CurrentRow.Cells["MaTK"].Value.ToString();

            dgvTaiKhoan.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvTaiKhoan.Columns)
            {
                col.ReadOnly = col.Name != "TrangThai";
            }

            MessageBox.Show("Bạn có thể chỉnh sửa Trạng thái tài khoản.\nSau khi chỉnh xong, nhấn Lưu để hoàn tất.",
                "Chế độ chỉnh sửa");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                MessageBox.Show("Không có tài khoản nào đang được sửa.", "Thông báo");
                return;
            }

            DataGridViewRow row = dgvTaiKhoan.CurrentRow;
            string trangThai = row.Cells["TrangThai"].Value.ToString();

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = "UPDATE TAIKHOAN SET TrangThai=@tt WHERE MaTK=@mtk";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tt", trangThai);
                cmd.Parameters.AddWithValue("@mtk", editingMaTK);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Đã lưu thay đổi trạng thái thành công.", "Thành công");

            isEditing = false;
            editingMaTK = "";
            dgvTaiKhoan.ReadOnly = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;

            LoadTatCaTaiKhoan();
        }
        private void CauHinhDataGridView()
        {
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.MultiSelect = false;
            dgvTaiKhoan.AllowUserToAddRows = false;
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.RowHeadersVisible = false;

            dgvTaiKhoan.ColumnHeadersVisible = true;
            dgvTaiKhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvTaiKhoan.ColumnHeadersHeight = 40;

            dgvTaiKhoan.Columns.Clear();
            AddColumn("MaTK", "Mã TK", 50);
            AddColumn("TaiKhoan", "Tài khoản", 150);
            AddColumn("MatKhau", "Mật khẩu", 150);
            AddColumn("LoaiPQ", "Phân quyền", 120);
            AddColumn("NgayTao", "Ngày tạo", 130);

            DataGridViewComboBoxColumn colTrangThai = new DataGridViewComboBoxColumn()
            {
                Name = "TrangThai",
                DataPropertyName = "TrangThai",
                HeaderText = "Trạng thái",
                Width = 120,
                FlatStyle = FlatStyle.Flat,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                ReadOnly = true
            };
            colTrangThai.Items.AddRange("Hoạt động", "Khóa");
            dgvTaiKhoan.Columns.Add(colTrangThai);
        }

        private void AddColumn(string dataProp, string header, int width)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn()
            {
                Name = dataProp,
                DataPropertyName = dataProp,
                HeaderText = header,
                Width = width,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            dgvTaiKhoan.Columns.Add(col);
        }

        private void LoadPhanQuyen()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = "SELECT MaPQ, LoaiPQ FROM PHANQUYEN";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dtPQ = new DataTable();
                    da.Fill(dtPQ);

                    DataRow dr = dtPQ.NewRow();
                    dr["MaPQ"] = 0;
                    dr["LoaiPQ"] = "Tất cả";
                    dtPQ.Rows.InsertAt(dr, 0);

                    cboPhanQuyen.DataSource = dtPQ;
                    cboPhanQuyen.DisplayMember = "LoaiPQ";
                    cboPhanQuyen.ValueMember = "MaPQ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load phân quyền: " + ex.Message);
            }
        }

        private void LoadTatCaTaiKhoan()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    string sql = @"SELECT tk.MaTK, tk.TaiKhoan, tk.MatKhau, pq.LoaiPQ, tk.NgayTao, tk.TrangThai
                                   FROM TAIKHOAN tk
                                   JOIN PHANQUYEN pq ON tk.MaPQ = pq.MaPQ";

                    object selectedValue = cboPhanQuyen.SelectedValue;
                    int maPQ = 0;

                    if (selectedValue != null && int.TryParse(selectedValue.ToString(), out int parsed))
                        maPQ = parsed;
                    if (maPQ != 0)
                        sql += " WHERE tk.MaPQ = @mapq";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    if (maPQ != 0)
                        cmd.Parameters.AddWithValue("@mapq", maPQ);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dtTaiKhoan = new DataTable();
                    da.Fill(dtTaiKhoan);

                    dgvTaiKhoan.DataSource = dtTaiKhoan;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load tài khoản: " + ex.Message);
            }
        }
        private void cboPhanQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhanQuyen.SelectedValue != null)
                LoadTatCaTaiKhoan();
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !isEditing)
            {
                btnSua.Enabled = true;
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                MessageBox.Show("Không có tài khoản nào đang được sửa.", "Thông báo");
                return;
            }

            DataGridViewRow row = dgvTaiKhoan.CurrentRow;
            string trangThai = row.Cells["TrangThai"].Value.ToString();

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = "UPDATE TAIKHOAN SET TrangThai=@tt WHERE MaTK=@mtk";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tt", trangThai);
                cmd.Parameters.AddWithValue("@mtk", editingMaTK);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Đã lưu thay đổi trạng thái thành công.", "Thành công");

            isEditing = false;
            editingMaTK = "";
            dgvTaiKhoan.ReadOnly = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;

            LoadTatCaTaiKhoan();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu ô tìm kiếm trống → load lại toàn bộ
                LoadTatCaTaiKhoan();
                return;
            }

            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    string sql = @"
                SELECT tk.MaTK, tk.TaiKhoan, tk.MatKhau, pq.LoaiPQ, tk.NgayTao, tk.TrangThai
                FROM TAIKHOAN tk
                JOIN PHANQUYEN pq ON tk.MaPQ = pq.MaPQ
                WHERE tk.TaiKhoan LIKE @keyword OR CAST(tk.MaTK AS NVARCHAR) LIKE @keyword";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("❌ Không tìm thấy tài khoản nào phù hợp!", "Kết quả tìm kiếm");
                    }

                    dgvTaiKhoan.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi");
            }
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
