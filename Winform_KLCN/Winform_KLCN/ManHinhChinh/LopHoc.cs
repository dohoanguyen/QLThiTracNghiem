using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform_KLCN.ManHinhChinh;

namespace Winform_KLCN.ManHinhChinh
{
    public partial class LopHoc : UserControl
    {
        private DataTable dtLopHoc;
        public LopHoc()
        {
            InitializeComponent();
            CauHinhDataGridView();
            LoadLopHoc();
        }

        private void LopHoc_Load(object sender, EventArgs e)
        {

        }
        private void CauHinhDataGridView()
        {
            dgvLopHoc.AutoGenerateColumns = false;
            dgvLopHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLopHoc.MultiSelect = false;
            dgvLopHoc.AllowUserToAddRows = false;
            dgvLopHoc.ReadOnly = true;

            dgvLopHoc.ColumnHeadersVisible = true;
            dgvLopHoc.RowHeadersVisible = false;
            dgvLopHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvLopHoc.ColumnHeadersHeight = 40;
            dgvLopHoc.CellFormatting += DgvLopHoc_CellFormatting;

            dgvLopHoc.Columns.Clear();

            AddColumn("MaL", "Mã lớp", 70);
            AddColumn("TenLop", "Tên lớp", 150);
            AddColumn("TenKhoaHoc", "Khóa học", 120);
            AddColumn("TenMon", "Môn học", 100);
            AddColumn("TenGV", "Giáo viên", 150);
            AddColumn("SoHV", "Số HV", 80);
            AddColumn("TrangThai", "Trạng thái", 120);
        }
        private void AddColumn(string dataProp, string header, int width)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = dataProp,
                HeaderText = header,
                Width = width,
                Visible = true,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            dgvLopHoc.Columns.Add(col);
        }
        private void LoadLopHoc()
        {
            int maGV = UserSession.MaGV;
            if (maGV == 0)
            {
                MessageBox.Show("Không xác định được giáo viên.");
                return;
            }

            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    // Đã thêm kh.TrangThai vào SELECT và GROUP BY
                    string sql = @"
                SELECT 
                    lh.MaL,
                    lh.TenLop,
                    kh.TenKhoaHoc,
                    m.TenMon,
                    gv.TenGV,
                    kh.TrangThai,  -- <--- THÊM Ở ĐÂY
                    ISNULL(COUNT(hl.MaHV), 0) AS SoHV
                FROM LOPHOC lh
                JOIN KHOAHOC kh ON lh.MaK = kh.MaK
                JOIN MON m ON lh.MaM = m.MaM
                JOIN GIAOVIEN gv ON lh.MaGV = gv.MaGV
                LEFT JOIN HOCVIEN_LOPHOC hl ON lh.MaL = hl.MaL
                WHERE lh.MaGV = @MaGV
                GROUP BY lh.MaL, lh.TenLop, kh.TenKhoaHoc, m.TenMon, gv.TenGV, kh.TrangThai -- <--- VÀ THÊM Ở ĐÂY
                ORDER BY lh.TenLop";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaGV", maGV);

                    dtLopHoc = new DataTable();
                    da.Fill(dtLopHoc);

                    dgvLopHoc.DataSource = dtLopHoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách lớp: " + ex.Message);
            }
        }
        private void DgvLopHoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu là cột Trạng thái
            if (dgvLopHoc.Columns[e.ColumnIndex].DataPropertyName == "TrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status.Contains("Đang học"))
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else if (status.Contains("kết thúc"))
                {
                    e.CellStyle.ForeColor = Color.Gray;
                }
                else if (status.Contains("Chưa"))
                {
                    e.CellStyle.ForeColor = Color.OrangeRed;
                }
            }
        }
    }
}
    