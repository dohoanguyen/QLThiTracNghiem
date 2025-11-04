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
    public partial class CauHoi : UserControl
    {
        private DataTable dtCauHoi;
        
        public CauHoi()
        {
            InitializeComponent();
            CauHinhDataGridView();
            LoadMonHoc();
            LoadCauHoi();
            lbxMonHoc.SelectedIndexChanged += lbxMonHoc_SelectedIndexChanged;
     
        }

        private void CauHoi_Load(object sender, EventArgs e)
        {

        }
        private void CauHinhDataGridView()
        {
            dgvCauHoi.AutoGenerateColumns = false;
            dgvCauHoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCauHoi.MultiSelect = false;
            dgvCauHoi.AllowUserToAddRows = false;
            dgvCauHoi.ReadOnly = true;

            // ✅ BUỘC HIỆN HEADER + ẨN ROW HEADER
            dgvCauHoi.ColumnHeadersVisible = true;
            dgvCauHoi.RowHeadersVisible = false;
            dgvCauHoi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvCauHoi.ColumnHeadersHeight = 40; // ✅ TĂNG CHiều CAO HEADER

            // ✅ QUAN TRỌNG: KHÔNG SET AutoSizeColumnsMode
            dgvCauHoi.Columns.Clear();

            // ✅ THÊM CỘT VỚI WIDTH CỐ ĐỊNH
            AddColumn("MaM", "Mã môn", 70);
            AddColumn("MaCH", "Mã CH", 70);
            AddColumn("NoiDung", "Nội dung", 350);
            AddColumn("DoKho", "Độ khó", 70);
            AddColumn("DapAnA", "Đáp án A", 100);
            AddColumn("DapAnB", "Đáp án B", 100);
            AddColumn("DapAnC", "Đáp án C", 100);
            AddColumn("DapAnD", "Đáp án D", 100);
            AddColumn("DapAnDung", "Đáp án đúng", 90);
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
            dgvCauHoi.Columns.Add(col);
        }



        private void LoadMonHoc()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    // Chỉ lấy các môn mà giáo viên đang dạy
                    string sql = @"
                SELECT M.MaM, M.TenMon
                FROM MON M
                INNER JOIN GIAOVIEN_MON GM ON M.MaM = GM.MaM
                WHERE GM.MaGV = @MaGV";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaGV", UserSession.MaGV);

                    DataTable dtMonHoc = new DataTable();
                    da.Fill(dtMonHoc);

                    // Thêm dòng “TẤT CẢ” (đại diện cho tất cả môn GV đó dạy)
                    DataRow rowTatCa = dtMonHoc.NewRow();
                    rowTatCa["MaM"] = 0;
                    rowTatCa["TenMon"] = "TẤT CẢ";
                    dtMonHoc.Rows.InsertAt(rowTatCa, 0);

                    // Gán vào ListBox
                    lbxMonHoc.DisplayMember = "TenMon";
                    lbxMonHoc.ValueMember = "MaM";
                    lbxMonHoc.DataSource = dtMonHoc;

                    lbxMonHoc.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách môn học: " + ex.Message);
            }
        }


        private void LoadCauHoi()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = "SELECT * FROM NGANHANGCAUHOI";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    dtCauHoi = new DataTable();
                    da.Fill(dtCauHoi);

                    dgvCauHoi.DataSource = dtCauHoi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách câu hỏi: " + ex.Message);
            }

        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (lbxMonHoc.SelectedValue == null || dtCauHoi == null)
            {
                MessageBox.Show("Vui lòng chọn môn học để tìm kiếm!");
                return;
            }

            try
            {
                int maMon;
                if (!int.TryParse(lbxMonHoc.SelectedValue.ToString(), out maMon))
                {
                    MessageBox.Show("Mã môn không hợp lệ!");
                    return;
                }

                DataView dv = dtCauHoi.DefaultView;
                dv.RowFilter = $"MaM = {maMon}";

                dgvCauHoi.DataSource = dv;

                int soLuong = dv.Count;
                MessageBox.Show($"Tìm thấy {soLuong} câu hỏi thuộc môn '{lbxMonHoc.Text}'");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            if (dtCauHoi != null)
            {
                dgvCauHoi.DataSource = dtCauHoi;
                
                lbxMonHoc.ClearSelected();
            }
        }

        private void lbxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtCauHoi == null) return;

            try
            {
                int maMon;

                if (int.TryParse(lbxMonHoc.SelectedValue?.ToString(), out maMon))
                {
                    if (maMon == 0) 
                    {
                        dgvCauHoi.DataSource = dtCauHoi;
                        lblKetQua.Text = $"Tất cả câu hỏi ({dtCauHoi.Rows.Count} câu)";
                        return;
                    }

                    DataView dv = dtCauHoi.DefaultView;
                    dv.RowFilter = $"MaM = {maMon}";
                    dgvCauHoi.DataSource = dv;
                    lblKetQua.Text = $"Môn: {lbxMonHoc.Text} ({dv.Count} câu hỏi)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemCauHoi form = new ThemCauHoi();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadCauHoi(); // Hàm reload lại danh sách câu hỏi
            }
        }

        private void dgvCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
