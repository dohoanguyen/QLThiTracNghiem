using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Winform_KLCN.ChucNangAdmin
{
    public partial class taoDeThi : Form
    {
        public taoDeThi()
        {
            InitializeComponent();
        }


        // ----------------- LOAD DỮ LIỆU -----------------
        private void LoadMonThi()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MaM, TenMon FROM MON", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboMon.DataSource = dt;
                    cboMon.DisplayMember = "TenMon";
                    cboMon.ValueMember = "MaM";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải môn thi: " + ex.Message);
            }
        }

        private void LoadDeThiChuaHoatDong()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT 
    D.MaD, 
    D.TenDe, 
    M.TenMon, 
    D.ThoiGian, 
    D.SoCau, 
    D.NgayTao, 
    D.TrangThai
FROM DETHI D
JOIN MON M ON D.MaM = M.MaM
WHERE D.TrangThai = N'Chưa hoạt động'";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDeThiChuaHoatDong.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách đề thi: " + ex.Message);
            }
        }

       
        private void dgvDeThiChuaHoatDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnThemCauHoi.Enabled = true;
            }
        }


        private void btnXacNhan_Click_1(object sender, EventArgs e)
        {
            string tenDe = txtTenDe.Text.Trim();
            int soCau, thoiGian, maMon;

            // --- Kiểm tra dữ liệu nhập ---
            if (string.IsNullOrEmpty(tenDe) || !int.TryParse(txtSoCau.Text, out soCau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đề và số câu hợp lệ!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtThoiGian.Text, out thoiGian))
                thoiGian = 15;

            maMon = Convert.ToInt32(cboMon.SelectedValue);

            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    string query = @"
                INSERT INTO DETHI (TenDe, MaM, SoCau, ThoiGian, TrangThai)
                VALUES (@TenDe, @MaM, @SoCau, @ThoiGian, N'Chưa hoạt động');
                SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDe", tenDe);
                    cmd.Parameters.AddWithValue("@MaM", maMon);
                    cmd.Parameters.AddWithValue("@SoCau", soCau);
                    cmd.Parameters.AddWithValue("@ThoiGian", thoiGian);

                    object resultObj = cmd.ExecuteScalar();
                    if (resultObj == null)
                    {
                        MessageBox.Show("Không lấy được mã đề thi mới!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int maDeThiMoi = Convert.ToInt32(resultObj);

                    // --- Hỏi người dùng có muốn thêm câu hỏi không ---
                    DialogResult result = MessageBox.Show(
                        "Tạo đề thi thành công! Bạn có muốn thêm câu hỏi cho đề vừa tạo không?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Mở form thêm câu hỏi cho đề vừa tạo
                        themCauHoi frm = new themCauHoi(maDeThiMoi);
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                    }
                    else
                    {
                        // Nếu không thêm câu hỏi thì chỉ reload lại danh sách
                        LoadDeThiChuaHoatDong();
                    }

                    // Reset các ô nhập
                    txtTenDe.Clear();
                    txtSoCau.Clear();
                    txtThoiGian.Text = "15";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo đề thi: " + ex.Message);
            }
        }

        private void taoDeThi_Load_1(object sender, EventArgs e)
        {
            LoadMonThi();
            LoadDeThiChuaHoatDong();
            btnThemCauHoi.Enabled = false; // Chỉ bật khi chọn đề thi
            txtThoiGian.Text = "15";
        }

        private void dgvDeThiChuaHoatDong_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string trangThai = dgvDeThiChuaHoatDong.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();
                btnThemCauHoi.Enabled = trangThai == "Chưa hoạt động";
            }
        }

        private void btnThemCauHoi_Click_1(object sender, EventArgs e)
        {
            if (dgvDeThiChuaHoatDong.CurrentRow != null)
            {
                // ✅ Lấy mã đề được chọn
                int maDe = Convert.ToInt32(dgvDeThiChuaHoatDong.CurrentRow.Cells["MaD"].Value);

                // ✅ Truyền mã đề sang form ThemCauHoi
                themCauHoi frm = new themCauHoi(maDe);
                frm.StartPosition = FormStartPosition.CenterParent;

                // ✅ Khi form con đóng, tự load lại danh sách đề
                frm.ShowDialog();
                LoadDeThiChuaHoatDong();
            }
        }
    }
}
