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
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.lblXinChao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.menuAdmin = new System.Windows.Forms.MenuStrip();
            this.TaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.QlyTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.themTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.themGiaoVien = new System.Windows.Forms.ToolStripMenuItem();
            this.themHocVien = new System.Windows.Forms.ToolStripMenuItem();
            this.GiaoVien = new System.Windows.Forms.ToolStripMenuItem();
            this.HocVien = new System.Windows.Forms.ToolStripMenuItem();
            this.CauHoi = new System.Windows.Forms.ToolStripMenuItem();
            this.DeThi = new System.Windows.Forms.ToolStripMenuItem();
            this.LichThi = new System.Windows.Forms.ToolStripMenuItem();
            this.KyThi = new System.Windows.Forms.ToolStripMenuItem();
            this.KhoaHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.LopHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.MonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.ThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.SaoLuu = new System.Windows.Forms.ToolStripMenuItem();
            this.panelNoiDung = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2GradientPanel1.SuspendLayout();
            this.menuAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BorderColor = System.Drawing.Color.Transparent;
            this.btnDangXuat.BorderRadius = 5;
            this.btnDangXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangXuat.FillColor = System.Drawing.Color.Transparent;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(991, 9);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(179, 33);
            this.btnDangXuat.TabIndex = 5;
            this.btnDangXuat.Text = "🚪  Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // lblXinChao
            // 
            this.lblXinChao.AutoSize = true;
            this.lblXinChao.Font = new System.Drawing.Font("Arial", 10.2F);
            this.lblXinChao.ForeColor = System.Drawing.Color.White;
            this.lblXinChao.Location = new System.Drawing.Point(39, 17);
            this.lblXinChao.Name = "lblXinChao";
            this.lblXinChao.Size = new System.Drawing.Size(130, 19);
            this.lblXinChao.TabIndex = 2;
            this.lblXinChao.Text = "Xin chào ADMIN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.2F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(385, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "TRUNG TÂM QUẢN LÝ CỦA TUQ";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(0)))), ((int)(((byte)(172)))));
            this.guna2GradientPanel1.Controls.Add(this.btnDangXuat);
            this.guna2GradientPanel1.Controls.Add(this.lblXinChao);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1182, 52);
            this.guna2GradientPanel1.TabIndex = 1;
            // 
            // menuAdmin
            // 
            this.menuAdmin.BackColor = System.Drawing.Color.Transparent;
            this.menuAdmin.Dock = System.Windows.Forms.DockStyle.None;
            this.menuAdmin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.menuAdmin.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TaiKhoan,
            this.GiaoVien,
            this.HocVien,
            this.CauHoi,
            this.DeThi,
            this.LichThi,
            this.KyThi,
            this.KhoaHoc,
            this.LopHoc,
            this.MonHoc,
            this.ThongKe,
            this.SaoLuu});
            this.menuAdmin.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuAdmin.Location = new System.Drawing.Point(0, 55);
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(1098, 26);
            this.menuAdmin.TabIndex = 2;
            this.menuAdmin.Text = "menuAdmin";
            // 
            // TaiKhoan
            // 
            this.TaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QlyTaiKhoan,
            this.themTaiKhoan});
            this.TaiKhoan.Name = "TaiKhoan";
            this.TaiKhoan.Size = new System.Drawing.Size(103, 22);
            this.TaiKhoan.Text = "TÀI KHOẢN";
            this.TaiKhoan.Click += new System.EventHandler(this.gIÁOVIÊNToolStripMenuItem_Click);
            // 
            // QlyTaiKhoan
            // 
            this.QlyTaiKhoan.Name = "QlyTaiKhoan";
            this.QlyTaiKhoan.Size = new System.Drawing.Size(241, 26);
            this.QlyTaiKhoan.Text = "QUẢN LÝ TÀI KHOẢN";
            // 
            // themTaiKhoan
            // 
            this.themTaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themGiaoVien,
            this.themHocVien});
            this.themTaiKhoan.Name = "themTaiKhoan";
            this.themTaiKhoan.Size = new System.Drawing.Size(241, 26);
            this.themTaiKhoan.Text = "THÊM TÀI KHOẢN";
            // 
            // themGiaoVien
            // 
            this.themGiaoVien.Name = "themGiaoVien";
            this.themGiaoVien.Size = new System.Drawing.Size(165, 26);
            this.themGiaoVien.Text = "GIÁO VIÊN";
            // 
            // themHocVien
            // 
            this.themHocVien.Name = "themHocVien";
            this.themHocVien.Size = new System.Drawing.Size(165, 26);
            this.themHocVien.Text = "HỌC VIÊN";
            // 
            // GiaoVien
            // 
            this.GiaoVien.Name = "GiaoVien";
            this.GiaoVien.Size = new System.Drawing.Size(97, 22);
            this.GiaoVien.Text = "GIÁO VIÊN";
            this.GiaoVien.Click += new System.EventHandler(this.GiaoVien_Click);
            // 
            // HocVien
            // 
            this.HocVien.Name = "HocVien";
            this.HocVien.Size = new System.Drawing.Size(94, 22);
            this.HocVien.Text = "HỌC VIÊN";
            // 
            // CauHoi
            // 
            this.CauHoi.Name = "CauHoi";
            this.CauHoi.Size = new System.Drawing.Size(84, 22);
            this.CauHoi.Text = "CÂU HỎI";
            // 
            // DeThi
            // 
            this.DeThi.Name = "DeThi";
            this.DeThi.Size = new System.Drawing.Size(72, 22);
            this.DeThi.Text = "ĐỀ THI";
            // 
            // LichThi
            // 
            this.LichThi.Name = "LichThi";
            this.LichThi.Size = new System.Drawing.Size(86, 22);
            this.LichThi.Text = "LỊCH THI";
            // 
            // KyThi
            // 
            this.KyThi.Name = "KyThi";
            this.KyThi.Size = new System.Drawing.Size(72, 22);
            this.KyThi.Text = "KỲ THI";
            // 
            // KhoaHoc
            // 
            this.KhoaHoc.Name = "KhoaHoc";
            this.KhoaHoc.Size = new System.Drawing.Size(102, 22);
            this.KhoaHoc.Text = "KHÓA HỌC";
            this.KhoaHoc.Click += new System.EventHandler(this.lỚPToolStripMenuItem_Click);
            // 
            // LopHoc
            // 
            this.LopHoc.Name = "LopHoc";
            this.LopHoc.Size = new System.Drawing.Size(92, 22);
            this.LopHoc.Text = "LỚP HỌC";
            // 
            // MonHoc
            // 
            this.MonHoc.Name = "MonHoc";
            this.MonHoc.Size = new System.Drawing.Size(96, 22);
            this.MonHoc.Text = "MÔN HỌC";
            // 
            // ThongKe
            // 
            this.ThongKe.Name = "ThongKe";
            this.ThongKe.Size = new System.Drawing.Size(103, 22);
            this.ThongKe.Text = "THỐNG KÊ";
            // 
            // SaoLuu
            // 
            this.SaoLuu.Name = "SaoLuu";
            this.SaoLuu.Size = new System.Drawing.Size(89, 22);
            this.SaoLuu.Text = "SAO LƯU";
            // 
            // panelNoiDung
            // 
            this.panelNoiDung.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelNoiDung.Location = new System.Drawing.Point(0, 84);
            this.panelNoiDung.Name = "panelNoiDung";
            this.panelNoiDung.Size = new System.Drawing.Size(1182, 570);
            this.panelNoiDung.TabIndex = 3;
            // 
            // ManHinhAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
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
        private System.Windows.Forms.ToolStripMenuItem KyThi;
        private System.Windows.Forms.ToolStripMenuItem KhoaHoc;
        private System.Windows.Forms.ToolStripMenuItem QlyTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem themTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem LopHoc;
        private System.Windows.Forms.ToolStripMenuItem MonHoc;
        private System.Windows.Forms.ToolStripMenuItem ThongKe;
        private System.Windows.Forms.ToolStripMenuItem themGiaoVien;
        private System.Windows.Forms.ToolStripMenuItem themHocVien;
        private System.Windows.Forms.ToolStripMenuItem SaoLuu;
        private Guna.UI2.WinForms.Guna2Panel panelNoiDung;
    }
}