using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Winform_KLCN.ChucNangAdmin
{
    public partial class chiaLop : UserControl
    {
        private DataTable dtHocVien;
        private DataTable dtHocVienHienCo;
        private int maLopHienTai = -1;
        
        public chiaLop()
        {

            InitializeComponent();
            LoadNamHoc();
            
        }

        private void LoadNamHoc()
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

                    cboNamHoc.DataSource = dt;
                    cboNamHoc.DisplayMember = "NamHoc";
                    cboNamHoc.ValueMember = "NamHoc";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load năm học: " + ex.Message);
            }
        }

        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedValue == null || cboNamHoc.SelectedValue.ToString() == "System.Data.DataRowView") return;
            LoadKhoaHocTheoNam(cboNamHoc.SelectedValue.ToString());
        }

        private void LoadKhoaHocTheoNam(string namHoc)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT MaK, TenKhoaHoc 
FROM KHOAHOC
WHERE NamHoc=@NamHoc AND TrangThai=N'Chưa hoàn thiện'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@NamHoc", namHoc);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboKhoa.DataSource = dt;
                    cboKhoa.DisplayMember = "TenKhoaHoc";
                    cboKhoa.ValueMember = "MaK";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load khóa học: " + ex.Message);
            }
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoa.SelectedValue == null || cboKhoa.SelectedValue.ToString() == "System.Data.DataRowView") return;
            LoadLopHocTheoKhoa(Convert.ToInt32(cboKhoa.SelectedValue));
        }

        private void LoadLopHocTheoKhoa(int maKhoa)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = "SELECT MaL, TenLop FROM LOPHOC WHERE MaK=@MaK";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaK", maKhoa);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboLopHoc.DataSource = dt;
                    cboLopHoc.DisplayMember = "TenLop";
                    cboLopHoc.ValueMember = "MaL";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load lớp học: " + ex.Message);
            }
        }

        private void cboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLopHoc.SelectedValue == null || cboLopHoc.SelectedValue.ToString() == "System.Data.DataRowView") return;
            maLopHienTai = Convert.ToInt32(cboLopHoc.SelectedValue);
            LoadHocVien();
            LoadHocVienHienCo();
        }

        private void LoadHocVien()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT MaHV, TenHV, GioiTinh, NgaySinh 
FROM HOCVIEN
WHERE MaHV NOT IN (SELECT MaHV FROM HOCVIEN_LOPHOC WHERE MaL=@MaL)";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaL", maLopHienTai);
                    dtHocVien = new DataTable();
                    da.Fill(dtHocVien);

                    dgvHocVien.Columns.Clear();
                    dgvHocVien.AutoGenerateColumns = false;

                    dgvHocVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaHV", DataPropertyName = "MaHV", Visible = false });
                    dgvHocVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenHV", DataPropertyName = "TenHV", HeaderText = "Học viên", Width = 150 });
                    dgvHocVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "GioiTinh", DataPropertyName = "GioiTinh", HeaderText = "Giới tính", Width = 80 });
                    dgvHocVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgaySinh", DataPropertyName = "NgaySinh", HeaderText = "Ngày sinh", Width = 100 });

                    DataGridViewButtonColumn btnThem = new DataGridViewButtonColumn();
                    btnThem.Name = "Them";
                    btnThem.HeaderText = "";
                    btnThem.Text = "+";
                    btnThem.UseColumnTextForButtonValue = true;
                    btnThem.Width = 40;
                    dgvHocVien.Columns.Add(btnThem);

                    dgvHocVien.DataSource = dtHocVien;
                    dgvHocVien.CellClick -= DgvHocVien_CellClick;
                    dgvHocVien.CellClick += DgvHocVien_CellClick;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load học viên: " + ex.Message);
            }
        }

        private void LoadHocVienHienCo()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT HV.MaHV, HV.TenHV, HV.GioiTinh, HV.NgaySinh
FROM HOCVIEN HV
JOIN HOCVIEN_LOPHOC HL ON HV.MaHV=HL.MaHV
WHERE HL.MaL=@MaL";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaL", maLopHienTai);
                    dtHocVienHienCo = new DataTable();
                    da.Fill(dtHocVienHienCo);

                    dgvHocVienHienCo.Columns.Clear();
                    dgvHocVienHienCo.AutoGenerateColumns = false;

                    dgvHocVienHienCo.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaHV", DataPropertyName = "MaHV", Visible = false });
                    dgvHocVienHienCo.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenHV", DataPropertyName = "TenHV", HeaderText = "Học viên", Width = 150 });
                    dgvHocVienHienCo.Columns.Add(new DataGridViewTextBoxColumn { Name = "GioiTinh", DataPropertyName = "GioiTinh", HeaderText = "Giới tính", Width = 80 });
                    dgvHocVienHienCo.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgaySinh", DataPropertyName = "NgaySinh", HeaderText = "Ngày sinh", Width = 100 });

                    DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
                    btnXoa.Name = "Xoa";
                    btnXoa.HeaderText = "";
                    btnXoa.Text = "Xóa";
                    btnXoa.UseColumnTextForButtonValue = true;
                    btnXoa.Width = 50;
                    dgvHocVienHienCo.Columns.Add(btnXoa);

                    dgvHocVienHienCo.DataSource = dtHocVienHienCo;
                    dgvHocVienHienCo.CellClick -= DgvHocVienHienCo_CellClick;
                    dgvHocVienHienCo.CellClick += DgvHocVienHienCo_CellClick;

                    lblSiSo.Text = dtHocVienHienCo.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load học viên hiện có: " + ex.Message);
            }
        }

        private void DgvHocVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvHocVien.Columns[e.ColumnIndex].Name != "Them") return;

            int maHV = Convert.ToInt32(dgvHocVien.Rows[e.RowIndex].Cells["MaHV"].Value);

            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "IF EXISTS(SELECT 1 FROM HOCVIEN_LOPHOC WHERE MaL=@MaL AND MaHV=@MaHV) " +
                        "RAISERROR('Học viên đã có trong lớp!',16,1) " +
                        "ELSE INSERT INTO HOCVIEN_LOPHOC(MaL,MaHV) VALUES(@MaL,@MaHV)", conn);
                    cmd.Parameters.AddWithValue("@MaL", maLopHienTai);
                    cmd.Parameters.AddWithValue("@MaHV", maHV);

                    cmd.ExecuteNonQuery();
                }

                LoadHocVien();
                LoadHocVienHienCo();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvHocVienHienCo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvHocVienHienCo.Columns[e.ColumnIndex].Name != "Xoa") return;

            int maHV = Convert.ToInt32(dgvHocVienHienCo.Rows[e.RowIndex].Cells["MaHV"].Value);

            if (MessageBox.Show("Xóa học viên khỏi lớp?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM HOCVIEN_LOPHOC WHERE MaL=@MaL AND MaHV=@MaHV", conn);
                    cmd.Parameters.AddWithValue("@MaL", maLopHienTai);
                    cmd.Parameters.AddWithValue("@MaHV", maHV);
                    cmd.ExecuteNonQuery();
                }

                LoadHocVien();
                LoadHocVienHienCo();
            }
        }
    }
}
