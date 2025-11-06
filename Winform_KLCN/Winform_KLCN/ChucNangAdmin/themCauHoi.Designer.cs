namespace Winform_KLCN.ChucNangAdmin
{
    partial class themCauHoi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboDoKho = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvCauHoi = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvCauHoiHienCo = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoiHienCo)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDoKho
            // 
            this.cboDoKho.BackColor = System.Drawing.Color.Transparent;
            this.cboDoKho.BorderRadius = 20;
            this.cboDoKho.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDoKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoKho.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDoKho.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDoKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDoKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboDoKho.ItemHeight = 30;
            this.cboDoKho.Location = new System.Drawing.Point(468, 54);
            this.cboDoKho.Name = "cboDoKho";
            this.cboDoKho.Size = new System.Drawing.Size(206, 36);
            this.cboDoKho.TabIndex = 29;
            this.cboDoKho.SelectedIndexChanged += new System.EventHandler(this.cboDoKho_SelectedIndexChanged);
            // 
            // dgvCauHoi
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvCauHoi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCauHoi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCauHoi.ColumnHeadersHeight = 4;
            this.dgvCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCauHoi.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCauHoi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCauHoi.Location = new System.Drawing.Point(22, 115);
            this.dgvCauHoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCauHoi.Name = "dgvCauHoi";
            this.dgvCauHoi.RowHeadersVisible = false;
            this.dgvCauHoi.RowHeadersWidth = 51;
            this.dgvCauHoi.RowTemplate.Height = 24;
            this.dgvCauHoi.Size = new System.Drawing.Size(500, 500);
            this.dgvCauHoi.TabIndex = 30;
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
            this.dgvCauHoi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCauHoi_CellClick);
            // 
            // dgvCauHoiHienCo
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvCauHoiHienCo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCauHoiHienCo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvCauHoiHienCo.ColumnHeadersHeight = 4;
            this.dgvCauHoiHienCo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCauHoiHienCo.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvCauHoiHienCo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCauHoiHienCo.Location = new System.Drawing.Point(602, 115);
            this.dgvCauHoiHienCo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCauHoiHienCo.Name = "dgvCauHoiHienCo";
            this.dgvCauHoiHienCo.RowHeadersVisible = false;
            this.dgvCauHoiHienCo.RowHeadersWidth = 51;
            this.dgvCauHoiHienCo.RowTemplate.Height = 24;
            this.dgvCauHoiHienCo.Size = new System.Drawing.Size(500, 500);
            this.dgvCauHoiHienCo.TabIndex = 31;
            this.dgvCauHoiHienCo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCauHoiHienCo.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCauHoiHienCo.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCauHoiHienCo.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCauHoiHienCo.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCauHoiHienCo.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCauHoiHienCo.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCauHoiHienCo.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCauHoiHienCo.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCauHoiHienCo.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvCauHoiHienCo.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCauHoiHienCo.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCauHoiHienCo.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvCauHoiHienCo.ThemeStyle.ReadOnly = false;
            this.dgvCauHoiHienCo.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCauHoiHienCo.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCauHoiHienCo.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvCauHoiHienCo.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCauHoiHienCo.ThemeStyle.RowsStyle.Height = 24;
            this.dgvCauHoiHienCo.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCauHoiHienCo.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // themCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 523);
            this.Controls.Add(this.dgvCauHoiHienCo);
            this.Controls.Add(this.dgvCauHoi);
            this.Controls.Add(this.cboDoKho);
            this.Name = "themCauHoi";
            this.Text = "themCauHoi";
            this.Load += new System.EventHandler(this.themCauHoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoiHienCo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cboDoKho;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCauHoi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCauHoiHienCo;
    }
}