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

        public qlyCauHoi()
        {
            InitializeComponent();
            CauHinhDataGridView();
            LoadMon();
            LoadDoKho();
            LoadCauHoi(); // load all by default

            btnXacNhan.Click += btnXacNhan_Click;
        }

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
            AddColumn("NoiDung", "Nội dung", 250);
            AddColumn("DapAnA", "Đáp án A", 150);
            AddColumn("DapAnB", "Đáp án B", 150);
            AddColumn("DapAnC", "Đáp án C", 150);
            AddColumn("DapAnD", "Đáp án D", 150);
            AddColumn("DapAnDung", "Đáp án đúng", 100);

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

        private void LoadCauHoi(int maM = -1, int maDK = -1)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT CH.MaCH, M.TenMon, DK.TenDoKho, CH.NoiDung, CH.DapAnA, CH.DapAnB, CH.DapAnC, CH.DapAnD, CH.DapAnDung
FROM NGANHANGCAUHOI CH
INNER JOIN MON M ON CH.MaM = M.MaM
INNER JOIN DOKHO DK ON CH.MaDK = DK.MaDK
WHERE (1=1)";

                    if (maM > 0) sql += " AND CH.MaM = @MaM";
                    if (maDK > 0) sql += " AND CH.MaDK = @MaDK";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (maM > 0) cmd.Parameters.AddWithValue("@MaM", maM);
                        if (maDK > 0) cmd.Parameters.AddWithValue("@MaDK", maDK);

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

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int maM = cboMon.SelectedValue != null ? Convert.ToInt32(cboMon.SelectedValue) : -1;
            int maDK = cboDoKho.SelectedValue != null ? Convert.ToInt32(cboDoKho.SelectedValue) : -1;
            LoadCauHoi(maM, maDK);
        }

        private void cboDoKho_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
