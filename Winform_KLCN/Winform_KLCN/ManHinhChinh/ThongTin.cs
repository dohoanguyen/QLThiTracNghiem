using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform_KLCN.GiaoDien;

namespace Winform_KLCN.ManHinhChinh
{
    public partial class ThongTin : UserControl
    {
        public ThongTin()
        {
            InitializeComponent();
        }

        private void ThongTin_Load(object sender, EventArgs e)
        {
            btnLuu.Visible = false;
            btnTroLai.Visible = false;
            lblmkc.Visible=false;
            lblmkm.Visible=false;
            lblxnmkm.Visible=false;
            txtMatKhauCu.Visible = false;
            txtMatKhauMoi.Visible = false;
            txtXacNhanMKM.Visible = false;
        }
        public void LoadData(string maTK)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    // 1. SỬA CÂU SQL: Thêm cột chứa tên ảnh (ví dụ: AnhDaiDien) vào câu SELECT
                    string sql = @"SELECT TenGV, GioiTinh, NgaySinh, DiaChi, TrinhDo, SDT, AnhDaiDien 
                           FROM GIAOVIEN 
                           WHERE MaTK = @MaTK";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTK", maTK);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Load các thông tin chữ như bình thường
                                lblTen.Text = reader["TenGV"].ToString();
                                txtGioiTinh.Text = reader["GioiTinh"].ToString();
                                txtNgaySinh.Text = Convert.ToDateTime(reader["NgaySinh"]).ToString("dd/MM/yyyy");
                                txtDiaChi.Text = reader["DiaChi"].ToString();
                                txtTrinhDo.Text = reader["TrinhDo"].ToString();
                                txtSDT.Text = reader["SDT"].ToString();

                                // 2. PHẦN XỬ LÝ ẢNH (MỚI THÊM)
                                // Lấy tên file từ CSDL
                                string tenFileAnh = reader["AnhDaiDien"].ToString();

                                if (!string.IsNullOrEmpty(tenFileAnh))
                                {
                                    // Đường dẫn đến thư mục Images nằm trong thư mục Debug/bin của dự án
                                    string folderPath = Path.Combine(Application.StartupPath, "Images");
                                    string fullPath = Path.Combine(folderPath, tenFileAnh);

                                    // Kiểm tra file có tồn tại không rồi mới load
                                    if (File.Exists(fullPath))
                                    {
                                        // Dọn dẹp ảnh cũ trong picturebox (nếu có) để tránh tốn ram
                                        if (pictureBox1.Image != null) pictureBox1.Image.Dispose();

                                        // Load ảnh mới
                                        pictureBox1.Image = Image.FromFile(fullPath);
                                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Chỉnh ảnh co giãn vừa khung
                                    }
                                    else
                                    {
                                        // Nếu có tên file trong DB nhưng không thấy file ảnh đâu -> Load ảnh trống hoặc mặc định
                                        pictureBox1.Image = null;
                                    }
                                }
                                else
                                {
                                    // Trường hợp trong DB chưa có tên ảnh
                                    pictureBox1.Image = null;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin giáo viên.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load thông tin giáo viên: " + ex.Message);
            }
        }

        private void btnDoiTT_Click(object sender, EventArgs e)
        {
            btnDoiMK.Visible = false;
            btnDoiTT.Visible = false;
            txtDiaChi.ReadOnly = false;

            // Hiện các nút Lưu và Trở lại
            btnLuu.Visible = true;
            btnTroLai.Visible = true;

            // Ẩn các textbox mật khẩu nếu có
            txtMatKhauCu.Visible = false;
            txtMatKhauMoi.Visible = false;
            txtXacNhanMKM.Visible = false;

            txtTrinhDo.Enabled = true;
            txtNgaySinh.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            btnDoiMK.Visible = false;
            btnDoiTT.Visible = false;

            lblmkc.Visible = true;
            lblmkm.Visible = true;
            lblxnmkm.Visible = true;
            txtMatKhauCu.Visible = true;
            txtMatKhauMoi.Visible = true;
            txtXacNhanMKM.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            txtDiaChi.Visible = false;
            txtGioiTinh.Visible = false;
            txtNgaySinh.Visible = false;
            txtTrinhDo.Visible = false;
            txtSDT.Visible = false;

           
            btnLuu.Visible = true;
            btnTroLai.Visible = true;

            txtDiaChi.ReadOnly = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    if (txtMatKhauCu.Visible) 
                    {
                        
                        string sqlCheck = "SELECT MatKhau FROM TAIKHOAN WHERE MaTK = @MaTK";
                        string matKhauHienTai;
                        using (SqlCommand cmd = new SqlCommand(sqlCheck, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaTK", UserSession.MaTK);
                            matKhauHienTai = cmd.ExecuteScalar()?.ToString();
                        }

                        if (txtMatKhauCu.Text != matKhauHienTai)
                        {
                            MessageBox.Show("Mật khẩu cũ không đúng!");
                            return;
                        }

                        if (txtMatKhauMoi.Text != txtXacNhanMKM.Text)
                        {
                            MessageBox.Show("Mật khẩu mới và xác nhận không khớp!");
                            return;
                        }

                       
                        string sqlUpdate = "UPDATE TAIKHOAN SET MatKhau = @MatKhauMoi WHERE MaTK = @MaTK";
                        using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
                        {
                            cmd.Parameters.AddWithValue("@MatKhauMoi", txtMatKhauMoi.Text);
                            cmd.Parameters.AddWithValue("@MaTK", UserSession.MaTK);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Đổi mật khẩu thành công! Mời đăng nhập lại ");
                        UserSession.MaPQ = null;
                        UserSession.MaTK = null;

                        this.Hide();

                        DangNhap frmDangNhap = new DangNhap();
                        frmDangNhap.ShowDialog();


                        this.Visible = false;


                    }
                    else 
                    {
                        string sqlUpdate = "UPDATE GIAOVIEN SET DiaChi = @DiaChi, SDT = @SDT WHERE MaTK = @MaTK";
                        using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
                        {
                            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                            cmd.Parameters.AddWithValue("@MaTK", UserSession.MaTK);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Cập nhật thông tin thành công!");
                    }
                }

                btnLuu.Visible = false;
                btnTroLai.Visible = false;
                lblmkc.Visible = false;
                lblmkm.Visible = false;
                lblxnmkm.Visible = false;
                txtMatKhauCu.Visible = false;
                txtMatKhauMoi.Visible = false;
                txtXacNhanMKM.Visible = false;

                btnLuu.Visible = false;
                btnTroLai.Visible = false;
                txtDiaChi.ReadOnly = true;
                txtMatKhauCu.Visible = false;
                txtMatKhauMoi.Visible = false;
                txtXacNhanMKM.Visible = false;

                txtTrinhDo.Enabled = false;
                txtNgaySinh.Enabled = false;
                txtGioiTinh.Enabled = false;
                txtDiaChi.Enabled = false;
                txtSDT.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
            btnDoiMK.Visible = true;
            btnDoiTT.Visible = true;
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            btnDoiMK.Visible = true;
            btnDoiTT.Visible = true;

            btnLuu.Visible = false;
            btnTroLai.Visible = false;
            lblmkc.Visible = false;
            lblmkm.Visible = false;
            lblxnmkm.Visible = false;
            txtMatKhauCu.Visible = false;
            txtMatKhauMoi.Visible = false;
            txtXacNhanMKM.Visible = false;

            btnLuu.Visible = false;
            btnTroLai.Visible = false;
            txtDiaChi.ReadOnly = true;
            txtMatKhauCu.Visible = false;
            txtMatKhauMoi.Visible = false;
            txtXacNhanMKM.Visible = false;

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            txtDiaChi.Visible = true;
            txtGioiTinh.Visible = true;
            txtNgaySinh.Visible = true;
            txtTrinhDo.Visible = true;
            txtSDT.Visible = true;

            txtTrinhDo.Enabled = false;
            txtNgaySinh.Enabled = false;
            txtGioiTinh.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            LoadData(UserSession.MaTK);
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
