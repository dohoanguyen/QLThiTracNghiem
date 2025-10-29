namespace Winform_KLCN.ManHinhChinh
{
    partial class ThemCauHoi
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
            this.cbMon = new System.Windows.Forms.ComboBox();
            this.cbDoKho = new System.Windows.Forms.ComboBox();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtD = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDung = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMon
            // 
            this.cbMon.FormattingEnabled = true;
            this.cbMon.Location = new System.Drawing.Point(33, 22);
            this.cbMon.Name = "cbMon";
            this.cbMon.Size = new System.Drawing.Size(121, 21);
            this.cbMon.TabIndex = 0;
            this.cbMon.Text = "Chọn môn học";
            // 
            // cbDoKho
            // 
            this.cbDoKho.FormattingEnabled = true;
            this.cbDoKho.Location = new System.Drawing.Point(176, 22);
            this.cbDoKho.Name = "cbDoKho";
            this.cbDoKho.Size = new System.Drawing.Size(121, 21);
            this.cbDoKho.TabIndex = 1;
            this.cbDoKho.Text = "Chọn độ khó";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(11, 19);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(421, 133);
            this.txtNoiDung.TabIndex = 2;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(117, 229);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(348, 20);
            this.txtA.TabIndex = 3;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(117, 266);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(348, 20);
            this.txtB.TabIndex = 4;
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(117, 303);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(348, 20);
            this.txtC.TabIndex = 5;
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(117, 338);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(348, 20);
            this.txtD.TabIndex = 6;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(402, 415);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "Lưu câu hỏi";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNoiDung);
            this.groupBox1.Location = new System.Drawing.Point(33, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 163);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nội dung câu hỏi";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(312, 415);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Đáp án A:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Đáp án B:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Đáp án C:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Đáp án D:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Đáp án đúng:";
            // 
            // cbDung
            // 
            this.cbDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDung.FormattingEnabled = true;
            this.cbDung.Location = new System.Drawing.Point(117, 379);
            this.cbDung.Name = "cbDung";
            this.cbDung.Size = new System.Drawing.Size(121, 21);
            this.cbDung.TabIndex = 14;
            // 
            // ThemCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbDung);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.cbDoKho);
            this.Controls.Add(this.cbMon);
            this.Name = "ThemCauHoi";
            this.Text = "ThemCauHoi";
            this.Load += new System.EventHandler(this.ThemCauHoi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMon;
        private System.Windows.Forms.ComboBox cbDoKho;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDung;
    }
}