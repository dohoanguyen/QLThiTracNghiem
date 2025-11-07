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
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichThi)).BeginInit();
            this.SuspendLayout();
            // 
            // cboLop
            // 
            this.cboLop.BackColor = System.Drawing.Color.Transparent;
            this.cboLop.BorderRadius = 20;
            this.cboLop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLop.ItemHeight = 30;
            this.cboLop.Location = new System.Drawing.Point(12, 209);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(200, 36);
            this.cboLop.TabIndex = 38;
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 20;
            this.btnThem.CustomizableEdges.BottomLeft = false;
            this.btnThem.CustomizableEdges.TopRight = false;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(12, 339);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(174, 46);
            this.btnThem.TabIndex = 37;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // dtpNgayThi
            // 
            this.dtpNgayThi.Checked = true;
            this.dtpNgayThi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayThi.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgayThi.Location = new System.Drawing.Point(12, 12);
            this.dtpNgayThi.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayThi.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayThi.Name = "dtpNgayThi";
            this.dtpNgayThi.Size = new System.Drawing.Size(200, 36);
            this.dtpNgayThi.TabIndex = 35;
            this.dtpNgayThi.Value = new System.DateTime(2025, 11, 6, 11, 44, 3, 420);
            // 
            // cboDe
            // 
            this.cboDe.BackColor = System.Drawing.Color.Transparent;
            this.cboDe.BorderRadius = 20;
            this.cboDe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDe.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboDe.ItemHeight = 30;
            this.cboDe.Location = new System.Drawing.Point(12, 276);
            this.cboDe.Name = "cboDe";
            this.cboDe.Size = new System.Drawing.Size(200, 36);
            this.cboDe.TabIndex = 39;
            // 
            // dtpGioBD
            // 
            this.dtpGioBD.Checked = true;
            this.dtpGioBD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpGioBD.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpGioBD.Location = new System.Drawing.Point(12, 74);
            this.dtpGioBD.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpGioBD.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpGioBD.Name = "dtpGioBD";
            this.dtpGioBD.Size = new System.Drawing.Size(200, 36);
            this.dtpGioBD.TabIndex = 40;
            this.dtpGioBD.Value = new System.DateTime(2025, 11, 6, 11, 44, 3, 420);
            // 
            // dtpGioKT
            // 
            this.dtpGioKT.Checked = true;
            this.dtpGioKT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpGioKT.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpGioKT.Location = new System.Drawing.Point(12, 139);
            this.dtpGioKT.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpGioKT.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpGioKT.Name = "dtpGioKT";
            this.dtpGioKT.Size = new System.Drawing.Size(200, 36);
            this.dtpGioKT.TabIndex = 41;
            this.dtpGioKT.Value = new System.DateTime(2025, 11, 6, 11, 44, 3, 420);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BorderRadius = 20;
            this.btnQuayLai.CustomizableEdges.BottomLeft = false;
            this.btnQuayLai.CustomizableEdges.TopRight = false;
            this.btnQuayLai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQuayLai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQuayLai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQuayLai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQuayLai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnQuayLai.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQuayLai.ForeColor = System.Drawing.Color.White;
            this.btnQuayLai.Location = new System.Drawing.Point(12, 404);
            this.btnQuayLai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(174, 46);
            this.btnQuayLai.TabIndex = 42;
            this.btnQuayLai.Text = "Quay Lại";
            // 
            // btnHoanThien
            // 
            this.btnHoanThien.BorderRadius = 20;
            this.btnHoanThien.CustomizableEdges.BottomLeft = false;
            this.btnHoanThien.CustomizableEdges.TopRight = false;
            this.btnHoanThien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHoanThien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHoanThien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHoanThien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHoanThien.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnHoanThien.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHoanThien.ForeColor = System.Drawing.Color.White;
            this.btnHoanThien.Location = new System.Drawing.Point(12, 466);
            this.btnHoanThien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHoanThien.Name = "btnHoanThien";
            this.btnHoanThien.Size = new System.Drawing.Size(174, 46);
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
            this.dgvLichThi.Location = new System.Drawing.Point(277, 41);
            this.dgvLichThi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLichThi.Name = "dgvLichThi";
            this.dgvLichThi.RowHeadersVisible = false;
            this.dgvLichThi.RowHeadersWidth = 51;
            this.dgvLichThi.RowTemplate.Height = 24;
            this.dgvLichThi.Size = new System.Drawing.Size(826, 439);
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
            // themLichThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 523);
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
            this.Name = "themLichThi";
            this.Text = "themLichThi";
            this.Load += new System.EventHandler(this.themLichThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichThi)).EndInit();
            this.ResumeLayout(false);

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
    }
}