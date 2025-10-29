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
            this.gIÁOVIÊNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hỌCVIÊNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cÂUHỎIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đỀTHIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lỊCHTHIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kỲTHIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kHÓAHỌCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lỚPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mÔNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tHÊMGIÁOVIÊNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mÔNHỌCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tHỐNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tÀIKHOẢNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.gIÁOVIÊNToolStripMenuItem,
            this.hỌCVIÊNToolStripMenuItem,
            this.cÂUHỎIToolStripMenuItem,
            this.đỀTHIToolStripMenuItem,
            this.lỊCHTHIToolStripMenuItem,
            this.kỲTHIToolStripMenuItem,
            this.kHÓAHỌCToolStripMenuItem,
            this.lỚPToolStripMenuItem,
            this.mÔNHỌCToolStripMenuItem,
            this.tHỐNGToolStripMenuItem,
            this.tÀIKHOẢNToolStripMenuItem});
            this.menuAdmin.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuAdmin.Location = new System.Drawing.Point(0, 55);
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(1159, 28);
            this.menuAdmin.TabIndex = 2;
            this.menuAdmin.Text = "menuAdmin";
            // 
            // gIÁOVIÊNToolStripMenuItem
            // 
            this.gIÁOVIÊNToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mÔNToolStripMenuItem,
            this.tHÊMGIÁOVIÊNToolStripMenuItem});
            this.gIÁOVIÊNToolStripMenuItem.Name = "gIÁOVIÊNToolStripMenuItem";
            this.gIÁOVIÊNToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.gIÁOVIÊNToolStripMenuItem.Text = "TÀI KHOẢN";
            this.gIÁOVIÊNToolStripMenuItem.Click += new System.EventHandler(this.gIÁOVIÊNToolStripMenuItem_Click);
            // 
            // hỌCVIÊNToolStripMenuItem
            // 
            this.hỌCVIÊNToolStripMenuItem.Name = "hỌCVIÊNToolStripMenuItem";
            this.hỌCVIÊNToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.hỌCVIÊNToolStripMenuItem.Text = "GIÁO VIÊN";
            // 
            // cÂUHỎIToolStripMenuItem
            // 
            this.cÂUHỎIToolStripMenuItem.Name = "cÂUHỎIToolStripMenuItem";
            this.cÂUHỎIToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.cÂUHỎIToolStripMenuItem.Text = "HỌC VIÊN";
            // 
            // đỀTHIToolStripMenuItem
            // 
            this.đỀTHIToolStripMenuItem.Name = "đỀTHIToolStripMenuItem";
            this.đỀTHIToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.đỀTHIToolStripMenuItem.Text = "CÂU HỎI";
            // 
            // lỊCHTHIToolStripMenuItem
            // 
            this.lỊCHTHIToolStripMenuItem.Name = "lỊCHTHIToolStripMenuItem";
            this.lỊCHTHIToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.lỊCHTHIToolStripMenuItem.Text = "ĐỀ THI";
            // 
            // kỲTHIToolStripMenuItem
            // 
            this.kỲTHIToolStripMenuItem.Name = "kỲTHIToolStripMenuItem";
            this.kỲTHIToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.kỲTHIToolStripMenuItem.Text = "LỊCH THI";
            // 
            // kHÓAHỌCToolStripMenuItem
            // 
            this.kHÓAHỌCToolStripMenuItem.Name = "kHÓAHỌCToolStripMenuItem";
            this.kHÓAHỌCToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.kHÓAHỌCToolStripMenuItem.Text = "KỲ THI";
            // 
            // lỚPToolStripMenuItem
            // 
            this.lỚPToolStripMenuItem.Name = "lỚPToolStripMenuItem";
            this.lỚPToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.lỚPToolStripMenuItem.Text = "KHÓA HỌC";
            this.lỚPToolStripMenuItem.Click += new System.EventHandler(this.lỚPToolStripMenuItem_Click);
            // 
            // mÔNToolStripMenuItem
            // 
            this.mÔNToolStripMenuItem.Name = "mÔNToolStripMenuItem";
            this.mÔNToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.mÔNToolStripMenuItem.Text = "QUẢN LÝ TÀI KHOẢN";
            // 
            // tHÊMGIÁOVIÊNToolStripMenuItem
            // 
            this.tHÊMGIÁOVIÊNToolStripMenuItem.Name = "tHÊMGIÁOVIÊNToolStripMenuItem";
            this.tHÊMGIÁOVIÊNToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.tHÊMGIÁOVIÊNToolStripMenuItem.Text = "THÊM TÀI KHOẢN";
            // 
            // mÔNHỌCToolStripMenuItem
            // 
            this.mÔNHỌCToolStripMenuItem.Name = "mÔNHỌCToolStripMenuItem";
            this.mÔNHỌCToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.mÔNHỌCToolStripMenuItem.Text = "LỚP HỌC";
            // 
            // tHỐNGToolStripMenuItem
            // 
            this.tHỐNGToolStripMenuItem.Name = "tHỐNGToolStripMenuItem";
            this.tHỐNGToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.tHỐNGToolStripMenuItem.Text = "MÔN HỌC";
            // 
            // tÀIKHOẢNToolStripMenuItem
            // 
            this.tÀIKHOẢNToolStripMenuItem.Name = "tÀIKHOẢNToolStripMenuItem";
            this.tÀIKHOẢNToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.tÀIKHOẢNToolStripMenuItem.Text = "THỐNG KÊ";
            // 
            // ManHinhAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
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
        private System.Windows.Forms.ToolStripMenuItem gIÁOVIÊNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hỌCVIÊNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cÂUHỎIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đỀTHIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lỊCHTHIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kỲTHIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kHÓAHỌCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lỚPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mÔNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tHÊMGIÁOVIÊNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mÔNHỌCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tHỐNGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tÀIKHOẢNToolStripMenuItem;
    }
}