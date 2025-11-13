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
            this.Text = tenDe;
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
SELECT CH.MaCH, CH.NoiDung, CH.DapAnA, CH.DapAnB, CH.DapAnC, CH.DapAnD, CH.DapAnDung,
       P.TenPhan,
       (SELECT STRING_AGG(MaPhuongAn + '. ' + NoiDung, ' | ') 
        FROM DAPAN 
        WHERE MaCH = CH.MaCH) AS DapAnPhanII,
       (SELECT STRING_AGG(DungSai, ',') 
        FROM DAPAN 
        WHERE MaCH = CH.MaCH) AS DungSaiPhanII
FROM DETHI_CAUHOI DC
INNER JOIN NGANHANGCAUHOI CH ON DC.MaCH = CH.MaCH
INNER JOIN PHAN P ON CH.MaP = P.MaP
WHERE DC.MaD = @MaD
ORDER BY P.MaP, DC.STT";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaD", maDe);
                    SqlDataAdapter daAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    daAdapter.Fill(dt);

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

                    Panel pnl = new Panel
                    {
                        Dock = DockStyle.Fill,
                        AutoScroll = true
                    };
                    this.Controls.Add(pnl);

                    int y = 20;
                    string currentPhan = "";
                    int soThuTu = 1;

                    foreach (DataRow r in dt.Rows)
                    {
                        string phan = r["TenPhan"].ToString();
                        string noiDung = r["NoiDung"].ToString();
                        string daDung = r["DapAnDung"].ToString();

                        // Nếu Phần thay đổi, thêm label phân phần
                        if (phan != currentPhan)
                        {
                            Label lblPhan = new Label()
                            {
                                Text = phan,
                                Location = new Point(10, y),
                                AutoSize = true,
                                Font = new Font("Segoe UI", 12, FontStyle.Bold | FontStyle.Underline)
                            };
                            pnl.Controls.Add(lblPhan);
                            y += 30;
                            currentPhan = phan;
                            soThuTu = 1; // reset số thứ tự cho từng phần
                        }

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

                        if (phan == "Phần I")
                        {
                            // đánh dấu đáp án đúng dựa trên nội dung thực tế
                            y = TaoRadioButton(pnl, "A. " + r["DapAnA"].ToString(), r["DapAnA"].ToString() == daDung, y);
                            y = TaoRadioButton(pnl, "B. " + r["DapAnB"].ToString(), r["DapAnB"].ToString() == daDung, y);
                            y = TaoRadioButton(pnl, "C. " + r["DapAnC"].ToString(), r["DapAnC"].ToString() == daDung, y);
                            y = TaoRadioButton(pnl, "D. " + r["DapAnD"].ToString(), r["DapAnD"].ToString() == daDung, y);
                        }
                        else if (phan == "Phần II")
                        {
                            string dapAnPhanII = r["DapAnPhanII"].ToString();
                            string dungSaiStr = r["DungSaiPhanII"].ToString(); // ví dụ: 1,0,1,0
                            if (!string.IsNullOrEmpty(dapAnPhanII))
                            {
                                string[] arr = dapAnPhanII.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                                string[] arrDungSai = dungSaiStr.Split(',');
                                for (int i = 0; i < arr.Length; i++)
                                {
                                    bool isDung = arrDungSai[i] == "1";
                                    y = TaoRadioButton(pnl, arr[i], isDung, y);
                                }
                            }
                        }
                        else if (phan == "Phần III")
                        {
                            // Tự luận, chỉ hiển thị đáp án đúng
                            Label lblDapAn = new Label()
                            {
                                Text = "Đáp án: " + daDung,
                                Location = new Point(40, y),
                                AutoSize = true,
                                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                                ForeColor = Color.Blue
                            };
                            pnl.Controls.Add(lblDapAn);
                            y += 25;
                        }

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

        private int TaoRadioButton(Panel pnl, string text, bool checkedState, int y)
        {
            RadioButton rb = new RadioButton()
            {
                Text = text,
                Location = new Point(40, y),
                AutoSize = true,
                Checked = checkedState,
                Enabled = false
            };
            pnl.Controls.Add(rb);
            return y + 25;
        }
    }
}
