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
        private int tongSoCau;

        public themCauHoi(int maDe)
        {
            InitializeComponent();
            this.maDe = maDe;
        }

        private void themCauHoi_Load(object sender, EventArgs e)
        {
            LayThongTinDeThi();
            LoadDoKho();
            LoadCauHoi();
            LoadCauHoiTrongDe();
        }

        // ==============================
        //  LẤY THÔNG TIN ĐỀ THI
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

                    this.Text = $"Thêm câu hỏi cho đề: {tenDe}";
                }
            }
        }

        // ==============================
        //  LOAD ĐỘ KHÓ
        // ==============================
        private void LoadDoKho()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaDK, TenDoKho FROM DOKHO", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboDoKho.DataSource = dt;
                cboDoKho.DisplayMember = "TenDoKho";
                cboDoKho.ValueMember = "MaDK";
                cboDoKho.SelectedIndexChanged += cboDoKho_SelectedIndexChanged;
            }
        }

        // ==============================
        //  LOAD CÂU HỎI NGÂN HÀNG
        // ==============================
        private void LoadCauHoi()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"SELECT MaCH, NoiDung, MaDK
                       FROM NGANHANGCAUHOI
                       WHERE MaM = @MaM";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@MaM", maMon);

                // Kiểm tra kỹ kiểu dữ liệu SelectedValue
                if (cboDoKho.SelectedValue != null && !(cboDoKho.SelectedValue is DataRowView))
                {
                    int maDK = Convert.ToInt32(cboDoKho.SelectedValue);
                    sql += " AND MaDK = @MaDK";
                    cmd.Parameters.AddWithValue("@MaDK", maDK);
                }

                cmd.CommandText = sql;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvCauHoi.Columns.Clear();
                dgvCauHoi.DataSource = dt;

                // Thêm nút "Thêm"
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
        //  NHẤN "THÊM" TRONG DGV CÂU HỎI
        // ==============================


        // ==============================
        //  THÊM CÂU HỎI VÀO ĐỀ
        // ==============================
        private void ThemCauHoiVaoDe(int maCH)
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();

                // Kiểm tra trùng
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

                // Thêm mới
                // Lấy STT kế tiếp
                string sqlGetSTT = "SELECT ISNULL(MAX(STT), 0) + 1 FROM DETHI_CAUHOI WHERE MaD = @MaD";
                SqlCommand cmdGetSTT = new SqlCommand(sqlGetSTT, conn);
                cmdGetSTT.Parameters.AddWithValue("@MaD", maDe);
                int stt = (int)cmdGetSTT.ExecuteScalar();

                // Thêm mới có STT
                string sqlInsert = "INSERT INTO DETHI_CAUHOI (MaD, MaCH, STT) VALUES (@MaD, @MaCH, @STT)";
                SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn);
                cmdInsert.Parameters.AddWithValue("@MaD", maDe);
                cmdInsert.Parameters.AddWithValue("@MaCH", maCH);
                cmdInsert.Parameters.AddWithValue("@STT", stt);
                cmdInsert.ExecuteNonQuery();

                string sqlCount = "SELECT COUNT(*) FROM DETHI_CAUHOI WHERE MaD = @MaD";
                SqlCommand cmdCount = new SqlCommand(sqlCount, conn);
                cmdCount.Parameters.AddWithValue("@MaD", maDe);
                int soHienCo = (int)cmdCount.ExecuteScalar();


                LoadCauHoiTrongDe();

             
                if (soHienCo >= tongSoCau)
                {
                    CapNhatTrangThaiKhoa();
                    MessageBox.Show("Đã đủ số lượng câu hỏi. Đề thi đã được khóa!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
              
            }
        }

        // ==============================
        //  LOAD CÂU HỎI ĐÃ CÓ TRONG ĐỀ
        // ==============================
        private void LoadCauHoiTrongDe()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"SELECT DC.STT, CH.MaCH, CH.NoiDung, DK.TenDoKho
               FROM DETHI_CAUHOI DC
               JOIN NGANHANGCAUHOI CH ON DC.MaCH = CH.MaCH
               JOIN DOKHO DK ON CH.MaDK = DK.MaDK
               WHERE DC.MaD = @MaD
               ORDER BY DC.STT";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaD", maDe);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCauHoiHienCo.DataSource = dt;
            }
            
        }

        // ==============================
        //  KHÓA ĐỀ
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
        //  CHỌN LỌC ĐỘ KHÓ
        // ==============================
        private void cboDoKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCauHoi();
        }

        private void dgvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCauHoi.Columns[e.ColumnIndex].Name == "btnThem")
            {
                int maCH = Convert.ToInt32(dgvCauHoi.Rows[e.RowIndex].Cells["MaCH"].Value);
                ThemCauHoiVaoDe(maCH);
            }
        }
    }
}
