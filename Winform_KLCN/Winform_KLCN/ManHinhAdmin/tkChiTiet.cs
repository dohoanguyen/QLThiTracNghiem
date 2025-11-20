using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Winform_KLCN.ManHinhAdmin
{
    public partial class tkChiTiet : UserControl
    {
        private DataTable dtGiaoVien;
        private DataTable dtLopHoc;
        private DataTable dtKyThi;

        public tkChiTiet()
        {
            InitializeComponent();

            // Cau hinh DGV
            CauHinhDGVChiTiet1();
            CauHinhDGVGiaoVien();
            CauHinhDGVLopHoc();
            CauHinhDGVKyThi();

            // Load dữ liệu
            LoadChiTietTongQuan();
            LoadNamHoc();

            // Events
            cboNamHoc.SelectedIndexChanged += CboNamHoc_SelectedIndexChanged;
            cboKhoaHoc.SelectedIndexChanged += CboKhoaHoc_SelectedIndexChanged;
            cboMonHoc.SelectedIndexChanged += CboMonHoc_SelectedIndexChanged;

            dgvGiaoVien.CellClick += DgvGiaoVien_CellClick;
            dgvLopHoc.CellClick += DgvLopHoc_CellClick;
        }

        #region --- Cau hinh DGV ---

        private void CauHinhDGVChiTiet1()
        {
            dgvChiTiet1.AutoGenerateColumns = false;
            dgvChiTiet1.Columns.Clear();
            dgvChiTiet1.Columns.Add("TenLoai", "Loại");
            dgvChiTiet1.Columns.Add("SoLuong", "Số lượng");
        }

        private void CauHinhDGVGiaoVien()
        {
            dgvGiaoVien.AutoGenerateColumns = false;
            dgvGiaoVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGiaoVien.MultiSelect = false;
            dgvGiaoVien.ReadOnly = true;
            dgvGiaoVien.RowHeadersVisible = false;
            dgvGiaoVien.Columns.Clear();

            // Mã GV ẩn
            dgvGiaoVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaGV",
                HeaderText = "Mã GV",
                DataPropertyName = "MaGV",
                Visible = false
            });

            // Tên GV hiển thị
            dgvGiaoVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenGV",
                HeaderText = "Tên Giáo Viên",
                DataPropertyName = "TenGV",
                Width = 200
            });
        }

        private void CauHinhDGVLopHoc()
        {
            dgvLopHoc.AutoGenerateColumns = false;
            dgvLopHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLopHoc.MultiSelect = false;
            dgvLopHoc.ReadOnly = true;
            dgvLopHoc.RowHeadersVisible = false;
            dgvLopHoc.Columns.Clear();

            dgvLopHoc.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaL",
                HeaderText = "Mã Lớp",
                DataPropertyName = "MaL",
                Visible = false
            });

            dgvLopHoc.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenLop",
                HeaderText = "Tên Lớp",
                DataPropertyName = "TenLop",
                Width = 200
            });
        }

        private void CauHinhDGVKyThi()
        {
            dgvKyThi.AutoGenerateColumns = false;
            dgvKyThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKyThi.MultiSelect = false;
            dgvKyThi.ReadOnly = true;
            dgvKyThi.RowHeadersVisible = false;
            dgvKyThi.Columns.Clear();

            dgvKyThi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaKT",
                HeaderText = "Mã Kỳ Thi",
                DataPropertyName = "MaKT",
                Visible = false
            });

            dgvKyThi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenKyThi",
                HeaderText = "Tên Kỳ Thi",
                DataPropertyName = "TenKyThi",
                Width = 200
            });
        }

        #endregion

        #region --- Load phần 1 ---

        private void LoadChiTietTongQuan()
        {
            dgvChiTiet1.Rows.Clear();
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                int soGV = (int)new SqlCommand("SELECT COUNT(*) FROM GIAOVIEN", conn).ExecuteScalar();
                int soHV = (int)new SqlCommand("SELECT COUNT(*) FROM HOCVIEN", conn).ExecuteScalar();
                int soKhoa = (int)new SqlCommand("SELECT COUNT(*) FROM KHOAHOC", conn).ExecuteScalar();
                int soMon = (int)new SqlCommand("SELECT COUNT(*) FROM MON", conn).ExecuteScalar();
                int soDe = (int)new SqlCommand("SELECT COUNT(*) FROM DETHI", conn).ExecuteScalar();
                int soCH = (int)new SqlCommand("SELECT COUNT(*) FROM NGANHANGCAUHOI", conn).ExecuteScalar();

                dgvChiTiet1.Rows.Add("Giáo Viên", soGV);
                dgvChiTiet1.Rows.Add("Học Viên", soHV);
                dgvChiTiet1.Rows.Add("Khóa Học", soKhoa);
                dgvChiTiet1.Rows.Add("Môn Học", soMon);
                dgvChiTiet1.Rows.Add("Đề Thi", soDe);
                dgvChiTiet1.Rows.Add("Câu Hỏi", soCH);
            }
        }

        #endregion

        #region --- Load combobox lọc ---

        private void LoadNamHoc()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = "SELECT DISTINCT NamHoc FROM KHOAHOC ORDER BY NamHoc DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                cboNamHoc.Items.Clear();
                cboNamHoc.Items.Add("Tất Cả");
                while (dr.Read()) cboNamHoc.Items.Add(dr["NamHoc"].ToString());
                dr.Close();
                cboNamHoc.SelectedIndex = 0;
            }
            LoadKhoaHoc();
        }

        private void LoadKhoaHoc()
        {
            string namHoc = cboNamHoc.SelectedItem?.ToString() ?? "Tất Cả";
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = namHoc == "Tất Cả"
                    ? "SELECT DISTINCT TenKhoaHoc FROM KHOAHOC"
                    : "SELECT DISTINCT TenKhoaHoc FROM KHOAHOC WHERE NamHoc=@NamHoc";
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (namHoc != "Tất Cả") cmd.Parameters.AddWithValue("@NamHoc", namHoc);

                SqlDataReader dr = cmd.ExecuteReader();
                cboKhoaHoc.Items.Clear();
                cboKhoaHoc.Items.Add("Tất Cả");
                while (dr.Read()) cboKhoaHoc.Items.Add(dr["TenKhoaHoc"].ToString());
                dr.Close();
                cboKhoaHoc.SelectedIndex = 0;
            }
            LoadMonHoc();
        }

        private void LoadMonHoc()
        {
            string namHoc = cboNamHoc.SelectedItem?.ToString() ?? "Tất Cả";
            string khoaHoc = cboKhoaHoc.SelectedItem?.ToString() ?? "Tất Cả";

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"SELECT DISTINCT M.TenMon 
                               FROM MON M
                               INNER JOIN LOPHOC L ON M.MaM = L.MaM
                               INNER JOIN KHOAHOC K ON L.MaK = K.MaK
                               WHERE 1=1 ";
                if (namHoc != "Tất Cả") sql += " AND K.NamHoc=@NamHoc";
                if (khoaHoc != "Tất Cả") sql += " AND K.TenKhoaHoc=@TenKhoaHoc";
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (namHoc != "Tất Cả") cmd.Parameters.AddWithValue("@NamHoc", namHoc);
                if (khoaHoc != "Tất Cả") cmd.Parameters.AddWithValue("@TenKhoaHoc", khoaHoc);

                SqlDataReader dr = cmd.ExecuteReader();
                cboMonHoc.Items.Clear();
                cboMonHoc.Items.Add("Tất Cả");
                while (dr.Read()) cboMonHoc.Items.Add(dr["TenMon"].ToString());
                dr.Close();
                cboMonHoc.SelectedIndex = 0;
            }
            LoadDGVGiaoVien();
        }

        #endregion

        #region --- Load DGV chi tiết ---

        private void LoadDGVGiaoVien()
        {
            string namHoc = cboNamHoc.SelectedItem?.ToString() ?? "Tất Cả";
            string khoaHoc = cboKhoaHoc.SelectedItem?.ToString() ?? "Tất Cả";
            string monHoc = cboMonHoc.SelectedItem?.ToString() ?? "Tất Cả";

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"SELECT G.MaGV, G.TenGV
                               FROM GIAOVIEN G
                               WHERE 1=1 ";
                if (namHoc != "Tất Cả")
                    sql += @" AND G.MaGV IN (SELECT DISTINCT L.MaGV FROM LOPHOC L
                                             INNER JOIN KHOAHOC K ON L.MaK = K.MaK
                                             WHERE K.NamHoc=@NamHoc)";
                if (khoaHoc != "Tất Cả")
                    sql += @" AND G.MaGV IN (SELECT DISTINCT L.MaGV FROM LOPHOC L
                                             INNER JOIN KHOAHOC K ON L.MaK = K.MaK
                                             WHERE K.TenKhoaHoc=@TenKhoaHoc)";
                if (monHoc != "Tất Cả")
                    sql += @" AND G.MaGV IN (SELECT DISTINCT GM.MaGV FROM GIAOVIEN_MON GM
                                             INNER JOIN MON M ON GM.MaM = M.MaM
                                             WHERE M.TenMon=@TenMon)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                if (namHoc != "Tất Cả") cmd.Parameters.AddWithValue("@NamHoc", namHoc);
                if (khoaHoc != "Tất Cả") cmd.Parameters.AddWithValue("@TenKhoaHoc", khoaHoc);
                if (monHoc != "Tất Cả") cmd.Parameters.AddWithValue("@TenMon", monHoc);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dtGiaoVien = new DataTable();
                da.Fill(dtGiaoVien);
                dgvGiaoVien.DataSource = dtGiaoVien;
            }

            dgvLopHoc.DataSource = null;
            dgvKyThi.DataSource = null;
        }

        private void LoadDVGLopHoc(int maGV)
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"SELECT L.MaL, L.TenLop
                               FROM LOPHOC L
                               WHERE L.MaGV=@MaGV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaGV", maGV);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dtLopHoc = new DataTable();
                da.Fill(dtLopHoc);
                dgvLopHoc.DataSource = dtLopHoc;
            }

            dgvKyThi.DataSource = null;
        }

        private void LoadDGVKyThi(int maL)
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"SELECT KT.MaKT, KT.TenKyThi
                               FROM LICHTHI LT
                               INNER JOIN KYTHI KT ON LT.MaKT = KT.MaKT
                               WHERE LT.MaL=@MaL";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaL", maL);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dtKyThi = new DataTable();
                da.Fill(dtKyThi);
                dgvKyThi.DataSource = dtKyThi;
            }
        }

        #endregion

        #region --- Events ---

        private void CboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadKhoaHoc();
        }

        private void CboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMonHoc();
        }

        private void CboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDGVGiaoVien();
        }

        private void DgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maGV = Convert.ToInt32(dgvGiaoVien.Rows[e.RowIndex].Cells["MaGV"].Value);
            LoadDVGLopHoc(maGV);
        }

        private void DgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maL = Convert.ToInt32(dgvLopHoc.Rows[e.RowIndex].Cells["MaL"].Value);
            LoadDGVKyThi(maL);
        }

        #endregion
    }
}
