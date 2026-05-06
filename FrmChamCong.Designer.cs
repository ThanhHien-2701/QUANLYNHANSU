namespace QUANLYNHANSU
{
    partial class FrmChamCong
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.dtpGioRa = new System.Windows.Forms.DateTimePicker();
            this.dtpGioVao = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayChamCong = new System.Windows.Forms.DateTimePicker();
            this.txtMaBCC = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Location = new System.Drawing.Point(12, 240);
            this.dgvData.Name = "dgvData";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(1394, 497);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.cboMaNV);
            this.groupBox1.Controls.Add(this.dtpGioRa);
            this.groupBox1.Controls.Add(this.dtpGioVao);
            this.groupBox1.Controls.Add(this.dtpNgayChamCong);
            this.groupBox1.Controls.Add(this.txtMaBCC);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 220);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập dữ liệu chấm công";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DarkRed;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(636, 116);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 41);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.LightCyan;
            this.btnSua.Location = new System.Drawing.Point(506, 116);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(102, 41);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.LightCyan;
            this.btnThem.Location = new System.Drawing.Point(371, 116);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(102, 41);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cboMaNV
            // 
            this.cboMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaNV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNV.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(486, 34);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(250, 27);
            this.cboMaNV.TabIndex = 9;
            // 
            // dtpGioRa
            // 
            this.dtpGioRa.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpGioRa.CalendarTitleForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpGioRa.CalendarTrailingForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpGioRa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpGioRa.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpGioRa.Location = new System.Drawing.Point(167, 166);
            this.dtpGioRa.Name = "dtpGioRa";
            this.dtpGioRa.ShowUpDown = true;
            this.dtpGioRa.Size = new System.Drawing.Size(184, 27);
            this.dtpGioRa.TabIndex = 8;
            // 
            // dtpGioVao
            // 
            this.dtpGioVao.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpGioVao.CalendarTitleForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpGioVao.CalendarTrailingForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpGioVao.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpGioVao.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpGioVao.Location = new System.Drawing.Point(167, 122);
            this.dtpGioVao.Name = "dtpGioVao";
            this.dtpGioVao.ShowUpDown = true;
            this.dtpGioVao.Size = new System.Drawing.Size(184, 27);
            this.dtpGioVao.TabIndex = 7;
            // 
            // dtpNgayChamCong
            // 
            this.dtpNgayChamCong.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpNgayChamCong.CalendarMonthBackground = System.Drawing.Color.LightCyan;
            this.dtpNgayChamCong.CalendarTitleForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpNgayChamCong.CalendarTrailingForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpNgayChamCong.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayChamCong.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayChamCong.Location = new System.Drawing.Point(167, 79);
            this.dtpNgayChamCong.Name = "dtpNgayChamCong";
            this.dtpNgayChamCong.Size = new System.Drawing.Size(184, 27);
            this.dtpNgayChamCong.TabIndex = 6;
            // 
            // txtMaBCC
            // 
            this.txtMaBCC.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaBCC.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMaBCC.Location = new System.Drawing.Point(167, 34);
            this.txtMaBCC.Name = "txtMaBCC";
            this.txtMaBCC.Size = new System.Drawing.Size(184, 27);
            this.txtMaBCC.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(367, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "Mã nhân viên:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 19);
            this.label6.TabIndex = 3;
            this.label6.Text = "Giờ ra:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Giờ vào:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ngày chấm công:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã chấm công:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.btnLoc);
            this.groupBox2.Controls.Add(this.txtSoluong);
            this.groupBox2.Controls.Add(this.cboNam);
            this.groupBox2.Controls.Add(this.cboThang);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox2.Location = new System.Drawing.Point(768, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(638, 220);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lọc dữ liệu";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LightCyan;
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.Location = new System.Drawing.Point(514, 29);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 42);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnLoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.ForeColor = System.Drawing.Color.LightCyan;
            this.btnLoc.Location = new System.Drawing.Point(408, 29);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(100, 42);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // txtSoluong
            // 
            this.txtSoluong.Enabled = false;
            this.txtSoluong.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoluong.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtSoluong.Location = new System.Drawing.Point(246, 134);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(100, 27);
            this.txtSoluong.TabIndex = 5;
            // 
            // cboNam
            // 
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(146, 84);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(200, 27);
            this.cboNam.TabIndex = 4;
            // 
            // cboThang
            // 
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThang.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(146, 34);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(200, 27);
            this.cboThang.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 19);
            this.label8.TabIndex = 2;
            this.label8.Text = "Số lượng bản ghi tìm thấy:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Năm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng:";
            // 
            // FrmChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1420, 757);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvData);
            this.Name = "FrmChamCong";
            this.Text = "Quản lý chấm công";
            this.Load += new System.EventHandler(this.FrmChamCong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaBCC;
        private System.Windows.Forms.DateTimePicker dtpNgayChamCong;
        private System.Windows.Forms.DateTimePicker dtpGioVao;
        private System.Windows.Forms.DateTimePicker dtpGioRa;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnRefresh;
    }
}
