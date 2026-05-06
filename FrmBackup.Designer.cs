namespace QUANLYNHANSU
{
    partial class FrmBackup
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
            this.btn_Backup = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Backup
            // 
            this.btn_Backup.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_Backup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Backup.ForeColor = System.Drawing.Color.LightCyan;
            this.btn_Backup.Location = new System.Drawing.Point(354, 94);
            this.btn_Backup.Name = "btn_Backup";
            this.btn_Backup.Size = new System.Drawing.Size(107, 39);
            this.btn_Backup.TabIndex = 35;
            this.btn_Backup.Text = "Backup";
            this.btn_Backup.UseVisualStyleBackColor = false;
            this.btn_Backup.Click += new System.EventHandler(this.btn_Backup_Click_1);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnBrowse.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.LightCyan;
            this.btnBrowse.Location = new System.Drawing.Point(354, 37);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(107, 39);
            this.btnBrowse.TabIndex = 36;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtPath.Location = new System.Drawing.Point(17, 37);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(285, 34);
            this.txtPath.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 26);
            this.label1.TabIndex = 62;
            this.label1.Text = "Trang chủ > Backup dữ liệu";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.btn_Backup);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Location = new System.Drawing.Point(162, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 161);
            this.panel1.TabIndex = 63;
            // 
            // FrmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(836, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FrmBackup";
            this.Text = "FrmBackup";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Backup;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}