using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Winform_KLCN.ChucNangAdmin;

namespace Winform_KLCN.ManHinhAdmin
{
    public partial class qlyKhoaHoc : UserControl
    {
        private DataTable dtKhoaHoc;

        public qlyKhoaHoc()
        {
            InitializeComponent();
            CauHinhDataGridView();
            LoadNamHoc();
            LoadKhoaHoc();

            cboNamHoc.SelectedIndexChanged += CboNamHoc_SelectedIndexChanged;
            dgvKhoaHoc.CellClick += DgvKhoaHoc_CellClick;
        }

        private void CauHinhDataGridView()
        {
            dgvKhoaHoc.AutoGenerateColumns = false;
            dgvKhoaHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhoaHoc.MultiSelect = false;
            dgvKhoaHoc.AllowUserToAddRows = false;
            dgvKhoaHoc.ReadOnly = true;
            dgvKhoaHoc.RowHeadersVisible = false;
            dgvKhoaHoc.ColumnHeadersHeight = 40;

            dgvKhoaHoc.Columns.Clear();

            // Cột ẩn MaK
            var colMaK = new DataGridViewTextBoxColumn
            {
                Name = "MaK",
                DataPropertyName = "MaK",
                Visible = false
            };
            dgvKhoaHoc.Columns.Add(colMaK);

            AddColumn("TenKhoaHoc", "Tên khóa học", 200);
            AddColumn("NamHoc", "Năm học", 120);
            AddColumn("NgayBatDau", "Ngày bắt đầu", 120);
            AddColumn("NgayKetThuc", "Ngày kết thúc", 120);

            // Nút xem danh sách lớp
            DataGridViewButtonColumn btnDanhSachLop = new DataGridViewButtonColumn
            {
                Name = "DanhSachLop",
                HeaderText = "Danh sách lớp",
                Text = "Xem",
                UseColumnTextForButtonValue = true,
                Width = 120
            };
            dgvKhoaHoc.Columns.Add(btnDanhSachLop);
        }

        private void AddColumn(string dataProp, string header, int width)
        {
            dgvKhoaHoc.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = dataProp,
                DataPropertyName = dataProp,
                HeaderText = header,
                Width = width,
                ReadOnly = true
            });
        }

        private void LoadNamHoc()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = "SELECT DISTINCT NamHoc FROM KHOAHOC ORDER BY NamHoc DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                cboNamHoc.Items.Clear();
                cboNamHoc.Items.Add("Tất cả");
                while (dr.Read())
                    cboNamHoc.Items.Add(dr["NamHoc"].ToString());

                dr.Close();
                cboNamHoc.SelectedIndex = 0;
            }
        }

        private void LoadKhoaHoc(string namHoc = "Tất cả")
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"
SELECT MaK, TenKhoaHoc, NamHoc, NgayBatDau, NgayKetThuc
FROM KHOAHOC
WHERE TrangThai <> N'Chưa hoàn thiện'"; // Chỉ lấy khóa học đã hoàn thiện hoặc đang học

                if (namHoc != "Tất cả")
                    sql += " AND NamHoc = @NamHoc";

                sql += " ORDER BY NgayBatDau DESC;";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (namHoc != "Tất cả")
                        cmd.Parameters.AddWithValue("@NamHoc", namHoc);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dtKhoaHoc = new DataTable();
                    da.Fill(dtKhoaHoc);
                    dgvKhoaHoc.DataSource = dtKhoaHoc;
                }
            }
        }


        private void CboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedItem == null) return;
            LoadKhoaHoc(cboNamHoc.SelectedItem.ToString());
        }

        private void DgvKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvKhoaHoc.Columns[e.ColumnIndex].Name == "DanhSachLop")
            {
                int maK = Convert.ToInt32(dgvKhoaHoc.Rows[e.RowIndex].Cells["MaK"].Value);
                string tenKhoa = dgvKhoaHoc.Rows[e.RowIndex].Cells["TenKhoaHoc"].Value.ToString();

                // Debug: chắc chắn lấy đúng MaK
                //MessageBox.Show("MaK = " + maK + ", Tên khóa: " + tenKhoa);

                // Mở form ctKhoaHoc
                ctKhoaHoc frm = new ctKhoaHoc(maK, tenKhoa);
                frm.ShowDialog();
            }
        }
    }
}
