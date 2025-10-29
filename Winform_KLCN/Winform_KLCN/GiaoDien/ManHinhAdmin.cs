using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
