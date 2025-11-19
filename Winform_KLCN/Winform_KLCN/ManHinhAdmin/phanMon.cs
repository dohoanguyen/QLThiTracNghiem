using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Winform_KLCN.ManHinhAdmin
{
    public partial class phanMon : UserControl
    {
        private int addingRowIndex = -1; // Dòng GV đang thêm môn

        public phanMon()
        {
            InitializeComponent();
            CauHinhDataGridView();
            LoadGiaoVien();
            cboMon.Visible = true; // vẫn ở ngoài
            btnLuu.Visible = true;

            dgvGiaoVien.CellContentClick += dgvGiaoVien_CellContentClick;
            btnLuu.Click += btnLuu_Click;
        }

        private void CauHinhDataGridView()
        {
            dgvGiaoVien.AutoGenerateColumns = false;
            dgvGiaoVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGiaoVien.MultiSelect = false;
            dgvGiaoVien.AllowUserToAddRows = false;
            dgvGiaoVien.ReadOnly = true;
            dgvGiaoVien.RowHeadersVisible = false;
            dgvGiaoVien.Columns.Clear();

            AddColumn("MaGV", "Mã GV", 50, true); // Ẩn
            AddColumn("TenGV", "Tên Giáo Viên", 180);
            AddColumn("TrinhDo", "Trình Độ", 120);
            AddColumn("MonDay", "Môn Dạy", 250);

            // Nút Thêm cuối mỗi dòng
            DataGridViewButtonColumn btnAdd = new DataGridViewButtonColumn();
            btnAdd.Name = "btnThem";
            btnAdd.HeaderText = "Thêm Môn";
            btnAdd.Text = "Thêm";
            btnAdd.UseColumnTextForButtonValue = true;
            btnAdd.Width = 80;
            dgvGiaoVien.Columns.Add(btnAdd);
        }

        private void AddColumn(string dataProp, string header, int width, bool hidden = false)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn()
            {
                Name = dataProp,
                DataPropertyName = dataProp,
                HeaderText = header,
                Width = width,
                ReadOnly = true,
                Visible = !hidden
            };
            dgvGiaoVien.Columns.Add(col);
        }

        private void LoadGiaoVien(string keyword = "")
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
                        SELECT GV.MaGV, GV.TenGV, GV.TrinhDo,
                               ISNULL(STUFF((SELECT ', ' + M.TenMon
                                             FROM GIAOVIEN_MON GM
                                             JOIN MON M ON GM.MaM = M.MaM
                                             WHERE GM.MaGV = GV.MaGV
                                             FOR XML PATH('')), 1, 2, ''), '') AS MonDay
                        FROM GIAOVIEN GV
                        WHERE GV.TenGV LIKE @kw";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvGiaoVien.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load giáo viên: " + ex.Message);
            }
        }

        private void dgvGiaoVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvGiaoVien.Columns[e.ColumnIndex].Name != "btnThem") return;

            // Lưu dòng GV đang thêm môn
            addingRowIndex = e.RowIndex;

            // Load môn chưa dạy vào cboMon
            string maGV = dgvGiaoVien.Rows[e.RowIndex].Cells["MaGV"].Value.ToString();
            LoadMonChuaDay(maGV);
        }

        private void LoadMonChuaDay(string maGV)
        {
            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = @"
                        SELECT MaM, TenMon
                        FROM MON
                        WHERE MaM NOT IN (
                            SELECT MaM FROM GIAOVIEN_MON WHERE MaGV=@mgv
                        )";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@mgv", maGV);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboMon.DataSource = dt;
                    cboMon.DisplayMember = "TenMon";
                    cboMon.ValueMember = "MaM";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load môn chưa dạy: " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (addingRowIndex < 0)
            {
                MessageBox.Show("Vui lòng nhấn Thêm ở dòng giáo viên trước!");
                return;
            }

            if (cboMon.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn môn cần thêm!");
                return;
            }

            string maGV = dgvGiaoVien.Rows[addingRowIndex].Cells["MaGV"].Value.ToString();
            string maM = cboMon.SelectedValue.ToString();

            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    conn.Open();
                    string sql = "INSERT INTO GIAOVIEN_MON(MaGV, MaM) VALUES(@mgv, @mm)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@mgv", maGV);
                    cmd.Parameters.AddWithValue("@mm", maM);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm môn thành công!");
                addingRowIndex = -1;
                LoadGiaoVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm môn: " + ex.Message);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTim.Text.Trim();
            LoadGiaoVien(keyword);
        }
    }
}
