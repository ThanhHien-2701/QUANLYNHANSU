namespace QUANLYNHANSU
{
    partial class FrmNghiPhep
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupInfo = new System.Windows.Forms.GroupBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaNP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupActions = new System.Windows.Forms.GroupBox();
            this.cbbLocTrangThai = new System.Windows.Forms.ComboBox();
            this.lblLoc = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.groupInfo.SuspendLayout();
            this.groupActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupInfo
            // 
            this.groupInfo.BackColor = System.Drawing.Color.LightCyan;
            this.groupInfo.Controls.Add(this.cboTrangThai);
            this.groupInfo.Controls.Add(this.label6);
            this.groupInfo.Controls.Add(this.txtLyDo);
            this.groupInfo.Controls.Add(this.label5);
            this.groupInfo.Controls.Add(this.dtpDenNgay);
            this.groupInfo.Controls.Add(this.label4);
            this.groupInfo.Controls.Add(this.dtpTuNgay);
            this.groupInfo.Controls.Add(this.label3);
            this.groupInfo.Controls.Add(this.cboMaNV);
            this.groupInfo.Controls.Add(this.label2);
            this.groupInfo.Controls.Add(this.txtMaNP);
            this.groupInfo.Controls.Add(this.label1);
            this.groupInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupInfo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupInfo.Location = new System.Drawing.Point(12, 46);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(405, 324);
            this.groupInfo.TabIndex = 1;
            this.groupInfo.TabStop = false;
            this.groupInfo.Text = "Thông tin nghỉ phép";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTrangThai.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(129, 281);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(268, 27);
            this.cboTrangThai.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Trạng thái:";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLyDo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtLyDo.Location = new System.Drawing.Point(129, 209);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(268, 57);
            this.txtLyDo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Lý do:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpDenNgay.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay.Location = new System.Drawing.Point(129, 167);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(267, 27);
            this.dtpDenNgay.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtpTuNgay.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay.Location = new System.Drawing.Point(129, 123);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(267, 27);
            this.dtpTuNgay.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Từ ngày:";
            // 
            // cboMaNV
            // 
            this.cboMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaNV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNV.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(129, 82);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(267, 27);
            this.cboMaNV.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã nhân viên:";
            // 
            // txtMaNP
            // 
            this.txtMaNP.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNP.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMaNP.Location = new System.Drawing.Point(129, 40);
            this.txtMaNP.Name = "txtMaNP";
            this.txtMaNP.Size = new System.Drawing.Size(267, 27);
            this.txtMaNP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã nghỉ phép:";
            // 
            // groupActions
            // 
            this.groupActions.BackColor = System.Drawing.Color.LightCyan;
            this.groupActions.Controls.Add(this.cbbLocTrangThai);
            this.groupActions.Controls.Add(this.lblLoc);
            this.groupActions.Controls.Add(this.btnXoa);
            this.groupActions.Controls.Add(this.btnRefresh);
            this.groupActions.Controls.Add(this.btnSua);
            this.groupActions.Controls.Add(this.btnTim);
            this.groupActions.Controls.Add(this.btnThem);
            this.groupActions.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupActions.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupActions.Location = new System.Drawing.Point(12, 376);
            this.groupActions.Name = "groupActions";
            this.groupActions.Size = new System.Drawing.Size(405, 196);
            this.groupActions.TabIndex = 2;
            this.groupActions.TabStop = false;
            this.groupActions.Text = "Chức năng";
            // 
            // cbbLocTrangThai
            // 
            this.cbbLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLocTrangThai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLocTrangThai.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cbbLocTrangThai.FormattingEnabled = true;
            this.cbbLocTrangThai.Location = new System.Drawing.Point(191, 155);
            this.cbbLocTrangThai.Name = "cbbLocTrangThai";
            this.cbbLocTrangThai.Size = new System.Drawing.Size(121, 30);
            this.cbbLocTrangThai.TabIndex = 6;
            this.cbbLocTrangThai.SelectionChangeCommitted += new System.EventHandler(this.cbbLocTrangThai_SelectionChangeCommitted);
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.BackColor = System.Drawing.Color.LightCyan;
            this.lblLoc.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblLoc.Location = new System.Drawing.Point(85, 158);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(91, 23);
            this.lblLoc.TabIndex = 5;
            this.lblLoc.Text = "Lọc theo:";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DarkRed;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(283, 29);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(114, 48);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LightCyan;
            this.btnRefresh.Location = new System.Drawing.Point(213, 94);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(114, 48);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSua.ForeColor = System.Drawing.Color.LightCyan;
            this.btnSua.Location = new System.Drawing.Point(144, 29);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(114, 48);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTim.ForeColor = System.Drawing.Color.LightCyan;
            this.btnTim.Location = new System.Drawing.Point(73, 94);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(114, 48);
            this.btnTim.TabIndex = 1;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnThem.ForeColor = System.Drawing.Color.LightCyan;
            this.btnThem.Location = new System.Drawing.Point(7, 29);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(114, 48);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvData
            // 
            this.dgvData.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
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
            this.dgvData.Location = new System.Drawing.Point(424, 46);
            this.dgvData.Name = "dgvData";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(752, 526);
            this.dgvData.TabIndex = 3;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(7, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(310, 26);
            this.label7.TabIndex = 62;
            this.label7.Text = "Trang chủ > Quản lý nghỉ phép";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // FrmNghiPhep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1188, 585);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupActions);
            this.Controls.Add(this.groupInfo);
            this.Name = "FrmNghiPhep";
            this.Text = "Quản lý nghỉ phép";
            this.Load += new System.EventHandler(this.FrmNghiPhep_Load);
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            this.groupActions.ResumeLayout(false);
            this.groupActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupInfo;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaNP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupActions;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ComboBox cbbLocTrangThai;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.Label label7;
    }
}


