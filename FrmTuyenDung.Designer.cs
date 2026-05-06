namespace QUANLYNHANSU
{
    partial class FrmTuyenDung
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.cboManv = new System.Windows.Forms.ComboBox();
            this.cboMaPB = new System.Windows.Forms.ComboBox();
            this.txtVitri = new System.Windows.Forms.TextBox();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.txtMaDTD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.data1 = new QUANLYNHANSU.Data();
            this.dgvDataDTD = new System.Windows.Forms.DataGridView();
            this.nhanvienTableAdapter1 = new QUANLYNHANSU.DataTableAdapters.NHANVIENTableAdapter();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.dgvDataDPV = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtManv = new System.Windows.Forms.TextBox();
            this.txtMaDPV = new System.Windows.Forms.TextBox();
            this.txtTenDPV = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpNgayPV = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDPV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpNgayBatDau.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(692, 40);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(124, 27);
            this.dtpNgayBatDau.TabIndex = 0;
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpNgayKetThuc.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(692, 83);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(124, 27);
            this.dtpNgayKetThuc.TabIndex = 1;
            // 
            // cboManv
            // 
            this.cboManv.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboManv.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboManv.FormattingEnabled = true;
            this.cboManv.Location = new System.Drawing.Point(443, 40);
            this.cboManv.Name = "cboManv";
            this.cboManv.Size = new System.Drawing.Size(121, 27);
            this.cboManv.TabIndex = 2;
            // 
            // cboMaPB
            // 
            this.cboMaPB.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaPB.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboMaPB.FormattingEnabled = true;
            this.cboMaPB.Location = new System.Drawing.Point(443, 83);
            this.cboMaPB.Name = "cboMaPB";
            this.cboMaPB.Size = new System.Drawing.Size(121, 27);
            this.cboMaPB.TabIndex = 3;
            // 
            // txtVitri
            // 
            this.txtVitri.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVitri.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtVitri.Location = new System.Drawing.Point(141, 83);
            this.txtVitri.Name = "txtVitri";
            this.txtVitri.Size = new System.Drawing.Size(170, 27);
            this.txtVitri.TabIndex = 4;
            // 
            // txtSoluong
            // 
            this.txtSoluong.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoluong.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtSoluong.Location = new System.Drawing.Point(141, 124);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(170, 27);
            this.txtSoluong.TabIndex = 5;
            // 
            // txtMaDTD
            // 
            this.txtMaDTD.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDTD.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMaDTD.Location = new System.Drawing.Point(141, 40);
            this.txtMaDTD.Name = "txtMaDTD";
            this.txtMaDTD.Size = new System.Drawing.Size(116, 27);
            this.txtMaDTD.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mã đợt tuyển:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Vị trí tuyển:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Số lượng tuyển:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(319, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mã nhân viên:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(319, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Mã phòng ban:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(577, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ngày bắt đầu:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(577, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ngày kết thúc:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox1.Controls.Add(this.txtMaDTD);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.dtpNgayBatDau);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.dtpNgayKetThuc);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboManv);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboMaPB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtVitri);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSoluong);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Location = new System.Drawing.Point(11, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(832, 166);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đợt tuyển dụng";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.LightCyan;
            this.btnTimKiem.Location = new System.Drawing.Point(716, 121);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 40);
            this.btnTimKiem.TabIndex = 20;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DarkRed;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(586, 121);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 40);
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.LightCyan;
            this.btnSua.Location = new System.Drawing.Point(454, 121);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 40);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.LightCyan;
            this.btnThem.Location = new System.Drawing.Point(323, 121);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 40);
            this.btnThem.TabIndex = 21;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // data1
            // 
            this.data1.DataSetName = "Data";
            this.data1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvDataDTD
            // 
            this.dgvDataDTD.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataDTD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDataDTD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDataDTD.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDataDTD.Location = new System.Drawing.Point(11, 242);
            this.dgvDataDTD.Name = "dgvDataDTD";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataDTD.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDataDTD.RowHeadersWidth = 51;
            this.dgvDataDTD.RowTemplate.Height = 24;
            this.dgvDataDTD.Size = new System.Drawing.Size(832, 362);
            this.dgvDataDTD.TabIndex = 15;
            this.dgvDataDTD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataDTD_CellClick);
            // 
            // nhanvienTableAdapter1
            // 
            this.nhanvienTableAdapter1.ClearBeforeFill = true;
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnIn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ForeColor = System.Drawing.Color.LightCyan;
            this.btnIn.Location = new System.Drawing.Point(969, 165);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(100, 40);
            this.btnIn.TabIndex = 16;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.LightCyan;
            this.btnShow.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnShow.Location = new System.Drawing.Point(848, 165);
            this.btnShow.Margin = new System.Windows.Forms.Padding(2);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(100, 40);
            this.btnShow.TabIndex = 19;
            this.btnShow.Text = "Làm mới";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvDataDPV
            // 
            this.dgvDataDPV.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataDPV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDataDPV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDataDPV.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDataDPV.Location = new System.Drawing.Point(850, 242);
            this.dgvDataDPV.Name = "dgvDataDPV";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataDPV.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDataDPV.RowHeadersWidth = 51;
            this.dgvDataDPV.RowTemplate.Height = 24;
            this.dgvDataDPV.Size = new System.Drawing.Size(670, 362);
            this.dgvDataDPV.TabIndex = 22;
            this.dgvDataDPV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataPhongVan_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox2.Controls.Add(this.txtManv);
            this.groupBox2.Controls.Add(this.txtMaDPV);
            this.groupBox2.Controls.Add(this.txtTenDPV);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.dtpNgayPV);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox2.Location = new System.Drawing.Point(848, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(670, 117);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin đợt phỏng vấn";
            // 
            // txtManv
            // 
            this.txtManv.Enabled = false;
            this.txtManv.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManv.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtManv.Location = new System.Drawing.Point(531, 40);
            this.txtManv.Name = "txtManv";
            this.txtManv.Size = new System.Drawing.Size(111, 27);
            this.txtManv.TabIndex = 34;
            // 
            // txtMaDPV
            // 
            this.txtMaDPV.Enabled = false;
            this.txtMaDPV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDPV.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMaDPV.Location = new System.Drawing.Point(171, 40);
            this.txtMaDPV.Name = "txtMaDPV";
            this.txtMaDPV.Size = new System.Drawing.Size(100, 27);
            this.txtMaDPV.TabIndex = 24;
            // 
            // txtTenDPV
            // 
            this.txtTenDPV.Enabled = false;
            this.txtTenDPV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDPV.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtTenDPV.Location = new System.Drawing.Point(171, 83);
            this.txtTenDPV.Name = "txtTenDPV";
            this.txtTenDPV.Size = new System.Drawing.Size(159, 27);
            this.txtTenDPV.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(359, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 19);
            this.label11.TabIndex = 31;
            this.label11.Text = "Ngày phỏng vấn:";
            // 
            // dtpNgayPV
            // 
            this.dtpNgayPV.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpNgayPV.Enabled = false;
            this.dtpNgayPV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayPV.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayPV.Location = new System.Drawing.Point(531, 80);
            this.dtpNgayPV.Name = "dtpNgayPV";
            this.dtpNgayPV.Size = new System.Drawing.Size(111, 27);
            this.dtpNgayPV.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(359, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 19);
            this.label10.TabIndex = 30;
            this.label10.Text = "Nhân viên phỏng vấn:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 19);
            this.label8.TabIndex = 28;
            this.label8.Text = "Mã đợt phỏng vấn:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 19);
            this.label9.TabIndex = 29;
            this.label9.Text = "Tên đợt phỏng vấn:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label12.Location = new System.Drawing.Point(11, 216);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 23);
            this.label12.TabIndex = 24;
            this.label12.Text = "Đợt tuyển dụng";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label13.Location = new System.Drawing.Point(846, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 23);
            this.label13.TabIndex = 25;
            this.label13.Text = "Đợt phỏng vấn";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.LightCyan;
            this.button1.Location = new System.Drawing.Point(1090, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 39);
            this.button1.TabIndex = 66;
            this.button1.Text = "Gửi DS ứng viên đạt";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label14.Location = new System.Drawing.Point(7, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(322, 26);
            this.label14.TabIndex = 67;
            this.label14.Text = "Trang chủ > Quản lý tuyển dụng";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // FrmTuyenDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1532, 618);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvDataDPV);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dgvDataDTD);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmTuyenDung";
            this.Text = "FrmTuyenDung";
            this.Load += new System.EventHandler(this.FrmTuyenDung_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDPV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.ComboBox cboManv;
        private System.Windows.Forms.ComboBox cboMaPB;
        private System.Windows.Forms.TextBox txtVitri;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.TextBox txtMaDTD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private Data data1;
        private System.Windows.Forms.DataGridView dgvDataDTD;
        private DataTableAdapters.NHANVIENTableAdapter nhanvienTableAdapter1;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvDataDPV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMaDPV;
        private System.Windows.Forms.TextBox txtTenDPV;
        private System.Windows.Forms.DateTimePicker dtpNgayPV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtManv;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label14;
    }
}