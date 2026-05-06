namespace QUANLYNHANSU
{
    partial class FrmMail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGui = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.txtND = new System.Windows.Forms.TextBox();
            this.txtTieude = new System.Windows.Forms.TextBox();
            this.lblND = new System.Windows.Forms.Label();
            this.lblTieude = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNguoinhan = new System.Windows.Forms.Label();
            this.txtNguoinhan = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.txtNguoinhan);
            this.panel1.Controls.Add(this.lblNguoinhan);
            this.panel1.Controls.Add(this.txtND);
            this.panel1.Controls.Add(this.txtTieude);
            this.panel1.Controls.Add(this.lblND);
            this.panel1.Controls.Add(this.lblTieude);
            this.panel1.Location = new System.Drawing.Point(148, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 317);
            this.panel1.TabIndex = 0;
            // 
            // btnGui
            // 
            this.btnGui.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnGui.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGui.ForeColor = System.Drawing.Color.LightCyan;
            this.btnGui.Location = new System.Drawing.Point(597, 477);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(134, 50);
            this.btnGui.TabIndex = 5;
            this.btnGui.Text = "Gửi mail";
            this.btnGui.UseVisualStyleBackColor = false;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.DarkRed;
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(457, 477);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(134, 50);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtND
            // 
            this.txtND.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtND.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtND.Location = new System.Drawing.Point(147, 146);
            this.txtND.Multiline = true;
            this.txtND.Name = "txtND";
            this.txtND.Size = new System.Drawing.Size(396, 131);
            this.txtND.TabIndex = 3;
            // 
            // txtTieude
            // 
            this.txtTieude.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTieude.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtTieude.Location = new System.Drawing.Point(147, 88);
            this.txtTieude.Name = "txtTieude";
            this.txtTieude.Size = new System.Drawing.Size(396, 27);
            this.txtTieude.TabIndex = 2;
            // 
            // lblND
            // 
            this.lblND.AutoSize = true;
            this.lblND.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblND.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblND.Location = new System.Drawing.Point(27, 137);
            this.lblND.Name = "lblND";
            this.lblND.Size = new System.Drawing.Size(91, 23);
            this.lblND.TabIndex = 1;
            this.lblND.Text = "Nội dung:";
            // 
            // lblTieude
            // 
            this.lblTieude.AutoSize = true;
            this.lblTieude.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieude.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTieude.Location = new System.Drawing.Point(27, 88);
            this.lblTieude.Name = "lblTieude";
            this.lblTieude.Size = new System.Drawing.Size(79, 23);
            this.lblTieude.TabIndex = 0;
            this.lblTieude.Text = "Tiêu đề:";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::QUANLYNHANSU.Properties.Resources.TH;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(147, 108);
            this.panel3.TabIndex = 59;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(148, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 108);
            this.panel2.TabIndex = 60;
            // 
            // lblNguoinhan
            // 
            this.lblNguoinhan.AutoSize = true;
            this.lblNguoinhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoinhan.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblNguoinhan.Location = new System.Drawing.Point(27, 39);
            this.lblNguoinhan.Name = "lblNguoinhan";
            this.lblNguoinhan.Size = new System.Drawing.Size(114, 23);
            this.lblNguoinhan.TabIndex = 4;
            this.lblNguoinhan.Text = "Người nhận:";
            // 
            // txtNguoinhan
            // 
            this.txtNguoinhan.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoinhan.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtNguoinhan.Location = new System.Drawing.Point(147, 36);
            this.txtNguoinhan.Name = "txtNguoinhan";
            this.txtNguoinhan.Size = new System.Drawing.Size(396, 27);
            this.txtNguoinhan.TabIndex = 5;
            // 
            // FrmMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(888, 568);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMail";
            this.Text = "FrmMail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.TextBox txtND;
        private System.Windows.Forms.TextBox txtTieude;
        private System.Windows.Forms.Label lblND;
        private System.Windows.Forms.Label lblTieude;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNguoinhan;
        private System.Windows.Forms.Label lblNguoinhan;
    }
}