using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Winform_KLCN.ChucNangAdmin
{
    public partial class taoKhoaHoc : Form
    {
        private DataTable dtKhoaHocChuaHoanThien;
        private int maKhoa_DangChon = -1;
        private string tenKhoa_DangChon = "";


        public taoKhoaHoc()
        {
            InitializeComponent();
        }

        private void taoKhoaHoc_Load(object sender, EventArgs e)
        {
            btnThemLopHoc.Enabled = false;

            txtTenKhoa.Clear();
            txtNamHoc.Text = DateTime.Today.Year.ToString();
            dtpNgayBatDau.Value = DateTime.Today;
            dtpNgayKetThuc.Value = DateTime.Today.AddMonths(6);

            CauHinhDataGridViewChuaHoanThien();
            LoadKhoaHocChuaHoanThien();
        }

        private void CauHinhDataGridViewChuaHoanThien()
        {
            dgvKhoaHocChuaHoanThien.AutoGenerateColumns = false;
            dgvKhoaHocChuaHoanThien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhoaHocChuaHoanThien.MultiSelect = false;
            dgvKhoaHocChuaHoanThien.ReadOnly = true;
            dgvKhoaHocChuaHoanThien.RowHeadersVisible = false;
            dgvKhoaHocChuaHoanThien.ColumnHeadersHeight = 40;
            dgvKhoaHocChuaHoanThien.Columns.Clear();

            dgvKhoaHocChuaHoanThien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaK",
                DataPropertyName = "MaK",
                Visible = false
            });
            dgvKhoaHocChuaHoanThien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenKhoaHoc",
                DataPropertyName = "TenKhoaHoc",
                HeaderText = "Tên Khóa Học",
                Width = 200
            });
            dgvKhoaHocChuaHoanThien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NamHoc",
                DataPropertyName = "NamHoc",
                HeaderText = "Năm Học",
                Width = 100
            });
            dgvKhoaHocChuaHoanThien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayBatDau",
                DataPropertyName = "NgayBatDau",
                HeaderText = "Ngày Bắt Đầu",
                Width = 120
            });
            dgvKhoaHocChuaHoanThien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayKetThuc",
                DataPropertyName = "NgayKetThuc",
                HeaderText = "Ngày Kết Thúc",
                Width = 120
            });

            dgvKhoaHocChuaHoanThien.CellClick += DgvKhoaHocChuaHoanThien_CellClick;
        }

        private void LoadKhoaHocChuaHoanThien()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT MaK, TenKhoaHoc, NamHoc, NgayBatDau, NgayKetThuc
FROM KHOAHOC
WHERE TrangThai = N'Chưa hoàn thiện'
ORDER BY NgayBatDau DESC";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    dtKhoaHocChuaHoanThien = new DataTable();
                    da.Fill(dtKhoaHocChuaHoanThien);
                    dgvKhoaHocChuaHoanThien.DataSource = dtKhoaHocChuaHoanThien;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải khóa học chưa hoàn thiện: " + ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnThemLopHoc.Enabled = false;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string tenKhoa = txtTenKhoa.Text.Trim();
            string namHoc = txtNamHoc.Text.Trim();
            DateTime ngayBD = dtpNgayBatDau.Value.Date;
            DateTime ngayKT = dtpNgayKetThuc.Value.Date;

            if (string.IsNullOrEmpty(tenKhoa) || string.IsNullOrEmpty(namHoc))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên khóa học và Năm học!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ngayKT < ngayBD)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
INSERT INTO KHOAHOC (TenKhoaHoc, NamHoc, NgayBatDau, NgayKetThuc, TrangThai)
VALUES (@TenKhoaHoc, @NamHoc, @NgayBD, @NgayKT, N'Chưa hoàn thiện');
SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TenKhoaHoc", tenKhoa);
                    cmd.Parameters.AddWithValue("@NamHoc", namHoc);
                    cmd.Parameters.AddWithValue("@NgayBD", ngayBD);
                    cmd.Parameters.AddWithValue("@NgayKT", ngayKT);

                    int maKhoaMoi = Convert.ToInt32(cmd.ExecuteScalar());

                    MessageBox.Show("Tạo khóa học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload DataGridView khóa chưa hoàn thiện
                    LoadKhoaHocChuaHoanThien();

                    // Hỏi có muốn thêm lớp ngay không
                    DialogResult dr = MessageBox.Show(
                        "Bạn có muốn thêm lớp cho khóa vừa tạo không?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        themLopHoc frm = new themLopHoc(maKhoaMoi);
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                    }

                    // Reset form
                    txtTenKhoa.Clear();
                    txtNamHoc.Text = DateTime.Today.Year.ToString();
                    dtpNgayBatDau.Value = DateTime.Today;
                    dtpNgayKetThuc.Value = DateTime.Today.AddMonths(6);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo khóa học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvKhoaHocChuaHoanThien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            maKhoa_DangChon = Convert.ToInt32(dgvKhoaHocChuaHoanThien.Rows[e.RowIndex].Cells["MaK"].Value);
            tenKhoa_DangChon = dgvKhoaHocChuaHoanThien.Rows[e.RowIndex].Cells["TenKhoaHoc"].Value.ToString();
            // Sau khi đóng, reload lại danh sách
            LoadKhoaHocChuaHoanThien();
            btnThemLopHoc.Enabled = true;
        }

        private void btnThemLopHoc_Click(object sender, EventArgs e)
        {
            if (maKhoa_DangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn một khóa học!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            themLopHoc frm = new themLopHoc(maKhoa_DangChon);
            frm.Text = $"Thêm Lớp Học vào Khóa: {tenKhoa_DangChon}";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            // Reload dữ liệu sau khi đóng form
            LoadKhoaHocChuaHoanThien();
        }
    }
}
