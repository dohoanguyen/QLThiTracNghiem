using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Winform_KLCN.ManHinhAdmin
{
    public partial class qlyHocVien : UserControl
    {
        private DataTable dtHocVien;
        private DataTable dtLop;
        private bool isEditing = false;
        private int editingMaHV = -1;

        public qlyHocVien()
        {
            InitializeComponent();
            CauHinhDataGridView();
            LoadLop();
            LoadHocVien(); // load all by default

            // sự kiện
            cboLop.SelectedIndexChanged += cbbLop_SelectedIndexChanged;
            btnTimKiem.Click += btnTimKiem_Click;
            btnSua.Click += btnSua_Click;
            btnLuu.Click += btnLuu_Click;
            dgvHocVien.CellClick += dgvHocVien_CellClick;

            btnSua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void CauHinhDataGridView()
        {
            dgvHocVien.AutoGenerateColumns = false;
            dgvHocVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHocVien.MultiSelect = false;
            dgvHocVien.AllowUserToAddRows = false;
            dgvHocVien.ReadOnly = true;
            dgvHocVien.RowHeadersVisible = false;
            dgvHocVien.ColumnHeadersVisible = true;
            dgvHocVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvHocVien.ColumnHeadersHeight = 40;

            dgvHocVien.Columns.Clear();
            AddColumn("MaHV", "Mã HV", 60);
            AddColumn("TenHV", "Họ và tên", 200);
            AddColumn("GioiTinh", "Giới tính", 80);
            AddColumn("NgaySinh", "Ngày sinh", 110);
            AddColumn("DiaChi", "Địa chỉ", 220);
            AddColumn("SDT", "SĐT", 110);
            AddColumn("TrangThai", "Trạng thái", 120);
            AddColumn("TenLop", "Lớp", 180);
        }

        private void AddColumn(string dataProp, string header, int width)
        {
            var col = new DataGridViewTextBoxColumn()
            {
                Name = dataProp,
                DataPropertyName = dataProp,
                HeaderText = header,
                Width = width,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            dgvHocVien.Columns.Add(col);
        }

        private void LoadLop()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = "SELECT MaL, TenLop FROM LOPHOC ORDER BY TenLop";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    dtLop = new DataTable();
                    da.Fill(dtLop);

                    // Thêm "Tất cả" và "Chưa phân lớp"
                    DataTable dtCombo = dtLop.Clone();
                    DataRow rAll = dtCombo.NewRow();
                    rAll["MaL"] = -1;
                    rAll["TenLop"] = "Tất cả";
                    dtCombo.Rows.Add(rAll);

                    DataRow rNone = dtCombo.NewRow();
                    rNone["MaL"] = 0;
                    rNone["TenLop"] = "Chưa phân lớp";
                    dtCombo.Rows.Add(rNone);

                    foreach (DataRow r in dtLop.Rows)
                        dtCombo.ImportRow(r);

                    cboLop.DisplayMember = "TenLop";
                    cboLop.ValueMember = "MaL";
                    cboLop.DataSource = dtCombo;
                    cboLop.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách lớp: " + ex.Message);
            }
        }

        /// <summary>
        /// Load học viên
        /// </summary>
        private void LoadHocVien(int maL = -1)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql;

                    if (maL == 0) // chưa phân lớp
                    {
                        sql = @"
                            SELECT HV.MaHV, HV.TenHV, HV.GioiTinh, HV.NgaySinh, HV.DiaChi, HV.SDT, HV.TrangThai,
                                   N'Chưa phân lớp' AS TenLop
                            FROM HOCVIEN HV
                            WHERE HV.MaHV NOT IN (SELECT MaHV FROM HOCVIEN_LOPHOC)";
                    }
                    else if (maL > 0) // theo lớp cụ thể
                    {
                        sql = @"
                            SELECT HV.MaHV, HV.TenHV, HV.GioiTinh, HV.NgaySinh, HV.DiaChi, HV.SDT, HV.TrangThai,
                                   STRING_AGG(L.TenLop, ', ') AS TenLop
                            FROM HOCVIEN HV
                            JOIN HOCVIEN_LOPHOC HL ON HV.MaHV = HL.MaHV
                            JOIN LOPHOC L ON HL.MaL = L.MaL
                            WHERE L.MaL = @MaL
                            GROUP BY HV.MaHV, HV.TenHV, HV.GioiTinh, HV.NgaySinh, HV.DiaChi, HV.SDT, HV.TrangThai";
                    }
                    else // tất cả
                    {
                        sql = @"
                            SELECT HV.MaHV, HV.TenHV, HV.GioiTinh, HV.NgaySinh, HV.DiaChi, HV.SDT, HV.TrangThai,
                                   COALESCE(STRING_AGG(L.TenLop, ', '), N'Chưa phân lớp') AS TenLop
                            FROM HOCVIEN HV
                            LEFT JOIN HOCVIEN_LOPHOC HL ON HV.MaHV = HL.MaHV
                            LEFT JOIN LOPHOC L ON HL.MaL = L.MaL
                            GROUP BY HV.MaHV, HV.TenHV, HV.GioiTinh, HV.NgaySinh, HV.DiaChi, HV.SDT, HV.TrangThai";
                    }

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (maL > 0) cmd.Parameters.AddWithValue("@MaL", maL);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dtHocVien = new DataTable();
                        da.Fill(dtHocVien);
                        dgvHocVien.DataSource = dtHocVien;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load học viên: " + ex.Message);
            }
        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLop.SelectedValue == null) return;
            LoadHocVien(Convert.ToInt32(cboLop.SelectedValue));
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();

            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
                        SELECT HV.MaHV, HV.TenHV, HV.GioiTinh, HV.NgaySinh, HV.DiaChi, HV.SDT, HV.TrangThai,
                               COALESCE(STRING_AGG(L.TenLop, ', '), N'Chưa phân lớp') AS TenLop
                        FROM HOCVIEN HV
                        LEFT JOIN HOCVIEN_LOPHOC HL ON HV.MaHV = HL.MaHV
                        LEFT JOIN LOPHOC L ON HL.MaL = L.MaL
                        WHERE HV.TenHV LIKE @kw OR HV.SDT LIKE @kw OR CAST(HV.MaHV AS NVARCHAR(10)) LIKE @kw
                        GROUP BY HV.MaHV, HV.TenHV, HV.GioiTinh, HV.NgaySinh, HV.DiaChi, HV.SDT, HV.TrangThai";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + kw + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvHocVien.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void dgvHocVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!isEditing)
            {
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
            }

            if (dgvHocVien.CurrentRow != null && dgvHocVien.CurrentRow.Cells["MaHV"].Value != null)
                int.TryParse(dgvHocVien.CurrentRow.Cells["MaHV"].Value.ToString(), out editingMaHV);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (editingMaHV <= 0)
            {
                MessageBox.Show("Vui lòng chọn học viên cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditing = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;

            dgvHocVien.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvHocVien.Columns)
            {
                col.ReadOnly = !(col.Name == "DiaChi" || col.Name == "SDT");
            }

            MessageBox.Show("Bạn chỉ có thể chỉnh sửa Địa chỉ và SĐT. Nhấn Lưu để xác nhận.", "Chế độ sửa");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!isEditing || editingMaHV <= 0)
            {
                MessageBox.Show("Không có thay đổi để lưu.", "Thông báo");
                return;
            }

            try
            {
                var row = dgvHocVien.CurrentRow;
                if (row == null) return;

                string diaChi = row.Cells["DiaChi"].Value?.ToString();
                string sdt = row.Cells["SDT"].Value?.ToString();

                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"UPDATE HOCVIEN SET DiaChi=@DiaChi, SDT=@SDT WHERE MaHV=@MaHV";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@DiaChi", (object)diaChi ?? DBNull.Value);
                    string digits = sdt == null ? "" : new string(sdt.Where(char.IsDigit).ToArray());
                    cmd.Parameters.AddWithValue("@SDT", digits.Length == 10 ? digits : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaHV", editingMaHV);

                    int aff = cmd.ExecuteNonQuery();
                    MessageBox.Show(aff > 0 ? "Đã lưu thay đổi!" : "Không có dòng nào được cập nhật.", "Kết quả");
                }

                isEditing = false;
                editingMaHV = -1;
                dgvHocVien.ReadOnly = true;
                btnLuu.Enabled = false;
                btnSua.Enabled = false;

                LoadHocVien(Convert.ToInt32(cboLop.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }
    }
}
