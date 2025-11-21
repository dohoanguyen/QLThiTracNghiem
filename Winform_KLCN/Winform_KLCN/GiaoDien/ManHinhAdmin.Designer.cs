namespace Winform_KLCN.GiaoDien
{
    partial class ManHinhAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManHinhAdmin));
            this.lblXinChao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.menuAdmin = new System.Windows.Forms.MenuStrip();
            this.TaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.QlyTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.themTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.themGiaoVien = new System.Windows.Forms.ToolStripMenuItem();
            this.themHocVien = new System.Windows.Forms.ToolStripMenuItem();
            this.themAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.GiaoVien = new System.Windows.Forms.ToolStripMenuItem();
            this.QlyGiaoVien = new System.Windows.Forms.ToolStripMenuItem();
            this.phanMon = new System.Windows.Forms.ToolStripMenuItem();
            this.HocVien = new System.Windows.Forms.ToolStripMenuItem();
            this.QlyHocVien = new System.Windows.Forms.ToolStripMenuItem();
            this.chiaLop = new System.Windows.Forms.ToolStripMenuItem();
            this.CauHoi = new System.Windows.Forms.ToolStripMenuItem();
            this.qlyCauHoi = new System.Windows.Forms.ToolStripMenuItem();
            this.DeThi = new System.Windows.Forms.ToolStripMenuItem();
            this.taoDeThi = new System.Windows.Forms.ToolStripMenuItem();
            this.qlyDeThi = new System.Windows.Forms.ToolStripMenuItem();
            this.LichThi = new System.Windows.Forms.ToolStripMenuItem();
            this.QlyKyThi = new System.Windows.Forms.ToolStripMenuItem();
            this.taoKyThi = new System.Windows.Forms.ToolStripMenuItem();
            this.KH = new System.Windows.Forms.ToolStripMenuItem();
            this.taoKhoaHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.qlyKhoaHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.ThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.chiTiet = new System.Windows.Forms.ToolStripMenuItem();
            this.ketQua = new System.Windows.Forms.ToolStripMenuItem();
            this.SaoLuu = new System.Windows.Forms.ToolStripMenuItem();
            this.panelNoiDung = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1.SuspendLayout();
            this.menuAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblXinChao
            // 
            this.lblXinChao.AutoSize = true;
            this.lblXinChao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXinChao.ForeColor = System.Drawing.Color.White;
            this.lblXinChao.Location = new System.Drawing.Point(44, 19);
            this.lblXinChao.Name = "lblXinChao";
            this.lblXinChao.Size = new System.Drawing.Size(82, 28);
            this.lblXinChao.TabIndex = 2;
            this.lblXinChao.Text = "ADMIN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(434, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "TRUNG TÂM QUẢN LÝ CỦA TUQ";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.guna2GradientPanel1.Controls.Add(this.btnDangXuat);
            this.guna2GradientPanel1.Controls.Add(this.lblXinChao);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1329, 65);
            this.guna2GradientPanel1.TabIndex = 1;
            // 
            // menuAdmin
            // 
            this.menuAdmin.BackColor = System.Drawing.Color.Transparent;
            this.menuAdmin.Dock = System.Windows.Forms.DockStyle.None;
            this.menuAdmin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.menuAdmin.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuAdmin.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TaiKhoan,
            this.GiaoVien,
            this.HocVien,
            this.CauHoi,
            this.DeThi,
            this.LichThi,
            this.KH,
            this.ThongKe,
            this.SaoLuu});
            this.menuAdmin.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuAdmin.Location = new System.Drawing.Point(0, 68);
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuAdmin.Size = new System.Drawing.Size(1002, 35);
            this.menuAdmin.TabIndex = 2;
            this.menuAdmin.Text = "menuAdmin";
            // 
            // TaiKhoan
            // 
            this.TaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QlyTaiKhoan,
            this.themTaiKhoan});
            this.TaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TaiKhoan.Name = "TaiKhoan";
            this.TaiKhoan.Size = new System.Drawing.Size(129, 29);
            this.TaiKhoan.Text = "TÀI KHOẢN";
            this.TaiKhoan.Click += new System.EventHandler(this.gIÁOVIÊNToolStripMenuItem_Click);
            // 
            // QlyTaiKhoan
            // 
            this.QlyTaiKhoan.Name = "QlyTaiKhoan";
            this.QlyTaiKhoan.Size = new System.Drawing.Size(298, 34);
            this.QlyTaiKhoan.Text = "QUẢN LÝ TÀI KHOẢN";
            this.QlyTaiKhoan.Click += new System.EventHandler(this.QlyTaiKhoan_Click);
            // 
            // themTaiKhoan
            // 
            this.themTaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themGiaoVien,
            this.themHocVien,
            this.themAdmin});
            this.themTaiKhoan.Name = "themTaiKhoan";
            this.themTaiKhoan.Size = new System.Drawing.Size(298, 34);
            this.themTaiKhoan.Text = "THÊM TÀI KHOẢN";
            this.themTaiKhoan.Click += new System.EventHandler(this.themTaiKhoan_Click);
            // 
            // themGiaoVien
            // 
            this.themGiaoVien.Name = "themGiaoVien";
            this.themGiaoVien.Size = new System.Drawing.Size(207, 34);
            this.themGiaoVien.Text = "GIÁO VIÊN";
            this.themGiaoVien.Click += new System.EventHandler(this.themGiaoVien_Click);
            // 
            // themHocVien
            // 
            this.themHocVien.Name = "themHocVien";
            this.themHocVien.Size = new System.Drawing.Size(207, 34);
            this.themHocVien.Text = "HỌC VIÊN";
            this.themHocVien.Click += new System.EventHandler(this.themHocVien_Click);
            // 
            // themAdmin
            // 
            this.themAdmin.Name = "themAdmin";
            this.themAdmin.Size = new System.Drawing.Size(207, 34);
            this.themAdmin.Text = "ADMIN";
            this.themAdmin.Click += new System.EventHandler(this.themAdmin_Click);
            // 
            // GiaoVien
            // 
            this.GiaoVien.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QlyGiaoVien,
            this.phanMon});
            this.GiaoVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.GiaoVien.Name = "GiaoVien";
            this.GiaoVien.Size = new System.Drawing.Size(121, 29);
            this.GiaoVien.Text = "GIÁO VIÊN";
            this.GiaoVien.Click += new System.EventHandler(this.GiaoVien_Click);
            // 
            // QlyGiaoVien
            // 
            this.QlyGiaoVien.Name = "QlyGiaoVien";
            this.QlyGiaoVien.Size = new System.Drawing.Size(319, 34);
            this.QlyGiaoVien.Text = "DANH SÁCH GIÁO VIÊN";
            this.QlyGiaoVien.Click += new System.EventHandler(this.QlyGiaoVien_Click);
            // 
            // phanMon
            // 
            this.phanMon.Name = "phanMon";
            this.phanMon.Size = new System.Drawing.Size(319, 34);
            this.phanMon.Text = "PHÂN MÔN";
            this.phanMon.Click += new System.EventHandler(this.phanMon_Click);
            // 
            // HocVien
            // 
            this.HocVien.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QlyHocVien,
            this.chiaLop});
            this.HocVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.HocVien.Name = "HocVien";
            this.HocVien.Size = new System.Drawing.Size(114, 29);
            this.HocVien.Text = "HỌC VIÊN";
            this.HocVien.Click += new System.EventHandler(this.HocVien_Click);
            // 
            // QlyHocVien
            // 
            this.QlyHocVien.Name = "QlyHocVien";
            this.QlyHocVien.Size = new System.Drawing.Size(312, 34);
            this.QlyHocVien.Text = "DANH SÁCH HỌC VIÊN";
            this.QlyHocVien.Click += new System.EventHandler(this.QlyHocVien_Click);
            // 
            // chiaLop
            // 
            this.chiaLop.Name = "chiaLop";
            this.chiaLop.Size = new System.Drawing.Size(312, 34);
            this.chiaLop.Text = "PHÂN LỚP HỌC VIÊN";
            this.chiaLop.Click += new System.EventHandler(this.chiaLop_Click);
            // 
            // CauHoi
            // 
            this.CauHoi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qlyCauHoi});
            this.CauHoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.CauHoi.Name = "CauHoi";
            this.CauHoi.Size = new System.Drawing.Size(104, 29);
            this.CauHoi.Text = "CÂU HỎI";
            this.CauHoi.Click += new System.EventHandler(this.CauHoi_Click);
            // 
            // qlyCauHoi
            // 
            this.qlyCauHoi.Name = "qlyCauHoi";
            this.qlyCauHoi.Size = new System.Drawing.Size(308, 34);
            this.qlyCauHoi.Text = "NGÂN HÀNG CÂU HỎI";
            this.qlyCauHoi.Click += new System.EventHandler(this.nGÂNHÀNGCÂUHỎIToolStripMenuItem_Click);
            // 
            // DeThi
            // 
            this.DeThi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taoDeThi,
            this.qlyDeThi});
            this.DeThi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.DeThi.Name = "DeThi";
            this.DeThi.Size = new System.Drawing.Size(87, 29);
            this.DeThi.Text = "ĐỀ THI";
            // 
            // taoDeThi
            // 
            this.taoDeThi.Name = "taoDeThi";
            this.taoDeThi.Size = new System.Drawing.Size(256, 34);
            this.taoDeThi.Text = "TẠO ĐỀ THI";
            this.taoDeThi.Click += new System.EventHandler(this.taoDeThi_Click);
            // 
            // qlyDeThi
            // 
            this.qlyDeThi.Name = "qlyDeThi";
            this.qlyDeThi.Size = new System.Drawing.Size(256, 34);
            this.qlyDeThi.Text = "QUẢN LÝ ĐỀ THI";
            this.qlyDeThi.Click += new System.EventHandler(this.qlyDeThi_Click);
            // 
            // LichThi
            // 
            this.LichThi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QlyKyThi,
            this.taoKyThi});
            this.LichThi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.LichThi.Name = "LichThi";
            this.LichThi.Size = new System.Drawing.Size(87, 29);
            this.LichThi.Text = "KỲ THI";
            // 
            // QlyKyThi
            // 
            this.QlyKyThi.Name = "QlyKyThi";
            this.QlyKyThi.Size = new System.Drawing.Size(285, 34);
            this.QlyKyThi.Text = "DANH SÁCH KỲ THI";
            this.QlyKyThi.Click += new System.EventHandler(this.QlyKyThi_Click);
            // 
            // taoKyThi
            // 
            this.taoKyThi.Name = "taoKyThi";
            this.taoKyThi.Size = new System.Drawing.Size(285, 34);
            this.taoKyThi.Text = "TẠO KỲ THI";
            this.taoKyThi.Click += new System.EventHandler(this.taoKyThi_Click);
            // 
            // KH
            // 
            this.KH.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taoKhoaHoc,
            this.qlyKhoaHoc});
            this.KH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.KH.Name = "KH";
            this.KH.Size = new System.Drawing.Size(125, 29);
            this.KH.Text = "KHÓA HỌC";
            // 
            // taoKhoaHoc
            // 
            this.taoKhoaHoc.Name = "taoKhoaHoc";
            this.taoKhoaHoc.Size = new System.Drawing.Size(294, 34);
            this.taoKhoaHoc.Text = "TẠO KHÓA HỌC";
            this.taoKhoaHoc.Click += new System.EventHandler(this.taoKhoaHoc_Click);
            // 
            // qlyKhoaHoc
            // 
            this.qlyKhoaHoc.Name = "qlyKhoaHoc";
            this.qlyKhoaHoc.Size = new System.Drawing.Size(294, 34);
            this.qlyKhoaHoc.Text = "QUẢN LÝ KHÓA HỌC";
            this.qlyKhoaHoc.Click += new System.EventHandler(this.qlyKhoaHoc_Click);
            // 
            // ThongKe
            // 
            this.ThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chiTiet,
            this.ketQua});
            this.ThongKe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ThongKe.Name = "ThongKe";
            this.ThongKe.Size = new System.Drawing.Size(121, 29);
            this.ThongKe.Text = "THỐNG KÊ";
            // 
            // chiTiet
            // 
            this.chiTiet.Name = "chiTiet";
            this.chiTiet.Size = new System.Drawing.Size(290, 34);
            this.chiTiet.Text = "THỐNG KÊ CHI TIẾT";
            this.chiTiet.Click += new System.EventHandler(this.chiTiet_Click);
            // 
            // ketQua
            // 
            this.ketQua.Name = "ketQua";
            this.ketQua.Size = new System.Drawing.Size(290, 34);
            this.ketQua.Text = "THỐNG KÊ KẾT QUẢ";
            this.ketQua.Click += new System.EventHandler(this.ketQua_Click);
            // 
            // SaoLuu
            // 
            this.SaoLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.SaoLuu.Name = "SaoLuu";
            this.SaoLuu.Size = new System.Drawing.Size(106, 29);
            this.SaoLuu.Text = "SAO LƯU";
            // 
            // panelNoiDung
            // 
            this.panelNoiDung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panelNoiDung.Location = new System.Drawing.Point(0, 105);
            this.panelNoiDung.Name = "panelNoiDung";
            this.panelNoiDung.Size = new System.Drawing.Size(1329, 712);
            this.panelNoiDung.TabIndex = 3;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.Transparent;
            this.btnDangXuat.BorderColor = System.Drawing.Color.Transparent;
            this.btnDangXuat.BorderRadius = 5;
            this.btnDangXuat.DefaultAutoSize = true;
            this.btnDangXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangXuat.FillColor = System.Drawing.Color.Transparent;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Image = global::Winform_KLCN.Properties.Resources.logout_white;
            this.btnDangXuat.Location = new System.Drawing.Point(1101, 14);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(158, 39);
            this.btnDangXuat.TabIndex = 5;
            this.btnDangXuat.Text = " Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // ManHinhAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(234)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1329, 817);
            this.Controls.Add(this.panelNoiDung);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.menuAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManHinhAdmin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.ManHinhAdmin_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.menuAdmin.ResumeLayout(false);
            this.menuAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnDangXuat;
        private System.Windows.Forms.Label lblXinChao;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.MenuStrip menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem TaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem GiaoVien;
        private System.Windows.Forms.ToolStripMenuItem HocVien;
        private System.Windows.Forms.ToolStripMenuItem CauHoi;
        private System.Windows.Forms.ToolStripMenuItem DeThi;
        private System.Windows.Forms.ToolStripMenuItem LichThi;
        private System.Windows.Forms.ToolStripMenuItem QlyTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem themTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem ThongKe;
        private System.Windows.Forms.ToolStripMenuItem themGiaoVien;
        private System.Windows.Forms.ToolStripMenuItem themHocVien;
        private System.Windows.Forms.ToolStripMenuItem SaoLuu;
        private Guna.UI2.WinForms.Guna2Panel panelNoiDung;
        private System.Windows.Forms.ToolStripMenuItem QlyGiaoVien;
        private System.Windows.Forms.ToolStripMenuItem QlyHocVien;
        private System.Windows.Forms.ToolStripMenuItem themAdmin;
        private System.Windows.Forms.ToolStripMenuItem chiaLop;
        private System.Windows.Forms.ToolStripMenuItem qlyCauHoi;
        private System.Windows.Forms.ToolStripMenuItem taoDeThi;
        private System.Windows.Forms.ToolStripMenuItem qlyDeThi;
        private System.Windows.Forms.ToolStripMenuItem QlyKyThi;
        private System.Windows.Forms.ToolStripMenuItem taoKyThi;
        private System.Windows.Forms.ToolStripMenuItem chiTiet;
        private System.Windows.Forms.ToolStripMenuItem ketQua;
        private System.Windows.Forms.ToolStripMenuItem KH;
        private System.Windows.Forms.ToolStripMenuItem taoKhoaHoc;
        private System.Windows.Forms.ToolStripMenuItem qlyKhoaHoc;
        private System.Windows.Forms.ToolStripMenuItem phanMon;
    }
}