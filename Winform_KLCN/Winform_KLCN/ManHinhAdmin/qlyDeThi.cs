using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Winform_KLCN.ManHinhAdmin
{
    public partial class qlyDeThi : UserControl
    {
        private DataTable dtDeThi;
        private DataTable dtMon;

        public qlyDeThi()
        {
            InitializeComponent();
            CauHinhDataGridView();
            LoadMon();
            LoadDeThi();

            cboMon.SelectedIndexChanged += CboMon_SelectedIndexChanged;
            dgvDeThi.CellClick += DgvDeThi_CellClick;
        }

        private void CauHinhDataGridView()
        {
            dgvDeThi.AutoGenerateColumns = false;
            dgvDeThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeThi.MultiSelect = false;
            dgvDeThi.AllowUserToAddRows = false;
            dgvDeThi.ReadOnly = true;
            dgvDeThi.RowHeadersVisible = false;
            dgvDeThi.ColumnHeadersVisible = true;
            dgvDeThi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvDeThi.ColumnHeadersHeight = 40;

            dgvDeThi.Columns.Clear();
            AddColumn("MaD", "Mã Đề", 60);
            AddColumn("TenMon", "Môn học", 120);
            AddColumn("TenDe", "Tên đề", 200);
            AddColumn("SoCau", "Số câu", 80);
            AddColumn("ThoiGian", "Thời gian (phút)", 120);
            AddColumn("NgayTao", "Ngày tạo", 120);

            // --- Cột combobox Trạng Thái ---
            DataGridViewComboBoxColumn colTrangThai = new DataGridViewComboBoxColumn
            {
                Name = "TrangThai",
                HeaderText = "Trạng thái",
                DataPropertyName = "TrangThai",
                Width = 100,
                FlatStyle = FlatStyle.Flat,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                ReadOnly = false // Cho phép chỉnh sửa
            };
            colTrangThai.Items.Add("Hoạt động");
            colTrangThai.Items.Add("Khóa");
          
            dgvDeThi.Columns.Add(colTrangThai);

            // --- Cột nút Chi Tiết ---
            DataGridViewButtonColumn btnChiTiet = new DataGridViewButtonColumn
            {
                Name = "ChiTiet",
                HeaderText = "Chi Tiết",
                Text = "Chi Tiết",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            dgvDeThi.Columns.Add(btnChiTiet);
        }

        private void AddColumn(string dataProp, string header, int width)
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = dataProp,
                DataPropertyName = dataProp,
                HeaderText = header,
                Width = width,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            dgvDeThi.Columns.Add(col);
        }

        private void LoadMon()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = "SELECT MaM, TenMon FROM MON ORDER BY TenMon";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    dtMon = new DataTable();
                    da.Fill(dtMon);

                    DataTable dtCombo = dtMon.Clone();
                    DataRow rAll = dtCombo.NewRow();
                    rAll["MaM"] = -1;
                    rAll["TenMon"] = "Tất cả";
                    dtCombo.Rows.Add(rAll);

                    foreach (DataRow r in dtMon.Rows)
                        dtCombo.ImportRow(r);

                    cboMon.DisplayMember = "TenMon";
                    cboMon.ValueMember = "MaM";
                    cboMon.DataSource = dtCombo;
                    cboMon.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải môn học: " + ex.Message);
            }
        }

        private void LoadDeThi(int maM = -1)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT D.MaD, M.TenMon, D.TenDe, D.SoCau, D.ThoiGian, D.NgayTao, D.TrangThai
FROM DETHI D
INNER JOIN MON M ON D.MaM = M.MaM
WHERE D.TrangThai IN (N'Hoạt động', N'Khóa')";

                    if (maM > 0) sql += " AND D.MaM = @MaM";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (maM > 0) cmd.Parameters.AddWithValue("@MaM", maM);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dtDeThi = new DataTable();
                        da.Fill(dtDeThi);
                        dgvDeThi.DataSource = dtDeThi;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load đề thi: " + ex.Message);
            }
        }

        private void CboMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMon.SelectedValue == null) return;
            int maM = Convert.ToInt32(cboMon.SelectedValue);
            LoadDeThi(maM);
        }

        private void DgvDeThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvDeThi.Columns[e.ColumnIndex].Name == "ChiTiet")
            {
                int maD = Convert.ToInt32(dgvDeThi.Rows[e.RowIndex].Cells["MaD"].Value);
                string tenDe = dgvDeThi.Rows[e.RowIndex].Cells["TenDe"].Value.ToString();

                ctDeThi form = new ctDeThi(maD, tenDe);
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            dgvDeThi.ReadOnly = false;

            foreach (DataGridViewColumn col in dgvDeThi.Columns)
            {
                // Chỉ cho sửa cột trạng thái
                col.ReadOnly = (col.Name != "TrangThai");
            }

            // Bắt buộc refresh lại edit control để combobox kích hoạt chọn được
            dgvDeThi.EditMode = DataGridViewEditMode.EditOnEnter;

            MessageBox.Show("Bạn có thể chỉnh sửa cột 'Trạng thái' của đề thi.",
                "Chế độ sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvDeThi.Rows)
                    {
                        if (row.IsNewRow) continue;
                        int maD = Convert.ToInt32(row.Cells["MaD"].Value);
                        string trangThai = row.Cells["TrangThai"].Value.ToString();

                        string sql = "UPDATE DETHI SET TrangThai = @TrangThai WHERE MaD = @MaD";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                            cmd.Parameters.AddWithValue("@MaD", maD);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Đã lưu thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDeThi(Convert.ToInt32(cboMon.SelectedValue));
                dgvDeThi.ReadOnly = true;
                dgvDeThi.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thay đổi: " + ex.Message);
            }
        }
    }
}
