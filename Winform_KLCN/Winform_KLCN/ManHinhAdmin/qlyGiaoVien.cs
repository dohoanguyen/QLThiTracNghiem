using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Winform_KLCN.ManHinhAdmin
{
    public partial class qlyGiaoVien : UserControl
    {
        private DataTable dtGiaoVien;
        private bool isEditing = false;
        private string editingMaGV = "";

        public qlyGiaoVien()
        {
            InitializeComponent();
            CauHinhDataGridView();
            LoadTatCaGiaoVien();

            btnSua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void CauHinhDataGridView()
        {
            dgvGiaoVien.AutoGenerateColumns = false;
            dgvGiaoVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGiaoVien.MultiSelect = false;
            dgvGiaoVien.AllowUserToAddRows = false;
            dgvGiaoVien.ReadOnly = true;
            dgvGiaoVien.RowHeadersVisible = false;

            dgvGiaoVien.Columns.Clear();

            // ✅ Thêm cột MaGV nhưng ẩn
            AddColumn("MaGV", "Mã GV", 50);
            dgvGiaoVien.Columns["MaGV"].Visible = false;

            AddColumn("TenGV", "Tên giáo viên", 180);
            AddColumn("GioiTinh", "Giới tính", 40);
            AddColumn("NgaySinh", "Ngày sinh", 100);
            AddColumn("TrinhDo", "Trình độ", 120);
            AddColumn("SDT", "SĐT", 100);
            AddColumn("TrangThai", "Trạng thái", 120);
            AddColumn("DiaChi", "Địa chỉ", 200);
            AddColumn("MonDay", "Môn dạy", 150);
            AddColumn("LopDay", "Lớp dạy", 150);

            // Thêm nút Xóa
            if (!dgvGiaoVien.Columns.Contains("btnXoa"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.Name = "btnXoa";
                btnDelete.HeaderText = "Xóa";
                btnDelete.Text = "Xóa";
                btnDelete.UseColumnTextForButtonValue = true;
                btnDelete.Width = 60;
                dgvGiaoVien.Columns.Add(btnDelete);
            }

            dgvGiaoVien.CellClick += dgvGiaoVien_CellClick;
            dgvGiaoVien.CellContentClick += dgvGiaoVien_CellContentClick;
        }


        private void AddColumn(string dataProp, string header, int width)
        {
            dgvGiaoVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = dataProp,
                DataPropertyName = dataProp,
                HeaderText = header,
                Width = width,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }


        private void LoadTatCaGiaoVien()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
                SELECT gv.MaGV, gv.TenGV, gv.GioiTinh, gv.NgaySinh, gv.TrinhDo, gv.SDT, gv.TrangThai, gv.DiaChi,
                       (SELECT STRING_AGG(m.TenMon, ', ') 
                        FROM GIAOVIEN_MON gm
                        JOIN MON m ON gm.MaM = m.MaM
                        WHERE gm.MaGV = gv.MaGV) AS MonDay,
                       (SELECT STRING_AGG(l.TenLop, ', ') 
                        FROM LOPHOC l
                        WHERE l.MaGV = gv.MaGV) AS LopDay
                FROM GIAOVIEN gv";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    dtGiaoVien = new DataTable();
                    da.Fill(dtGiaoVien);
                    dgvGiaoVien.DataSource = dtGiaoVien;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load giáo viên: " + ex.Message);
            }
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvGiaoVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn giáo viên cần sửa!", "Thông báo");
                return;
            }

            isEditing = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;

            // Lưu mã GV đang sửa
            editingMaGV = dgvGiaoVien.CurrentRow.Cells["MaGV"].Value.ToString();

            // Cho phép chỉnh sửa 3 cột: Trình độ, SDT, Địa chỉ
            dgvGiaoVien.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvGiaoVien.Columns)
            {
                if (col.Name == "TrinhDo" || col.Name == "SDT" || col.Name == "DiaChi")
                    col.ReadOnly = false;
                else
                    col.ReadOnly = true;
            }

            MessageBox.Show(
                "Bạn có thể chỉnh sửa Trình độ, SĐT và Địa chỉ.\nSau khi chỉnh xong, nhấn Lưu để hoàn tất.",
                "Chế độ chỉnh sửa");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                MessageBox.Show("Không có thông tin nào đang được sửa.", "Thông báo");
                return;
            }

            DataGridViewRow row = dgvGiaoVien.CurrentRow;
            string trinhDo = row.Cells["TrinhDo"].Value.ToString();
            string sdt = row.Cells["SDT"].Value.ToString();
            string diaChi = row.Cells["DiaChi"].Value.ToString();

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = "UPDATE GIAOVIEN SET TrinhDo=@td, SDT=@sdt, DiaChi=@dc WHERE MaGV=@mgv";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@td", trinhDo);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                cmd.Parameters.AddWithValue("@dc", diaChi);
                cmd.Parameters.AddWithValue("@mgv", editingMaGV);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Đã lưu thay đổi thành công.", "Thành công");

            // Reset trạng thái
            isEditing = false;
            editingMaGV = "";
            dgvGiaoVien.ReadOnly = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;

            LoadTatCaGiaoVien();
        }

        private void dgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !isEditing)
            {
                btnSua.Enabled = true;
            }
        }

        private void dgvGiaoVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvGiaoVien.Columns[e.ColumnIndex].Name == "btnXoa")
            {
                string maGV = dgvGiaoVien.Rows[e.RowIndex].Cells["MaGV"].Value.ToString();
                string tenGV = dgvGiaoVien.Rows[e.RowIndex].Cells["TenGV"].Value.ToString();

                DialogResult dr = MessageBox.Show(
                    $"Bạn có chắc muốn xóa giáo viên {tenGV} (Mã: {maGV})?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = KetNoi.TaoKetNoi())
                        {
                            conn.Open();

                            // Kiểm tra xem GV có đang dạy lớp nào không
                            string checkSql = "SELECT COUNT(*) FROM LOPHOC WHERE MaGV=@mgv";
                            SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                            checkCmd.Parameters.AddWithValue("@mgv", maGV);
                            int count = (int)checkCmd.ExecuteScalar();

                            if (count > 0)
                            {
                                MessageBox.Show(
                                    $"Không thể xóa giáo viên {tenGV} vì đang dạy {count} lớp!",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; // thoát khỏi hàm
                            }

                            // Nếu không có lớp nào thì mới xóa
                            string sql = "DELETE FROM GIAOVIEN WHERE MaGV=@mgv";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@mgv", maGV);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Đã xóa giáo viên thành công!", "Thành công");
                        LoadTatCaGiaoVien();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa giáo viên: " + ex.Message, "Lỗi");
                    }
                }
            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadTatCaGiaoVien();
                return;
            }

            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    string sql = @"
                        SELECT MaGV, TenGV, GioiTinh, NgaySinh, TrinhDo, SDT, TrangThai, DiaChi
                        FROM GIAOVIEN
                        WHERE TenGV LIKE @keyword OR CAST(MaGV AS NVARCHAR) LIKE @keyword";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("❌ Không tìm thấy giáo viên nào phù hợp!", "Kết quả tìm kiếm");
                    }

                    dgvGiaoVien.DataSource = dt;

                    // ✅ Thêm nút Xóa sau khi tìm kiếm nếu chưa tồn tại
                    if (!dgvGiaoVien.Columns.Contains("btnXoa"))
                    {
                        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                        btnDelete.Name = "btnXoa";
                        btnDelete.HeaderText = "Xóa";
                        btnDelete.Text = "Xóa";
                        btnDelete.UseColumnTextForButtonValue = true;
                        btnDelete.Width = 60;
                        dgvGiaoVien.Columns.Add(btnDelete);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi");
            }
        }
    }
}
