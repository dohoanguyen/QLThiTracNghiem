namespace Winform_KLCN.ChucNangAdmin
{
    partial class taoKyThi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(taoKyThi));
            this.dtpNgayBatDau = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpNgayKetThuc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtTenKyThi = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvKyThiChuaHoanThien = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.cboKhoaHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtMoTa = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThemLichThi = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKyThiChuaHoanThien)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Checked = true;
            this.dtpNgayBatDau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(21, 22);
            this.dtpNgayBatDau.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayBatDau.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(200, 36);
            this.dtpNgayBatDau.TabIndex = 0;
            this.dtpNgayBatDau.Value = new System.DateTime(2025, 11, 6, 11, 44, 3, 420);
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Checked = true;
            this.dtpNgayKetThuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(21, 76);
            this.dtpNgayKetThuc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayKetThuc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(200, 36);
            this.dtpNgayKetThuc.TabIndex = 1;
            this.dtpNgayKetThuc.Value = new System.DateTime(2025, 11, 6, 11, 44, 3, 420);
            // 
            // txtTenKyThi
            // 
            this.txtTenKyThi.BorderRadius = 20;
            this.txtTenKyThi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenKyThi.CustomizableEdges.BottomLeft = false;
            this.txtTenKyThi.DefaultText = "";
            this.txtTenKyThi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenKyThi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenKyThi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenKyThi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenKyThi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenKyThi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenKyThi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenKyThi.Location = new System.Drawing.Point(21, 137);
            this.txtTenKyThi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenKyThi.Name = "txtTenKyThi";
            this.txtTenKyThi.PlaceholderText = "";
            this.txtTenKyThi.SelectedText = "";
            this.txtTenKyThi.Size = new System.Drawing.Size(169, 45);
            this.txtTenKyThi.TabIndex = 31;
            // 
            // dgvKyThiChuaHoanThien
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvKyThiChuaHoanThien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKyThiChuaHoanThien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKyThiChuaHoanThien.ColumnHeadersHeight = 4;
            this.dgvKyThiChuaHoanThien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKyThiChuaHoanThien.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKyThiChuaHoanThien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKyThiChuaHoanThien.Location = new System.Drawing.Point(522, 34);
            this.dgvKyThiChuaHoanThien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvKyThiChuaHoanThien.Name = "dgvKyThiChuaHoanThien";
            this.dgvKyThiChuaHoanThien.RowHeadersVisible = false;
            this.dgvKyThiChuaHoanThien.RowHeadersWidth = 51;
            this.dgvKyThiChuaHoanThien.RowTemplate.Height = 24;
            this.dgvKyThiChuaHoanThien.Size = new System.Drawing.Size(630, 446);
            this.dgvKyThiChuaHoanThien.TabIndex = 32;
            this.dgvKyThiChuaHoanThien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKyThiChuaHoanThien.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvKyThiChuaHoanThien.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvKyThiChuaHoanThien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvKyThiChuaHoanThien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvKyThiChuaHoanThien.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvKyThiChuaHoanThien.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKyThiChuaHoanThien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvKyThiChuaHoanThien.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKyThiChuaHoanThien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvKyThiChuaHoanThien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvKyThiChuaHoanThien.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvKyThiChuaHoanThien.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvKyThiChuaHoanThien.ThemeStyle.ReadOnly = false;
            this.dgvKyThiChuaHoanThien.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKyThiChuaHoanThien.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKyThiChuaHoanThien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvKyThiChuaHoanThien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvKyThiChuaHoanThien.ThemeStyle.RowsStyle.Height = 24;
            this.dgvKyThiChuaHoanThien.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKyThiChuaHoanThien.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BorderRadius = 20;
            this.btnXacNhan.CustomizableEdges.BottomLeft = false;
            this.btnXacNhan.CustomizableEdges.TopRight = false;
            this.btnXacNhan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXacNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXacNhan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(21, 283);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(174, 46);
            this.btnXacNhan.TabIndex = 33;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // cboKhoaHoc
            // 
            this.cboKhoaHoc.BackColor = System.Drawing.Color.Transparent;
            this.cboKhoaHoc.BorderRadius = 20;
            this.cboKhoaHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboKhoaHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaHoc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboKhoaHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboKhoaHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboKhoaHoc.ItemHeight = 30;
            this.cboKhoaHoc.Location = new System.Drawing.Point(21, 211);
            this.cboKhoaHoc.Name = "cboKhoaHoc";
            this.cboKhoaHoc.Size = new System.Drawing.Size(260, 36);
            this.cboKhoaHoc.TabIndex = 34;
            // 
            // txtMoTa
            // 
            this.txtMoTa.BorderRadius = 20;
            this.txtMoTa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMoTa.CustomizableEdges.BottomLeft = false;
            this.txtMoTa.DefaultText = "";
            this.txtMoTa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMoTa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMoTa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMoTa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMoTa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMoTa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMoTa.Location = new System.Drawing.Point(264, 137);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.PlaceholderText = "";
            this.txtMoTa.SelectedText = "";
            this.txtMoTa.Size = new System.Drawing.Size(169, 45);
            this.txtMoTa.TabIndex = 35;
            // 
            // btnThemLichThi
            // 
            this.btnThemLichThi.BorderRadius = 20;
            this.btnThemLichThi.CustomizableEdges.BottomLeft = false;
            this.btnThemLichThi.CustomizableEdges.TopRight = false;
            this.btnThemLichThi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemLichThi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemLichThi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemLichThi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemLichThi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnThemLichThi.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThemLichThi.ForeColor = System.Drawing.Color.White;
            this.btnThemLichThi.Location = new System.Drawing.Point(222, 283);
            this.btnThemLichThi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemLichThi.Name = "btnThemLichThi";
            this.btnThemLichThi.Size = new System.Drawing.Size(174, 46);
            this.btnThemLichThi.TabIndex = 36;
            this.btnThemLichThi.Text = "Thêm Lịch Thi";
            this.btnThemLichThi.Click += new System.EventHandler(this.btnThemLichThi_Click_1);
            // 
            // taoKyThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 523);
            this.Controls.Add(this.btnThemLichThi);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.cboKhoaHoc);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.dgvKyThiChuaHoanThien);
            this.Controls.Add(this.txtTenKyThi);
            this.Controls.Add(this.dtpNgayKetThuc);
            this.Controls.Add(this.dtpNgayBatDau);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "taoKyThi";
            this.Text = "taoKyThi";
            this.Load += new System.EventHandler(this.taoKyThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKyThiChuaHoanThien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayBatDau;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayKetThuc;
        private Guna.UI2.WinForms.Guna2TextBox txtTenKyThi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvKyThiChuaHoanThien;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2ComboBox cboKhoaHoc;
        private Guna.UI2.WinForms.Guna2TextBox txtMoTa;
        private Guna.UI2.WinForms.Guna2Button btnThemLichThi;
    }
}