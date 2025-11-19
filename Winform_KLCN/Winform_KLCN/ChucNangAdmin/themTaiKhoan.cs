using ExcelDataReader;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Winform_KLCN.ChucNangAdmin
{
    public partial class themTaiKhoan : Form
    {
        private string loaiTaiKhoan; // "GV", "HV", "AD"
        private DataTable dtDuLieuExcel;

        public themTaiKhoan(string loai)
        {
            InitializeComponent();
            loaiTaiKhoan = loai;
            CauHinhGiaoDien();
        }

        private void CauHinhGiaoDien()
        {
            this.Text = "Thêm tài khoản " +
                (loaiTaiKhoan == "GV" ? "Giáo viên" :
                 loaiTaiKhoan == "HV" ? "Học viên" : "Admin");

            if (loaiTaiKhoan == "AD")
            {
                // Ẩn tất cả textbox GV/HV
                txtTen.Visible = false;
                cboGioiTinh.Visible = false;
                dtpNgaySinh.Visible = false;
                txtEmail.Visible = false;
                txtSDT.Visible = false;
                txtDiaChi.Visible = false;
                txtTrinhDo.Visible = false;
                btnChonFile.Visible = false;

                // Hiện textbox admin
                txtTaiKhoan.Visible = true;

                // Thu form về 500x500
                this.Size = new Size(350, 300);
            }
            else
            {
                // Hiển thị textbox GV/HV
                txtTen.Visible = true;
                cboGioiTinh.Visible = true;
                dtpNgaySinh.Visible = true;
                txtEmail.Visible = true;
                txtSDT.Visible = true;
                txtDiaChi.Visible = true;
                txtTrinhDo.Visible = loaiTaiKhoan == "GV";
                btnChonFile.Visible = true;
                label7.Visible = loaiTaiKhoan == "GV";
                cboGioiTinh.Items.Clear();
                cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ", "Khác" });
                cboGioiTinh.SelectedIndex = 0; // mặc định chọn Nam
                // Ẩn textbox admin
                txtTaiKhoan.Visible = false;
            }
        }

        // --- Chọn file Excel ---
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Chọn file Excel"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });

                        dtDuLieuExcel = result.Tables[0];
                        dgvXem.DataSource = dtDuLieuExcel;
                        MessageBox.Show("✅ Đọc file Excel thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Lỗi đọc file: " + ex.Message);
                }
            }
        }

        // --- Xác nhận dùng chung ---
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (loaiTaiKhoan == "AD")
                ThemAdminThuCong();
            else
            {
                if (dtDuLieuExcel != null && dtDuLieuExcel.Rows.Count > 0)
                    ThemTuFileExcel();
                else
                    ThemThuCong();
            }
        }

        // --- Thêm Admin thủ công ---
        private void ThemAdminThuCong()
        {
            string taiKhoan = txtTaiKhoan.Text.Trim();
            if (string.IsNullOrEmpty(taiKhoan))
            {
                MessageBox.Show("Vui lòng nhập tài khoản admin!");
                return;
            }

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string check = "SELECT COUNT(*) FROM TAIKHOAN WHERE TaiKhoan=@tk";
                SqlCommand cmdCheck = new SqlCommand(check, conn);
                cmdCheck.Parameters.AddWithValue("@tk", taiKhoan);
                int count = (int)cmdCheck.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("❌ Tài khoản đã tồn tại!");
                    return;
                }

                string sql = @"INSERT INTO TAIKHOAN (TaiKhoan, MatKhau, MaPQ, TrangThai, NgayTao)
                               VALUES (@tk, @mk, 1, N'Hoạt động', GETDATE())";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tk", taiKhoan);
                cmd.Parameters.AddWithValue("@mk", "Admin@123");
                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Thêm tài khoản admin thành công!");
                this.Close();
            }
        }

        // --- Thêm GV/HV thủ công ---
        private void ThemThuCong()
        {
            string ten = txtTen.Text.Trim();
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập tên!");
                return;
            }

            string email = txtEmail.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            // Kiểm tra SDT hợp lệ
            if (!string.IsNullOrEmpty(sdt) && (sdt.Length != 10 || !ulong.TryParse(sdt, out _))) sdt = null;

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // Kiểm tra Email trùng
                    if (!string.IsNullOrEmpty(email))
                    {
                        string checkEmailSql = loaiTaiKhoan == "GV" ?
                            "SELECT COUNT(*) FROM GIAOVIEN WHERE Email=@e" :
                            "SELECT COUNT(*) FROM HOCVIEN WHERE Email=@e";

                        SqlCommand cmdCheckEmail = new SqlCommand(checkEmailSql, conn, tran);
                        cmdCheckEmail.Parameters.AddWithValue("@e", email);
                        if ((int)cmdCheckEmail.ExecuteScalar() > 0) email = null;
                    }

                    string taiKhoan = TaoTenTaiKhoan(ten, loaiTaiKhoan);
                    string matKhau = loaiTaiKhoan == "GV" ? "Gv@123" : "Hv@123";
                    int maPQ = loaiTaiKhoan == "GV" ? 2 : 3;

                    // Kiểm tra tài khoản tồn tại
                    string sqlCheck = "SELECT COUNT(*) FROM TAIKHOAN WHERE TaiKhoan=@tk";
                    SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn, tran);
                    cmdCheck.Parameters.AddWithValue("@tk", taiKhoan);
                    if ((int)cmdCheck.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("❌ Tài khoản đã tồn tại!");
                        tran.Rollback();
                        return;
                    }

                    // Thêm vào TAIKHOAN
                    string sqlTK = @"INSERT INTO TAIKHOAN (TaiKhoan, MatKhau, MaPQ, TrangThai, NgayTao)
                                     OUTPUT INSERTED.MaTK
                                     VALUES (@tk, @mk, @pq, N'Hoạt động', GETDATE())";

                    SqlCommand cmdTK = new SqlCommand(sqlTK, conn, tran);
                    cmdTK.Parameters.AddWithValue("@tk", taiKhoan);
                    cmdTK.Parameters.AddWithValue("@mk", matKhau);
                    cmdTK.Parameters.AddWithValue("@pq", maPQ);
                    int maTK = Convert.ToInt32(cmdTK.ExecuteScalar());

                    // Thêm vào chi tiết
                    if (loaiTaiKhoan == "GV")
                    {
                        string sqlGV = @"INSERT INTO GIAOVIEN (MaTK, TenGV, GioiTinh, NgaySinh, Email, DiaChi, TrinhDo, SDT, TrangThai)
                                         VALUES (@matk, @ten, @gt, @ns, @email, @dc, @td, @sdt, N'Đang dạy')";
                        SqlCommand cmdGV = new SqlCommand(sqlGV, conn, tran);
                        cmdGV.Parameters.AddWithValue("@matk", maTK);
                        cmdGV.Parameters.AddWithValue("@ten", ten);
                        cmdGV.Parameters.AddWithValue("@gt", cboGioiTinh.SelectedItem ?? DBNull.Value);
                        cmdGV.Parameters.AddWithValue("@ns", dtpNgaySinh.Value.Date);
                        cmdGV.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                        cmdGV.Parameters.AddWithValue("@dc", txtDiaChi.Text.Trim());
                        cmdGV.Parameters.AddWithValue("@td", txtTrinhDo.Text.Trim());
                        cmdGV.Parameters.AddWithValue("@sdt", (object)sdt ?? DBNull.Value);
                        cmdGV.ExecuteNonQuery();
                    }
                    else
                    {
                        string sqlHV = @"INSERT INTO HOCVIEN (MaTK, TenHV, GioiTinh, NgaySinh, Email, SDT, DiaChi, TrangThai)
                                         VALUES (@matk, @ten, @gt, @ns, @email, @sdt, @dc, N'Đang học')";
                        SqlCommand cmdHV = new SqlCommand(sqlHV, conn, tran);
                        cmdHV.Parameters.AddWithValue("@matk", maTK);
                        cmdHV.Parameters.AddWithValue("@ten", ten);
                        cmdHV.Parameters.AddWithValue("@gt", cboGioiTinh.SelectedItem ?? DBNull.Value);
                        cmdHV.Parameters.AddWithValue("@ns", dtpNgaySinh.Value.Date);
                        cmdHV.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                        cmdHV.Parameters.AddWithValue("@sdt", (object)sdt ?? DBNull.Value);
                        cmdHV.Parameters.AddWithValue("@dc", txtDiaChi.Text.Trim());
                        cmdHV.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("✅ Thêm thành công!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("❌ Lỗi khi thêm dữ liệu: " + ex.Message);
                }
            }
        }

        // --- Thêm từ Excel ---
        private void ThemTuFileExcel()
        {
            if (dtDuLieuExcel == null || dtDuLieuExcel.Rows.Count == 0)
            {
                MessageBox.Show("❌ Chưa có dữ liệu Excel!");
                return;
            }

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                int countAdded = 0;

                try
                {
                    foreach (DataRow row in dtDuLieuExcel.Rows)
                    {
                        string ten = loaiTaiKhoan == "GV" ? row["TenGV"]?.ToString().Trim() : row["TenHV"]?.ToString().Trim();
                        string email = row["Email"]?.ToString().Trim();
                        string sdt = row["SDT"]?.ToString().Trim();

                        if (string.IsNullOrEmpty(ten)) continue;
                        if (!string.IsNullOrEmpty(sdt) && (sdt.Length != 10 || !ulong.TryParse(sdt, out _))) sdt = null;

                        // Kiểm tra Email trùng
                        if (!string.IsNullOrEmpty(email))
                        {
                            string checkEmailSql = loaiTaiKhoan == "GV" ?
                                "SELECT COUNT(*) FROM GIAOVIEN WHERE Email=@e" :
                                "SELECT COUNT(*) FROM HOCVIEN WHERE Email=@e";

                            SqlCommand cmdCheckEmail = new SqlCommand(checkEmailSql, conn, tran);
                            cmdCheckEmail.Parameters.AddWithValue("@e", email);
                            if ((int)cmdCheckEmail.ExecuteScalar() > 0) email = null;
                        }

                        string taiKhoan = TaoTenTaiKhoan(ten, loaiTaiKhoan);
                        string matKhau = loaiTaiKhoan == "GV" ? "Gv@123" : "Hv@123";
                        int maPQ = loaiTaiKhoan == "GV" ? 2 : 3;

                        // Kiểm tra tài khoản tồn tại
                        string sqlCheck = "SELECT COUNT(*) FROM TAIKHOAN WHERE TaiKhoan=@tk";
                        SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn, tran);
                        cmdCheck.Parameters.AddWithValue("@tk", taiKhoan);
                        if ((int)cmdCheck.ExecuteScalar() > 0) continue;

                        // Thêm vào TAIKHOAN
                        string sqlTK = @"INSERT INTO TAIKHOAN (TaiKhoan, MatKhau, MaPQ, TrangThai, NgayTao)
                                         OUTPUT INSERTED.MaTK
                                         VALUES (@tk, @mk, @pq, N'Hoạt động', GETDATE())";

                        SqlCommand cmdTK = new SqlCommand(sqlTK, conn, tran);
                        cmdTK.Parameters.AddWithValue("@tk", taiKhoan);
                        cmdTK.Parameters.AddWithValue("@mk", matKhau);
                        cmdTK.Parameters.AddWithValue("@pq", maPQ);
                        object result = cmdTK.ExecuteScalar();
                        if (result == null || result == DBNull.Value) continue;
                        int maTK = Convert.ToInt32(result);

                        // Thêm chi tiết
                        if (loaiTaiKhoan == "GV")
                        {
                            string sqlGV = @"INSERT INTO GIAOVIEN (MaTK, TenGV, GioiTinh, NgaySinh, Email, DiaChi, TrinhDo, SDT, TrangThai)
                                             VALUES (@matk, @ten, @gt, @ns, @email, @dc, @td, @sdt, N'Đang dạy')";
                            SqlCommand cmdGV = new SqlCommand(sqlGV, conn, tran);
                            cmdGV.Parameters.AddWithValue("@matk", maTK);
                            cmdGV.Parameters.AddWithValue("@ten", ten);
                            cmdGV.Parameters.AddWithValue("@gt", row["GioiTinh"] ?? DBNull.Value);
                            cmdGV.Parameters.AddWithValue("@ns", row["NgaySinh"] ?? DBNull.Value);
                            cmdGV.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                            cmdGV.Parameters.AddWithValue("@dc", row["DiaChi"] ?? DBNull.Value);
                            cmdGV.Parameters.AddWithValue("@td", row["TrinhDo"] ?? DBNull.Value);
                            cmdGV.Parameters.AddWithValue("@sdt", (object)sdt ?? DBNull.Value);
                            cmdGV.ExecuteNonQuery();
                        }
                        else
                        {
                            string sqlHV = @"INSERT INTO HOCVIEN (MaTK, TenHV, GioiTinh, NgaySinh, Email, SDT, DiaChi, TrangThai)
                                             VALUES (@matk, @ten, @gt, @ns, @email, @sdt, @dc, N'Đang học')";
                            SqlCommand cmdHV = new SqlCommand(sqlHV, conn, tran);
                            cmdHV.Parameters.AddWithValue("@matk", maTK);
                            cmdHV.Parameters.AddWithValue("@ten", ten);
                            cmdHV.Parameters.AddWithValue("@gt", row["GioiTinh"] ?? DBNull.Value);
                            cmdHV.Parameters.AddWithValue("@ns", row["NgaySinh"] ?? DBNull.Value);
                            cmdHV.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                            cmdHV.Parameters.AddWithValue("@sdt", (object)sdt ?? DBNull.Value);
                            cmdHV.Parameters.AddWithValue("@dc", row["DiaChi"] ?? DBNull.Value);
                            cmdHV.ExecuteNonQuery();
                        }

                        countAdded++;
                    }

                    tran.Commit();
                    MessageBox.Show($"✅ Đã thêm thành công {countAdded} {(loaiTaiKhoan == "GV" ? "giáo viên" : "học viên")}!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("❌ Lỗi khi thêm dữ liệu: " + ex.Message);
                }
            }
        }

        // --- Tạo tên tài khoản ---
        private string TaoTenTaiKhoan(string ten, string loai)
        {
            string[] parts = ten.Trim().Split(' ');
            string tenChinh = parts[parts.Length - 1].ToLower();
            if (parts.Length > 1)
                tenChinh = parts[parts.Length - 2].ToLower() + tenChinh;
            return BoDauTiengViet(tenChinh);
        }

        private string BoDauTiengViet(string s)
        {
            string[] viet = { "á","à","ả","ã","ạ","ă","ắ","ằ","ẳ","ẵ","ặ","â","ấ","ầ","ẩ","ẫ","ậ","đ",
                              "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
                              "í","ì","ỉ","ĩ","ị",
                              "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
                              "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
                              "ý","ỳ","ỷ","ỹ","ỵ" };
            string[] eng = { "a","a","a","a","a","a","a","a","a","a","a","a","a","a","a","a","a","d",
                             "e","e","e","e","e","e","e","e","e","e","e",
                             "i","i","i","i","i",
                             "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
                             "u","u","u","u","u","u","u","u","u","u","u",
                             "y","y","y","y","y" };
            for (int i = 0; i < viet.Length; i++)
                s = s.Replace(viet[i], eng[i]);
            return s;
        }

        private void txtTrinhDo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
