using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Winform_KLCN.ChucNangAdmin
{
    public partial class taoKyThi : Form
    {
        public taoKyThi()
        {
            InitializeComponent();
        }

        private void taoKyThi_Load(object sender, EventArgs e)
        {
            LoadKhoaHoc();
            LoadKyThiChuaHoanThien();
        }

        // ======================
        // 1. Load danh sách khóa học vào combobox
        // ======================
        private void LoadKhoaHoc()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = "SELECT MaK, TenKhoaHoc FROM KHOAHOC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboKhoaHoc.DataSource = dt;
                cboKhoaHoc.DisplayMember = "TenKhoaHoc";
                cboKhoaHoc.ValueMember = "MaK";
                cboKhoaHoc.SelectedIndex = -1;
            }
        }

        // ======================
        // 2. Load kỳ thi chưa hoàn thiện
        // ======================
        private void LoadKyThiChuaHoanThien()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"
                    SELECT MaKT, TenKyThi, NgayBatDau, NgayKetThuc, TrangThai
                    FROM KYTHI
                    WHERE TrangThai = N'Chưa hoàn thiện'
                    ORDER BY NgayBatDau DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvKyThiChuaHoanThien.DataSource = dt;
            }
        }

      
        private void dgvKyThiChuaHoanThien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnThemLichThi.Enabled = true; // bật nút
            }
        }

        

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string tenKyThi = txtTenKyThi.Text.Trim();
            string moTa = txtMoTa.Text.Trim();
            int maKhoaHoc;

            if (string.IsNullOrEmpty(tenKyThi) || cboKhoaHoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cboKhoaHoc.SelectedValue.ToString(), out maKhoaHoc))
            {
                MessageBox.Show("Lỗi chọn khóa học.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ngayBatDau = dtpNgayBatDau.Value.Date;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value.Date;

            if (ngayKetThuc < ngayBatDau)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"
                    INSERT INTO KYTHI (TenKyThi, MaK, NgayBatDau, NgayKetThuc, MoTa, TrangThai)
                    VALUES (@TenKyThi, @MaK, @NgayBatDau, @NgayKetThuc, @MoTa, N'Chưa hoàn thiện');
                    SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenKyThi", tenKyThi);
                cmd.Parameters.AddWithValue("@MaK", maKhoaHoc);
                cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                cmd.Parameters.AddWithValue("@MoTa", moTa);

                int maKyThiMoi = Convert.ToInt32(cmd.ExecuteScalar());

                // Hỏi có muốn thêm lịch thi luôn không
                DialogResult dialog = MessageBox.Show(
                    "Tạo kỳ thi thành công!\nBạn có muốn thêm lịch thi ngay bây giờ không?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    themLichThi frm = new themLichThi(maKyThiMoi, tenKyThi);
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }

                // Sau khi thêm xong, refresh lại dgv
                LoadKyThiChuaHoanThien();

                // Reset form nhập
                txtTenKyThi.Clear();
                txtMoTa.Clear();
                cboKhoaHoc.SelectedIndex = -1;
                dtpNgayBatDau.Value = DateTime.Today;
                dtpNgayKetThuc.Value = DateTime.Today.AddDays(7);
            }
        }

        private void btnThemLichThi_Click_1(object sender, EventArgs e)
        {
            if (dgvKyThiChuaHoanThien.CurrentRow != null)
            {
                int maKT = Convert.ToInt32(dgvKyThiChuaHoanThien.CurrentRow.Cells["MaKT"].Value);
                string tenKyThi = dgvKyThiChuaHoanThien.CurrentRow.Cells["TenKyThi"].Value.ToString();

                themLichThi frm = new themLichThi(maKT, tenKyThi);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();

                LoadKyThiChuaHoanThien(); // reload lại
            }
        }
    }
}
