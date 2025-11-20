using Guna.UI2.WinForms;
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
using Winform_KLCN.ManHinhChinh;

namespace Winform_KLCN.GiaoDien
{
    public partial class ManHinhChinh : Form
    {
        public ManHinhChinh()
        {
            InitializeComponent();
        }

        private void ManHinhChinh_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sqlGV = "SELECT MaGV, TenGV FROM GIAOVIEN WHERE MaTK = @MaTK";
                    using (SqlCommand cmdGV = new SqlCommand(sqlGV, conn))
                    {
                        cmdGV.Parameters.AddWithValue("@MaTK", UserSession.MaTK);
                        using (SqlDataReader reader = cmdGV.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserSession.MaGV = reader.GetInt32(0);   // Lưu MaGV vào session
                                string tenGV = reader.GetString(1);
                                lblXinChao.Text = "Xin chào: " + tenGV;
                            }
                            else
                            {
                                lblXinChao.Text = "Xin chào: Giáo viên";
                                UserSession.MaGV = 0;
                            }
                        }
                    }
                }
                panelNoiDung.Controls.Clear();
                TrangChu uc = new TrangChu();
                uc.Dock = DockStyle.Fill;
                panelNoiDung.Controls.Add(uc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất không?",
                                          "Xác nhận",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                UserSession.MaPQ = null;
                UserSession.MaTK = null;
                UserSession.MaGV = 0;


                this.Hide();

                DangNhap frmDangNhap = new DangNhap();
                frmDangNhap.ShowDialog();


                this.Close();
            }
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            timerMenu.Start();
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            panelNoiDung.Controls.Clear();

            ThongTin ucThongTin = new ThongTin();
            ucThongTin.Dock = DockStyle.Fill;


            ucThongTin.LoadData(UserSession.MaTK);

            panelNoiDung.Controls.Add(ucThongTin);

        }

        private void btnCauHoi_Click(object sender, EventArgs e)
        {

            panelNoiDung.Controls.Clear();


            CauHoi ucCauHoi = new CauHoi();
            ucCauHoi.Dock = DockStyle.Fill;


            panelNoiDung.Controls.Add(ucCauHoi);
        }

        private void btnDeThi_Click(object sender, EventArgs e)
        {

        }

        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            panelNoiDung.Controls.Clear();

            LopHoc uc = new LopHoc();
            uc.Dock = DockStyle.Fill;

            panelNoiDung.Controls.Add(uc);
        }

        private void btnHocVien_Click(object sender, EventArgs e)
        {
            panelNoiDung.Controls.Clear();

            HocVien uc = new HocVien();
            uc.Dock = DockStyle.Fill;

            panelNoiDung.Controls.Add(uc);
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            panelNoiDung.Controls.Clear();

            TrangChu uc = new TrangChu();
            uc.Dock = DockStyle.Fill;

            panelNoiDung.Controls.Add(uc);
        }
    }
}
