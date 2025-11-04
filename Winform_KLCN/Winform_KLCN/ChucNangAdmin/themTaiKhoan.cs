using ExcelDataReader;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Winform_KLCN.ChucNangAdmin
{
    public partial class themTaiKhoan : Form
    {
        private string loaiTaiKhoan; // "GV" - Giáo viên | "HV" - Học viên | "AD" - Admin
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

            btnChonFile.Visible = loaiTaiKhoan != "AD";
            txtTaiKhoan.Visible = loaiTaiKhoan == "AD";
            btnXacNhan.Enabled = true;
        }

        // --- Nút chọn file Excel ---
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
                        btnXacNhan.Enabled = true;
                        MessageBox.Show("✅ Đọc file Excel thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Lỗi đọc file: " + ex.Message);
                }
            }
        }

        // --- Nút xác nhận ---
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (loaiTaiKhoan == "AD")
                ThemAdminThuCong();
            else
                ThemTuFileExcel();
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
            btnXacNhan.Enabled = false;

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();

                string check = "SELECT COUNT(*) FROM TAIKHOAN WHERE TaiKhoan=@tk";
                SqlCommand checkCmd = new SqlCommand(check, conn);
                checkCmd.Parameters.AddWithValue("@tk", taiKhoan);
                int count = (int)checkCmd.ExecuteScalar();

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

        // --- Thêm giáo viên / học viên từ Excel ---
        private void ThemTuFileExcel()
        {
            if (dtDuLieuExcel == null || dtDuLieuExcel.Rows.Count == 0)
            {
                MessageBox.Show("❌ Chưa có dữ liệu để thêm!");
                return;
            }

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    foreach (DataRow row in dtDuLieuExcel.Rows)
                    {
                        string ten = loaiTaiKhoan == "GV" ? row["TenGV"]?.ToString().Trim() : row["TenHV"]?.ToString().Trim();
                        if (string.IsNullOrEmpty(ten)) continue;

                        string taiKhoan = TaoTenTaiKhoan(ten, loaiTaiKhoan);
                        string matKhau = loaiTaiKhoan == "GV" ? "Gv@123" : "Hv@123";
                        int maPQ = loaiTaiKhoan == "GV" ? 2 : 3;

                        // --- B1: Thêm tài khoản ---
                        string sqlTK = @"INSERT INTO TAIKHOAN (TaiKhoan, MatKhau, MaPQ, TrangThai, NgayTao)
                                         OUTPUT INSERTED.MaTK
                                         VALUES (@tk, @mk, @pq, N'Hoạt động', GETDATE())";
                        SqlCommand cmdTK = new SqlCommand(sqlTK, conn, tran);
                        cmdTK.Parameters.AddWithValue("@tk", taiKhoan);
                        cmdTK.Parameters.AddWithValue("@mk", matKhau);
                        cmdTK.Parameters.AddWithValue("@pq", maPQ);

                        object result = cmdTK.ExecuteScalar();
                        if (result == null || result == DBNull.Value)
                            throw new Exception("Không thể tạo tài khoản cho " + ten);

                        int maTK = Convert.ToInt32(result);

                        // --- B2: Thêm vào bảng GIAOVIEN hoặc HOCVIEN ---
                        if (loaiTaiKhoan == "GV")
                        {
                            string sqlGV = @"INSERT INTO GIAOVIEN (MaTK, TenGV, GioiTinh, NgaySinh, DiaChi, TrinhDo, SDT, TrangThai)
                                             VALUES (@matk, @ten, @gt, @ns, @dc, @td, @sdt, N'Đang dạy')";
                            SqlCommand cmdGV = new SqlCommand(sqlGV, conn, tran);
                            cmdGV.Parameters.AddWithValue("@matk", maTK);
                            cmdGV.Parameters.AddWithValue("@ten", ten);
                            cmdGV.Parameters.AddWithValue("@gt", row["GioiTinh"] ?? DBNull.Value);
                            cmdGV.Parameters.AddWithValue("@ns", row["NgaySinh"] ?? DBNull.Value);
                            cmdGV.Parameters.AddWithValue("@dc", row["DiaChi"] ?? DBNull.Value);
                            cmdGV.Parameters.AddWithValue("@td", row["TrinhDo"] ?? DBNull.Value);
                            cmdGV.Parameters.AddWithValue("@sdt", row["SDT"] ?? DBNull.Value);
                            cmdGV.ExecuteNonQuery();
                        }
                        else
                        {
                            string sqlHV = @"INSERT INTO HOCVIEN (MaTK, TenHV, GioiTinh, NgaySinh, DiaChi, SDT, TrangThai)
                                             VALUES (@matk, @ten, @gt, @ns, @dc, @sdt, N'Đang học')";
                            SqlCommand cmdHV = new SqlCommand(sqlHV, conn, tran);
                            cmdHV.Parameters.AddWithValue("@matk", maTK);
                            cmdHV.Parameters.AddWithValue("@ten", ten);
                            cmdHV.Parameters.AddWithValue("@gt", row["GioiTinh"] ?? DBNull.Value);
                            cmdHV.Parameters.AddWithValue("@ns", row["NgaySinh"] ?? DBNull.Value);
                            cmdHV.Parameters.AddWithValue("@dc", row["DiaChi"] ?? DBNull.Value);
                            cmdHV.Parameters.AddWithValue("@sdt", row["SDT"] ?? DBNull.Value);
                            cmdHV.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    MessageBox.Show("✅ Đã thêm tất cả " + (loaiTaiKhoan == "GV" ? "giáo viên" : "học viên") + " thành công!");
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
    }
}
