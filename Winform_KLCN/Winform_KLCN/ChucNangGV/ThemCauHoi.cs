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
using ClosedXML.Excel;

namespace Winform_KLCN.ManHinhChinh
{
    public partial class ThemCauHoi : Form
    {
        private DataTable dtCauHoi = new DataTable();
        private DataTable LoadMon()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                string sql = "SELECT MaM, TenMon FROM MON";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private DataTable LoadDoKho()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                string sql = "SELECT MaDK, TenDoKho FROM DOKHO";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public ThemCauHoi()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private void ThemCauHoi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_TUQ_NEWDataSet.NGANHANGCAUHOI' table. You can move, or remove it, as needed.
            this.nGANHANGCAUHOITableAdapter.Fill(this.qL_TUQ_NEWDataSet.NGANHANGCAUHOI);
            // Tạo cấu trúc DataTable
            dtCauHoi.Columns.Add("MaM", typeof(int));
            dtCauHoi.Columns.Add("MaDK", typeof(int));
            dtCauHoi.Columns.Add("NoiDung", typeof(string));
            dtCauHoi.Columns.Add("DaA", typeof(string));
            dtCauHoi.Columns.Add("DaB", typeof(string));
            dtCauHoi.Columns.Add("DaC", typeof(string));
            dtCauHoi.Columns.Add("DaD", typeof(string));
            dtCauHoi.Columns.Add("DaDung", typeof(string));

            dgvCauHoi.DataSource = dtCauHoi;
            dgvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCauHoi.AllowUserToAddRows = false;
            dgvCauHoi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCauHoi.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvCauHoi.EnableHeadersVisualStyles = false;
            dgvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCauHoi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCauHoi.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvCauHoi.Columns["MaM"].HeaderText = "Môn học";
            dgvCauHoi.Columns["MaDK"].HeaderText = "Độ khó";
            dgvCauHoi.Columns["NoiDung"].HeaderText = "Nội dung câu hỏi";
            dgvCauHoi.Columns["DaA"].HeaderText = "Đáp án A";
            dgvCauHoi.Columns["DaB"].HeaderText = "Đáp án B";
            dgvCauHoi.Columns["DaC"].HeaderText = "Đáp án C";
            dgvCauHoi.Columns["DaD"].HeaderText = "Đáp án D";
            dgvCauHoi.Columns["DaDung"].HeaderText = "Đáp án đúng";

            // 🔹 Gắn ComboBox cho cột Môn học
            DataGridViewComboBoxColumn colMon = new DataGridViewComboBoxColumn();
            colMon.HeaderText = "Môn học";
            colMon.DataPropertyName = "MaM"; // Cột dữ liệu tương ứng
            colMon.DataSource = LoadMon();
            colMon.DisplayMember = "TenMon";
            colMon.ValueMember = "MaM";
            colMon.AutoComplete = true;

            // 🔹 Gắn ComboBox cho cột Độ khó
            DataGridViewComboBoxColumn colDoKho = new DataGridViewComboBoxColumn();
            colDoKho.HeaderText = "Độ khó";
            colDoKho.DataPropertyName = "MaDK";
            colDoKho.DataSource = LoadDoKho();
            colDoKho.DisplayMember = "TenDoKho";
            colDoKho.ValueMember = "MaDK";
            colDoKho.AutoComplete = true;

            // 🔹 Xóa 2 cột cũ rồi thêm ComboBox mới vào vị trí tương ứng
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
                var worksheet = workbook.Worksheet(1); // Sheet đầu tiên
                var rows = worksheet.RangeUsed().RowsUsed();

                // HashSet để kiểm tra trùng nội dung
                HashSet<string> seenNoiDung = new HashSet<string>();
                List<string> duplicated = new List<string>();

                foreach (var row in rows.Skip(1)) // Bỏ qua tiêu đề
                {
                    string noiDung = row.Cell(3).GetValue<string>().Trim();

                    if (string.IsNullOrWhiteSpace(noiDung))
                        continue; // Bỏ qua dòng trống

                    if (seenNoiDung.Contains(noiDung))
                    {
                        duplicated.Add(noiDung);
                        continue; // Bỏ qua dòng trùng
                    }

                    seenNoiDung.Add(noiDung);

                    dtCauHoi.Rows.Add(
                        Convert.ToInt32(row.Cell(1).GetValue<string>()), // MaM
                        Convert.ToInt32(row.Cell(2).GetValue<string>()), // MaDK
                        noiDung, // NoiDung
                        row.Cell(4).GetValue<string>(), // DaA
                        row.Cell(5).GetValue<string>(), // DaB
                        row.Cell(6).GetValue<string>(), // DaC
                        row.Cell(7).GetValue<string>(), // DaD
                        row.Cell(8).GetValue<string>().ToUpper() // DaDung
                    );
                }

                // ⚠️ Hiển thị cảnh báo nếu có câu hỏi trùng
                if (duplicated.Count > 0)
                {
                    MessageBox.Show(
                        $"⚠️ Phát hiện {duplicated.Count} câu hỏi trùng nội dung trong file Excel!\n" +
                        $"Các dòng trùng đã bị bỏ qua.",
                        "Cảnh báo trùng dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }

            // Cập nhật lại giao diện DataGridView
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
                                       (MaM, MaDK, NoiDung, DaA, DaB, DaC, DaD, DaDung)
                                       VALUES (@MaM, @MaDK, @NoiDung, @A, @B, @C, @D, @Dung)";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaM", row["MaM"]);
                            cmd.Parameters.AddWithValue("@MaDK", row["MaDK"]);
                            cmd.Parameters.AddWithValue("@NoiDung", row["NoiDung"]);
                            cmd.Parameters.AddWithValue("@A", row["DaA"]);
                            cmd.Parameters.AddWithValue("@B", row["DaB"]);
                            cmd.Parameters.AddWithValue("@C", row["DaC"]);
                            cmd.Parameters.AddWithValue("@D", row["DaD"]);
                            cmd.Parameters.AddWithValue("@Dung", row["DaDung"]);

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
