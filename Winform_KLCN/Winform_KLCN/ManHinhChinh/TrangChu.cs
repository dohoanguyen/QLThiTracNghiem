using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Winform_KLCN.GiaoDien;

namespace Winform_KLCN.ManHinhChinh
{
    public partial class TrangChu : UserControl
    {
        private string _maGV;

        public TrangChu()
        {
            InitializeComponent();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            // 1. Lấy Mã Giáo Viên từ UserSession
            _maGV = LayMaGVTuMaTK(UserSession.MaTK);

            HienThiTenGV();

            if (string.IsNullOrEmpty(_maGV))
            {
                MessageBox.Show("Không tìm thấy thông tin giáo viên!");
                return;
            }

            // 2. Load dữ liệu vào 2 ComboBox
            LoadComboBoxData();

            // 3. Hiển thị thống kê ban đầu
            LoadThongKe();
        }

        private void HienThiTenGV()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    // Lấy tên giáo viên dựa vào Mã Tài Khoản đang đăng nhập
                    string sql = "SELECT TenGV FROM GIAOVIEN WHERE MaTK = @MaTK";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTK", UserSession.MaTK);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            // Gán tên vào Label bạn đã đặt tên ở Bước 1
                            lblTenGV.Text = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy tên giáo viên: " + ex.Message);
            }
        }

        // Hàm lấy Mã GV từ bảng GIAOVIEN dựa trên MaTK
        private string LayMaGVTuMaTK(string maTK)
        {
            string maGV = "";
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = "SELECT MaGV FROM GIAOVIEN WHERE MaTK = @MaTK";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Lưu ý: MaTK trong DB của bạn là kiểu INT, cần đảm bảo UserSession.MaTK parse được sang int hoặc truyền đúng kiểu
                        cmd.Parameters.AddWithValue("@MaTK", maTK);
                        object result = cmd.ExecuteScalar();
                        if (result != null) maGV = result.ToString();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lấy MaGV: " + ex.Message); }
            return maGV;
        }

        private void LoadComboBoxData()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    // --- 1. LOAD NĂM HỌC (Lấy từ bảng KHOAHOC join LOPHOC) ---
                    // Chỉ lấy những năm học mà giáo viên này có lớp dạy
                    string sqlNam = @"SELECT DISTINCT k.NamHoc 
                                      FROM KHOAHOC k 
                                      JOIN LOPHOC l ON k.MaK = l.MaK 
                                      WHERE l.MaGV = @MaGV";

                    SqlDataAdapter daNam = new SqlDataAdapter(sqlNam, conn);
                    daNam.SelectCommand.Parameters.AddWithValue("@MaGV", _maGV);
                    DataTable dtNam = new DataTable();
                    daNam.Fill(dtNam);

                    // Thêm dòng 'Tất cả'
                    DataRow rowNam = dtNam.NewRow();
                    rowNam["NamHoc"] = "Tất cả";
                    dtNam.Rows.InsertAt(rowNam, 0);

                    cboNamHoc.DataSource = dtNam;
                    cboNamHoc.DisplayMember = "NamHoc";
                    cboNamHoc.ValueMember = "NamHoc";
                    cboNamHoc.SelectedIndex = 0;

                    // --- 2. LOAD KHÓA HỌC (Lấy từ bảng KHOAHOC join LOPHOC) ---
                    string sqlKhoa = @"SELECT DISTINCT k.MaK, k.TenKhoaHoc 
                                       FROM KHOAHOC k 
                                       JOIN LOPHOC l ON k.MaK = l.MaK 
                                       WHERE l.MaGV = @MaGV";

                    SqlDataAdapter daKhoa = new SqlDataAdapter(sqlKhoa, conn);
                    daKhoa.SelectCommand.Parameters.AddWithValue("@MaGV", _maGV);
                    DataTable dtKhoa = new DataTable();
                    daKhoa.Fill(dtKhoa);

                    // Thêm dòng 'Tất cả' (MaK = -1 hoặc 0 để đánh dấu)
                    DataRow rowKhoa = dtKhoa.NewRow();
                    rowKhoa["MaK"] = -1;
                    rowKhoa["TenKhoaHoc"] = "Tất cả";
                    dtKhoa.Rows.InsertAt(rowKhoa, 0);

                    cboKhoaHoc.DataSource = dtKhoa;
                    cboKhoaHoc.DisplayMember = "TenKhoaHoc";
                    cboKhoaHoc.ValueMember = "MaK"; // Dùng Mã khóa để lọc cho chính xác
                    cboKhoaHoc.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu lọc: " + ex.Message);
            }
        }

        private void LoadThongKe()
        {
            if (string.IsNullOrEmpty(_maGV)) return;

            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    // Tạo câu điều kiện lọc động
                    string whereClause = " WHERE l.MaGV = @MaGV ";

                    // Nếu không chọn "Tất cả" ở Năm học
                    if (cboNamHoc.SelectedIndex > 0)
                    {
                        whereClause += " AND k.NamHoc = @NamHoc ";
                    }

                    // Nếu không chọn "Tất cả" ở Khóa học (ValueMember là MaK - kiểu int)
                    int maKSelected = -1;
                    if (cboKhoaHoc.SelectedIndex > 0 && int.TryParse(cboKhoaHoc.SelectedValue.ToString(), out maKSelected))
                    {
                        whereClause += " AND k.MaK = @MaK ";
                    }



                    // --- 1. ĐẾM SỐ LỚP HỌC ---
                    // Phải JOIN với KHOAHOC để lọc theo NamHoc và MaK
                    string sqlCountLop = $@"SELECT COUNT(l.MaL) 
                                            FROM LOPHOC l 
                                            JOIN KHOAHOC k ON l.MaK = k.MaK 
                                            {whereClause}";

                    using (SqlCommand cmd = new SqlCommand(sqlCountLop, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaGV", _maGV);

                        if (cboNamHoc.SelectedIndex > 0)
                            cmd.Parameters.AddWithValue("@NamHoc", cboNamHoc.SelectedValue.ToString());

                        if (maKSelected != -1)
                            cmd.Parameters.AddWithValue("@MaK", maKSelected);

                        int soLop = (int)cmd.ExecuteScalar();
                        lblSoLuongLop.Text = soLop.ToString();
                    }

                    // --- 2. ĐẾM SỐ HỌC VIÊN ---
                    // Phải JOIN qua 3 bảng: HOCVIEN_LOPHOC -> LOPHOC -> KHOAHOC
                    string sqlCountHV = $@"SELECT COUNT(hl.MaHV) 
                                           FROM HOCVIEN_LOPHOC hl 
                                           JOIN LOPHOC l ON hl.MaL = l.MaL 
                                           JOIN KHOAHOC k ON l.MaK = k.MaK 
                                           {whereClause}";

                    using (SqlCommand cmd = new SqlCommand(sqlCountHV, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaGV", _maGV);

                        if (cboNamHoc.SelectedIndex > 0)
                            cmd.Parameters.AddWithValue("@NamHoc", cboNamHoc.SelectedValue.ToString());

                        if (maKSelected != -1)
                            cmd.Parameters.AddWithValue("@MaK", maKSelected);

                        int soHV = (int)cmd.ExecuteScalar();
                        lblSoLuongHV.Text = soHV.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message); // Debug
            }
        }

        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThongKe();
        }
    }
}