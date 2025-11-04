using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Winform_KLCN.ManHinhChinh
{
    public partial class ThemCauHoi : Form
    {
        private DataTable dtCauHoi = new DataTable();

        public ThemCauHoi()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private DataTable LoadMon()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = "SELECT MaM, TenMon FROM MON";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        private DataTable LoadDoKho()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = "SELECT MaDK, TenDoKho FROM DOKHO";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        private void ThemCauHoi_Load(object sender, EventArgs e)
        {
            // Tạo cấu trúc DataTable
            dtCauHoi.Columns.Add("MaM", typeof(int));
            dtCauHoi.Columns.Add("MaDK", typeof(int));
            dtCauHoi.Columns.Add("NoiDung", typeof(string));
            dtCauHoi.Columns.Add("DapAnA", typeof(string));
            dtCauHoi.Columns.Add("DapAnB", typeof(string));
            dtCauHoi.Columns.Add("DapAnC", typeof(string));
            dtCauHoi.Columns.Add("DapAnD", typeof(string));
            dtCauHoi.Columns.Add("DapAnDung", typeof(string));

            // Load dữ liệu từ DB trực tiếp
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                string sql = @"SELECT MaM, MaDK, NoiDung, DapAnA, DapAnB, DapAnC, DapAnD, DapAnDung FROM NGANHANGCAUHOI";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dtCauHoi.Load(reader);
                }
            }

            // Cấu hình DataGridView
            dgvCauHoi.DataSource = dtCauHoi;
            dgvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCauHoi.AllowUserToAddRows = false;
            dgvCauHoi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCauHoi.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvCauHoi.EnableHeadersVisualStyles = false;
            dgvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCauHoi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCauHoi.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Gán tên cột
            dgvCauHoi.Columns["MaM"].HeaderText = "Môn học";
            dgvCauHoi.Columns["MaDK"].HeaderText = "Độ khó";
            dgvCauHoi.Columns["NoiDung"].HeaderText = "Nội dung câu hỏi";
            dgvCauHoi.Columns["DapAnA"].HeaderText = "Đáp án A";
            dgvCauHoi.Columns["DapAnB"].HeaderText = "Đáp án B";
            dgvCauHoi.Columns["DapAnC"].HeaderText = "Đáp án C";
            dgvCauHoi.Columns["DapAnD"].HeaderText = "Đáp án D";
            dgvCauHoi.Columns["DapAnDung"].HeaderText = "Đáp án đúng";

            // Gắn ComboBox cho cột Môn học
            DataGridViewComboBoxColumn colMon = new DataGridViewComboBoxColumn
            {
                HeaderText = "Môn học",
                DataPropertyName = "MaM",
                DataSource = LoadMon(),
                DisplayMember = "TenMon",
                ValueMember = "MaM",
                AutoComplete = true
            };

            // Gắn ComboBox cho cột Độ khó
            DataGridViewComboBoxColumn colDoKho = new DataGridViewComboBoxColumn
            {
                HeaderText = "Độ khó",
                DataPropertyName = "MaDK",
                DataSource = LoadDoKho(),
                DisplayMember = "TenDoKho",
                ValueMember = "MaDK",
                AutoComplete = true
            };

            dgvCauHoi.Columns.Remove("MaM");
            dgvCauHoi.Columns.Remove("MaDK");
            dgvCauHoi.Columns.Insert(0, colMon);
            dgvCauHoi.Columns.Insert(1, colDoKho);
        }

        private void LoadExcelToGrid(string filePath)
        {
            dtCauHoi.Rows.Clear();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                var rows = worksheet.RangeUsed().RowsUsed();

                HashSet<string> seenNoiDung = new HashSet<string>();
                List<string> duplicated = new List<string>();

                foreach (var row in rows.Skip(1))
                {
                    string noiDung = row.Cell(3).GetValue<string>().Trim();
                    if (string.IsNullOrWhiteSpace(noiDung)) continue;

                    if (seenNoiDung.Contains(noiDung))
                    {
                        duplicated.Add(noiDung);
                        continue;
                    }
                    seenNoiDung.Add(noiDung);

                    dtCauHoi.Rows.Add(
                        Convert.ToInt32(row.Cell(1).GetValue<string>()),
                        Convert.ToInt32(row.Cell(2).GetValue<string>()),
                        noiDung,
                        row.Cell(4).GetValue<string>(),
                        row.Cell(5).GetValue<string>(),
                        row.Cell(6).GetValue<string>(),
                        row.Cell(7).GetValue<string>(),
                        row.Cell(8).GetValue<string>().ToUpper()
                    );
                }

                if (duplicated.Count > 0)
                {
                    MessageBox.Show($"⚠️ Phát hiện {duplicated.Count} câu hỏi trùng nội dung trong file Excel!\nCác dòng trùng đã bị bỏ qua.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            dgvCauHoi.DataSource = dtCauHoi;
            dgvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCauHoi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCauHoi.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Chọn file Excel chứa câu hỏi"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        LoadExcelToGrid(ofd.FileName);
                        MessageBox.Show("✅ Đọc file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("❌ Lỗi khi đọc file Excel: " + ex.Message);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát mà không lưu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtCauHoi.Rows.Count == 0)
            {
                MessageBox.Show("⚠️ Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    foreach (DataRow row in dtCauHoi.Rows)
                    {
                        string sql = @"INSERT INTO NGANHANGCAUHOI 
                               (MaM, MaDK, NoiDung, DapAnA, DapAnB, DapAnC, DapAnD, DapAnDung, MaGV)
                               VALUES (@MaM, @MaDK, @NoiDung, @A, @B, @C, @D, @Dung, @MaGV)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaM", row["MaM"]);
                            cmd.Parameters.AddWithValue("@MaDK", row["MaDK"]);
                            cmd.Parameters.AddWithValue("@NoiDung", row["NoiDung"]);
                            cmd.Parameters.AddWithValue("@A", row["DapAnA"]);
                            cmd.Parameters.AddWithValue("@B", row["DapAnB"]);
                            cmd.Parameters.AddWithValue("@C", row["DapAnC"]);
                            cmd.Parameters.AddWithValue("@D", row["DapAnD"]);
                            cmd.Parameters.AddWithValue("@Dung", row["DapAnDung"]);
                            cmd.Parameters.AddWithValue("@MaGV", UserSession.MaGV); // ✅ Thêm MaGV

                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("🎉 Lưu dữ liệu vào database thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }
    }
}
