using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Winform_KLCN.ManHinhAdmin
{
    public partial class ctDeThi : Form
    {
        private int maDe;
        private string tenDe;

        public ctDeThi(int maDe, string tenDe)
        {
            InitializeComponent();
            this.maDe = maDe;
            this.tenDe = tenDe;
            this.Text = tenDe; // đổi tên form theo tên đề
            LoadCauHoi();
        }

        private void LoadCauHoi()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
SELECT CH.MaCH, CH.NoiDung, CH.DapAnA, CH.DapAnB, CH.DapAnC, CH.DapAnD, CH.DapAnDung
FROM DETHI_CAUHOI DC
INNER JOIN NGANHANGCAUHOI CH ON DC.MaCH = CH.MaCH
WHERE DC.MaD = @MaD
ORDER BY CH.MaCH";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaD", maDe);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        Label lblEmpty = new Label()
                        {
                            Text = "Đề thi này chưa có câu hỏi nào!",
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Segoe UI", 12, FontStyle.Italic)
                        };
                        this.Controls.Add(lblEmpty);
                        return;
                    }

                    // Dùng Panel cuộn được để hiển thị danh sách câu hỏi
                    Panel pnl = new Panel
                    {
                        Dock = DockStyle.Fill,
                        AutoScroll = true
                    };
                    this.Controls.Add(pnl);

                    int y = 20;
                    int soThuTu = 1;
                    foreach (DataRow r in dt.Rows)
                    {
                        string noiDung = r["NoiDung"].ToString();
                        string daA = r["DapAnA"].ToString();
                        string daB = r["DapAnB"].ToString();
                        string daC = r["DapAnC"].ToString();
                        string daD = r["DapAnD"].ToString();
                        string daDung = r["DapAnDung"].ToString();

                        // Label câu hỏi
                        Label lbl = new Label()
                        {
                            Text = $"{soThuTu}. {noiDung}",
                            AutoSize = true,
                            Location = new Point(20, y),
                            Font = new Font("Segoe UI", 10, FontStyle.Bold)
                        };
                        pnl.Controls.Add(lbl);
                        y += 25;

                        // Tạo radio button cho từng đáp án
                        y = TaoRadioButton(pnl, "A", daA, daDung == "A", y);
                        y = TaoRadioButton(pnl, "B", daB, daDung == "B", y);
                        y = TaoRadioButton(pnl, "C", daC, daDung == "C", y);
                        y = TaoRadioButton(pnl, "D", daD, daDung == "D", y);

                        y += 15;
                        soThuTu++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load chi tiết đề thi: " + ex.Message);
            }
        }

        private int TaoRadioButton(Panel pnl, string label, string text, bool checkedState, int y)
        {
            RadioButton rb = new RadioButton()
            {
                Text = $"{label}. {text}",
                Location = new Point(40, y),
                AutoSize = true,
                Checked = checkedState,
                Enabled = false // không cho chỉnh sửa
            };
            pnl.Controls.Add(rb);
            return y + 25;
        }

        private void ctDeThi_Load(object sender, EventArgs e)
        {

        }
    }
}
