using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    public partial class FrmBackup : Form
    {
        public FrmBackup()
        {
            InitializeComponent();
        }
        //SqlConnection SqlConn = new SqlConnection(@"Data Source=MAC-HIENLTT23\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True");
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = fd.SelectedPath;
            }
        }

        private void btn_Backup_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPath.Text))
                {
                    MessageBox.Show("Vui lòng chọn đường dẫn lưu file backup!");
                    return;
                }

                string backupFile = Path.Combine(
                    txtPath.Text,
                    "QUANLYNHANSU_Backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak"
                );

                using (SqlConnection sqlConn = new SqlConnection(@"Data Source=MAC-HIENLTT23\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True"))
                {
                    sqlConn.Open();
                    string query = $@"BACKUP DATABASE [QUANLYNHANSU] TO  DISK = '{backupFile}' WITH NOFORMAT, NOINIT,  NAME = N'QUANLYNHANSU-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                    //string query = "BACKUP DATABASE ["+sqlConn.Database+"] TO  DISK = N'"+txtPath.Text+".bak'";
                    SqlCommand cmd = new SqlCommand(query, sqlConn);
                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    MessageBox.Show("Backup thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
