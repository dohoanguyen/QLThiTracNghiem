namespace Winform_KLCN.ManHinhAdmin
{
    partial class qlyCauHoi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboMon = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.dgvCauHoi = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cboDoKho = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboPhan = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMon
            // 
            this.cboMon.BackColor = System.Drawing.Color.Transparent;
            this.cboMon.BorderRadius = 5;
            this.cboMon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMon.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboMon.ItemHeight = 30;
            this.cboMon.Location = new System.Drawing.Point(25, 88);
            this.cboMon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboMon.Name = "cboMon";
            this.cboMon.Size = new System.Drawing.Size(220, 36);
            this.cboMon.TabIndex = 29;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BorderRadius = 10;
            this.btnXacNhan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXacNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXacNhan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(25, 320);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(220, 58);
            this.btnXacNhan.TabIndex = 28;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // dgvCauHoi
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvCauHoi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCauHoi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCauHoi.ColumnHeadersHeight = 4;
            this.dgvCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCauHoi.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCauHoi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCauHoi.Location = new System.Drawing.Point(272, 88);
            this.dgvCauHoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCauHoi.Name = "dgvCauHoi";
            this.dgvCauHoi.RowHeadersVisible = false;
            this.dgvCauHoi.RowHeadersWidth = 51;
            this.dgvCauHoi.RowTemplate.Height = 24;
            this.dgvCauHoi.Size = new System.Drawing.Size(1029, 596);
            this.dgvCauHoi.TabIndex = 27;
            this.dgvCauHoi.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCauHoi.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCauHoi.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCauHoi.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCauHoi.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCauHoi.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCauHoi.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCauHoi.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCauHoi.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCauHoi.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvCauHoi.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCauHoi.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCauHoi.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvCauHoi.ThemeStyle.ReadOnly = false;
            this.dgvCauHoi.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCauHoi.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCauHoi.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvCauHoi.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCauHoi.ThemeStyle.RowsStyle.Height = 24;
            this.dgvCauHoi.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCauHoi.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCauHoi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCauHoi_CellContentClick);
            // 
            // cboDoKho
            // 
            this.cboDoKho.BackColor = System.Drawing.Color.Transparent;
            this.cboDoKho.BorderRadius = 5;
            this.cboDoKho.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDoKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoKho.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDoKho.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDoKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDoKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboDoKho.ItemHeight = 30;
            this.cboDoKho.Location = new System.Drawing.Point(25, 157);
            this.cboDoKho.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDoKho.Name = "cboDoKho";
            this.cboDoKho.Size = new System.Drawing.Size(220, 36);
            this.cboDoKho.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(651, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(271, 32);
            this.label6.TabIndex = 56;
            this.label6.Text = "NGÂN HÀNG CÂU HỎI";
            // 
            // cboPhan
            // 
            this.cboPhan.BackColor = System.Drawing.Color.Transparent;
            this.cboPhan.BorderRadius = 5;
            this.cboPhan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPhan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPhan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboPhan.ItemHeight = 30;
            this.cboPhan.Location = new System.Drawing.Point(25, 226);
            this.cboPhan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboPhan.Name = "cboPhan";
            this.cboPhan.Size = new System.Drawing.Size(220, 36);
            this.cboPhan.TabIndex = 57;
            // 
            // qlyCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.cboPhan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboDoKho);
            this.Controls.Add(this.cboMon);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.dgvCauHoi);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "qlyCauHoi";
            this.Size = new System.Drawing.Size(1330, 712);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cboMon;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCauHoi;
        private Guna.UI2.WinForms.Guna2ComboBox cboDoKho;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cboPhan;
    }
}
