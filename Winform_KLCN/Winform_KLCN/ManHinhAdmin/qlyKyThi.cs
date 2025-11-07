using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Winform_KLCN.ChucNangAdmin;

namespace Winform_KLCN.ManHinhAdmin
{
    public partial class qlyKyThi : UserControl
    {
        private DataTable dtKyThi;
        private DataTable dtKhoa;

        public qlyKyThi()
        {
            InitializeComponent();
            CauHinhDataGridView();
            LoadKhoa();
            LoadKyThi();

            cboKhoa.SelectedIndexChanged += LocDuLieu;
            cboTrangThai.SelectedIndexChanged += LocDuLieu;
            dgvKyThi.CellClick += DgvKyThi_CellClick;
        }

        private void CauHinhDataGridView()
        {
            dgvKyThi.AutoGenerateColumns = false;
            dgvKyThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKyThi.MultiSelect = false;
            dgvKyThi.AllowUserToAddRows = false;
            dgvKyThi.ReadOnly = true;
            dgvKyThi.RowHeadersVisible = false;
            dgvKyThi.ColumnHeadersHeight = 40;

            dgvKyThi.Columns.Clear();

            // 🔹 Thêm cột ẩn MaKT để lưu mã kỳ thi
            var colMaKT = new DataGridViewTextBoxColumn
            {
                Name = "MaKT",
                DataPropertyName = "MaKT",
                Visible = false
            };
            dgvKyThi.Columns.Add(colMaKT);

            // Các cột hiển thị
            AddColumn("TenKyThi", "Tên kỳ thi", 150);
            AddColumn("TenKhoaHoc", "Khóa học", 150);
            AddColumn("NgayBatDau", "Ngày bắt đầu", 120);
            AddColumn("NgayKetThuc", "Ngày kết thúc", 120);
            AddColumn("MoTa", "Mô tả", 200);
            AddColumn("TrangThai", "Trạng thái", 120);

            // Cột nút chi tiết
            DataGridViewButtonColumn btnChiTiet = new DataGridViewButtonColumn
            {
                Name = "ChiTiet",
                HeaderText = "Chi tiết",
                Text = "Chi tiết",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            dgvKyThi.Columns.Add(btnChiTiet);
        }


        private void AddColumn(string dataProp, string header, int width)
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = dataProp,
                DataPropertyName = dataProp,
                HeaderText = header,
                Width = width,
                ReadOnly = true
            };
            dgvKyThi.Columns.Add(col);
        }

        private void LoadKhoa()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = "SELECT MaK, TenKhoaHoc FROM KHOAHOC ORDER BY TenKhoaHoc";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                dtKhoa = new DataTable();
                da.Fill(dtKhoa);

                DataTable dtCombo = dtKhoa.Clone();
                DataRow rAll = dtCombo.NewRow();
                rAll["MaK"] = -1;
                rAll["TenKhoaHoc"] = "Tất cả";
                dtCombo.Rows.Add(rAll);
                foreach (DataRow r in dtKhoa.Rows) dtCombo.ImportRow(r);

                cboKhoa.DisplayMember = "TenKhoaHoc";
                cboKhoa.ValueMember = "MaK";
                cboKhoa.DataSource = dtCombo;
                cboKhoa.SelectedIndex = 0;
            }

            // Load cboTrangThai
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Sắp diễn ra");
            cboTrangThai.Items.Add("Đang thi");
            cboTrangThai.Items.Add("Đã kết thúc");
            cboTrangThai.SelectedIndex = 0;
        }

        private void LoadKyThi(int maK = -1, string trangThai = "Tất cả")
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"
SELECT K.MaKT, K.TenKyThi, KH.TenKhoaHoc, K.NgayBatDau, K.NgayKetThuc, K.MoTa, K.TrangThai
FROM KYTHI K
INNER JOIN KHOAHOC KH ON K.MaK = KH.MaK
WHERE 1=1";

                if (maK != -1) sql += " AND K.MaK = @MaK";
                if (trangThai != "Tất cả") sql += " AND K.TrangThai = @TrangThai";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (maK != -1) cmd.Parameters.AddWithValue("@MaK", maK);
                    if (trangThai != "Tất cả") cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dtKyThi = new DataTable();
                    da.Fill(dtKyThi);
                    dgvKyThi.DataSource = dtKyThi;
                }
            }
        }

        private void LocDuLieu(object sender, EventArgs e)
        {
            if (cboKhoa.SelectedValue == null) return;
            int maK = Convert.ToInt32(cboKhoa.SelectedValue);
            string trangThai = cboTrangThai.SelectedItem.ToString();
            LoadKyThi(maK, trangThai);
        }

        private void DgvKyThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Khi click Chi tiết
            if (dgvKyThi.Columns[e.ColumnIndex].Name == "ChiTiet")
            {
                int maKT = Convert.ToInt32(dgvKyThi.Rows[e.RowIndex].Cells["MaKT"].Value);
                string tenKT = dgvKyThi.Rows[e.RowIndex].Cells["TenKyThi"].Value.ToString();
                ctKyThi frm = new ctKyThi(maKT, tenKT);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }

            // Khi chọn kỳ thi có trạng thái “Sắp diễn ra” => hiện btnSua
            string tt = dgvKyThi.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();
           
        }

        private void qlyKyThi_Load(object sender, EventArgs e)
        {

        }
    }
}
