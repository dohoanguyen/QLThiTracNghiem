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
        public ThemCauHoi()
        {
            InitializeComponent();
        }

        private void ThemCauHoi_Load(object sender, EventArgs e)
        {
            LoadMon();
            LoadDoKho();
            LoadDapAnDung();
        }

        private void LoadMon()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                string sql = "SELECT MaM, TenMon FROM MON";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbMon.DataSource = dt;
                cbMon.DisplayMember = "TenMon";
                cbMon.ValueMember = "MaM";
            }
        }

        private void LoadDoKho()
        {
            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                string sql = "SELECT MaDK, TenDoKho FROM DOKHO";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbDoKho.DataSource = dt;
                cbDoKho.DisplayMember = "TenDoKho";
                cbDoKho.ValueMember = "MaDK";
            }
        }

        private void LoadDapAnDung()
        {
            cbDung.Items.Clear();
            cbDung.Items.Add("A");
            cbDung.Items.Add("B");
            cbDung.Items.Add("C");
            cbDung.Items.Add("D");
            cbDung.SelectedIndex = 0; // Mặc định chọn "A"
        }

        private void ImportExcel(string filePath)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1); // Lấy sheet đầu tiên
                var rows = worksheet.RangeUsed().RowsUsed();

                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();

                    foreach (var row in rows.Skip(1)) // Bỏ qua dòng tiêu đề
                    {
                        int maM = Convert.ToInt32(row.Cell(1).GetValue<string>());
                        int maDK = Convert.ToInt32(row.Cell(2).GetValue<string>());
                        string noiDung = row.Cell(3).GetValue<string>();
                        string daA = row.Cell(4).GetValue<string>();
                        string daB = row.Cell(5).GetValue<string>();
                        string daC = row.Cell(6).GetValue<string>();
                        string daD = row.Cell(7).GetValue<string>();
                        string daDung = row.Cell(8).GetValue<string>().ToUpper();

                        string query = @"INSERT INTO NGANHANGCAUHOI (MaM, MaDK, NoiDung, DaA, DaB, DaC, DaD, DaDung)
                                 VALUES (@MaM, @MaDK, @NoiDung, @DaA, @DaB, @DaC, @DaD, @DaDung)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaM", maM);
                            cmd.Parameters.AddWithValue("@MaDK", maDK);
                            cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                            cmd.Parameters.AddWithValue("@DaA", daA);
                            cmd.Parameters.AddWithValue("@DaB", daB);
                            cmd.Parameters.AddWithValue("@DaC", daC);
                            cmd.Parameters.AddWithValue("@DaD", daD);
                            cmd.Parameters.AddWithValue("@DaDung", daDung);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    string sql = @"INSERT INTO NGANHANGCAUHOI 
                                  (MaM, MaDK, NoiDung, DaA, DaB, DaC, DaD, DaDung)
                                  VALUES (@MaM, @MaDK, @NoiDung, @A, @B, @C, @D, @Dung)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaM", cbMon.SelectedValue);
                    cmd.Parameters.AddWithValue("@MaDK", cbDoKho.SelectedValue);
                    cmd.Parameters.AddWithValue("@NoiDung", txtNoiDung.Text.Trim());
                    cmd.Parameters.AddWithValue("@A", txtA.Text.Trim());
                    cmd.Parameters.AddWithValue("@B", txtB.Text.Trim());
                    cmd.Parameters.AddWithValue("@C", txtC.Text.Trim());
                    cmd.Parameters.AddWithValue("@D", txtD.Text.Trim());
                    cmd.Parameters.AddWithValue("@Dung", cbDung.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Thêm câu hỏi thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi thêm câu hỏi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
        "Bạn có chắc chắn muốn huỷ và thoát không?",
        "Xác nhận thoát",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

    if (result == DialogResult.Yes)
    {
        this.Close(); // Đóng form ThemCauHoi
    }
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
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
                        ImportExcel(ofd.FileName);
                        MessageBox.Show("Đã nhập dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi nhập dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
