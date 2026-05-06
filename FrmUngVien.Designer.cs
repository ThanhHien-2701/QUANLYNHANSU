namespace QUANLYNHANSU
{
    partial class FrmUngVien
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mtbDienThoai = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMaUngVien = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHoUV = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTenUngVien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboNamKinhNghiem = new System.Windows.Forms.ComboBox();
            this.lblLoc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboChuyenMon = new System.Windows.Forms.ComboBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Location = new System.Drawing.Point(368, 11);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 62;
            this.dgvData.RowTemplate.Height = 28;
            this.dgvData.Size = new System.Drawing.Size(1155, 604);
            this.dgvData.TabIndex = 37;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox1.Controls.Add(this.mtbDienThoai);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtMaUngVien);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtHoUV);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cboGioiTinh);
            this.groupBox1.Controls.Add(this.dtpNgaySinh);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTenUngVien);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Location = new System.Drawing.Point(8, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(350, 310);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Ứng Viên";
            // 
            // mtbDienThoai
            // 
            this.mtbDienThoai.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDienThoai.ForeColor = System.Drawing.Color.MidnightBlue;
            this.mtbDienThoai.Location = new System.Drawing.Point(119, 232);
            this.mtbDienThoai.Margin = new System.Windows.Forms.Padding(2);
            this.mtbDienThoai.Mask = "0000000000";
            this.mtbDienThoai.Name = "mtbDienThoai";
            this.mtbDienThoai.Size = new System.Drawing.Size(153, 27);
            this.mtbDienThoai.TabIndex = 35;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtEmail.Location = new System.Drawing.Point(119, 271);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(216, 27);
            this.txtEmail.TabIndex = 34;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 274);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 19);
            this.label18.TabIndex = 33;
            this.label18.Text = "Email:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 41);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 19);
            this.label15.TabIndex = 27;
            this.label15.Text = "Mã ứng viên:";
            // 
            // txtMaUngVien
            // 
            this.txtMaUngVien.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaUngVien.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMaUngVien.Location = new System.Drawing.Point(120, 38);
            this.txtMaUngVien.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaUngVien.Name = "txtMaUngVien";
            this.txtMaUngVien.Size = new System.Drawing.Size(215, 27);
            this.txtMaUngVien.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 235);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 19);
            this.label9.TabIndex = 12;
            this.label9.Text = "Điện Thoại :";
            // 
            // txtHoUV
            // 
            this.txtHoUV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoUV.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtHoUV.Location = new System.Drawing.Point(119, 112);
            this.txtHoUV.Margin = new System.Windows.Forms.Padding(2);
            this.txtHoUV.Name = "txtHoUV";
            this.txtHoUV.Size = new System.Drawing.Size(216, 27);
            this.txtHoUV.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 115);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 19);
            this.label13.TabIndex = 23;
            this.label13.Text = "Họ đệm:";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGioiTinh.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGioiTinh.Location = new System.Drawing.Point(119, 154);
            this.cboGioiTinh.Margin = new System.Windows.Forms.Padding(2);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(108, 27);
            this.cboGioiTinh.TabIndex = 21;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpNgaySinh.CalendarTitleForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpNgaySinh.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(119, 193);
            this.dtpNgaySinh.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(153, 27);
            this.dtpNgaySinh.TabIndex = 13;
            this.dtpNgaySinh.Value = new System.DateTime(2025, 7, 5, 23, 23, 7, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 157);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "Giới Tính :";
            // 
            // txtTenUngVien
            // 
            this.txtTenUngVien.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenUngVien.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtTenUngVien.Location = new System.Drawing.Point(119, 75);
            this.txtTenUngVien.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenUngVien.Name = "txtTenUngVien";
            this.txtTenUngVien.Size = new System.Drawing.Size(216, 27);
            this.txtTenUngVien.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 199);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ngày sinh:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên ứng viên:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox2.Controls.Add(this.cboNamKinhNghiem);
            this.groupBox2.Controls.Add(this.lblLoc);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboChuyenMon);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnShow);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox2.Location = new System.Drawing.Point(8, 334);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(350, 281);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // cboNamKinhNghiem
            // 
            this.cboNamKinhNghiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamKinhNghiem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNamKinhNghiem.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboNamKinhNghiem.FormattingEnabled = true;
            this.cboNamKinhNghiem.Items.AddRange(new object[] {
            "Tất cả",
            "0 - 2 năm",
            "3 - 5 năm",
            "6 - 10 năm",
            "Trên 10 năm"});
            this.cboNamKinhNghiem.Location = new System.Drawing.Point(176, 206);
            this.cboNamKinhNghiem.Margin = new System.Windows.Forms.Padding(2);
            this.cboNamKinhNghiem.Name = "cboNamKinhNghiem";
            this.cboNamKinhNghiem.Size = new System.Drawing.Size(159, 27);
            this.cboNamKinhNghiem.TabIndex = 17;
            this.cboNamKinhNghiem.SelectionChangeCommitted += new System.EventHandler(this.cboNamKinhNghiem_SelectionChangeCommitted);
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoc.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblLoc.Location = new System.Drawing.Point(9, 170);
            this.lblLoc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(233, 23);
            this.lblLoc.TabIndex = 19;
            this.lblLoc.Text = "Lọc ứng viên theo tiêu chí:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 244);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "Bằng cấp, chứng chỉ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 209);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "Năm kinh nghiệm:";
            // 
            // cboChuyenMon
            // 
            this.cboChuyenMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyenMon.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChuyenMon.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboChuyenMon.FormattingEnabled = true;
            this.cboChuyenMon.Location = new System.Drawing.Point(176, 241);
            this.cboChuyenMon.Margin = new System.Windows.Forms.Padding(2);
            this.cboChuyenMon.Name = "cboChuyenMon";
            this.cboChuyenMon.Size = new System.Drawing.Size(159, 27);
            this.cboChuyenMon.TabIndex = 18;
            this.cboChuyenMon.SelectionChangeCommitted += new System.EventHandler(this.cboChuyenMon_SelectionChangeCommitted);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DarkRed;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Snow;
            this.btnXoa.Location = new System.Drawing.Point(246, 27);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 50);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.LightCyan;
            this.btnShow.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnShow.Location = new System.Drawing.Point(185, 91);
            this.btnShow.Margin = new System.Windows.Forms.Padding(2);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(100, 50);
            this.btnShow.TabIndex = 12;
            this.btnShow.Text = "Làm mới";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.LightCyan;
            this.btnSua.Location = new System.Drawing.Point(127, 27);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 50);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.LightCyan;
            this.btnTimKiem.Location = new System.Drawing.Point(68, 91);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 50);
            this.btnTimKiem.TabIndex = 13;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.LightCyan;
            this.btnThem.Location = new System.Drawing.Point(7, 27);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 50);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // FrmUngVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1534, 625);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmUngVien";
            this.Text = "FrmUngVien";
            this.Load += new System.EventHandler(this.FrmUngVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMaUngVien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHoUV;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTenUngVien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.MaskedTextBox mtbDienThoai;
        private System.Windows.Forms.ComboBox cboNamKinhNghiem;
        private System.Windows.Forms.ComboBox cboChuyenMon;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}