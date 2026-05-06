namespace QUANLYNHANSU
{
    partial class FrmPhongVan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDataUV = new System.Windows.Forms.DataGridView();
            this.dgvDataPV = new System.Windows.Forms.DataGridView();
            this.cboDottuyen = new System.Windows.Forms.ComboBox();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.txtMaDPV = new System.Windows.Forms.TextBox();
            this.txtTenDPV = new System.Windows.Forms.TextBox();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.dtpNgayPV = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboKetQua = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMaUV = new System.Windows.Forms.TextBox();
            this.btn_TimUV = new System.Windows.Forms.Button();
            this.txtVitri = new System.Windows.Forms.TextBox();
            this.txtTenUV = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnXoaUV = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataUV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataPV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDataUV
            // 
            this.dgvDataUV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvDataUV.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataUV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDataUV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDataUV.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDataUV.Location = new System.Drawing.Point(738, 226);
            this.dgvDataUV.Name = "dgvDataUV";
            this.dgvDataUV.RowHeadersWidth = 51;
            this.dgvDataUV.RowTemplate.Height = 24;
            this.dgvDataUV.Size = new System.Drawing.Size(784, 536);
            this.dgvDataUV.TabIndex = 0;
            this.dgvDataUV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataUV_CellClick);
            // 
            // dgvDataPV
            // 
            this.dgvDataPV.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataPV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDataPV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDataPV.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDataPV.Location = new System.Drawing.Point(12, 226);
            this.dgvDataPV.Name = "dgvDataPV";
            this.dgvDataPV.RowHeadersWidth = 51;
            this.dgvDataPV.RowTemplate.Height = 24;
            this.dgvDataPV.Size = new System.Drawing.Size(720, 536);
            this.dgvDataPV.TabIndex = 1;
            this.dgvDataPV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataPV_CellClick);
            // 
            // cboDottuyen
            // 
            this.cboDottuyen.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDottuyen.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboDottuyen.FormattingEnabled = true;
            this.cboDottuyen.Location = new System.Drawing.Point(545, 43);
            this.cboDottuyen.Name = "cboDottuyen";
            this.cboDottuyen.Size = new System.Drawing.Size(129, 27);
            this.cboDottuyen.TabIndex = 2;
            // 
            // cboMaNV
            // 
            this.cboMaNV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNV.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(545, 86);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(129, 27);
            this.cboMaNV.TabIndex = 3;
            // 
            // txtMaDPV
            // 
            this.txtMaDPV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDPV.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMaDPV.Location = new System.Drawing.Point(175, 43);
            this.txtMaDPV.Name = "txtMaDPV";
            this.txtMaDPV.Size = new System.Drawing.Size(174, 27);
            this.txtMaDPV.TabIndex = 4;
            // 
            // txtTenDPV
            // 
            this.txtTenDPV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDPV.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtTenDPV.Location = new System.Drawing.Point(175, 128);
            this.txtTenDPV.Name = "txtTenDPV";
            this.txtTenDPV.Size = new System.Drawing.Size(174, 27);
            this.txtTenDPV.TabIndex = 5;
            // 
            // txtSoluong
            // 
            this.txtSoluong.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoluong.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtSoluong.Location = new System.Drawing.Point(175, 86);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(174, 27);
            this.txtSoluong.TabIndex = 6;
            // 
            // dtpNgayPV
            // 
            this.dtpNgayPV.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpNgayPV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayPV.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayPV.Location = new System.Drawing.Point(545, 128);
            this.dtpNgayPV.Name = "dtpNgayPV";
            this.dtpNgayPV.Size = new System.Drawing.Size(129, 27);
            this.dtpNgayPV.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mã đợt phỏng vấn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên đợt phỏng vấn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Số lượng ứng viên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(385, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mã đợt tuyển dụng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(385, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mã nhân viên:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(385, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ngày phỏng vấn:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.txtMaDPV);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.cboDottuyen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.cboMaNV);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTenDPV);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSoluong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpNgayPV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1071, 172);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đợt phỏng vấn";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSend.ForeColor = System.Drawing.Color.LightCyan;
            this.btnSend.Location = new System.Drawing.Point(950, 107);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(101, 48);
            this.btnSend.TabIndex = 17;
            this.btnSend.Text = "Gửi mail";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.LightCyan;
            this.btnShow.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnShow.Location = new System.Drawing.Point(828, 108);
            this.btnShow.Margin = new System.Windows.Forms.Padding(2);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(101, 47);
            this.btnShow.TabIndex = 12;
            this.btnShow.Text = "Làm mới";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DarkRed;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(950, 43);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(101, 48);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.LightCyan;
            this.btnTimKiem.Location = new System.Drawing.Point(705, 108);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(101, 48);
            this.btnTimKiem.TabIndex = 13;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.LightCyan;
            this.btnSua.Location = new System.Drawing.Point(828, 43);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(101, 48);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.LightCyan;
            this.btnThem.Location = new System.Drawing.Point(705, 43);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(101, 48);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(8, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Đợt phỏng vấn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(734, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 23);
            this.label8.TabIndex = 16;
            this.label8.Text = "Ứng viên tham gia";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox2.Controls.Add(this.cboKetQua);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtMaUV);
            this.groupBox2.Controls.Add(this.btn_TimUV);
            this.groupBox2.Controls.Add(this.txtVitri);
            this.groupBox2.Controls.Add(this.txtTenUV);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnXoaUV);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox2.Location = new System.Drawing.Point(1102, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(420, 172);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ứng viên tham gia";
            // 
            // cboKetQua
            // 
            this.cboKetQua.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKetQua.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboKetQua.FormattingEnabled = true;
            this.cboKetQua.Location = new System.Drawing.Point(323, 38);
            this.cboKetQua.Name = "cboKetQua";
            this.cboKetQua.Size = new System.Drawing.Size(88, 27);
            this.cboKetQua.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(242, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 19);
            this.label12.TabIndex = 26;
            this.label12.Text = "Kết quả:";
            // 
            // txtMaUV
            // 
            this.txtMaUV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaUV.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMaUV.Location = new System.Drawing.Point(126, 38);
            this.txtMaUV.Name = "txtMaUV";
            this.txtMaUV.Size = new System.Drawing.Size(101, 27);
            this.txtMaUV.TabIndex = 24;
            // 
            // btn_TimUV
            // 
            this.btn_TimUV.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_TimUV.ForeColor = System.Drawing.Color.LightCyan;
            this.btn_TimUV.Location = new System.Drawing.Point(63, 119);
            this.btn_TimUV.Name = "btn_TimUV";
            this.btn_TimUV.Size = new System.Drawing.Size(101, 47);
            this.btn_TimUV.TabIndex = 23;
            this.btn_TimUV.Text = "Tìm";
            this.btn_TimUV.UseVisualStyleBackColor = false;
            this.btn_TimUV.Click += new System.EventHandler(this.btn_TimUV_Click);
            // 
            // txtVitri
            // 
            this.txtVitri.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVitri.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtVitri.Location = new System.Drawing.Point(323, 81);
            this.txtVitri.Name = "txtVitri";
            this.txtVitri.Size = new System.Drawing.Size(88, 27);
            this.txtVitri.TabIndex = 20;
            // 
            // txtTenUV
            // 
            this.txtTenUV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenUV.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtTenUV.Location = new System.Drawing.Point(53, 81);
            this.txtTenUV.Name = "txtTenUV";
            this.txtTenUV.Size = new System.Drawing.Size(106, 27);
            this.txtTenUV.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(5, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 19);
            this.label11.TabIndex = 21;
            this.label11.Text = "Tên:";
            // 
            // btnXoaUV
            // 
            this.btnXoaUV.BackColor = System.Drawing.Color.DarkRed;
            this.btnXoaUV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaUV.ForeColor = System.Drawing.Color.White;
            this.btnXoaUV.Location = new System.Drawing.Point(269, 119);
            this.btnXoaUV.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaUV.Name = "btnXoaUV";
            this.btnXoaUV.Size = new System.Drawing.Size(101, 47);
            this.btnXoaUV.TabIndex = 17;
            this.btnXoaUV.Text = "Xóa";
            this.btnXoaUV.UseVisualStyleBackColor = false;
            this.btnXoaUV.Click += new System.EventHandler(this.btnXoaUV_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(181, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 19);
            this.label10.TabIndex = 19;
            this.label10.Text = "Vị trí ứng tuyển:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "Mã ứng viên:";
            // 
            // FrmPhongVan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1534, 775);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDataPV);
            this.Controls.Add(this.dgvDataUV);
            this.Name = "FrmPhongVan";
            this.Text = "FrmPhongVan";
            this.Load += new System.EventHandler(this.FrmPhongVan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataUV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataPV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataUV;
        private System.Windows.Forms.DataGridView dgvDataPV;
        private System.Windows.Forms.ComboBox cboDottuyen;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.TextBox txtMaDPV;
        private System.Windows.Forms.TextBox txtTenDPV;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.DateTimePicker dtpNgayPV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnXoaUV;
        private System.Windows.Forms.TextBox txtTenUV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtVitri;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btn_TimUV;
        private System.Windows.Forms.TextBox txtMaUV;
        private System.Windows.Forms.ComboBox cboKetQua;
        private System.Windows.Forms.Label label12;
    }
}