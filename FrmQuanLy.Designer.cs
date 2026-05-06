namespace QUANLYNHANSU
{
    partial class FrmQuanLy
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nộiBộToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PhongBanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HDLDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TuyenDungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NhansuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nghỉPhépToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tieuChiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Topic = new System.Windows.Forms.Panel();
            this.BtnNext = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelFather = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.Topic.SuspendLayout();
            this.panelFather.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightCyan;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nộiBộToolStripMenuItem,
            this.TuyenDungToolStripMenuItem,
            this.NhansuToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(525, 35);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nộiBộToolStripMenuItem
            // 
            this.nộiBộToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PhongBanToolStripMenuItem,
            this.HDLDToolStripMenuItem,
            this.backupDữLiệuToolStripMenuItem});
            this.nộiBộToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nộiBộToolStripMenuItem.ForeColor = System.Drawing.Color.MidnightBlue;
            this.nộiBộToolStripMenuItem.Name = "nộiBộToolStripMenuItem";
            this.nộiBộToolStripMenuItem.Size = new System.Drawing.Size(172, 29);
            this.nộiBộToolStripMenuItem.Text = "Quản lý nội bộ";
            // 
            // PhongBanToolStripMenuItem
            // 
            this.PhongBanToolStripMenuItem.ForeColor = System.Drawing.Color.MidnightBlue;
            this.PhongBanToolStripMenuItem.Name = "PhongBanToolStripMenuItem";
            this.PhongBanToolStripMenuItem.Size = new System.Drawing.Size(289, 30);
            this.PhongBanToolStripMenuItem.Text = "Phòng ban";
            this.PhongBanToolStripMenuItem.Click += new System.EventHandler(this.PhongBanToolStripMenuItem_Click);
            // 
            // HDLDToolStripMenuItem
            // 
            this.HDLDToolStripMenuItem.ForeColor = System.Drawing.Color.MidnightBlue;
            this.HDLDToolStripMenuItem.Name = "HDLDToolStripMenuItem";
            this.HDLDToolStripMenuItem.Size = new System.Drawing.Size(289, 30);
            this.HDLDToolStripMenuItem.Text = "Hợp đồng lao động";
            this.HDLDToolStripMenuItem.Click += new System.EventHandler(this.HDLDToolStripMenuItem_Click);
            // 
            // backupDữLiệuToolStripMenuItem
            // 
            this.backupDữLiệuToolStripMenuItem.ForeColor = System.Drawing.Color.MidnightBlue;
            this.backupDữLiệuToolStripMenuItem.Name = "backupDữLiệuToolStripMenuItem";
            this.backupDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(289, 30);
            this.backupDữLiệuToolStripMenuItem.Text = "Backup dữ liệu";
            this.backupDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.backupDữLiệuToolStripMenuItem_Click);
            // 
            // TuyenDungToolStripMenuItem
            // 
            this.TuyenDungToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TuyenDungToolStripMenuItem.ForeColor = System.Drawing.Color.MidnightBlue;
            this.TuyenDungToolStripMenuItem.Name = "TuyenDungToolStripMenuItem";
            this.TuyenDungToolStripMenuItem.Size = new System.Drawing.Size(144, 29);
            this.TuyenDungToolStripMenuItem.Text = "Tuyển dụng";
            this.TuyenDungToolStripMenuItem.Click += new System.EventHandler(this.TuyenDungToolStripMenuItem_Click);
            // 
            // NhansuToolStripMenuItem
            // 
            this.NhansuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhânViênToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem,
            this.nghỉPhépToolStripMenuItem,
            this.tieuChiToolStripMenuItem});
            this.NhansuToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NhansuToolStripMenuItem.ForeColor = System.Drawing.Color.MidnightBlue;
            this.NhansuToolStripMenuItem.Name = "NhansuToolStripMenuItem";
            this.NhansuToolStripMenuItem.Size = new System.Drawing.Size(110, 29);
            this.NhansuToolStripMenuItem.Text = "Nhân sự";
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(201, 30);
            this.nhânViênToolStripMenuItem.Text = "Nhân viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(201, 30);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            this.tàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.tàiKhoảnToolStripMenuItem_Click);
            // 
            // nghỉPhépToolStripMenuItem
            // 
            this.nghỉPhépToolStripMenuItem.Name = "nghỉPhépToolStripMenuItem";
            this.nghỉPhépToolStripMenuItem.Size = new System.Drawing.Size(201, 30);
            this.nghỉPhépToolStripMenuItem.Text = "Nghỉ phép";
            this.nghỉPhépToolStripMenuItem.Click += new System.EventHandler(this.nghỉPhépToolStripMenuItem_Click);
            // 
            // tieuChiToolStripMenuItem
            // 
            this.tieuChiToolStripMenuItem.Name = "tieuChiToolStripMenuItem";
            this.tieuChiToolStripMenuItem.Size = new System.Drawing.Size(201, 30);
            this.tieuChiToolStripMenuItem.Text = "Tiêu chí";
            this.tieuChiToolStripMenuItem.Click += new System.EventHandler(this.tieuChiToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thoátToolStripMenuItem.ForeColor = System.Drawing.Color.MidnightBlue;
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(86, 29);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // Topic
            // 
            this.Topic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Topic.BackColor = System.Drawing.Color.Azure;
            this.Topic.Controls.Add(this.BtnNext);
            this.Topic.Location = new System.Drawing.Point(0, 40);
            this.Topic.Name = "Topic";
            this.Topic.Size = new System.Drawing.Size(1274, 635);
            this.Topic.TabIndex = 3;
            // 
            // BtnNext
            // 
            this.BtnNext.Location = new System.Drawing.Point(1177, 601);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(94, 31);
            this.BtnNext.TabIndex = 3;
            this.BtnNext.Text = ">>";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // panelFather
            // 
            this.panelFather.BackColor = System.Drawing.Color.LightCyan;
            this.panelFather.Controls.Add(this.menuStrip1);
            this.panelFather.Controls.Add(this.Topic);
            this.panelFather.Location = new System.Drawing.Point(0, 107);
            this.panelFather.Name = "panelFather";
            this.panelFather.Size = new System.Drawing.Size(1277, 678);
            this.panelFather.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(146, -4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1131, 108);
            this.panel2.TabIndex = 65;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightCyan;
            this.label5.Location = new System.Drawing.Point(205, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(732, 53);
            this.label5.TabIndex = 0;
            this.label5.Text = "HỆ THỐNG QUẢN LÝ NHÂN SỰ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::QUANLYNHANSU.Properties.Resources.TH1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(-6, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 108);
            this.panel1.TabIndex = 63;
            // 
            // FrmQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 786);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelFather);
            this.Name = "FrmQuanLy";
            this.Text = "FrmQuanLy";
            this.Load += new System.EventHandler(this.FrmQuanLy_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Topic.ResumeLayout(false);
            this.panelFather.ResumeLayout(false);
            this.panelFather.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nộiBộToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PhongBanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HDLDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TuyenDungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NhansuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.Panel Topic;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelFather;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nghỉPhépToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tieuChiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupDữLiệuToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
    }
}