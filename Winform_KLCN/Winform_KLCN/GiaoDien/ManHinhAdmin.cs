using ExcelDataReader;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform_KLCN.ChucNangAdmin;
using Winform_KLCN.ManHinhAdmin;
using Winform_KLCN.ManHinhChinh;

namespace Winform_KLCN.GiaoDien
{
    public partial class ManHinhAdmin : Form
    {
        public ManHinhAdmin()
        {
            InitializeComponent();
        }

        private void ManHinhAdmin_Load(object sender, EventArgs e)
        {
           
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất không?",
                                          "Xác nhận",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
            this.Hide();

            DangNhap frmDangNhap = new DangNhap();
            frmDangNhap.ShowDialog();


            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void lỚPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gIÁOVIÊNToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GiaoVien_Click(object sender, EventArgs e)
        {
        
        }

        private void QlyGiaoVien_Click(object sender, EventArgs e)
        {
            panelNoiDung.Controls.Clear();

            qlyGiaoVien uc = new qlyGiaoVien();
            uc.Dock = DockStyle.Fill;

            panelNoiDung.Controls.Add(uc);
        }

        private void bangPhanChia_Click(object sender, EventArgs e)
        {

        }

        private void themTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void HocVien_Click(object sender, EventArgs e)
        {

        }

        private void QlyTaiKhoan_Click(object sender, EventArgs e)
        {
            panelNoiDung.Controls.Clear();

            qlyTaiKhoan uc = new qlyTaiKhoan();
            uc.Dock = DockStyle.Fill;

            panelNoiDung.Controls.Add(uc);
        }

        //private DataTable ReadExcel(string filePath)
        //{
        //    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        //    {
        //        using (var reader = ExcelReaderFactory.CreateReader(stream))
        //        {
        //            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
        //            {
        //                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
        //            });
        //            return result.Tables[0];
        //        }
        //    }
        //}
        //private string BoDau(string text)
        //{
        //    string normalized = text.Normalize(NormalizationForm.FormD);
        //    Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        //    string noSign = regex.Replace(normalized, string.Empty)
        //        .Replace('đ', 'd').Replace('Đ', 'D');
        //    return noSign.ToLower().Replace(" ", "");
        //}

        private void themGiaoVien_Click(object sender, EventArgs e)
        {
            new themTaiKhoan("GV").ShowDialog();
            //OpenFileDialog ofd = new OpenFileDialog
            //{
            //    Filter = "Excel Files|*.xlsx;*.xls",
            //    Title = "Chọn file danh sách giáo viên"
            //};
            //if (ofd.ShowDialog() != DialogResult.OK) return;

            //DataTable dt = ReadExcel(ofd.FileName);

            //using (SqlConnection conn = KetNoi.TaoKetNoi())
            //{
            //    conn.Open();
            //    int count = 0;

            //    foreach (DataRow r in dt.Rows)
            //    {
            //        string hoTen = r["TenGV"].ToString();
            //        string tenKhongDau = BoDau(hoTen.Split(' ').Last());

            //        // 1️⃣ Thêm giáo viên → lấy mã GV tự động
            //        string sqlGV = @"INSERT INTO GIAOVIEN (TenGV, GioiTinh, NgaySinh, SDT, DiaChi, TrangThai)
            //                         OUTPUT INSERTED.MaGV
            //                         VALUES (@ht, @gt, @ns, @sdt, @dc, @tt)";
            //        SqlCommand cmdGV = new SqlCommand(sqlGV, conn);
            //        cmdGV.Parameters.AddWithValue("@ht", hoTen);
            //        cmdGV.Parameters.AddWithValue("@gt", r["GioiTinh"].ToString());
            //        cmdGV.Parameters.AddWithValue("@ns", r["NgaySinh"]);
            //        cmdGV.Parameters.AddWithValue("@dc", r["SDT"].ToString());
            //        cmdGV.Parameters.AddWithValue("@dc", r["DiaChi"].ToString());
            //        cmdGV.Parameters.AddWithValue("@tt", r["TrangThai"].ToString());
            //        int maGV = Convert.ToInt32(cmdGV.ExecuteScalar());

            //        // 2️⃣ Sinh tài khoản tự động
            //        string taiKhoan = $"gv_{tenKhongDau}_{maGV}";
            //        string matKhau = "Gv@123";

            //        // 3️⃣ Thêm vào bảng TAIKHOAN
            //        string sqlTK = @"INSERT INTO TAIKHOAN (TaiKhoan, MatKhau, MaPQ, TrangThai, NgayTao)
            //                         VALUES (@tk, @mk, 2, N'Hoạt động', GETDATE())";
            //        SqlCommand cmdTK = new SqlCommand(sqlTK, conn);
            //        cmdTK.Parameters.AddWithValue("@tk", taiKhoan);
            //        cmdTK.Parameters.AddWithValue("@mk", matKhau);
            //        cmdTK.ExecuteNonQuery();

            //        count++;
            //    }

            //    MessageBox.Show($"Đã thêm {count} tài khoản giáo viên thành công!");
            //}

        }

        private void themHocVien_Click(object sender, EventArgs e)
        {
            new themTaiKhoan("HV").ShowDialog();
            //OpenFileDialog ofd = new OpenFileDialog
            //{
            //    Filter = "Excel Files|*.xlsx;*.xls",
            //    Title = "Chọn file danh sách học viên"
            //};
            //if (ofd.ShowDialog() != DialogResult.OK) return;

            //DataTable dt = ReadExcel(ofd.FileName);

            //using (SqlConnection conn = KetNoi.TaoKetNoi())
            //{
            //    conn.Open();
            //    int count = 0;

            //    foreach (DataRow r in dt.Rows)
            //    {
            //        string hoTen = r["HoTen"].ToString();
            //        string tenKhongDau = BoDau(hoTen.Split(' ').Last());

            //        string sqlHV = @"INSERT INTO HOCVIEN (HoTen, GioiTinh, NgaySinh, SDT, Email)
            //                         OUTPUT INSERTED.MaHV
            //                         VALUES (@ht, @gt, @ns, @sdt, @email)";
            //        SqlCommand cmdHV = new SqlCommand(sqlHV, conn);
            //        cmdHV.Parameters.AddWithValue("@ht", hoTen);
            //        cmdHV.Parameters.AddWithValue("@gt", r["GioiTinh"].ToString());
            //        cmdHV.Parameters.AddWithValue("@ns", r["NgaySinh"]);
            //        cmdHV.Parameters.AddWithValue("@sdt", r["SDT"].ToString());
            //        cmdHV.Parameters.AddWithValue("@email", r["Email"].ToString());
            //        int maHV = Convert.ToInt32(cmdHV.ExecuteScalar());

            //        string taiKhoan = $"hv_{tenKhongDau}_{maHV}";
            //        string matKhau = "Hv@123";

            //        string sqlTK = @"INSERT INTO TAIKHOAN (TaiKhoan, MatKhau, MaPQ, TrangThai, NgayTao)
            //                         VALUES (@tk, @mk, 3, N'Hoạt động', GETDATE())";
            //        SqlCommand cmdTK = new SqlCommand(sqlTK, conn);
            //        cmdTK.Parameters.AddWithValue("@tk", taiKhoan);
            //        cmdTK.Parameters.AddWithValue("@mk", matKhau);
            //        cmdTK.ExecuteNonQuery();

            //        count++;
            //    }

            //    MessageBox.Show($"Đã thêm {count} tài khoản học viên thành công!");
            //}
        }

        private void themAdmin_Click(object sender, EventArgs e)
        {
            new themTaiKhoan("AD").ShowDialog();
            //txtTaiKhoan.Visible=true;
            //string tk = txtTaiKhoan.Text.Trim();
            //if (string.IsNullOrEmpty(tk))
            //{
            //    MessageBox.Show("Vui lòng nhập tài khoản admin!");
            //    return;
            //}

            //using (SqlConnection conn = KetNoi.TaoKetNoi())
            //{
            //    conn.Open();

            //    string check = "SELECT COUNT(*) FROM TAIKHOAN WHERE TaiKhoan = @tk";
            //    SqlCommand cmdCheck = new SqlCommand(check, conn);
            //    cmdCheck.Parameters.AddWithValue("@tk", tk);
            //    int count = (int)cmdCheck.ExecuteScalar();
            //    if (count > 0)
            //    {
            //        MessageBox.Show("Tài khoản đã tồn tại!");
            //        return;
            //    }

            //    string sql = @"INSERT INTO TAIKHOAN (TaiKhoan, MatKhau, MaPQ, TrangThai, NgayTao)
            //                   VALUES (@tk, 'Admin@123', 1, N'Hoạt động', GETDATE())";
            //    SqlCommand cmd = new SqlCommand(sql, conn);
            //    cmd.Parameters.AddWithValue("@tk", tk);
            //    cmd.ExecuteNonQuery();

            //    MessageBox.Show("Thêm tài khoản admin thành công!");
            //    txtTaiKhoan.Visible = false;
            //}
        }

        private void QlyHocVien_Click(object sender, EventArgs e)
        {
            panelNoiDung.Controls.Clear();

            qlyHocVien uc = new qlyHocVien();
            uc.Dock = DockStyle.Fill;

            panelNoiDung.Controls.Add(uc);
        }

        private void CauHoi_Click(object sender, EventArgs e)
        {

        }

        private void nGÂNHÀNGCÂUHỎIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelNoiDung.Controls.Clear();

            qlyCauHoi uc = new qlyCauHoi();
            uc.Dock = DockStyle.Fill;

            panelNoiDung.Controls.Add(uc);
        }

        private void qlyDeThi_Click(object sender, EventArgs e)
        {
            panelNoiDung.Controls.Clear();

            qlyDeThi uc = new qlyDeThi();
            uc.Dock = DockStyle.Fill;

            panelNoiDung.Controls.Add(uc);
        }

        private void taoDeThi_Click(object sender, EventArgs e)
        {
            taoDeThi form = new taoDeThi();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog(); // mở dạng popup chặn
        }

        private void QlyKyThi_Click(object sender, EventArgs e)
        {
            panelNoiDung.Controls.Clear();

            qlyKyThi uc = new qlyKyThi();
            uc.Dock = DockStyle.Fill;

            panelNoiDung.Controls.Add(uc);
        }

        private void taoKyThi_Click(object sender, EventArgs e)
        {
            taoKyThi form = new taoKyThi();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog(); // mở dạng popup chặn
        }

        private void qlyKhoaHoc_Click(object sender, EventArgs e)
        {
            panelNoiDung.Controls.Clear();

            qlyKhoaHoc uc = new qlyKhoaHoc();
            uc.Dock = DockStyle.Fill;

            panelNoiDung.Controls.Add(uc);
        }




        private void taoKhoaHoc_Click(object sender, EventArgs e)
        {
            taoKhoaHoc form = new taoKhoaHoc();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
    }
    
}
