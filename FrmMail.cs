    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Net.Mail;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Net;
    using System.Net.Mail;

    namespace QUANLYNHANSU
    {
        public partial class FrmMail : Form
        {
        private string attachmentPath;

        public FrmMail(string pdfFile = null)   // <-- constructor mới
        {
            InitializeComponent();
            attachmentPath = pdfFile;  // lưu đường dẫn file
        }
        public FrmMail()
            {
                InitializeComponent();
            }

            private void btnHuy_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnGui_Click(object sender, EventArgs e)
            {
                try
                {
                    string toEmail = txtNguoinhan.Text.Trim();
                    string subject = txtTieude.Text.Trim();
                    string body = txtND.Text.Trim();

                    if (string.IsNullOrWhiteSpace(toEmail))
                    {
                        MessageBox.Show("Vui lòng nhập email người nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(subject))
                    {
                        MessageBox.Show("Vui lòng nhập tiêu đề!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // ============= SETUP GMAIL =============
                    string fromEmail = "thanhhienle08@gmail.com";   // Email gửi
                    string appPassword = "utzc iisz acdb wazp";     // Mật khẩu ứng dụng Google App Password

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(fromEmail);

                    // Cho phép nhập nhiều email: cách nhau bởi ;
                    string[] recipients = toEmail.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string email in recipients)
                    {
                        mail.To.Add(email.Trim());
                    }

                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = false;

                // Chỉ thêm attachment nếu có đường dẫn hợp lệ
                if (!string.IsNullOrWhiteSpace(attachmentPath))
                {
                    mail.Attachments.Add(new Attachment(attachmentPath));
                }

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(fromEmail, appPassword);

                    smtp.Send(mail);

                    MessageBox.Show("Gửi email thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
