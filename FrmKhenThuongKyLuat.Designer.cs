namespace QUANLYNHANSU
{
	partial class FrmKhenThuongKyLuat
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
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.txt_Sotien = new System.Windows.Forms.TextBox();
            this.lbl_Sotien = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.cboMaTC = new System.Windows.Forms.ComboBox();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.lblLoai = new System.Windows.Forms.Label();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.lblMaTC = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.groupBoxAction = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTimMa = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.BackColor = System.Drawing.Color.LightCyan;
            this.groupBoxInfo.Controls.Add(this.txt_Sotien);
            this.groupBoxInfo.Controls.Add(this.lbl_Sotien);
            this.groupBoxInfo.Controls.Add(this.cboLoai);
            this.groupBoxInfo.Controls.Add(this.txtMa);
            this.groupBoxInfo.Controls.Add(this.cboMaNV);
            this.groupBoxInfo.Controls.Add(this.cboMaTC);
            this.groupBoxInfo.Controls.Add(this.dtpNgay);
            this.groupBoxInfo.Controls.Add(this.txtGhiChu);
            this.groupBoxInfo.Controls.Add(this.lblMa);
            this.groupBoxInfo.Controls.Add(this.lblLoai);
            this.groupBoxInfo.Controls.Add(this.lblMaNV);
            this.groupBoxInfo.Controls.Add(this.lblMaTC);
            this.groupBoxInfo.Controls.Add(this.lblNgay);
            this.groupBoxInfo.Controls.Add(this.lblGhiChu);
            this.groupBoxInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInfo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBoxInfo.Location = new System.Drawing.Point(12, 9);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(617, 200);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Thông tin";
            // 
            // txt_Sotien
            // 
            this.txt_Sotien.Location = new System.Drawing.Point(419, 72);
            this.txt_Sotien.Name = "txt_Sotien";
            this.txt_Sotien.Size = new System.Drawing.Size(178, 30);
            this.txt_Sotien.TabIndex = 7;
            // 
            // lbl_Sotien
            // 
            this.lbl_Sotien.AutoSize = true;
            this.lbl_Sotien.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Sotien.Location = new System.Drawing.Point(326, 79);
            this.lbl_Sotien.Name = "lbl_Sotien";
            this.lbl_Sotien.Size = new System.Drawing.Size(68, 20);
            this.lbl_Sotien.TabIndex = 6;
            this.lbl_Sotien.Text = "Số tiền:";
            // 
            // cboLoai
            // 
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoai.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Items.AddRange(new object[] {
            "KhenThuong",
            "KyLuat"});
            this.cboLoai.Location = new System.Drawing.Point(104, 116);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(172, 27);
            this.cboLoai.TabIndex = 1;
            this.cboLoai.SelectedIndexChanged += new System.EventHandler(this.cboLoai_SelectedIndexChanged);
            // 
            // txtMa
            // 
            this.txtMa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMa.Location = new System.Drawing.Point(104, 35);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(172, 27);
            this.txtMa.TabIndex = 0;
            // 
            // cboMaNV
            // 
            this.cboMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaNV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNV.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(104, 72);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(172, 27);
            this.cboMaNV.TabIndex = 2;
            // 
            // cboMaTC
            // 
            this.cboMaTC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaTC.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaTC.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboMaTC.FormattingEnabled = true;
            this.cboMaTC.Location = new System.Drawing.Point(104, 156);
            this.cboMaTC.Name = "cboMaTC";
            this.cboMaTC.Size = new System.Drawing.Size(172, 27);
            this.cboMaTC.TabIndex = 3;
            // 
            // dtpNgay
            // 
            this.dtpNgay.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpNgay.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgay.Location = new System.Drawing.Point(419, 35);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(178, 27);
            this.dtpNgay.TabIndex = 4;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtGhiChu.Location = new System.Drawing.Point(419, 116);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(178, 45);
            this.txtGhiChu.TabIndex = 5;
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMa.Location = new System.Drawing.Point(18, 38);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(39, 19);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã:";
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoai.Location = new System.Drawing.Point(18, 119);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(49, 19);
            this.lblLoai.TabIndex = 0;
            this.lblLoai.Text = "Loại:";
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.Location = new System.Drawing.Point(18, 77);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(64, 19);
            this.lblMaNV.TabIndex = 0;
            this.lblMaNV.Text = "Mã NV:";
            // 
            // lblMaTC
            // 
            this.lblMaTC.AutoSize = true;
            this.lblMaTC.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaTC.Location = new System.Drawing.Point(18, 158);
            this.lblMaTC.Name = "lblMaTC";
            this.lblMaTC.Size = new System.Drawing.Size(65, 19);
            this.lblMaTC.TabIndex = 0;
            this.lblMaTC.Text = "Mã TC:";
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgay.Location = new System.Drawing.Point(326, 38);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(52, 19);
            this.lblNgay.TabIndex = 0;
            this.lblNgay.Text = "Ngày:";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.Location = new System.Drawing.Point(326, 119);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(74, 19);
            this.lblGhiChu.TabIndex = 0;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // groupBoxAction
            // 
            this.groupBoxAction.BackColor = System.Drawing.Color.LightCyan;
            this.groupBoxAction.Controls.Add(this.btnThem);
            this.groupBoxAction.Controls.Add(this.btnSua);
            this.groupBoxAction.Controls.Add(this.btnLamMoi);
            this.groupBoxAction.Controls.Add(this.txtTimMa);
            this.groupBoxAction.Controls.Add(this.btnTim);
            this.groupBoxAction.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAction.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBoxAction.Location = new System.Drawing.Point(635, 9);
            this.groupBoxAction.Name = "groupBoxAction";
            this.groupBoxAction.Size = new System.Drawing.Size(365, 200);
            this.groupBoxAction.TabIndex = 1;
            this.groupBoxAction.TabStop = false;
            this.groupBoxAction.Text = "Chức năng";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.LightCyan;
            this.btnThem.Location = new System.Drawing.Point(20, 51);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(105, 45);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSua.ForeColor = System.Drawing.Color.LightCyan;
            this.btnSua.Location = new System.Drawing.Point(131, 51);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(105, 45);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.LightCyan;
            this.btnLamMoi.Location = new System.Drawing.Point(242, 51);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(105, 45);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtTimMa
            // 
            this.txtTimMa.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimMa.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtTimMa.Location = new System.Drawing.Point(179, 125);
            this.txtTimMa.Name = "txtTimMa";
            this.txtTimMa.Size = new System.Drawing.Size(168, 28);
            this.txtTimMa.TabIndex = 4;
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTim.ForeColor = System.Drawing.Color.LightCyan;
            this.btnTim.Location = new System.Drawing.Point(20, 115);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(105, 45);
            this.btnTim.TabIndex = 5;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Location = new System.Drawing.Point(12, 215);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(988, 415);
            this.dgv.TabIndex = 2;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // FrmKhenThuongKyLuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1012, 639);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupBoxAction);
            this.Controls.Add(this.groupBoxInfo);
            this.Name = "FrmKhenThuongKyLuat";
            this.Text = "Quản lý khen thưởng / kỷ luật";
            this.Load += new System.EventHandler(this.FrmKhenThuongKyLuat_Load);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.groupBoxAction.ResumeLayout(false);
            this.groupBoxAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxInfo;
		private System.Windows.Forms.ComboBox cboLoai;
		private System.Windows.Forms.TextBox txtMa;
		private System.Windows.Forms.ComboBox cboMaNV;
		private System.Windows.Forms.ComboBox cboMaTC;
		private System.Windows.Forms.DateTimePicker dtpNgay;
		private System.Windows.Forms.TextBox txtGhiChu;
		private System.Windows.Forms.Label lblMa;
		private System.Windows.Forms.Label lblLoai;
		private System.Windows.Forms.Label lblMaNV;
		private System.Windows.Forms.Label lblMaTC;
		private System.Windows.Forms.Label lblNgay;
		private System.Windows.Forms.Label lblGhiChu;
		private System.Windows.Forms.GroupBox groupBoxAction;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.Button btnLamMoi;
		private System.Windows.Forms.TextBox txtTimMa;
		private System.Windows.Forms.Button btnTim;
		private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txt_Sotien;
        private System.Windows.Forms.Label lbl_Sotien;
    }
}

