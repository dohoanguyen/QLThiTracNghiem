using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Winform_KLCN.ManHinhAdmin
{
    public partial class tkKetQua : UserControl
    {
        public tkKetQua()
        {
            InitializeComponent();

            // cấu hình DGV
            ConfigureDgvChiTiet1();
            ConfigureDgvKyThi();
            ConfigureDgvMonThi();
            ConfigureDgvChiTiet2();

            // events
            this.Load += TkKetQua_Load;
            cboNamHoc1.SelectedIndexChanged += CboNamHoc1_SelectedIndexChanged;
            cboNamHoc2.SelectedIndexChanged += CboNamHoc2_SelectedIndexChanged;
            cboKhoaHoc.SelectedIndexChanged += CboKhoaHoc_SelectedIndexChanged;

            dgvKyThi.CellClick += DgvKyThi_CellClick;
            dgvMonThi.CellClick += DgvMonThi_CellClick;
        }

        // ---------------------------
        // Helpers: KetNoi.TaoKetNoi() must exist in your project
        // ---------------------------

        // ---------------------------
        // Load / Init
        // ---------------------------
        private void TkKetQua_Load(object sender, EventArgs e)
        {
            LoadNamHocForBoth();    // load cboNamHoc1 and cboNamHoc2 (with "Tất Cả")
            LoadKhoaHoc_All();      // initial load of cboKhoaHoc (will be replaced when cboNamHoc2 changes)
            LoadThongKePhan1();     // fill dgvChiTiet1
        }

        // ---------------------------
        // Configure DGVs
        // ---------------------------
        private void ConfigureDgvChiTiet1()
        {
            dgvChiTiet1.AutoGenerateColumns = false;
            dgvChiTiet1.Columns.Clear();
            dgvChiTiet1.ReadOnly = true;
            dgvChiTiet1.AllowUserToAddRows = false;

            dgvChiTiet1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Ten", HeaderText = "Chỉ tiêu", DataPropertyName = "ChiTieu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvChiTiet1.Columns.Add(new DataGridViewTextBoxColumn { Name = "GiaTri", HeaderText = "Giá trị", DataPropertyName = "GiaTri", Width = 120 });
        }

        private void ConfigureDgvKyThi()
        {
            dgvKyThi.AutoGenerateColumns = false;
            dgvKyThi.Columns.Clear();
            dgvKyThi.ReadOnly = true;
            dgvKyThi.AllowUserToAddRows = false;
            dgvKyThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvKyThi.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaKT", HeaderText = "MaKT", DataPropertyName = "MaKT", Visible = false });
            dgvKyThi.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKyThi", HeaderText = "Tên Kỳ Thi", DataPropertyName = "TenKyThi", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvKyThi.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayBatDau", HeaderText = "Ngày Bắt Đầu", DataPropertyName = "NgayBatDau", Width = 110 });
            dgvKyThi.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayKetThuc", HeaderText = "Ngày Kết Thúc", DataPropertyName = "NgayKetThuc", Width = 110 });
        }

        private void ConfigureDgvMonThi()
        {
            dgvMonThi.AutoGenerateColumns = false;
            dgvMonThi.Columns.Clear();
            dgvMonThi.ReadOnly = true;
            dgvMonThi.AllowUserToAddRows = false;
            dgvMonThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvMonThi.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaM", HeaderText = "MaM", DataPropertyName = "MaM", Visible = false });
            dgvMonThi.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenMon", HeaderText = "Tên Môn", DataPropertyName = "TenMon", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        private void ConfigureDgvChiTiet2()
        {
            dgvChiTiet2.AutoGenerateColumns = false;
            dgvChiTiet2.Columns.Clear();
            dgvChiTiet2.ReadOnly = true;
            dgvChiTiet2.AllowUserToAddRows = false;

            dgvChiTiet2.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiemTB", HeaderText = "Điểm TB", DataPropertyName = "DiemTrungBinh", Width = 120 });
            dgvChiTiet2.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiemMax", HeaderText = "Điểm Cao Nhất", DataPropertyName = "DiemCaoNhat", Width = 120 });
            dgvChiTiet2.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiemMin", HeaderText = "Điểm Thấp Nhất", DataPropertyName = "DiemThapNhat", Width = 120 });
            dgvChiTiet2.Columns.Add(new DataGridViewTextBoxColumn { Name = "HVTop", HeaderText = "Học viên cao nhất", DataPropertyName = "HocVienGioi", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvChiTiet2.Columns.Add(new DataGridViewTextBoxColumn { Name = "HVLow", HeaderText = "Học viên thấp nhất", DataPropertyName = "HocVienYeu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        // ---------------------------
        // Load combos
        // ---------------------------
        private void LoadNamHocForBoth()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = "SELECT DISTINCT NamHoc FROM KHOAHOC ORDER BY NamHoc DESC";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // prep a table with "Tất Cả" at top
                    DataTable src = new DataTable();
                    src.Columns.Add("NamHoc", typeof(string));
                    DataRow r = src.NewRow(); r["NamHoc"] = "Tất Cả"; src.Rows.Add(r);
                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow rr = src.NewRow(); rr["NamHoc"] = row["NamHoc"].ToString(); src.Rows.Add(rr);
                    }

                    cboNamHoc1.DataSource = src.Copy();
                    cboNamHoc1.DisplayMember = "NamHoc";
                    cboNamHoc1.ValueMember = "NamHoc";
                    cboNamHoc1.SelectedIndex = 0;

                    cboNamHoc2.DataSource = src.Copy();
                    cboNamHoc2.DisplayMember = "NamHoc";
                    cboNamHoc2.ValueMember = "NamHoc";
                    cboNamHoc2.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load năm học: " + ex.Message);
            }
        }

        private void LoadKhoaHoc_All()
        {
            // load all khóa (no year filter) initially
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = "SELECT MaK, TenKhoaHoc, NamHoc FROM KHOAHOC ORDER BY MaK DESC";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataTable src = new DataTable();
                    src.Columns.Add("MaK", typeof(int));
                    src.Columns.Add("TenHien", typeof(string));
                    DataRow r = src.NewRow(); r["MaK"] = -1; r["TenHien"] = "Tất Cả"; src.Rows.Add(r);

                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow rr = src.NewRow();
                        rr["MaK"] = Convert.ToInt32(row["MaK"]);
                        rr["TenHien"] = $"{row["TenKhoaHoc"]} ({row["NamHoc"]})";
                        src.Rows.Add(rr);
                    }

                    cboKhoaHoc.DataSource = src;
                    cboKhoaHoc.DisplayMember = "TenHien";
                    cboKhoaHoc.ValueMember = "MaK";
                    cboKhoaHoc.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load khóa học: " + ex.Message);
            }
        }

        private void LoadKhoaHoc_ByNam(string namHoc)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = "SELECT MaK, TenKhoaHoc, NamHoc FROM KHOAHOC WHERE @Nam = 'Tất Cả' OR NamHoc = @Nam ORDER BY MaK DESC";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Nam", namHoc);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataTable src = new DataTable();
                    src.Columns.Add("MaK", typeof(int));
                    src.Columns.Add("TenHien", typeof(string));
                    DataRow r = src.NewRow(); r["MaK"] = -1; r["TenHien"] = "Tất Cả"; src.Rows.Add(r);

                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow rr = src.NewRow();
                        rr["MaK"] = Convert.ToInt32(row["MaK"]);
                        rr["TenHien"] = $"{row["TenKhoaHoc"]} ({row["NamHoc"]})";
                        src.Rows.Add(rr);
                    }

                    cboKhoaHoc.DataSource = src;
                    cboKhoaHoc.DisplayMember = "TenHien";
                    cboKhoaHoc.ValueMember = "MaK";
                    cboKhoaHoc.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load khóa theo năm: " + ex.Message);
            }
        }

        // ---------------------------
        // Part 1 - thống kê tổng quan theo năm (cboNamHoc1 -> dgvChiTiet1)
        // ---------------------------
        private void CboNamHoc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThongKePhan1();
        }

        private void LoadThongKePhan1()
        {
            string nam = cboNamHoc1.SelectedValue?.ToString() ?? "Tất Cả";

            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    // số kỳ thi (thuộc khóa có năm = nam), số môn thi (dựa trên LICHTHI -> DETHI.MaM),
                    // số học viên tham gia (distinct MaHV từ KETQUATHI liên quan đến LICHTHI của KYTHI)
                    // số đề sử dụng (distinct MaD trong LICHTHI)
                    string sql = @"
SELECT 
    (SELECT COUNT(DISTINCT K.MaKT)
     FROM KYTHI K
     JOIN KHOAHOC KH ON K.MaK = KH.MaK
     WHERE (@Nam = 'Tất Cả' OR KH.NamHoc = @Nam)
    ) AS SoKyThi,
    (SELECT COUNT(DISTINCT D.MaM)
     FROM LICHTHI LT
     JOIN DETHI D ON LT.MaD = D.MaD
     JOIN KYTHI K2 ON LT.MaKT = K2.MaKT
     JOIN KHOAHOC KH2 ON K2.MaK = KH2.MaK
     WHERE (@Nam = 'Tất Cả' OR KH2.NamHoc = @Nam)
    ) AS SoMonThi,
    (SELECT COUNT(DISTINCT KQ.MaHV)
     FROM KETQUATHI KQ
     JOIN LICHTHI LT2 ON KQ.MaLT = LT2.MaLT
     JOIN KYTHI K3 ON LT2.MaKT = K3.MaKT
     JOIN KHOAHOC KH3 ON K3.MaK = KH3.MaK
     WHERE (@Nam = 'Tất Cả' OR KH3.NamHoc = @Nam)
    ) AS SoHocVien,
    (SELECT COUNT(DISTINCT LT3.MaD)
     FROM LICHTHI LT3
     JOIN KYTHI K4 ON LT3.MaKT = K4.MaKT
     JOIN KHOAHOC KH4 ON K4.MaK = KH4.MaK
     WHERE (@Nam = 'Tất Cả' OR KH4.NamHoc = @Nam)
    ) AS SoDeSuDung
";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Nam", nam);

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    // transform to 2-column table for display
                    DataTable outDt = new DataTable();
                    outDt.Columns.Add("ChiTieu", typeof(string));
                    outDt.Columns.Add("GiaTri", typeof(string));

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        outDt.Rows.Add("Số kỳ thi", row["SoKyThi"].ToString());
                        outDt.Rows.Add("Số môn thi", row["SoMonThi"].ToString());
                        outDt.Rows.Add("Số học viên tham gia", row["SoHocVien"].ToString());
                        outDt.Rows.Add("Số đề sử dụng", row["SoDeSuDung"].ToString());
                    }

                    dgvChiTiet1.DataSource = outDt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thống kê tổng quan: " + ex.Message);
            }
        }

        // ---------------------------
        // Part 2 - chi tiết
        // ---------------------------
        private void CboNamHoc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nam = cboNamHoc2.SelectedValue?.ToString() ?? "Tất Cả";
            LoadKhoaHoc_ByNam(nam);

            dgvKyThi.DataSource = null;
            dgvMonThi.DataSource = null;
            dgvChiTiet2.DataSource = null;
        }

        private void CboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadKyThi_ByKhoa();
            dgvMonThi.DataSource = null;
            dgvChiTiet2.DataSource = null;
        }

        private void LoadKyThi_ByKhoa()
        {
            int maK = -1;
            try
            {
                maK = Convert.ToInt32(cboKhoaHoc.SelectedValue);
            }
            catch { maK = -1; }

            string nam = cboNamHoc2.SelectedValue?.ToString() ?? "Tất Cả";

            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT K.MaKT, K.TenKyThi AS TenKyThi, K.NgayBatDau, K.NgayKetThuc
FROM KYTHI K
JOIN KHOAHOC KH ON K.MaK = KH.MaK
WHERE (@Nam = 'Tất Cả' OR KH.NamHoc = @Nam)
AND (@MaK = -1 OR KH.MaK = @MaK)
ORDER BY K.NgayBatDau DESC, K.MaKT DESC
";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    cmd.Parameters.AddWithValue("@MaK", maK);

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    dgvKyThi.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load kỳ thi: " + ex.Message);
            }
        }

        private void DgvKyThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                int maKT = Convert.ToInt32(dgvKyThi.Rows[e.RowIndex].Cells["MaKT"].Value);
                LoadMonThi_ByKyThi(maKT);
                dgvChiTiet2.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy MaKT: " + ex.Message);
            }
        }

        private void LoadMonThi_ByKyThi(int maKT)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT DISTINCT M.MaM, M.TenMon
FROM LICHTHI LT
JOIN DETHI D ON LT.MaD = D.MaD
JOIN MON M ON D.MaM = M.MaM
WHERE LT.MaKT = @MaKT
ORDER BY M.TenMon
";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaKT", maKT);

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    dgvMonThi.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load môn thi: " + ex.Message);
            }
        }

        private void DgvMonThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                // MaM from dgvMonThi and MaKT from currently selected dgvKyThi row
                int maM = Convert.ToInt32(dgvMonThi.Rows[e.RowIndex].Cells["MaM"].Value);
                int maKT = -1;
                if (dgvKyThi.CurrentRow != null)
                    maKT = Convert.ToInt32(dgvKyThi.CurrentRow.Cells["MaKT"].Value);

                if (maKT <= 0)
                {
                    MessageBox.Show("Vui lòng chọn kỳ thi trước.");
                    return;
                }

                LoadThongKeDiem_ForMon(maKT, maM);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn môn: " + ex.Message);
            }
        }

        private void LoadThongKeDiem_ForMon(int maKT, int maM)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    // Lấy các MaLT liên quan tới (MaKT, MaM): LICHTHI.MaKT = maKT AND LICHTHI.MaD IN (DETHI where MaM=maM)
                    // Sau đó dùng KETQUATHI.MaLT IN (...)
                    string sql = @"
SELECT
    ROUND(AVG(KQ.Diem), 2) AS DiemTrungBinh,
    MAX(KQ.Diem) AS DiemCaoNhat,
    MIN(KQ.Diem) AS DiemThapNhat,
    (SELECT TOP 1 HV.TenHV
     FROM KETQUATHI K1
     JOIN HOCVIEN HV ON K1.MaHV = HV.MaHV
     WHERE K1.MaLT IN (
         SELECT LT2.MaLT FROM LICHTHI LT2
         JOIN DETHI D2 ON LT2.MaD = D2.MaD
         WHERE LT2.MaKT = @MaKT AND D2.MaM = @MaM
     )
     ORDER BY K1.Diem DESC, K1.MaKQ ASC
    ) AS HocVienGioi,
    (SELECT TOP 1 HV2.TenHV
     FROM KETQUATHI K2
     JOIN HOCVIEN HV2 ON K2.MaHV = HV2.MaHV
     WHERE K2.MaLT IN (
         SELECT LT3.MaLT FROM LICHTHI LT3
         JOIN DETHI D3 ON LT3.MaD = D3.MaD
         WHERE LT3.MaKT = @MaKT AND D3.MaM = @MaM
     )
     ORDER BY K2.Diem ASC, K2.MaKQ ASC
    ) AS HocVienYeu
FROM KETQUATHI KQ
WHERE KQ.MaLT IN (
    SELECT LT.MaLT FROM LICHTHI LT
    JOIN DETHI D ON LT.MaD = D.MaD
    WHERE LT.MaKT = @MaKT AND D.MaM = @MaM
)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaKT", maKT);
                    cmd.Parameters.AddWithValue("@MaM", maM);

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    dgvChiTiet2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thống kê điểm: " + ex.Message);
            }
        }
    }
}
