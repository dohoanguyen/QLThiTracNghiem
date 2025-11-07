namespace Winform_KLCN.ChucNangAdmin
{
    partial class taoKhoaHoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(taoKhoaHoc));
            this.txtTenKhoa = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.dgvKhoaHocChuaHoanThien = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtNamHoc = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpNgayKetThuc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpNgayBatDau = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoaHocChuaHoanThien)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTenKhoa
            // 
            this.txtTenKhoa.BorderRadius = 20;
            this.txtTenKhoa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenKhoa.CustomizableEdges.BottomLeft = false;
            this.txtTenKhoa.DefaultText = "";
            this.txtTenKhoa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenKhoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenKhoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenKhoa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenKhoa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenKhoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenKhoa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenKhoa.Location = new System.Drawing.Point(127, 125);
            this.txtTenKhoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenKhoa.Name = "txtTenKhoa";
            this.txtTenKhoa.PlaceholderText = "";
            this.txtTenKhoa.SelectedText = "";
            this.txtTenKhoa.Size = new System.Drawing.Size(169, 45);
            this.txtTenKhoa.TabIndex = 35;
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
            this.btnXacNhan.Location = new System.Drawing.Point(48, 389);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(228, 46);
            this.btnXacNhan.TabIndex = 34;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // dgvKhoaHocChuaHoanThien
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvKhoaHocChuaHoanThien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhoaHocChuaHoanThien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKhoaHocChuaHoanThien.ColumnHeadersHeight = 4;
            this.dgvKhoaHocChuaHoanThien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKhoaHocChuaHoanThien.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKhoaHocChuaHoanThien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKhoaHocChuaHoanThien.Location = new System.Drawing.Point(325, 54);
            this.dgvKhoaHocChuaHoanThien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvKhoaHocChuaHoanThien.Name = "dgvKhoaHocChuaHoanThien";
            this.dgvKhoaHocChuaHoanThien.RowHeadersVisible = false;
            this.dgvKhoaHocChuaHoanThien.RowHeadersWidth = 51;
            this.dgvKhoaHocChuaHoanThien.RowTemplate.Height = 24;
            this.dgvKhoaHocChuaHoanThien.Size = new System.Drawing.Size(818, 446);
            this.dgvKhoaHocChuaHoanThien.TabIndex = 33;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.ReadOnly = false;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.RowsStyle.Height = 24;
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKhoaHocChuaHoanThien.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // txtNamHoc
            // 
            this.txtNamHoc.BorderRadius = 20;
            this.txtNamHoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNamHoc.CustomizableEdges.BottomLeft = false;
            this.txtNamHoc.DefaultText = "";
            this.txtNamHoc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNamHoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNamHoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNamHoc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNamHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNamHoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNamHoc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNamHoc.Location = new System.Drawing.Point(127, 196);
            this.txtNamHoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNamHoc.Name = "txtNamHoc";
            this.txtNamHoc.PlaceholderText = "";
            this.txtNamHoc.SelectedText = "";
            this.txtNamHoc.Size = new System.Drawing.Size(169, 45);
            this.txtNamHoc.TabIndex = 37;
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Checked = true;
            this.dtpNgayKetThuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(141, 334);
            this.dtpNgayKetThuc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayKetThuc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(135, 36);
            this.dtpNgayKetThuc.TabIndex = 39;
            this.dtpNgayKetThuc.Value = new System.DateTime(2025, 11, 6, 11, 44, 3, 420);
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Checked = true;
            this.dtpNgayBatDau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(141, 274);
            this.dtpNgayBatDau.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayBatDau.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(135, 36);
            this.dtpNgayBatDau.TabIndex = 38;
            this.dtpNgayBatDau.Value = new System.DateTime(2025, 11, 6, 11, 44, 3, 420);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(648, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(286, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "KHÓA HỌC CHƯA HOÀN THIỆN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 40;
            this.label1.Text = "TÊN KHÓA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 42;
            this.label2.Text = "NĂM HỌC:";
            // 
            // taoKhoaHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1164, 523);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpNgayKetThuc);
            this.Controls.Add(this.dtpNgayBatDau);
            this.Controls.Add(this.txtNamHoc);
            this.Controls.Add(this.txtTenKhoa);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.dgvKhoaHocChuaHoanThien);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "taoKhoaHoc";
            this.Text = "taoKhoaHoc";
            this.Load += new System.EventHandler(this.taoKhoaHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoaHocChuaHoanThien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtTenKhoa;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2DataGridView dgvKhoaHocChuaHoanThien;
        private Guna.UI2.WinForms.Guna2TextBox txtNamHoc;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayKetThuc;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}