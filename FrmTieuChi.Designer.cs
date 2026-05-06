namespace QUANLYNHANSU
{
	partial class FrmTieuChi
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblLoai = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.groupBoxAction = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTim = new System.Windows.Forms.Label();
            this.txtTimMa = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.BackColor = System.Drawing.Color.LightCyan;
            this.groupBoxInfo.Controls.Add(this.txtMa);
            this.groupBoxInfo.Controls.Add(this.txtTen);
            this.groupBoxInfo.Controls.Add(this.cboLoai);
            this.groupBoxInfo.Controls.Add(this.txtMoTa);
            this.groupBoxInfo.Controls.Add(this.lblMa);
            this.groupBoxInfo.Controls.Add(this.lblTen);
            this.groupBoxInfo.Controls.Add(this.lblLoai);
            this.groupBoxInfo.Controls.Add(this.lblMoTa);
            this.groupBoxInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInfo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBoxInfo.Location = new System.Drawing.Point(12, 44);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(520, 167);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Thông tin tiêu chí";
            // 
            // txtMa
            // 
            this.txtMa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMa.Location = new System.Drawing.Point(78, 33);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(160, 27);
            this.txtMa.TabIndex = 0;
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtTen.Location = new System.Drawing.Point(78, 77);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(160, 27);
            this.txtTen.TabIndex = 1;
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
            this.cboLoai.Location = new System.Drawing.Point(78, 122);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(160, 27);
            this.cboLoai.TabIndex = 2;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTa.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMoTa.Location = new System.Drawing.Point(312, 33);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(186, 71);
            this.txtMoTa.TabIndex = 3;
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMa.Location = new System.Drawing.Point(18, 36);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(39, 19);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã:";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.Location = new System.Drawing.Point(18, 80);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(42, 19);
            this.lblTen.TabIndex = 0;
            this.lblTen.Text = "Tên:";
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoai.Location = new System.Drawing.Point(18, 125);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(49, 19);
            this.lblLoai.TabIndex = 0;
            this.lblLoai.Text = "Loại:";
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.Location = new System.Drawing.Point(248, 36);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(58, 19);
            this.lblMoTa.TabIndex = 0;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // groupBoxAction
            // 
            this.groupBoxAction.BackColor = System.Drawing.Color.LightCyan;
            this.groupBoxAction.Controls.Add(this.btnThem);
            this.groupBoxAction.Controls.Add(this.btnSua);
            this.groupBoxAction.Controls.Add(this.btnXoa);
            this.groupBoxAction.Controls.Add(this.btnLamMoi);
            this.groupBoxAction.Controls.Add(this.lblTim);
            this.groupBoxAction.Controls.Add(this.txtTimMa);
            this.groupBoxAction.Controls.Add(this.btnTim);
            this.groupBoxAction.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAction.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBoxAction.Location = new System.Drawing.Point(538, 44);
            this.groupBoxAction.Name = "groupBoxAction";
            this.groupBoxAction.Size = new System.Drawing.Size(379, 167);
            this.groupBoxAction.TabIndex = 1;
            this.groupBoxAction.TabStop = false;
            this.groupBoxAction.Text = "Chức năng";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnThem.ForeColor = System.Drawing.Color.LightCyan;
            this.btnThem.Location = new System.Drawing.Point(15, 22);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(106, 46);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSua.ForeColor = System.Drawing.Color.LightCyan;
            this.btnSua.Location = new System.Drawing.Point(145, 22);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(105, 46);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DarkRed;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(268, 22);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(105, 46);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.LightCyan;
            this.btnLamMoi.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnLamMoi.Location = new System.Drawing.Point(266, 110);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLamMoi.Size = new System.Drawing.Size(105, 46);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // lblTim
            // 
            this.lblTim.AutoSize = true;
            this.lblTim.Location = new System.Drawing.Point(9, 92);
            this.lblTim.Name = "lblTim";
            this.lblTim.Size = new System.Drawing.Size(123, 23);
            this.lblTim.TabIndex = 0;
            this.lblTim.Text = "Tìm theo mã:";
            // 
            // txtTimMa
            // 
            this.txtTimMa.Location = new System.Drawing.Point(13, 119);
            this.txtTimMa.Name = "txtTimMa";
            this.txtTimMa.Size = new System.Drawing.Size(130, 30);
            this.txtTimMa.TabIndex = 4;
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTim.ForeColor = System.Drawing.Color.LightCyan;
            this.btnTim.Location = new System.Drawing.Point(155, 110);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(105, 46);
            this.btnTim.TabIndex = 5;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.Location = new System.Drawing.Point(12, 224);
            this.dgv.Name = "dgv";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(905, 398);
            this.dgv.TabIndex = 2;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 26);
            this.label1.TabIndex = 62;
            this.label1.Text = "Trang chủ > Quản lý tiêu chí";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FrmTieuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(929, 634);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupBoxAction);
            this.Controls.Add(this.groupBoxInfo);
            this.Name = "FrmTieuChi";
            this.Text = "Quản lý tiêu chí";
            this.Load += new System.EventHandler(this.FrmTieuChi_Load);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.groupBoxAction.ResumeLayout(false);
            this.groupBoxAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private System.Windows.Forms.GroupBox groupBoxInfo;
		private System.Windows.Forms.TextBox txtMa;
		private System.Windows.Forms.TextBox txtTen;
		private System.Windows.Forms.ComboBox cboLoai;
		private System.Windows.Forms.TextBox txtMoTa;
		private System.Windows.Forms.Label lblMa;
		private System.Windows.Forms.Label lblTen;
		private System.Windows.Forms.Label lblLoai;
		private System.Windows.Forms.Label lblMoTa;
		private System.Windows.Forms.GroupBox groupBoxAction;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnLamMoi;
		private System.Windows.Forms.Label lblTim;
		private System.Windows.Forms.TextBox txtTimMa;
		private System.Windows.Forms.Button btnTim;
		private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
    }
}

