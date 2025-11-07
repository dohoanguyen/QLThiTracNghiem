using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Winform_KLCN.ChucNangAdmin
{
    public partial class ctKhoaHoc : Form
    {
        private readonly int _maK;
        private readonly string _tenKhoa;
        private DataGridView dgvLop;

        public ctKhoaHoc(int maK, string tenKhoa)
        {
            InitializeComponent();
            _maK = maK;
            _tenKhoa = tenKhoa;
            this.Load += ctKhoaHoc_Load;
        }

        private void ctKhoaHoc_Load(object sender, EventArgs e)
        {
            this.Text = $"Danh sách lớp của khóa: {_tenKhoa}";
            CauHinhDataGridView();
            LoadDanhSachLop();
        }

        private void CauHinhDataGridView()
        {
            dgvLop = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                RowHeadersVisible = false,
                ColumnHeadersHeight = 40
            };
            this.Controls.Add(dgvLop);

            dgvLop.Columns.Clear();
            dgvLop.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaL", DataPropertyName = "MaL", HeaderText = "Mã Lớp", Visible = false });
            dgvLop.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenLop", DataPropertyName = "TenLop", HeaderText = "Tên Lớp" });
            dgvLop.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenMon", DataPropertyName = "TenMon", HeaderText = "Môn Học" });
            dgvLop.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenGV", DataPropertyName = "TenGV", HeaderText = "Giáo Viên Chủ Nhiệm" });
            dgvLop.Columns.Add(new DataGridViewTextBoxColumn { Name = "SiSo", DataPropertyName = "SiSo", HeaderText = "Sĩ Số" });
        }

        private void LoadDanhSachLop()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT 
    L.MaL,
    L.TenLop,
    M.TenMon,
    GV.TenGV,
    L.SiSo
FROM LOPHOC L
INNER JOIN MON M ON L.MaM = M.MaM
INNER JOIN GIAOVIEN GV ON L.MaGV = GV.MaGV
WHERE L.MaK = @MaK
ORDER BY L.TenLop";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaK", _maK);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvLop.DataSource = dt;

                        if (dt.Rows.Count == 0)
                            MessageBox.Show("Khóa này chưa có lớp nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lớp: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
