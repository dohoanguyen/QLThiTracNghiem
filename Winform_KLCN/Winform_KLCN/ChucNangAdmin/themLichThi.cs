using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Winform_KLCN.ChucNangAdmin
{
    public partial class themLichThi : Form
    {
        private readonly int _maKT;
        private readonly string _tenKT;

        public themLichThi(int maKT, string tenKT)
        {
            InitializeComponent();
            _maKT = maKT;
            _tenKT = tenKT;
            cboLop.SelectedIndexChanged += cboLop_SelectedIndexChanged;
            
            btnQuayLai.Click += btnQuayLai_Click;
            btnHoanThien.Click += btnHoanThien_Click;

        }

        private void themLichThi_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = "SELECT NgayBatDau, NgayKetThuc FROM KYTHI WHERE MaKT = @MaKT";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaKT", _maKT);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    dtpNgayThi.MinDate = Convert.ToDateTime(reader["NgayBatDau"]);
                    dtpNgayThi.MaxDate = Convert.ToDateTime(reader["NgayKetThuc"]);
                }
            }
            this.Text = $"Tạo Lịch Thi: {_tenKT}";
            dtpNgayThi.MinDate = DateTime.Today.AddYears(-1); // an toàn
            dtpNgayThi.MaxDate = DateTime.Today.AddYears(5);
            dtpGioBD.Format = DateTimePickerFormat.Time;
            dtpGioBD.ShowUpDown = true;
            dtpGioKT.Format = DateTimePickerFormat.Time;
            dtpGioKT.ShowUpDown = true;

            LoadLopTheoKyThi();
            LoadLichThi_HienThi(); // load sơ đồ hiện có (nếu đã có lịch)
        }

        // Load tất cả lớp thuộc Khóa học của kỳ thi
        private void LoadLopTheoKyThi()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT L.MaL, L.TenLop, L.MaM
FROM LOPHOC L
WHERE L.MaK = (SELECT MaK FROM KYTHI WHERE MaKT = @MaKT)
ORDER BY L.TenLop";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKT", _maKT);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboLop.DisplayMember = "TenLop";
                        cboLop.ValueMember = "MaL";
                        cboLop.DataSource = dt;
                        cboLop.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lớp: " + ex.Message);
            }
        }

        // Khi chọn lớp -> load các đề cùng môn của lớp
        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLop.SelectedValue == null || cboLop.SelectedValue is DataRowView) return;
            int maL = Convert.ToInt32(cboLop.SelectedValue);
            LoadDeTheoLop(maL);
        }

        private void LoadDeTheoLop(int maL)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    // lấy môn của lớp (MaM)
                    string sqlGetMaM = "SELECT MaM FROM LOPHOC WHERE MaL = @MaL";
                    int maM;
                    using (SqlCommand cmd0 = new SqlCommand(sqlGetMaM, conn))
                    {
                        cmd0.Parameters.AddWithValue("@MaL", maL);
                        object o = cmd0.ExecuteScalar();
                        if (o == null) return;
                        maM = Convert.ToInt32(o);
                    }

                    // load đề thuộc môn đó (chỉ đề hoạt động/khóa)
                    string sql = @"SELECT MaD, TenDe, ThoiGian FROM DETHI
                                   WHERE MaM = @MaM AND TrangThai IN (N'Hoạt động', N'Khóa')
                                   ORDER BY TenDe";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaM", maM);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboDe.DisplayMember = "TenDe";
                        cboDe.ValueMember = "MaD";
                        cboDe.DataSource = dt;
                        cboDe.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải đề: " + ex.Message);
            }
        }

        // Thêm 1 lịch thi vào DB (và render luồng)


        // Load lịch thi của kỳ này và render lên flowLayoutPanel (sơ đồ)
        // Load lịch thi của kỳ này và hiển thị lên DataGridView
        private void LoadLichThi_HienThi()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT LT.MaLT, LT.NgayThi, LT.GioBatDau, LT.GioKetThuc,
       M.TenMon, L.TenLop, D.TenDe, LT.TrangThai
FROM LICHTHI LT
JOIN LOPHOC L ON LT.MaL = L.MaL
JOIN DETHI D ON LT.MaD = D.MaD
JOIN MON M ON L.MaM = M.MaM
WHERE LT.MaKT = @MaKT
ORDER BY LT.NgayThi, LT.GioBatDau";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKT", _maKT);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvLichThi.DataSource = dt;
                    }
                }

                // cấu hình hiển thị dgv
                dgvLichThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLichThi.ReadOnly = true;
                dgvLichThi.AllowUserToAddRows = false;
                dgvLichThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (dgvLichThi.Columns.Count > 0)
                {
                    dgvLichThi.Columns["MaLT"].HeaderText = "Mã LT";
                    dgvLichThi.Columns["NgayThi"].HeaderText = "Ngày Thi";
                    dgvLichThi.Columns["GioBatDau"].HeaderText = "Giờ BĐ";
                    dgvLichThi.Columns["GioKetThuc"].HeaderText = "Giờ KT";
                    dgvLichThi.Columns["TenMon"].HeaderText = "Môn";
                    dgvLichThi.Columns["TenLop"].HeaderText = "Lớp";
                    dgvLichThi.Columns["TenDe"].HeaderText = "Đề";
                    dgvLichThi.Columns["TrangThai"].HeaderText = "Trạng Thái";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch thi: " + ex.Message);
            }
        }

        // Tạo 1 Panel nhỏ (card) mô tả lịch


        // btnQuayLai: đóng form (lịch đã được lưu khi thêm)
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            // không cập nhật trạng thái KYTHI, chỉ đóng
            this.Close();
        }

        // btnHoanThien: cập nhật trạng thái KYTHI theo thời gian thực rồi đóng
        private void btnHoanThien_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    string sqlUpdateTrangThai = @"
UPDATE KYTHI
SET TrangThai = CASE
    WHEN GETDATE() < NgayBatDau THEN N'Sắp diễn ra'
    WHEN GETDATE() BETWEEN NgayBatDau AND NgayKetThuc THEN N'Đang thi'
    WHEN GETDATE() > NgayKetThuc THEN N'Đã kết thúc'
    ELSE TrangThai
END
WHERE MaKT = @MaKT";
                    using (SqlCommand cmd = new SqlCommand(sqlUpdateTrangThai, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKT", _maKT);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã hoàn thiện kỳ thi và cập nhật trạng thái theo thời gian thực.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái kỳ thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            

            if (cboLop.SelectedValue == null || cboDe.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp và đề trước khi thêm lịch.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maL = Convert.ToInt32(cboLop.SelectedValue);
            int maD = Convert.ToInt32(cboDe.SelectedValue);
            DateTime ngayThi = dtpNgayThi.Value.Date;
            TimeSpan gioBD = dtpGioBD.Value.TimeOfDay;
            TimeSpan gioKT = dtpGioKT.Value.TimeOfDay;

            if (gioKT <= gioBD)
            {
                MessageBox.Show("Giờ kết thúc phải lớn hơn giờ bắt đầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    // ✅ Kiểm tra ngày thi có nằm trong khoảng ngày của kỳ thi
                    string sqlNgayKT = "SELECT NgayBatDau, NgayKetThuc FROM KYTHI WHERE MaKT = @MaKT";
                    DateTime ngayBD, ngayKT;
                    using (SqlCommand cmd = new SqlCommand(sqlNgayKT, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKT", _maKT);
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (!rd.Read())
                            {
                                MessageBox.Show("Không tìm thấy thông tin kỳ thi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            ngayBD = Convert.ToDateTime(rd["NgayBatDau"]);
                            ngayKT = Convert.ToDateTime(rd["NgayKetThuc"]);
                        }
                    }

                    if (ngayThi < ngayBD || ngayThi > ngayKT)
                    {
                        MessageBox.Show($"Ngày thi phải nằm trong khoảng từ {ngayBD:dd/MM/yyyy} đến {ngayKT:dd/MM/yyyy}.",
                            "Ngày thi không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra đề có cùng môn với lớp
                    string sqlCheck = @"SELECT L.MaM AS MaM_Lop, D.MaM AS MaM_De
                                FROM LOPHOC L
                                JOIN DETHI D ON D.MaD = @MaD
                                WHERE L.MaL = @MaL";
                    using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@MaL", maL);
                        cmdCheck.Parameters.AddWithValue("@MaD", maD);
                        using (SqlDataReader rd = cmdCheck.ExecuteReader())
                        {
                            if (!rd.Read())
                            {
                                MessageBox.Show("Không tìm thấy thông tin lớp/đề.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            int maM_lop = Convert.ToInt32(rd["MaM_Lop"]);
                            int maM_de = Convert.ToInt32(rd["MaM_De"]);
                            if (maM_lop != maM_de)
                            {
                                MessageBox.Show("Đề được chọn không thuộc môn của lớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // Kiểm tra trùng lịch (không cho chồng thời gian)
                    string sqlConflict = @"
                SELECT COUNT(*) FROM LICHTHI LT
                JOIN LOPHOC L ON LT.MaL = L.MaL
                JOIN DETHI D ON LT.MaD = D.MaD
                WHERE LT.NgayThi = @NgayThi
                  AND NOT ( @GioKT <= LT.GioBatDau OR @GioBD >= LT.GioKetThuc )
                  AND D.MaM <> (SELECT MaM FROM LOPHOC WHERE MaL = @MaL)";
                    using (SqlCommand cmdConflict = new SqlCommand(sqlConflict, conn))
                    {
                        cmdConflict.Parameters.AddWithValue("@NgayThi", ngayThi);
                        cmdConflict.Parameters.AddWithValue("@GioBD", gioBD);
                        cmdConflict.Parameters.AddWithValue("@GioKT", gioKT);
                        cmdConflict.Parameters.AddWithValue("@MaL", maL);

                        int conflictCount = Convert.ToInt32(cmdConflict.ExecuteScalar());
                        if (conflictCount > 0)
                        {
                            MessageBox.Show("Có lịch thi khác cùng ngày & chồng thời gian với môn khác. Vui lòng chọn thời gian khác.",
                                "Xung đột lịch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // ✅ Qua hết kiểm tra hợp lệ
                    MessageBox.Show("✅ Qua kiểm tra hợp lệ, đang thêm lịch...", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Thực hiện INSERT
                    string sqlInsert = @"
                INSERT INTO LICHTHI (MaKT, MaL, MaD, NgayThi, GioBatDau, GioKetThuc, TrangThai)
                VALUES (@MaKT, @MaL, @MaD, @NgayThi, @GioBD, @GioKT, N'Chưa thi')";
                    using (SqlCommand cmdIns = new SqlCommand(sqlInsert, conn))
                    {
                        cmdIns.Parameters.AddWithValue("@MaKT", _maKT);
                        cmdIns.Parameters.AddWithValue("@MaL", maL);
                        cmdIns.Parameters.AddWithValue("@MaD", maD);
                        cmdIns.Parameters.AddWithValue("@NgayThi", ngayThi);
                        cmdIns.Parameters.AddWithValue("@GioBD", gioBD);
                        cmdIns.Parameters.AddWithValue("@GioKT", gioKT);
                        cmdIns.ExecuteNonQuery();
                    }
                } // end using conn

                // Sau khi thêm thành công -> load lại danh sách
                LoadLichThi_HienThi();

                MessageBox.Show("🎉 Đã thêm lịch thi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm lịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    

}

