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
            // Khởi tạo DataTable trống
            dtCauHoi.Columns.Add("MaM", typeof(int));
            dtCauHoi.Columns.Add("MaDK", typeof(int));
            dtCauHoi.Columns.Add("NoiDung", typeof(string));
            dtCauHoi.Columns.Add("DapAnA", typeof(string));
            dtCauHoi.Columns.Add("DapAnB", typeof(string));
            dtCauHoi.Columns.Add("DapAnC", typeof(string));
            dtCauHoi.Columns.Add("DapAnD", typeof(string));
            dtCauHoi.Columns.Add("DapAnDung", typeof(string));
            dtCauHoi.Columns.Add("MaP", typeof(int));

            // Ngăn DataGridView tự tạo cột
            dgvCauHoi.AutoGenerateColumns = false;
            dgvCauHoi.RowHeadersVisible = false; // ✅ Tắt cột trống đầu tiên

            // Tạo ComboBox cho Môn
            DataGridViewComboBoxColumn colMon = new DataGridViewComboBoxColumn
            {
                HeaderText = "Môn học",
                DataPropertyName = "MaM",
                DataSource = LoadMon(),
                DisplayMember = "TenMon",
                ValueMember = "MaM",
                AutoComplete = true
            };

            // Tạo ComboBox cho Độ khó
            DataGridViewComboBoxColumn colDoKho = new DataGridViewComboBoxColumn
            {
                HeaderText = "Độ khó",
                DataPropertyName = "MaDK",
                DataSource = LoadDoKho(),
                DisplayMember = "TenDoKho",
                ValueMember = "MaDK",
                AutoComplete = true
            };

            // Tạo các cột khác
            DataGridViewTextBoxColumn colNoiDung = new DataGridViewTextBoxColumn { HeaderText = "Nội dung câu hỏi", DataPropertyName = "NoiDung" };
            DataGridViewTextBoxColumn colA = new DataGridViewTextBoxColumn { HeaderText = "Đáp án A", DataPropertyName = "DapAnA" };
            DataGridViewTextBoxColumn colB = new DataGridViewTextBoxColumn { HeaderText = "Đáp án B", DataPropertyName = "DapAnB" };
            DataGridViewTextBoxColumn colC = new DataGridViewTextBoxColumn { HeaderText = "Đáp án C", DataPropertyName = "DapAnC" };
            DataGridViewTextBoxColumn colD = new DataGridViewTextBoxColumn { HeaderText = "Đáp án D", DataPropertyName = "DapAnD" };
            DataGridViewTextBoxColumn colDung = new DataGridViewTextBoxColumn { HeaderText = "Đáp án đúng", DataPropertyName = "DapAnDung" };
            DataGridViewTextBoxColumn colMaP = new DataGridViewTextBoxColumn { HeaderText = "Phần", DataPropertyName = "MaP" };

            // Thêm cột vào DataGridView theo thứ tự
            dgvCauHoi.Columns.Clear();
            dgvCauHoi.Columns.Add(colMon);
            dgvCauHoi.Columns.Add(colDoKho);
            dgvCauHoi.Columns.Add(colNoiDung);
            dgvCauHoi.Columns.Add(colA);
            dgvCauHoi.Columns.Add(colB);
            dgvCauHoi.Columns.Add(colC);
            dgvCauHoi.Columns.Add(colD);
            dgvCauHoi.Columns.Add(colDung);
            dgvCauHoi.Columns.Add(colMaP);

            // Gán DataSource (DataTable trống)
            dgvCauHoi.DataSource = dtCauHoi;

            // Các thiết lập khác
            dgvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCauHoi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCauHoi.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvCauHoi.AllowUserToAddRows = false;
        }
        private void LoadExcelToGrid(string filePath)
        {
            dtCauHoi.Rows.Clear();
            using (var workbook = new XLWorkbook(filePath))
            {
                HashSet<string> seenNoiDung = new HashSet<string>();
                List<string> loi = new List<string>();

                // Lấy danh sách môn giáo viên được phân công
                HashSet<int> monDuocPhanCong = new HashSet<int>();
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sqlMon = "SELECT MaM FROM GIAOVIEN_MON WHERE MaGV = @MaGV";
                    using (SqlCommand cmd = new SqlCommand(sqlMon, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaGV", UserSession.MaGV);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                monDuocPhanCong.Add(reader.GetInt32(0));
                        }
                    }
                }

                if (monDuocPhanCong.Count == 0)
                {
                    MessageBox.Show("⚠️ Giáo viên hiện tại chưa được phân công môn học nào, không thể import câu hỏi!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Duyệt từng sheet (Phần 1, 2, 3)
                for (int loaiPhan = 1; loaiPhan <= 3; loaiPhan++)
                {
                    if (workbook.Worksheets.Count < loaiPhan) continue;

                    var worksheet = workbook.Worksheet(loaiPhan);
                    var rows = worksheet.RangeUsed().RowsUsed();

                    foreach (var row in rows.Skip(1))
                    {
                        string noiDung = row.Cell(3).GetValue<string>().Trim();
                        if (string.IsNullOrWhiteSpace(noiDung))
                        {
                            loi.Add($"[Sheet {loaiPhan}] Dòng {row.RowNumber()}: Nội dung câu hỏi trống!");
                            continue;
                        }

                        if (seenNoiDung.Contains(noiDung))
                        {
                            loi.Add($"[Sheet {loaiPhan}] Dòng {row.RowNumber()}: Câu hỏi bị trùng!");
                            continue;
                        }
                        seenNoiDung.Add(noiDung);

                        // Kiểm tra MaM và MaDK hợp lệ nhưng chỉ ghi mô tả
                        int maM, maDK;
                        if (!int.TryParse(row.Cell(1).GetValue<string>(), out maM))
                        {
                            loi.Add($"[Sheet {loaiPhan}] Dòng {row.RowNumber()}: Môn học không hợp lệ!");
                            continue;
                        }

                        if (!monDuocPhanCong.Contains(maM))
                        {
                            loi.Add($"[Sheet {loaiPhan}] Dòng {row.RowNumber()}: Giáo viên không được phép nhập câu hỏi cho môn này!");
                            continue;
                        }

                        if (!int.TryParse(row.Cell(2).GetValue<string>(), out maDK))
                        {
                            loi.Add($"[Sheet {loaiPhan}] Dòng {row.RowNumber()}: Độ khó không hợp lệ!");
                            continue;
                        }

                        string dapAnA = row.Cell(4).GetValue<string>().Trim();
                        string dapAnB = row.Cell(5).GetValue<string>().Trim();
                        string dapAnC = row.Cell(6).GetValue<string>().Trim();
                        string dapAnD = row.Cell(7).GetValue<string>().Trim();
                        string dapAnDung = "";

                        if (loaiPhan == 1)
                        {
                            string dapAnKey = row.Cell(8).GetValue<string>().Trim().ToUpper();
                            if (dapAnKey == "A") dapAnDung = dapAnA;
                            else if (dapAnKey == "B") dapAnDung = dapAnB;
                            else if (dapAnKey == "C") dapAnDung = dapAnC;
                            else if (dapAnKey == "D") dapAnDung = dapAnD;
                            else dapAnDung = dapAnKey;
                        }
                        else if (loaiPhan == 2)
                        {
                            string dapAnKeys = row.Cell(8).GetValue<string>().Trim();
                            if (string.IsNullOrEmpty(dapAnKeys))
                            {
                                loi.Add($"[Sheet 2] Dòng {row.RowNumber()}: Chưa chọn đáp án đúng");
                                continue;
                            }

                            var keys = dapAnKeys.Replace(";", ",").Split(',');
                            List<string> dapAnDungList = new List<string>();

                            foreach (string k in keys)
                            {
                                string key = k.Trim().ToUpper();
                                if (key == "A") dapAnDungList.Add(dapAnA);
                                else if (key == "B") dapAnDungList.Add(dapAnB);
                                else if (key == "C") dapAnDungList.Add(dapAnC);
                                else if (key == "D") dapAnDungList.Add(dapAnD);
                                else dapAnDungList.Add(key);
                            }

                            dapAnDung = string.Join("; ", dapAnDungList);
                        }
                        else if (loaiPhan == 3)
                        {
                            dapAnDung = row.Cell(4).GetValue<string>().Trim();
                            if (string.IsNullOrEmpty(dapAnDung))
                                loi.Add($"[Sheet 3] Dòng {row.RowNumber()}: Thiếu đáp án đúng (trả lời ngắn)");
                        }

                        DataRow newRow = dtCauHoi.NewRow();
                        newRow["MaM"] = maM;
                        newRow["MaDK"] = maDK;
                        newRow["NoiDung"] = noiDung;
                        newRow["DapAnA"] = dapAnA;
                        newRow["DapAnB"] = dapAnB;
                        newRow["DapAnC"] = dapAnC;
                        newRow["DapAnD"] = dapAnD;
                        newRow["DapAnDung"] = dapAnDung;
                        newRow["MaP"] = loaiPhan;
                        dtCauHoi.Rows.Add(newRow);
                    }
                }

                dgvCauHoi.DataSource = dtCauHoi;
                dgvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvCauHoi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvCauHoi.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                if (loi.Count > 0)
                {
                    string thongBao = $"⚠️ Phát hiện {loi.Count} lỗi dữ liệu:\n\n" + string.Join("\n", loi.Take(15));
                    if (loi.Count > 15) thongBao += "\n... (còn nhiều lỗi khác)";
                    MessageBox.Show(thongBao, "Cảnh báo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("✅ Đọc tất cả câu hỏi (Phần 1–3) thành công, không phát hiện lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Chọn file Excel chứa danh sách câu hỏi (3 phần)"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        LoadExcelToGrid(ofd.FileName);
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
                                   (MaM, MaDK, NoiDung, DapAnA, DapAnB, DapAnC, DapAnD, DapAnDung, MaGV, MaP)
                                   VALUES (@MaM, @MaDK, @NoiDung, @A, @B, @C, @D, @Dung, @MaGV, @MaP)";

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
                            cmd.Parameters.AddWithValue("@MaGV", UserSession.MaGV);
                            cmd.Parameters.AddWithValue("@MaP", row["MaP"]);

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
