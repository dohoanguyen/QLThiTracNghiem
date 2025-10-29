namespace Winform_KLCN.ManHinhAdmin
{
    partial class qlyGiaoVien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbxMonHoc = new System.Windows.Forms.ListBox();
            this.dgvCauHoi = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblKetQua = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxMonHoc
            // 
            this.lbxMonHoc.FormattingEnabled = true;
            this.lbxMonHoc.ItemHeight = 16;
            this.lbxMonHoc.Location = new System.Drawing.Point(35, 20);
            this.lbxMonHoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxMonHoc.Name = "lbxMonHoc";
            this.lbxMonHoc.Size = new System.Drawing.Size(151, 84);
            this.lbxMonHoc.TabIndex = 3;
            // 
            // dgvCauHoi
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCauHoi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCauHoi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCauHoi.ColumnHeadersHeight = 4;
            this.dgvCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCauHoi.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCauHoi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCauHoi.Location = new System.Drawing.Point(10, 157);
            this.dgvCauHoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCauHoi.Name = "dgvCauHoi";
            this.dgvCauHoi.RowHeadersVisible = false;
            this.dgvCauHoi.RowHeadersWidth = 51;
            this.dgvCauHoi.RowTemplate.Height = 24;
            this.dgvCauHoi.Size = new System.Drawing.Size(1169, 398);
            this.dgvCauHoi.TabIndex = 4;
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
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(247, 20);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(106, 16);
            this.lblKetQua.TabIndex = 5;
            this.lblKetQua.Text = "Số lượng câu hỏi";
            // 
            // qlyGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.dgvCauHoi);
            this.Controls.Add(this.lbxMonHoc);
            this.Name = "qlyGiaoVien";
            this.Size = new System.Drawing.Size(1182, 570);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxMonHoc;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCauHoi;
        private System.Windows.Forms.Label lblKetQua;
    }
}
