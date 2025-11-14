using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Winform_KLCN.ManHinhAdmin
{
    public partial class qlyCauHoi : UserControl
    {
        private DataTable dtCauHoi;
        private DataTable dtMon;
        private DataTable dtDoKho;
        private DataTable dtPhan;

        public qlyCauHoi()
        {
            InitializeComponent();

            CauHinhDataGridView();

            LoadMon();
            LoadDoKho();
            LoadPhan();

            LoadCauHoi(); // load all by default

            btnXacNhan.Click += btnXacNhan_Click;
        }

        #region DataGridView Setup
        private void CauHinhDataGridView()
        {
            dgvCauHoi.AutoGenerateColumns = false;
            dgvCauHoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCauHoi.MultiSelect = false;
            dgvCauHoi.AllowUserToAddRows = false;
            dgvCauHoi.ReadOnly = true;
            dgvCauHoi.RowHeadersVisible = false;
            dgvCauHoi.ColumnHeadersVisible = true;
            dgvCauHoi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvCauHoi.ColumnHeadersHeight = 40;

            dgvCauHoi.Columns.Clear();

            AddColumn("MaCH", "Mã CH", 60);
            AddColumn("TenMon", "Môn học", 120);
            AddColumn("TenDoKho", "Độ khó", 120);
            AddColumn("TenPhan", "Phần", 100);
            AddColumn("MaGV", "Mã GV", 60);
            AddColumn("NoiDung", "Nội dung", 250);
            AddColumn("DapAn", "Đáp án", 300);
            AddColumn("DapAnDung", "Đáp án đúng", 100);
            AddColumn("GiaiThich", "Giải thích", 250);

            // ✅ Thêm nút Xóa
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "btnXoa";
            btnDelete.HeaderText = "Xóa";
            btnDelete.Text = "Xóa";
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.Width = 60;
            dgvCauHoi.Columns.Add(btnDelete);

            // Gắn sự kiện
            dgvCauHoi.CellContentClick += dgvCauHoi_CellContentClick;
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
            dgvCauHoi.Columns.Add(col);
        }
        #endregion

        #region Load ComboBoxes
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

        private void LoadDoKho()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = "SELECT MaDK, TenDoKho FROM DOKHO ORDER BY MaDK";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    dtDoKho = new DataTable();
                    da.Fill(dtDoKho);

                    DataTable dtCombo = dtDoKho.Clone();
                    DataRow rAll = dtCombo.NewRow();
                    rAll["MaDK"] = -1;
                    rAll["TenDoKho"] = "Tất cả";
                    dtCombo.Rows.Add(rAll);

                    foreach (DataRow r in dtDoKho.Rows)
                        dtCombo.ImportRow(r);

                    cboDoKho.DisplayMember = "TenDoKho";
                    cboDoKho.ValueMember = "MaDK";
                    cboDoKho.DataSource = dtCombo;
                    cboDoKho.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải độ khó: " + ex.Message);
            }
        }

        private void LoadPhan()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = "SELECT MaP, TenPhan FROM PHAN ORDER BY MaP";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    dtPhan = new DataTable();
                    da.Fill(dtPhan);

                    DataTable dtCombo = dtPhan.Clone();
                    DataRow rAll = dtCombo.NewRow();
                    rAll["MaP"] = -1;
                    rAll["TenPhan"] = "Tất cả";
                    dtCombo.Rows.Add(rAll);

                    foreach (DataRow r in dtPhan.Rows)
                        dtCombo.ImportRow(r);

                    cboPhan.DisplayMember = "TenPhan";
                    cboPhan.ValueMember = "MaP";
                    cboPhan.DataSource = dtCombo;
                    cboPhan.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải phần: " + ex.Message);
            }
        }
        #endregion

        #region Load Data
        private void LoadCauHoi(int maM = -1, int maDK = -1, int maP = -1)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    string sql = @"
SELECT CH.MaCH, M.TenMon, DK.TenDoKho, P.TenPhan, CH.MaGV, CH.NoiDung,
       CASE 
           WHEN P.TenPhan = N'Phần II' THEN ISNULL(DA.DapAnText, '')
           ELSE CH.DapAnA + ' | ' + CH.DapAnB + ' | ' + CH.DapAnC + ' | ' + CH.DapAnD
       END AS DapAn,
       CH.DapAnDung, CH.GiaiThich
FROM NGANHANGCAUHOI CH
INNER JOIN MON M ON CH.MaM = M.MaM
INNER JOIN DOKHO DK ON CH.MaDK = DK.MaDK
INNER JOIN PHAN P ON CH.MaP = P.MaP
LEFT JOIN (
    SELECT MaCH, STRING_AGG(MaPhuongAn + ':' + NoiDung, ' | ') AS DapAnText
    FROM DAPAN
    GROUP BY MaCH
) DA ON CH.MaCH = DA.MaCH
WHERE (1=1)";

                    if (maM > 0) sql += " AND CH.MaM = @MaM";
                    if (maDK > 0) sql += " AND CH.MaDK = @MaDK";
                    if (maP > 0) sql += " AND CH.MaP = @MaP";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (maM > 0) cmd.Parameters.AddWithValue("@MaM", maM);
                        if (maDK > 0) cmd.Parameters.AddWithValue("@MaDK", maDK);
                        if (maP > 0) cmd.Parameters.AddWithValue("@MaP", maP);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dtCauHoi = new DataTable();
                        da.Fill(dtCauHoi);

                        dgvCauHoi.DataSource = dtCauHoi;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load câu hỏi: " + ex.Message);
            }
        }
        #endregion

        #region Events
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int maM = cboMon.SelectedValue != null ? Convert.ToInt32(cboMon.SelectedValue) : -1;
            int maDK = cboDoKho.SelectedValue != null ? Convert.ToInt32(cboDoKho.SelectedValue) : -1;
            int maP = cboPhan.SelectedValue != null ? Convert.ToInt32(cboPhan.SelectedValue) : -1;

            LoadCauHoi(maM, maDK, maP);
        }
        #endregion

        private void dgvCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCauHoi.Columns[e.ColumnIndex].Name == "btnXoa")
            {
                string maCH = dgvCauHoi.Rows[e.RowIndex].Cells["MaCH"].Value.ToString();
                string noiDung = dgvCauHoi.Rows[e.RowIndex].Cells["NoiDung"].Value.ToString();

                DialogResult dr = MessageBox.Show(
                    $"Bạn có chắc muốn xóa câu hỏi:\n{noiDung} (Mã CH: {maCH})?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = KetNoi.TaoKetNoi())
                        {
                            conn.Open();

                            // ✅ Kiểm tra xem câu hỏi có đang được dùng trong đề thi
                            string checkSql = "SELECT COUNT(*) FROM DETHI_CAUHOI WHERE MaCH=@maCH";
                            SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                            checkCmd.Parameters.AddWithValue("@maCH", maCH);
                            int count = (int)checkCmd.ExecuteScalar();

                            if (count > 0)
                            {
                                MessageBox.Show(
                                    $"Không thể xóa câu hỏi này vì đang có {count} đề thi sử dụng!",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Nếu không bị dùng thì xóa
                            string sql = "DELETE FROM NGANHANGCAUHOI WHERE MaCH=@maCH";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@maCH", maCH);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Đã xóa câu hỏi thành công!", "Thành công");

                        // Reload DataGridView
                        int maM = cboMon.SelectedValue != null ? Convert.ToInt32(cboMon.SelectedValue) : -1;
                        int maDK = cboDoKho.SelectedValue != null ? Convert.ToInt32(cboDoKho.SelectedValue) : -1;
                        int maP = cboPhan.SelectedValue != null ? Convert.ToInt32(cboPhan.SelectedValue) : -1;
                        LoadCauHoi(maM, maDK, maP);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa câu hỏi: " + ex.Message, "Lỗi");
                    }
                }
            }

        }
    }
}
