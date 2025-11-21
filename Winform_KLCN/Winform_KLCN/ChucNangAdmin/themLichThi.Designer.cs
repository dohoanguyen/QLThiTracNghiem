namespace Winform_KLCN.ChucNangAdmin
{
    partial class themLichThi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(themLichThi));
            this.cboLop = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.dtpNgayThi = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cboDe = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpGioBD = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpGioKT = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnQuayLai = new Guna.UI2.WinForms.Guna2Button();
            this.btnHoanThien = new Guna.UI2.WinForms.Guna2Button();
            this.dgvLichThi = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichThi)).BeginInit();
            this.SuspendLayout();
            // 
            // cboLop
            // 
            this.cboLop.BackColor = System.Drawing.Color.Transparent;
            this.cboLop.BorderRadius = 5;
            this.cboLop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLop.ItemHeight = 30;
            this.cboLop.Location = new System.Drawing.Point(143, 304);
            this.cboLop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(264, 36);
            this.cboLop.TabIndex = 38;
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 10;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(44, 459);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(363, 58);
            this.btnThem.TabIndex = 37;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // dtpNgayThi
            // 
            this.dtpNgayThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dtpNgayThi.BorderRadius = 5;
            this.dtpNgayThi.Checked = true;
            this.dtpNgayThi.FillColor = System.Drawing.Color.White;
            this.dtpNgayThi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayThi.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgayThi.Location = new System.Drawing.Point(143, 106);
            this.dtpNgayThi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayThi.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayThi.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayThi.Name = "dtpNgayThi";
            this.dtpNgayThi.Size = new System.Drawing.Size(264, 36);
            this.dtpNgayThi.TabIndex = 35;
            this.dtpNgayThi.Value = new System.DateTime(2025, 11, 6, 11, 44, 3, 420);
            // 
            // cboDe
            // 
            this.cboDe.BackColor = System.Drawing.Color.Transparent;
            this.cboDe.BorderRadius = 5;
            this.cboDe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDe.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboDe.ItemHeight = 30;
            this.cboDe.Location = new System.Drawing.Point(143, 370);
            this.cboDe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDe.Name = "cboDe";
            this.cboDe.Size = new System.Drawing.Size(264, 36);
            this.cboDe.TabIndex = 39;
            // 
            // dtpGioBD
            // 
            this.dtpGioBD.BorderRadius = 5;
            this.dtpGioBD.Checked = true;
            this.dtpGioBD.FillColor = System.Drawing.Color.White;
            this.dtpGioBD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpGioBD.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpGioBD.Location = new System.Drawing.Point(143, 172);
            this.dtpGioBD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpGioBD.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpGioBD.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpGioBD.Name = "dtpGioBD";
            this.dtpGioBD.Size = new System.Drawing.Size(264, 36);
            this.dtpGioBD.TabIndex = 40;
            this.dtpGioBD.Value = new System.DateTime(2025, 11, 6, 11, 44, 3, 420);
            // 
            // dtpGioKT
            // 
            this.dtpGioKT.BorderRadius = 5;
            this.dtpGioKT.Checked = true;
            this.dtpGioKT.FillColor = System.Drawing.Color.White;
            this.dtpGioKT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpGioKT.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpGioKT.Location = new System.Drawing.Point(143, 238);
            this.dtpGioKT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpGioKT.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpGioKT.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpGioKT.Name = "dtpGioKT";
            this.dtpGioKT.Size = new System.Drawing.Size(264, 36);
            this.dtpGioKT.TabIndex = 41;
            this.dtpGioKT.Value = new System.DateTime(2025, 11, 6, 11, 44, 3, 420);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BorderRadius = 10;
            this.btnQuayLai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQuayLai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQuayLai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQuayLai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQuayLai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnQuayLai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQuayLai.ForeColor = System.Drawing.Color.White;
            this.btnQuayLai.Location = new System.Drawing.Point(44, 539);
            this.btnQuayLai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(170, 58);
            this.btnQuayLai.TabIndex = 42;
            this.btnQuayLai.Text = "Quay Lại";
            // 
            // btnHoanThien
            // 
            this.btnHoanThien.BorderRadius = 10;
            this.btnHoanThien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHoanThien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHoanThien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHoanThien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHoanThien.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnHoanThien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHoanThien.ForeColor = System.Drawing.Color.White;
            this.btnHoanThien.Location = new System.Drawing.Point(237, 539);
            this.btnHoanThien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHoanThien.Name = "btnHoanThien";
            this.btnHoanThien.Size = new System.Drawing.Size(170, 58);
            this.btnHoanThien.TabIndex = 43;
            this.btnHoanThien.Text = "Hoàn Thiện";
            // 
            // dgvLichThi
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvLichThi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichThi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLichThi.ColumnHeadersHeight = 4;
            this.dgvLichThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLichThi.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLichThi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLichThi.Location = new System.Drawing.Point(453, 68);
            this.dgvLichThi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLichThi.Name = "dgvLichThi";
            this.dgvLichThi.RowHeadersVisible = false;
            this.dgvLichThi.RowHeadersWidth = 51;
            this.dgvLichThi.RowTemplate.Height = 24;
            this.dgvLichThi.Size = new System.Drawing.Size(840, 571);
            this.dgvLichThi.TabIndex = 44;
            this.dgvLichThi.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLichThi.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvLichThi.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvLichThi.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvLichThi.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvLichThi.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvLichThi.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLichThi.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvLichThi.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLichThi.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvLichThi.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvLichThi.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvLichThi.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvLichThi.ThemeStyle.ReadOnly = false;
            this.dgvLichThi.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLichThi.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLichThi.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvLichThi.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvLichThi.ThemeStyle.RowsStyle.Height = 24;
            this.dgvLichThi.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLichThi.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 28);
            this.label4.TabIndex = 54;
            this.label4.Text = "Chọn đề";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 28);
            this.label5.TabIndex = 53;
            this.label5.Text = "Chọn lớp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 28);
            this.label3.TabIndex = 52;
            this.label3.Text = "Kết thúc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 28);
            this.label2.TabIndex = 51;
            this.label2.Text = "Bắt đầu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 28);
            this.label1.TabIndex = 50;
            this.label1.Text = "Ngày thi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(789, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 32);
            this.label6.TabIndex = 55;
            this.label6.Text = "LỊCH HIỆN TẠI";
            // 
            // themLichThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1310, 654);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLichThi);
            this.Controls.Add(this.btnHoanThien);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.dtpGioKT);
            this.Controls.Add(this.dtpGioBD);
            this.Controls.Add(this.cboDe);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dtpNgayThi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "themLichThi";
            this.Text = "themLichThi";
            this.Load += new System.EventHandler(this.themLichThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cboLop;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayThi;
        private Guna.UI2.WinForms.Guna2ComboBox cboDe;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpGioBD;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpGioKT;
        private Guna.UI2.WinForms.Guna2Button btnQuayLai;
        private Guna.UI2.WinForms.Guna2Button btnHoanThien;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLichThi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
    }
}