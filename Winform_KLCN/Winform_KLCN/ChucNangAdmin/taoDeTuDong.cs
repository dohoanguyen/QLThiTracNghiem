using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Winform_KLCN.ManHinhAdmin;

namespace Winform_KLCN.ChucNangAdmin
{
    public partial class taoDeTuDong : Form
    {
        private DataTable dtCauHoiDaChon; // tạm lưu câu hỏi đã chọn
        private int soCauP1, soCauP2, soCauP3; // cấu trúc phần
        private int tongSoCau;
        private int maMon;

        public taoDeTuDong()
        {
            InitializeComponent();
        }

        private void taoDeTuDong_Load(object sender, EventArgs e)
        {
            LoadMon();
            txtThoiGian.Text = "50";
            txtSoCau.Text = "40";
        }

        private void LoadMon()
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MaM, TenMon FROM MON", conn);
                    da.Fill(dt);

                    cboMon.DataSource = dt;
                    cboMon.DisplayMember = "TenMon";
                    cboMon.ValueMember = "MaM";
                    cboMon.SelectedIndexChanged += CboMon_SelectedIndexChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải môn thi: " + ex.Message);
            }
        }

        private void CboMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMon.SelectedValue == null || cboMon.SelectedValue is DataRowView) return;

            maMon = Convert.ToInt32(cboMon.SelectedValue);
            string tenMon = cboMon.Text.Trim().ToLower();

            // Xác định cấu trúc đề theo môn
            if (tenMon.Contains("toán"))
            {
                soCauP1 = 12; soCauP2 = 4; soCauP3 = 6;
                txtSoCau.Text = (soCauP1 + soCauP2 + soCauP3).ToString();
                txtThoiGian.Text = "90";
            }
            else if (tenMon.Contains("lý") || tenMon.Contains("hóa") || tenMon.Contains("sinh") || tenMon.Contains("địa"))
            {
                soCauP1 = 18; soCauP2 = 4; soCauP3 = 6;
                txtSoCau.Text = (soCauP1 + soCauP2 + soCauP3).ToString();
                txtThoiGian.Text = "50";
            }
            else
            {
                soCauP1 = 24; soCauP2 = 4; soCauP3 = 0;
                txtSoCau.Text = (soCauP1 + soCauP2 + soCauP3).ToString();
                txtThoiGian.Text = "50";
            }
        }

        // ========================== Bước 1: Tạo đề tự động ==========================
        private void btnTao_Click(object sender, EventArgs e)
        {
            tongSoCau = soCauP1 + soCauP2 + soCauP3;

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                // Lấy tất cả câu hỏi của môn
                string sql = @"
SELECT CH.MaCH, CH.NoiDung, CH.DapAnA, CH.DapAnB, CH.DapAnC, CH.DapAnD, CH.DapAnDung,
       CH.MaP,
       (SELECT STRING_AGG(MaPhuongAn + '. ' + NoiDung, ' | ') 
        FROM DAPAN 
        WHERE MaCH = CH.MaCH) AS DapAnPhanII,
       (SELECT STRING_AGG(DungSai, ',') 
        FROM DAPAN 
        WHERE MaCH = CH.MaCH) AS DungSaiPhanII
FROM NGANHANGCAUHOI CH
WHERE CH.MaM=@MaM";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaM", maMon);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Ngân hàng câu hỏi chưa có dữ liệu!");
                    return;
                }

                // Chọn ngẫu nhiên theo phần và độ khó
                dtCauHoiDaChon = ChonCauHoiTheoPhan(dt);

                // Hiển thị chi tiết trên Panel giống ctDeThi
                HienThiChiTiet(dtCauHoiDaChon);
            }
        }

        private DataTable ChonCauHoiTheoPhan(DataTable dt)
        {
            Random rnd = new Random();
            DataTable dtChon = dt.Clone();

            // Phần I
            var p1 = dt.AsEnumerable().Where(r => Convert.ToInt32(r["MaP"]) == 1)
                                      .OrderBy(x => rnd.Next())
                                      .Take(soCauP1);
            foreach (var r in p1) dtChon.ImportRow(r);

            // Phần II
            var p2 = dt.AsEnumerable().Where(r => Convert.ToInt32(r["MaP"]) == 2)
                                      .OrderBy(x => rnd.Next())
                                      .Take(soCauP2);
            foreach (var r in p2) dtChon.ImportRow(r);

            // Phần III
            if (soCauP3 > 0)
            {
                var p3 = dt.AsEnumerable().Where(r => Convert.ToInt32(r["MaP"]) == 3)
                                          .OrderBy(x => rnd.Next())
                                          .Take(soCauP3);
                foreach (var r in p3) dtChon.ImportRow(r);
            }

            return dtChon;
        }

        // ========================== Hiển thị chi tiết ==========================
        private void HienThiChiTiet(DataTable dt)
        {
            panelChiTiet.Controls.Clear();

            Panel pnl = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            panelChiTiet.Controls.Add(pnl);

            int y = 20;
            string currentPhan = "";
            int stt = 1;

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                foreach (DataRow r in dt.Rows)
                {
                    string phan = r["MaP"].ToString() == "1" ? "Phần I" :
                                  r["MaP"].ToString() == "2" ? "Phần II" : "Phần III";
                    string noiDung = r["NoiDung"].ToString();
                    string daDung = r["DapAnDung"].ToString();

                    // Thêm label phân phần nếu khác phần hiện tại
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
                        stt = 1;
                    }

                    // Label câu hỏi
                    Label lblCau = new Label()
                    {
                        Text = $"{stt}. {noiDung}",
                        Location = new Point(20, y),
                        AutoSize = true,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold)
                    };
                    pnl.Controls.Add(lblCau);
                    y += 25;

                    if (phan == "Phần I")
                    {
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
                        Label lblTuLuan = new Label()
                        {
                            Text = "Đáp án: " + daDung,
                            Location = new Point(40, y),
                            AutoSize = true,
                            Font = new Font("Segoe UI", 10, FontStyle.Italic),
                            ForeColor = Color.Blue
                        };
                        pnl.Controls.Add(lblTuLuan);
                        y += 25;
                    }

                    y += 15;
                    stt++;
                }
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


     

        // ========================== Bước 2: Lưu đề vào DB ==========================
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (dtCauHoiDaChon == null || dtCauHoiDaChon.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để lưu!");
                return;
            }

            string tenDe = txtTenDe.Text.Trim();
            if (string.IsNullOrEmpty(tenDe))
            {
                MessageBox.Show("Vui lòng nhập tên đề!");
                return;
            }

            int soCau = dtCauHoiDaChon.Rows.Count;
            int thoiGian = int.TryParse(txtThoiGian.Text, out int tg) ? tg : 50;

            using (SqlConnection conn = KetNoi.TaoKetNoi())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sqlDe = @"
INSERT INTO DETHI (TenDe, MaM, SoCau, ThoiGian, TrangThai)
VALUES (@TenDe, @MaM, @SoCau, @ThoiGian, N'Khóa');
SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdDe = new SqlCommand(sqlDe, conn, tran);
                    cmdDe.Parameters.AddWithValue("@TenDe", tenDe);
                    cmdDe.Parameters.AddWithValue("@MaM", maMon);
                    cmdDe.Parameters.AddWithValue("@SoCau", soCau);
                    cmdDe.Parameters.AddWithValue("@ThoiGian", thoiGian);

                    int maDe = Convert.ToInt32(cmdDe.ExecuteScalar());

                    // Thêm chi tiết câu hỏi
                    for (int i = 0; i < dtCauHoiDaChon.Rows.Count; i++)
                    {
                        DataRow r = dtCauHoiDaChon.Rows[i];
                        string sqlCT = "INSERT INTO DETHI_CAUHOI (MaD, MaCH, STT) VALUES (@MaD, @MaCH, @STT)";
                        SqlCommand cmdCT = new SqlCommand(sqlCT, conn, tran);
                        cmdCT.Parameters.AddWithValue("@MaD", maDe);
                        cmdCT.Parameters.AddWithValue("@MaCH", Convert.ToInt32(r["MaCH"]));
                        cmdCT.Parameters.AddWithValue("@STT", i + 1);
                        cmdCT.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Đề thi đã lưu thành công và được chuyển sang trạng thái Khóa!");
                    dtCauHoiDaChon = null;
                    panelChiTiet.Controls.Clear();
                    txtTenDe.Clear();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi khi lưu đề: " + ex.Message);
                }
            }
        }
    }
}
