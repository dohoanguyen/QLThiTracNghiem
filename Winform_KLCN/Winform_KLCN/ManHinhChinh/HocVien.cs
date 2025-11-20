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

            // QUAN TRỌNG: Phải để False thì mới bấm được vào ComboBox
            dgvHocVien.ReadOnly = false;

            dgvHocVien.ColumnHeadersVisible = true;
            dgvHocVien.RowHeadersVisible = false;
            dgvHocVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvHocVien.ColumnHeadersHeight = 40;

            dgvHocVien.Columns.Clear();

            // Thêm các cột văn bản (Vẫn set ReadOnly = true bên trong hàm AddColumn để không cho sửa tên/tuổi)
            AddColumn("MaHV", "Mã HV", 70);
            AddColumn("TenHV", "Họ tên", 200);
            AddColumn("GioiTinh", "Giới tính", 80);
            AddColumn("NgaySinh", "Ngày sinh", 100);
            AddColumn("DiaChi", "Địa chỉ", 200);

            // --- THÊM CỘT COMBOBOX CHO LỚP HỌC ---
            DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
            comboCol.HeaderText = "Lớp học";
            comboCol.Name = "colTenLop"; // Đặt tên để dễ gọi code
            comboCol.Width = 150;
            comboCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            comboCol.FlatStyle = FlatStyle.Flat;
            comboCol.ReadOnly = false; // Cột này phải cho phép thao tác
            dgvHocVien.Columns.Add(comboCol);
        }

        private void AddColumn(string dataProp, string header, int width)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = dataProp, // Lưu ý: Khi add thủ công thì cái này không tự map nữa, nhưng cứ để đó
                HeaderText = header,
                Width = width,
                Visible = true,
                ReadOnly = true, // Cố định không cho sửa text
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
                    // SQL giữ nguyên
                    string sql = @"
                        SELECT DISTINCT
                            hv.MaHV, hv.TenHV, hv.GioiTinh, hv.NgaySinh, hv.DiaChi, lh.TenLop
                        FROM HOCVIEN hv
                        JOIN HOCVIEN_LOPHOC hl ON hv.MaHV = hl.MaHV
                        JOIN LOPHOC lh ON hl.MaL = lh.MaL
                        WHERE lh.MaGV = @MaGV
                        ORDER BY hv.TenHV, lh.TenLop";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaGV", maGV);

                    dtHocVien = new DataTable();
                    da.Fill(dtHocVien); // Lấy dữ liệu thô (Dạng phẳng)

                    // --- XỬ LÝ DỮ LIỆU BẰNG LINQ & ĐỔ VÀO GRID ---
                    
                    dgvHocVien.Rows.Clear(); // Xóa dữ liệu cũ trên lưới

                    if (dtHocVien.Rows.Count > 0)
                    {
                        // Gom nhóm các dòng có cùng MaHV
                        var groupedData = dtHocVien.AsEnumerable()
                            .GroupBy(row => new
                            {
                                MaHV = row.Field<int>("MaHV"),
                                TenHV = row.Field<string>("TenHV"),
                                GioiTinh = row.Field<string>("GioiTinh"),
                                NgaySinh = row.Field<DateTime>("NgaySinh"),
                                DiaChi = row.Field<string>("DiaChi")
                            })
                            .Select(g => new
                            {
                                ThongTin = g.Key,
                                DanhSachLop = g.Select(r => r.Field<string>("TenLop")).ToList()
                            }).ToList();

                        // Duyệt qua từng học viên đã gom nhóm
                        foreach (var item in groupedData)
                        {
                            int idx = dgvHocVien.Rows.Add();
                            DataGridViewRow row = dgvHocVien.Rows[idx];

                            // Gán giá trị cho các cột Text
                            row.Cells[0].Value = item.ThongTin.MaHV;
                            row.Cells[1].Value = item.ThongTin.TenHV;
                            row.Cells[2].Value = item.ThongTin.GioiTinh;
                            row.Cells[3].Value = item.ThongTin.NgaySinh.ToString("dd/MM/yyyy");
                            row.Cells[4].Value = item.ThongTin.DiaChi;

                            // Gán giá trị cho cột ComboBox
                            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)row.Cells["colTenLop"];
                            
                            // Đổ list lớp vào Items của ô đó
                            foreach (var lop in item.DanhSachLop)
                            {
                                cell.Items.Add(lop);
                            }

                            // Chọn giá trị hiển thị mặc định (Lớp đầu tiên)
                            if (item.DanhSachLop.Count > 0)
                            {
                                cell.Value = item.DanhSachLop[0];
                            }

                            // *** LOGIC ẨN HIỆN COMBOBOX ***
                            if (item.DanhSachLop.Count <= 1)
                            {
                                // Nếu chỉ 1 lớp: Biến thành Textbox (ẩn nút mũi tên)
                                cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                                cell.ReadOnly = true; // Khóa lại cho chắc
                            }
                            else
                            {
                                // Nếu nhiều lớp: Hiện nút dropdown
                                cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
                                cell.ReadOnly = false; // Mở ra để chọn
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách học viên: " + ex.Message);
            }
        }
    }
}
