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

namespace Winform_KLCN.ManHinhChinh
{
    public partial class HocVien : UserControl
    {
        private DataTable dtHocVien;
        public HocVien()
        {
            InitializeComponent();
            CauHinhDataGridView();
            LoadHocVien();
        }

        private void HocVien_Load(object sender, EventArgs e)
        {

        }
        private void CauHinhDataGridView()
        {
            dgvHocVien.AutoGenerateColumns = false;
            dgvHocVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHocVien.MultiSelect = false;
            dgvHocVien.AllowUserToAddRows = false;
            dgvHocVien.ReadOnly = true;

            dgvHocVien.ColumnHeadersVisible = true;
            dgvHocVien.RowHeadersVisible = false;
            dgvHocVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvHocVien.ColumnHeadersHeight = 40;

            dgvHocVien.Columns.Clear();

            AddColumn("MaHV", "Mã HV", 70);
            AddColumn("TenHV", "Họ tên", 200);
            AddColumn("GioiTinh", "Giới tính", 80);
            AddColumn("NgaySinh", "Ngày sinh", 100);
            AddColumn("DiaChi", "Địa chỉ", 200);
            AddColumn("TenLop", "Lớp học", 150);
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
            dgvHocVien.Columns.Add(col);
        }

        private void LoadHocVien()
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
                    string sql = @"
                        SELECT DISTINCT
                            hv.MaHV,
                            hv.TenHV,
                            hv.GioiTinh,
                            hv.NgaySinh,
                            hv.DiaChi,
                            lh.TenLop
                        FROM HOCVIEN hv
                        JOIN HOCVIEN_LOPHOC hl ON hv.MaHV = hl.MaHV
                        JOIN LOPHOC lh ON hl.MaL = lh.MaL
                        WHERE lh.MaGV = @MaGV
                        ORDER BY hv.TenHV, lh.TenLop";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaGV", maGV);

                    dtHocVien = new DataTable();
                    da.Fill(dtHocVien);

                    dgvHocVien.DataSource = dtHocVien;

                    //lblKetQua.Text = $"Tổng {dtHocVien.Rows.Count} học viên";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách học viên: " + ex.Message);
            }
        }
    }
}
