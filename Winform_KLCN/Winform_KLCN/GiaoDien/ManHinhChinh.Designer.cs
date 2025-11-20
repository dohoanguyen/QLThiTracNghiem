namespace Winform_KLCN.GiaoDien
{
    partial class ManHinhChinh
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManHinhChinh));
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.lblXinChao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThongTin = new Guna.UI2.WinForms.Guna2Button();
            this.btnCauHoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnHocVien = new Guna.UI2.WinForms.Guna2Button();
            this.btnLopHoc = new Guna.UI2.WinForms.Guna2Button();
            this.btnTrangChu = new Guna.UI2.WinForms.Guna2Button();
            this.timerMenu = new System.Windows.Forms.Timer(this.components);
            this.panelNoiDung = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.guna2GradientPanel1.Controls.Add(this.btnDangXuat);
            this.guna2GradientPanel1.Controls.Add(this.lblXinChao);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(886, 42);
            this.guna2GradientPanel1.TabIndex = 0;
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
            this.btnDangXuat.Location = new System.Drawing.Point(750, 7);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(2);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(134, 27);
            this.btnDangXuat.TabIndex = 5;
            this.btnDangXuat.Text = "🚪  Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // lblXinChao
            // 
            this.lblXinChao.AutoSize = true;
            this.lblXinChao.Font = new System.Drawing.Font("Arial", 10.2F);
            this.lblXinChao.ForeColor = System.Drawing.Color.White;
            this.lblXinChao.Location = new System.Drawing.Point(11, 13);
            this.lblXinChao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblXinChao.Name = "lblXinChao";
            this.lblXinChao.Size = new System.Drawing.Size(146, 16);
            this.lblXinChao.TabIndex = 2;
            this.lblXinChao.Text = "Xin chào GV : Tên GV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.2F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(226, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "HỆ THỐNG QUẢN LÝ CỦA TRUNG TÂM TUQ";
            // 
            // btnThongTin
            // 
            this.btnThongTin.BorderRadius = 20;
            this.btnThongTin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongTin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongTin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongTin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongTin.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongTin.ForeColor = System.Drawing.Color.White;
            this.btnThongTin.Location = new System.Drawing.Point(539, 46);
            this.btnThongTin.Margin = new System.Windows.Forms.Padding(2);
            this.btnThongTin.Name = "btnThongTin";
            this.btnThongTin.Size = new System.Drawing.Size(128, 41);
            this.btnThongTin.TabIndex = 6;
            this.btnThongTin.Text = " 👤 Thông tin";
            this.btnThongTin.Click += new System.EventHandler(this.btnThongTin_Click);
            // 
            // btnCauHoi
            // 
            this.btnCauHoi.BorderRadius = 20;
            this.btnCauHoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCauHoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCauHoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCauHoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCauHoi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCauHoi.ForeColor = System.Drawing.Color.White;
            this.btnCauHoi.Location = new System.Drawing.Point(275, 46);
            this.btnCauHoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnCauHoi.Name = "btnCauHoi";
            this.btnCauHoi.Size = new System.Drawing.Size(128, 41);
            this.btnCauHoi.TabIndex = 4;
            this.btnCauHoi.Text = "❓  Câu hỏi";
            this.btnCauHoi.Click += new System.EventHandler(this.btnCauHoi_Click);
            // 
            // btnHocVien
            // 
            this.btnHocVien.BorderRadius = 20;
            this.btnHocVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHocVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHocVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHocVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHocVien.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHocVien.ForeColor = System.Drawing.Color.White;
            this.btnHocVien.Location = new System.Drawing.Point(143, 46);
            this.btnHocVien.Margin = new System.Windows.Forms.Padding(2);
            this.btnHocVien.Name = "btnHocVien";
            this.btnHocVien.Size = new System.Drawing.Size(128, 41);
            this.btnHocVien.TabIndex = 3;
            this.btnHocVien.Text = "🎓  Học viên";
            this.btnHocVien.Click += new System.EventHandler(this.btnHocVien_Click);
            // 
            // btnLopHoc
            // 
            this.btnLopHoc.BorderRadius = 20;
            this.btnLopHoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLopHoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLopHoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLopHoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLopHoc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLopHoc.ForeColor = System.Drawing.Color.White;
            this.btnLopHoc.Location = new System.Drawing.Point(407, 46);
            this.btnLopHoc.Margin = new System.Windows.Forms.Padding(2);
            this.btnLopHoc.Name = "btnLopHoc";
            this.btnLopHoc.Size = new System.Drawing.Size(128, 41);
            this.btnLopHoc.TabIndex = 2;
            this.btnLopHoc.Text = "🏫 Lớp học";
            this.btnLopHoc.Click += new System.EventHandler(this.btnLopHoc_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.BorderRadius = 20;
            this.btnTrangChu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTrangChu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTrangChu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTrangChu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTrangChu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTrangChu.ForeColor = System.Drawing.Color.White;
            this.btnTrangChu.Location = new System.Drawing.Point(11, 46);
            this.btnTrangChu.Margin = new System.Windows.Forms.Padding(2);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(128, 41);
            this.btnTrangChu.TabIndex = 1;
            this.btnTrangChu.Text = "🏠  Trang chủ";
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // panelNoiDung
            // 
            this.panelNoiDung.Location = new System.Drawing.Point(0, 91);
            this.panelNoiDung.Margin = new System.Windows.Forms.Padding(2);
            this.panelNoiDung.Name = "panelNoiDung";
            this.panelNoiDung.Size = new System.Drawing.Size(886, 439);
            this.panelNoiDung.TabIndex = 1;
            // 
            // ManHinhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(886, 531);
            this.Controls.Add(this.btnThongTin);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.btnLopHoc);
            this.Controls.Add(this.btnTrangChu);
            this.Controls.Add(this.btnCauHoi);
            this.Controls.Add(this.panelNoiDung);
            this.Controls.Add(this.btnHocVien);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ManHinhChinh";
            this.Text = "Màn Hình Chính";
            this.Load += new System.EventHandler(this.ManHinhChinh_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnDangXuat;
        private Guna.UI2.WinForms.Guna2Button btnCauHoi;
        private Guna.UI2.WinForms.Guna2Button btnHocVien;
        private Guna.UI2.WinForms.Guna2Button btnLopHoc;
        private Guna.UI2.WinForms.Guna2Button btnTrangChu;
        private Guna.UI2.WinForms.Guna2Button btnThongTin;
        private System.Windows.Forms.Label lblXinChao;
        private System.Windows.Forms.Timer timerMenu;
        private Guna.UI2.WinForms.Guna2Panel panelNoiDung;
    }
}