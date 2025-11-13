using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Winform_KLCN.ChucNangAdmin
{
    public partial class themCauHoi : Form
    {
        private int maDe;
        private string tenDe;
        private int maMon;
        private string tenMon;
        private int tongSoCau;
        private int soCauP1, soCauP2, soCauP3;

        public themCauHoi(int maDe)
        {
            InitializeComponent();
            this.maDe = maDe;
        }

        private void themCauHoi_Load(object sender, EventArgs e)
        {
            LayThongTinDeThi();
            XacDinhCauTrucTheoMon();
            LoadCboPhan();
            LoadDoKho();
            LoadCauHoi();
            LoadCauHoiTrongDe();
        }

        // ==============================
        // LẤY THÔNG TIN ĐỀ
        // ==============================
        private void LayThongTinDeThi()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"SELECT D.TenDe, D.SoCau, D.MaM, M.TenMon
                               FROM DETHI D
                               JOIN MON M ON D.MaM = M.MaM
                               WHERE D.MaD = @MaD";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaD", maDe);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tenDe = reader["TenDe"].ToString();
                    tongSoCau = Convert.ToInt32(reader["SoCau"]);
                    maMon = Convert.ToInt32(reader["MaM"]);
                    tenMon = reader["TenMon"].ToString();
                    this.Text = $"Thêm câu hỏi cho đề: {tenDe} ({tenMon})";
                }
            }
        }

        // ==============================
        // XÁC ĐỊNH CẤU TRÚC THEO MÔN
        // ==============================
        private void XacDinhCauTrucTheoMon()
        {
            string mon = tenMon.Trim().ToLower();
            if (mon.Contains("toán"))
            {
                soCauP1 = 12; soCauP2 = 4; soCauP3 = 6;
            }
            else if (mon.Contains("lý") || mon.Contains("hóa") || mon.Contains("sinh") || mon.Contains("địa"))
            {
                soCauP1 = 18; soCauP2 = 4; soCauP3 = 6;
            }
            else
            {
                soCauP1 = 24; soCauP2 = 4; soCauP3 = 0;
            }
            tongSoCau = soCauP1 + soCauP2 + soCauP3;
        }

        // ==============================
        // LOAD COMBOBOX PHẦN
        // ==============================
        private void LoadCboPhan()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaP, TenPhan FROM PHAN ORDER BY MaP", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboPhan.SelectedIndexChanged -= cboPhan_SelectedIndexChanged;
                cboPhan.DataSource = dt;
                cboPhan.DisplayMember = "TenPhan";
                cboPhan.ValueMember = "MaP";
                cboPhan.SelectedIndex = 0;
                cboPhan.SelectedIndexChanged += cboPhan_SelectedIndexChanged;
            }
        }

        // ==============================
        // LOAD ĐỘ KHÓ
        // ==============================
        private void LoadDoKho()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaDK, TenDoKho FROM DOKHO", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow allRow = dt.NewRow();
                allRow["MaDK"] = 0;
                allRow["TenDoKho"] = "Tất cả";
                dt.Rows.InsertAt(allRow, 0);

                cboDoKho.SelectedIndexChanged -= cboDoKho_SelectedIndexChanged;
                cboDoKho.DataSource = dt;
                cboDoKho.DisplayMember = "TenDoKho";
                cboDoKho.ValueMember = "MaDK";
                cboDoKho.SelectedIndex = 0;
                cboDoKho.SelectedIndexChanged += cboDoKho_SelectedIndexChanged;
            }
        }

        // ==============================
        // LOAD CÂU HỎI NGÂN HÀNG
        // ==============================
        private void LoadCauHoi()
        {
            if (cboPhan.SelectedValue == null || cboDoKho.SelectedValue == null) return;
            if (cboPhan.SelectedValue is DataRowView || cboDoKho.SelectedValue is DataRowView) return;

            if (!int.TryParse(cboPhan.SelectedValue.ToString(), out int maPhan)) return;
            if (!int.TryParse(cboDoKho.SelectedValue.ToString(), out int maDK)) return;

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"SELECT MaCH, NoiDung, DapAnA, DapAnB, DapAnC, DapAnD, DapAnDung
                               FROM NGANHANGCAUHOI
                               WHERE MaM = @MaM AND MaP = @MaP";
                if (maDK != 0) sql += " AND MaDK = @MaDK";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaM", maMon);
                cmd.Parameters.AddWithValue("@MaP", maPhan);
                if (maDK != 0) cmd.Parameters.AddWithValue("@MaDK", maDK);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                dgvCauHoi.Columns.Clear();
                dgvCauHoi.DataSource = dt;

                dgvCauHoi.Columns["MaCH"].HeaderText = "Mã";
                dgvCauHoi.Columns["NoiDung"].HeaderText = "Nội dung";

                if (!dgvCauHoi.Columns.Contains("btnThem"))
                {
                    DataGridViewButtonColumn btnThem = new DataGridViewButtonColumn();
                    btnThem.HeaderText = "Thêm";
                    btnThem.Name = "btnThem";
                    btnThem.Text = "➕";
                    btnThem.UseColumnTextForButtonValue = true;
                    dgvCauHoi.Columns.Add(btnThem);
                }
            }
        }

        // ==============================
        // THÊM CÂU HỎI VÀO ĐỀ (có giới hạn theo phần)
        // ==============================
        private void dgvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCauHoi.Columns[e.ColumnIndex].Name == "btnThem")
            {
                int maCH = Convert.ToInt32(dgvCauHoi.Rows[e.RowIndex].Cells["MaCH"].Value);
                ThemCauHoiVaoDe(maCH);
            }
        }

        private void ThemCauHoiVaoDe(int maCH)
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();

                // Lấy MaPhan của câu hỏi
                string sqlGetMaPhan = "SELECT MaP FROM NGANHANGCAUHOI WHERE MaCH = @MaCH";
                SqlCommand cmdGetMaPhan = new SqlCommand(sqlGetMaPhan, conn);
                cmdGetMaPhan.Parameters.AddWithValue("@MaCH", maCH);
                int maPhanCauHoi = (int)cmdGetMaPhan.ExecuteScalar();

                // Kiểm tra số câu hiện có trong phần
                string sqlDemPhan = "SELECT COUNT(*) FROM DETHI_CAUHOI DC " +
                                    "JOIN NGANHANGCAUHOI CH ON DC.MaCH = CH.MaCH " +
                                    "WHERE DC.MaD = @MaD AND CH.MaP = @MaP";
                SqlCommand cmdDemPhan = new SqlCommand(sqlDemPhan, conn);
                cmdDemPhan.Parameters.AddWithValue("@MaD", maDe);
                cmdDemPhan.Parameters.AddWithValue("@MaP", maPhanCauHoi);
                int soCauHienCo = (int)cmdDemPhan.ExecuteScalar();

                int gioiHan = 0;
                if (maPhanCauHoi == 1) gioiHan = soCauP1;
                else if (maPhanCauHoi == 2) gioiHan = soCauP2;
                else if (maPhanCauHoi == 3) gioiHan = soCauP3;

                if (soCauHienCo >= gioiHan)
                {
                    MessageBox.Show($"Đã đủ số câu của {((maPhanCauHoi == 1) ? "Phần I" : maPhanCauHoi == 2 ? "Phần II" : "Phần III")}!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra trùng câu
                string sqlCheck = "SELECT COUNT(*) FROM DETHI_CAUHOI WHERE MaD = @MaD AND MaCH = @MaCH";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@MaD", maDe);
                cmdCheck.Parameters.AddWithValue("@MaCH", maCH);
                int exist = (int)cmdCheck.ExecuteScalar();
                if (exist > 0)
                {
                    MessageBox.Show("Câu hỏi này đã có trong đề!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm câu
                string sqlGetSTT = "SELECT ISNULL(MAX(STT), 0) + 1 FROM DETHI_CAUHOI WHERE MaD = @MaD";
                SqlCommand cmdGetSTT = new SqlCommand(sqlGetSTT, conn);
                cmdGetSTT.Parameters.AddWithValue("@MaD", maDe);
                int stt = (int)cmdGetSTT.ExecuteScalar();

                string sqlInsert = "INSERT INTO DETHI_CAUHOI (MaD, MaCH, STT) VALUES (@MaD, @MaCH, @STT)";
                SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn);
                cmdInsert.Parameters.AddWithValue("@MaD", maDe);
                cmdInsert.Parameters.AddWithValue("@MaCH", maCH);
                cmdInsert.Parameters.AddWithValue("@STT", stt);
                cmdInsert.ExecuteNonQuery();

                LoadCauHoiTrongDe();

                int tongCauHienCo = DemSoLuongCauHoi(conn);
                if (tongCauHienCo >= tongSoCau)
                {
                    CapNhatTrangThaiKhoa();
                    MessageBox.Show("Đã đủ số lượng câu hỏi. Đề thi đã được khóa!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private int DemSoLuongCauHoi(SqlConnection conn)
        {
            string sql = "SELECT COUNT(*) FROM DETHI_CAUHOI WHERE MaD = @MaD";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaD", maDe);
            return (int)cmd.ExecuteScalar();
        }

        // ==============================
        // LOAD CÂU HỎI ĐÃ CÓ TRONG ĐỀ (có nút Xóa)
        // ==============================
        private void LoadCauHoiTrongDe()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"SELECT DC.STT, CH.NoiDung, DK.TenDoKho
                               FROM DETHI_CAUHOI DC
                               JOIN NGANHANGCAUHOI CH ON DC.MaCH = CH.MaCH
                               JOIN DOKHO DK ON CH.MaDK = DK.MaDK
                               WHERE DC.MaD = @MaD
                               ORDER BY DC.STT";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaD", maDe);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                dgvCauHoiHienCo.Columns.Clear();
                dgvCauHoiHienCo.DataSource = dt;

                if (!dgvCauHoiHienCo.Columns.Contains("btnXoa"))
                {
                    DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
                    btnXoa.HeaderText = "Xóa";
                    btnXoa.Name = "btnXoa";
                    btnXoa.Text = "❌";
                    btnXoa.UseColumnTextForButtonValue = true;
                    dgvCauHoiHienCo.Columns.Add(btnXoa);
                }
            }
        }

        private void dgvCauHoiHienCo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCauHoiHienCo.Columns[e.ColumnIndex].Name == "btnXoa")
            {
                int stt = Convert.ToInt32(dgvCauHoiHienCo.Rows[e.RowIndex].Cells["STT"].Value);
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = "DELETE FROM DETHI_CAUHOI WHERE MaD = @MaD AND STT = @STT";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaD", maDe);
                    cmd.Parameters.AddWithValue("@STT", stt);
                    cmd.ExecuteNonQuery();
                }
                LoadCauHoiTrongDe();
            }
        }

        // ==============================
        // KHÓA ĐỀ
        // ==============================
        private void CapNhatTrangThaiKhoa()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = "UPDATE DETHI SET TrangThai = N'Khóa' WHERE MaD = @MaD";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaD", maDe);
                cmd.ExecuteNonQuery();
            }
        }

        // ==============================
        // COMBOBOX SỰ KIỆN
        // ==============================
        private void cboPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCauHoi();
        }

        private void cboDoKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCauHoi();
        }
    }
}
