namespace Winform_KLCN.ChucNangAdmin
{
    partial class taoDeThi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(taoDeThi));
            this.cboMon = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtTenDe = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThemCauHoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDeThiChuaHoatDong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtSoCau = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtThoiGian = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTaoDeTuDong = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCauTruc = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeThiChuaHoatDong)).BeginInit();
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
            this.cboMon.Location = new System.Drawing.Point(23, 334);
            this.cboMon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboMon.Name = "cboMon";
            this.cboMon.Size = new System.Drawing.Size(328, 36);
            this.cboMon.TabIndex = 32;
            this.cboMon.SelectedIndexChanged += new System.EventHandler(this.CboMon_SelectedIndexChanged);
            // 
            // txtTenDe
            // 
            this.txtTenDe.BorderRadius = 5;
            this.txtTenDe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenDe.DefaultText = "";
            this.txtTenDe.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenDe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenDe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenDe.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenDe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenDe.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenDe.Location = new System.Drawing.Point(126, 145);
            this.txtTenDe.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTenDe.Name = "txtTenDe";
            this.txtTenDe.PlaceholderText = "";
            this.txtTenDe.SelectedText = "";
            this.txtTenDe.Size = new System.Drawing.Size(225, 36);
            this.txtTenDe.TabIndex = 30;
            this.txtTenDe.TextChanged += new System.EventHandler(this.txtTenDe_TextChanged);
            // 
            // btnThemCauHoi
            // 
            this.btnThemCauHoi.BorderRadius = 10;
            this.btnThemCauHoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemCauHoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemCauHoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemCauHoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemCauHoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnThemCauHoi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThemCauHoi.ForeColor = System.Drawing.Color.White;
            this.btnThemCauHoi.Location = new System.Drawing.Point(64, 486);
            this.btnThemCauHoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemCauHoi.Name = "btnThemCauHoi";
            this.btnThemCauHoi.Size = new System.Drawing.Size(242, 58);
            this.btnThemCauHoi.TabIndex = 29;
            this.btnThemCauHoi.Text = "Thêm Câu Hỏi";
            this.btnThemCauHoi.Click += new System.EventHandler(this.btnThemCauHoi_Click_1);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BorderRadius = 10;
            this.btnXacNhan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXacNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXacNhan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(64, 413);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(242, 58);
            this.btnXacNhan.TabIndex = 28;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click_1);
            // 
            // dgvDeThiChuaHoatDong
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDeThiChuaHoatDong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeThiChuaHoatDong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDeThiChuaHoatDong.ColumnHeadersHeight = 4;
            this.dgvDeThiChuaHoatDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeThiChuaHoatDong.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDeThiChuaHoatDong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDeThiChuaHoatDong.Location = new System.Drawing.Point(376, 83);
            this.dgvDeThiChuaHoatDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDeThiChuaHoatDong.Name = "dgvDeThiChuaHoatDong";
            this.dgvDeThiChuaHoatDong.RowHeadersVisible = false;
            this.dgvDeThiChuaHoatDong.RowHeadersWidth = 51;
            this.dgvDeThiChuaHoatDong.RowTemplate.Height = 24;
            this.dgvDeThiChuaHoatDong.Size = new System.Drawing.Size(920, 558);
            this.dgvDeThiChuaHoatDong.TabIndex = 27;
            this.dgvDeThiChuaHoatDong.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDeThiChuaHoatDong.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDeThiChuaHoatDong.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDeThiChuaHoatDong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDeThiChuaHoatDong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDeThiChuaHoatDong.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDeThiChuaHoatDong.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDeThiChuaHoatDong.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDeThiChuaHoatDong.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDeThiChuaHoatDong.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvDeThiChuaHoatDong.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDeThiChuaHoatDong.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDeThiChuaHoatDong.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvDeThiChuaHoatDong.ThemeStyle.ReadOnly = false;
            this.dgvDeThiChuaHoatDong.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDeThiChuaHoatDong.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDeThiChuaHoatDong.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvDeThiChuaHoatDong.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDeThiChuaHoatDong.ThemeStyle.RowsStyle.Height = 24;
            this.dgvDeThiChuaHoatDong.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDeThiChuaHoatDong.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDeThiChuaHoatDong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeThiChuaHoatDong_CellClick_1);
            // 
            // txtSoCau
            // 
            this.txtSoCau.BorderRadius = 5;
            this.txtSoCau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoCau.DefaultText = "";
            this.txtSoCau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSoCau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSoCau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSoCau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSoCau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSoCau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSoCau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSoCau.Location = new System.Drawing.Point(126, 207);
            this.txtSoCau.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSoCau.Name = "txtSoCau";
            this.txtSoCau.PlaceholderText = "";
            this.txtSoCau.SelectedText = "";
            this.txtSoCau.Size = new System.Drawing.Size(225, 36);
            this.txtSoCau.TabIndex = 33;
            // 
            // txtThoiGian
            // 
            this.txtThoiGian.BorderRadius = 5;
            this.txtThoiGian.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtThoiGian.DefaultText = "";
            this.txtThoiGian.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtThoiGian.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtThoiGian.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtThoiGian.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtThoiGian.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtThoiGian.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtThoiGian.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtThoiGian.Location = new System.Drawing.Point(126, 269);
            this.txtThoiGian.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtThoiGian.Name = "txtThoiGian";
            this.txtThoiGian.PlaceholderText = "";
            this.txtThoiGian.SelectedText = "";
            this.txtThoiGian.Size = new System.Drawing.Size(225, 36);
            this.txtThoiGian.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 28);
            this.label1.TabIndex = 35;
            this.label1.Text = "Tên đề";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 28);
            this.label2.TabIndex = 36;
            this.label2.Text = "Số câu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 28);
            this.label3.TabIndex = 37;
            this.label3.Text = "Thời gian";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(697, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 32);
            this.label4.TabIndex = 38;
            this.label4.Text = "ĐỀ CHƯA HOÀN THIỆN";
            // 
            // btnTaoDeTuDong
            // 
            this.btnTaoDeTuDong.BorderRadius = 10;
            this.btnTaoDeTuDong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoDeTuDong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoDeTuDong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaoDeTuDong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaoDeTuDong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnTaoDeTuDong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTaoDeTuDong.ForeColor = System.Drawing.Color.White;
            this.btnTaoDeTuDong.Location = new System.Drawing.Point(64, 559);
            this.btnTaoDeTuDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTaoDeTuDong.Name = "btnTaoDeTuDong";
            this.btnTaoDeTuDong.Size = new System.Drawing.Size(242, 58);
            this.btnTaoDeTuDong.TabIndex = 39;
            this.btnTaoDeTuDong.Text = "Tạo Đề Tự Động";
            this.btnTaoDeTuDong.Click += new System.EventHandler(this.btnTaoDeTuDong_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 28);
            this.label5.TabIndex = 41;
            this.label5.Text = "Cấu trúc";
            // 
            // txtCauTruc
            // 
            this.txtCauTruc.BorderRadius = 5;
            this.txtCauTruc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCauTruc.DefaultText = "";
            this.txtCauTruc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCauTruc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCauTruc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCauTruc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCauTruc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCauTruc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCauTruc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCauTruc.Location = new System.Drawing.Point(126, 83);
            this.txtCauTruc.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCauTruc.Name = "txtCauTruc";
            this.txtCauTruc.PlaceholderText = "";
            this.txtCauTruc.SelectedText = "";
            this.txtCauTruc.Size = new System.Drawing.Size(225, 36);
            this.txtCauTruc.TabIndex = 40;
            // 
            // taoDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1310, 654);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCauTruc);
            this.Controls.Add(this.btnTaoDeTuDong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtThoiGian);
            this.Controls.Add(this.txtSoCau);
            this.Controls.Add(this.cboMon);
            this.Controls.Add(this.txtTenDe);
            this.Controls.Add(this.btnThemCauHoi);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.dgvDeThiChuaHoatDong);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "taoDeThi";
            this.Text = "Tạo Đề Thi";
            this.Load += new System.EventHandler(this.taoDeThi_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeThiChuaHoatDong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cboMon;
        private Guna.UI2.WinForms.Guna2TextBox txtTenDe;
        private Guna.UI2.WinForms.Guna2Button btnThemCauHoi;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDeThiChuaHoatDong;
        private Guna.UI2.WinForms.Guna2TextBox txtSoCau;
        private Guna.UI2.WinForms.Guna2TextBox txtThoiGian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button btnTaoDeTuDong;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtCauTruc;
    }
}