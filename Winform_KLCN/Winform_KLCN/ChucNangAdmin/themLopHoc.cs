using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Winform_KLCN.ChucNangAdmin
{
    public partial class themLopHoc : Form
    {
        private int maKhoa;
        private DataTable dtLopHoc;

        private bool isEditing = false; // đang ở chế độ sửa

        public themLopHoc(int maKhoa)
        {
            InitializeComponent();
            this.maKhoa = maKhoa;
        }

        private void themLopHoc_Load(object sender, EventArgs e)
        {
            LoadComboMon();
            CauHinhDataGridView();
            LoadLopHocTheoKhoa();

            btnSua.Enabled = false;
            btnLuu.Enabled = false;

            dgvLopHoc.CellClick += dgvLopHoc_CellClick;
        }

        private void LoadComboMon()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = "SELECT MaM, TenMon FROM MON ORDER BY TenMon";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboMon.DataSource = dt;
                    cboMon.DisplayMember = "TenMon";
                    cboMon.ValueMember = "MaM";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách môn: " + ex.Message);
            }
        }

        private void CauHinhDataGridView()
        {
            dgvLopHoc.Columns.Clear();
            dgvLopHoc.AutoGenerateColumns = false;
            dgvLopHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLopHoc.ReadOnly = true;
            dgvLopHoc.RowHeadersVisible = false;

            dgvLopHoc.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaL",
                DataPropertyName = "MaL",
                Visible = false
            });

            dgvLopHoc.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenLop",
                DataPropertyName = "TenLop",
                HeaderText = "Tên lớp",
                Width = 150
            });

            dgvLopHoc.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenMon",
                DataPropertyName = "TenMon",
                HeaderText = "Môn học",
                Width = 130
            });

            // COMBOBOX GIÁO VIÊN
            DataGridViewComboBoxColumn gvCB = new DataGridViewComboBoxColumn();
            gvCB.Name = "GVCN";
            gvCB.HeaderText = "Giáo viên CN";
            gvCB.DataPropertyName = "MaGV"; // sẽ load theo ID
            gvCB.DisplayMember = "TenGV";
            gvCB.ValueMember = "MaGV";
            gvCB.Width = 150;
            gvCB.FlatStyle = FlatStyle.Popup;
            dgvLopHoc.Columns.Add(gvCB);

            dgvLopHoc.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SiSo",
                DataPropertyName = "SiSo",
                HeaderText = "Sĩ số",
                Width = 60
            });

            // NÚT XÓA
            DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
            btnXoa.Name = "Xoa";
            btnXoa.HeaderText = "";
            btnXoa.Text = "Xóa";
            btnXoa.UseColumnTextForButtonValue = true;
            btnXoa.Width = 60;
            dgvLopHoc.Columns.Add(btnXoa);

            // NÚT CHI TIẾT
            DataGridViewButtonColumn btnChiTiet = new DataGridViewButtonColumn();
            btnChiTiet.Name = "ChiTiet";
            btnChiTiet.HeaderText = "";
            btnChiTiet.Text = "Chi Tiết";
            btnChiTiet.UseColumnTextForButtonValue = true;
            btnChiTiet.Width = 80;
            dgvLopHoc.Columns.Add(btnChiTiet);

        }

        private void LoadGiaoVienCombo()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = "SELECT MaGV, TenGV FROM GIAOVIEN ORDER BY TenGV";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                var cbb = dgvLopHoc.Columns["GVCN"] as DataGridViewComboBoxColumn;
                cbb.DataSource = dt;
            }
        }


        private void LoadLopHocTheoKhoa()
        {
            try
            {
                LoadGiaoVienCombo();

                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT L.MaL, L.TenLop, 
       (SELECT COUNT(*) FROM HOCVIEN_LOPHOC HL WHERE HL.MaL = L.MaL) AS SiSo,
       M.TenMon, L.MaGV
FROM LOPHOC L
JOIN MON M ON L.MaM = M.MaM
WHERE L.MaK = @MaK";


                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaK", maKhoa);
                    dtLopHoc = new DataTable();
                    da.Fill(dtLopHoc);

                    dgvLopHoc.DataSource = dtLopHoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lớp học: " + ex.Message);
            }
        }

        // KHI CLICK HÀNG
        private void dgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            btnSua.Enabled = true;
            btnLuu.Enabled = false;

            // XỬ LÝ XÓA
            if (dgvLopHoc.Columns[e.ColumnIndex].Name == "Xoa")
            {
                int maL = Convert.ToInt32(dgvLopHoc.Rows[e.RowIndex].Cells["MaL"].Value);

                if (MessageBox.Show("Xóa lớp này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection conn = KetNoi.TaoKetNoi())
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM LOPHOC WHERE MaL = @MaL", conn);
                        cmd.Parameters.AddWithValue("@MaL", maL);
                        cmd.ExecuteNonQuery();
                    }
                    LoadLopHocTheoKhoa();
                }
               

            }
            if (dgvLopHoc.Columns[e.ColumnIndex].Name == "ChiTiet")
            {
                int maL = Convert.ToInt32(dgvLopHoc.Rows[e.RowIndex].Cells["MaL"].Value);
                LoadHocVienChiTiet(maL);
            }

        }
        private void LoadHocVienChiTiet(int maL)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT HV.MaHV, HV.TenHV, HV.GioiTinh, HV.NgaySinh, HV.Email, HV.SDT
FROM HOCVIEN HV
JOIN HOCVIEN_LOPHOC HL ON HV.MaHV = HL.MaHV
WHERE HL.MaL = @MaL";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaL", maL);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvChiTiet.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách học viên: " + ex.Message);
            }
        }


        // BẬT CHẾ ĐỘ SỬA
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLopHoc.SelectedRows.Count == 0) return;

            dgvLopHoc.ReadOnly = false;

            // Không cho sửa tên lớp / môn / sĩ số
            dgvLopHoc.Columns["TenLop"].ReadOnly = true;
            dgvLopHoc.Columns["TenMon"].ReadOnly = true;
            dgvLopHoc.Columns["SiSo"].ReadOnly = true;
            dgvLopHoc.Columns["Xoa"].ReadOnly = true;

            btnSua.Enabled = false;
            btnLuu.Enabled = true;

            isEditing = true;
        }

        // LƯU SỬA
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!isEditing) return;

            foreach (DataGridViewRow row in dgvLopHoc.Rows)
            {
                if (row.IsNewRow) continue;

                int maL = Convert.ToInt32(row.Cells["MaL"].Value);
                int maGV = Convert.ToInt32(row.Cells["GVCN"].Value);

                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE LOPHOC SET MaGV = @MaGV WHERE MaL = @MaL",
                        conn
                    );
                    cmd.Parameters.AddWithValue("@MaL", maL);
                    cmd.Parameters.AddWithValue("@MaGV", maGV);
                    cmd.ExecuteNonQuery();
                }
                btnLuu.Enabled=false;
            }

            MessageBox.Show("Lưu thay đổi thành công!");

            dgvLopHoc.ReadOnly = true;
            isEditing = false;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            LoadLopHocTheoKhoa();
        }

        // NÚT THÊM (GIỮ NGUYÊN CODE CỦA BẠN)
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenLop = txtTenLop.Text.Trim();
            if (string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!");
                return;
            }

            if (cboMon.SelectedValue == null || cboGVCN.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn môn và giáo viên!");
                return;
            }

            int maM = Convert.ToInt32(cboMon.SelectedValue);
            int maGV = Convert.ToInt32(cboGVCN.SelectedValue);

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"
INSERT INTO LOPHOC (MaK, MaM, TenLop, MaGV, SiSo)
VALUES (@MaK, @MaM, @TenLop, @MaGV, 0)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaK", maKhoa);
                cmd.Parameters.AddWithValue("@MaM", maM);
                cmd.Parameters.AddWithValue("@TenLop", tenLop);
                cmd.Parameters.AddWithValue("@MaGV", maGV);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Thêm lớp thành công!");
            txtTenLop.Clear();
            LoadLopHocTheoKhoa();
        }

        private void cboMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMon.SelectedValue == null || cboMon.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            int maMon = Convert.ToInt32(cboMon.SelectedValue);
            LoadComboGiaoVienTheoMon(maMon);
        }
        private void LoadComboGiaoVienTheoMon(int maMon)
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();

                string sql = @"
SELECT GV.MaGV, GV.TenGV
FROM GIAOVIEN GV
JOIN GIAOVIEN_MON GM ON GV.MaGV = GM.MaGV
WHERE GM.MaM = @MaM";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaM", maMon);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboGVCN.DataSource = dt;
                cboGVCN.DisplayMember = "TenGV";
                cboGVCN.ValueMember = "MaGV";
            }
        }

        private void dgvLopHoc_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!isEditing) return;

            // Chỉ xử lý cột GVCN
            if (dgvLopHoc.CurrentCell.ColumnIndex == dgvLopHoc.Columns["GVCN"].Index)
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.DropDownStyle = ComboBoxStyle.DropDownList;

                    // ----- Lấy mã môn của lớp đó -----
                    string tenMon = dgvLopHoc.CurrentRow.Cells["TenMon"].Value.ToString();
                    int maMon = LayMaMonTheoTen(tenMon);

                    // ----- Lấy danh sách giáo viên dạy môn -----
                    DataTable dtGV = LayGVTheoMon(maMon);

                    // Gán lại datasource cho combobox trong DGV
                    cb.DataSource = dtGV;
                    cb.DisplayMember = "TenGV";
                    cb.ValueMember = "MaGV";
                }
            }
        }
        private int LayMaMonTheoTen(string tenMon)
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT MaM FROM MON WHERE TenMon = @TenMon",
                    conn
                );
                cmd.Parameters.AddWithValue("@TenMon", tenMon);

                object rs = cmd.ExecuteScalar();
                return rs != null ? Convert.ToInt32(rs) : -1;
            }
        }
        private DataTable LayGVTheoMon(int maMon)
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();

                string sql = @"
            SELECT GV.MaGV, GV.TenGV
            FROM GIAOVIEN GV
            JOIN GIAOVIEN_MON GM ON GV.MaGV = GM.MaGV
            WHERE GM.MaM = @MaM";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaM", maMon);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        private void btnHoanThien_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
        "Bạn có chắc chắn muốn hoàn thiện khóa học này?\nSau khi hoàn thiện, trạng thái sẽ chuyển sang 'Chưa bắt đầu'.",
        "Xác nhận",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = KetNoi.TaoKetNoi())
                    {
                        conn.Open();
                        string sql = "UPDATE KHOAHOC SET TrangThai = N'Chưa bắt đầu' WHERE MaK = @MaK";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@MaK", maKhoa);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Hoàn thiện khóa học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Optionally: đóng form hoặc reload DataGridView
                    this.Close(); // nếu muốn tự đóng form
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hoàn thiện khóa học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
