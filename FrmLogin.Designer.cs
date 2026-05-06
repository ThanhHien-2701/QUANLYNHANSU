namespace QUANLYNHANSU
{
    partial class FrmLogin
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
            this.ckb_ShowPass = new System.Windows.Forms.CheckBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ckb_Manager = new System.Windows.Forms.CheckBox();
            this.ckb_Employee = new System.Windows.Forms.CheckBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.User = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckb_ShowPass
            // 
            this.ckb_ShowPass.AutoSize = true;
            this.ckb_ShowPass.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckb_ShowPass.ForeColor = System.Drawing.Color.LightCyan;
            this.ckb_ShowPass.Location = new System.Drawing.Point(156, 174);
            this.ckb_ShowPass.Name = "ckb_ShowPass";
            this.ckb_ShowPass.Size = new System.Drawing.Size(109, 19);
            this.ckb_ShowPass.TabIndex = 31;
            this.ckb_ShowPass.Text = "Hiện mật khẩu";
            this.ckb_ShowPass.UseVisualStyleBackColor = true;
            this.ckb_ShowPass.CheckedChanged += new System.EventHandler(this.ckb_ShowPass_CheckedChanged);
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.LightCyan;
            this.btn_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Login.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btn_Login.Location = new System.Drawing.Point(123, 262);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(138, 53);
            this.btn_Login.TabIndex = 30;
            this.btn_Login.Text = "Đăng nhập";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightCyan;
            this.label3.Location = new System.Drawing.Point(49, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Mật khẩu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightCyan;
            this.label2.Location = new System.Drawing.Point(49, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Tài khoản:";
            // 
            // ckb_Manager
            // 
            this.ckb_Manager.AutoSize = true;
            this.ckb_Manager.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckb_Manager.ForeColor = System.Drawing.Color.LightCyan;
            this.ckb_Manager.Location = new System.Drawing.Point(243, 207);
            this.ckb_Manager.Name = "ckb_Manager";
            this.ckb_Manager.Size = new System.Drawing.Size(88, 23);
            this.ckb_Manager.TabIndex = 27;
            this.ckb_Manager.Text = "Quản lý";
            this.ckb_Manager.UseVisualStyleBackColor = true;
            this.ckb_Manager.CheckedChanged += new System.EventHandler(this.ckb_Manager_CheckedChanged);
            // 
            // ckb_Employee
            // 
            this.ckb_Employee.AutoSize = true;
            this.ckb_Employee.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckb_Employee.ForeColor = System.Drawing.Color.LightCyan;
            this.ckb_Employee.Location = new System.Drawing.Point(50, 207);
            this.ckb_Employee.Name = "ckb_Employee";
            this.ckb_Employee.Size = new System.Drawing.Size(104, 23);
            this.ckb_Employee.TabIndex = 26;
            this.ckb_Employee.Text = "Nhân viên";
            this.ckb_Employee.UseVisualStyleBackColor = true;
            this.ckb_Employee.CheckedChanged += new System.EventHandler(this.ckb_Employee_CheckedChanged);
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.Color.Azure;
            this.Password.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(156, 141);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(175, 27);
            this.Password.TabIndex = 25;
            // 
            // User
            // 
            this.User.BackColor = System.Drawing.Color.Azure;
            this.User.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User.ForeColor = System.Drawing.Color.MidnightBlue;
            this.User.Location = new System.Drawing.Point(156, 98);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(175, 27);
            this.User.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightCyan;
            this.label1.Location = new System.Drawing.Point(104, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 45);
            this.label1.TabIndex = 23;
            this.label1.Text = "Welcome";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::QUANLYNHANSU.Properties.Resources.TH;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(3, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(526, 185);
            this.panel2.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = global::QUANLYNHANSU.Properties.Resources.banner;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(3, 181);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 317);
            this.panel1.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.User);
            this.panel3.Controls.Add(this.ckb_ShowPass);
            this.panel3.Controls.Add(this.Password);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btn_Login);
            this.panel3.Controls.Add(this.ckb_Employee);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.ckb_Manager);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(559, 82);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(386, 338);
            this.panel3.TabIndex = 32;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(972, 497);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ckb_ShowPass;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckb_Manager;
        private System.Windows.Forms.CheckBox ckb_Employee;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox User;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
    }
}