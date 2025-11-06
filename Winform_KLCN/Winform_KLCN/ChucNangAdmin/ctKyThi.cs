using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Winform_KLCN.ChucNangAdmin
{
    public partial class ctKyThi : Form
    {
        private readonly int _maKT;
        private readonly string _tenKT;

        public ctKyThi(int maKT, string tenKT)
        {
            InitializeComponent();
            _maKT = maKT;
            _tenKT = tenKT;
        }

        private void ctKyThi_Load(object sender, EventArgs e)
        {
            // tiêu đề form
            this.Text = $"Chi Tiết Kỳ Thi: {_tenKT}";
            LoadLichThi();
        }

        private void LoadLichThi()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    string sql = @"
SELECT 
    LT.MaLT AS [Mã Lịch Thi],
    L.TenLop AS [Lớp],
    M.TenMon AS [Môn Thi],
    D.TenDe AS [Tên Đề],
    CONVERT(varchar, LT.NgayThi, 103) AS [Ngày Thi],
    CONVERT(varchar(5), LT.GioBatDau, 108) AS [Giờ Bắt Đầu],
    CONVERT(varchar(5), LT.GioKetThuc, 108) AS [Giờ Kết Thúc],
    LT.TrangThai AS [Trạng Thái]
FROM LICHTHI LT
INNER JOIN LOPHOC L ON LT.MaL = L.MaL
INNER JOIN MON M ON L.MaM = M.MaM
INNER JOIN DETHI D ON LT.MaD = D.MaD
WHERE LT.MaKT = @MaKT
ORDER BY LT.NgayThi, LT.GioBatDau, LT.GioKetThuc;";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKT", _maKT);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvLichThi.DataSource = dt;

                        // Format DataGridView cho gọn
                        dgvLichThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvLichThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvLichThi.ReadOnly = true;
                        dgvLichThi.RowHeadersVisible = false;
                        dgvLichThi.ColumnHeadersHeight = 40;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch thi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
