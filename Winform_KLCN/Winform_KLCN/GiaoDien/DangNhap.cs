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

namespace Winform_KLCN.GiaoDien
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
           
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (taiKhoan == "" || matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //ahdsyhbucsuvskbssv
            //jgxcsc
            //skfsfj
            bool isLoggedIn = false;
            string maPhanQuyen = "";
            string maTaiKhoan = "";

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();

                string sql = "SELECT MaPQ, MaTK FROM TAIKHOAN WHERE TaiKhoan = @tk AND MatKhau = @mk";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tk", taiKhoan);
                cmd.Parameters.AddWithValue("@mk", matKhau);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        maPhanQuyen = reader.GetInt32(0).ToString();
                    if (!reader.IsDBNull(1))
                        maTaiKhoan = reader.GetInt32(1).ToString();

                    reader.Close();

                    if (maPhanQuyen != "3")
                    {
                        UserSession.MaPQ = maPhanQuyen;
                        UserSession.MaTK = maTaiKhoan;
                        isLoggedIn = true;
                    }
                }
            }

            if (isLoggedIn)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

                if (UserSession.MaPQ == "1")
                {
                    // ADMIN
                    ManHinhAdmin manHinhAdmin = new ManHinhAdmin();
                    manHinhAdmin.ShowDialog();
                }
                else
                {
                    // GIÁO VIÊN
                    ManHinhChinh manHinhChinh = new ManHinhChinh();
                    manHinhChinh.ShowDialog();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtTaiKhoan.Clear();
            }
        }


    }
}
