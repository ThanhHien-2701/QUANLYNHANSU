using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static QUANLYNHANSU.Session;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QUANLYNHANSU
{
    public partial class FrmLogin : Form
    {
        public static string tenNhanVienDangNhap;
        public static string tenChucVu;
        public static string diaChiChiNhanh;
        public static string SDTChiNhanh;
        public static string MANV;

        // ==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================

        public FrmLogin()
        {
            InitializeComponent();
            Password.UseSystemPasswordChar = true;

        }
        // ==================== AUTO RESIZE ====================
        private void StoreOriginalSizes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                originalControlBounds[c] = c.Bounds;
                if (c.Controls.Count > 0)
                    StoreOriginalSizes(c);
            }
        }
        private void ResizeAllControls(Control parent)
        {
            float xRatio = (float)this.Width / originalFormSize.Width;
            float yRatio = (float)this.Height / originalFormSize.Height;

            foreach (Control c in parent.Controls)
            {
                Rectangle original = originalControlBounds[c];
                c.SetBounds(
                    (int)(original.X * xRatio),
                    (int)(original.Y * yRatio),
                    (int)(original.Width * xRatio),
                    (int)(original.Height * yRatio)
                );

                if (c.Controls.Count > 0)
                    ResizeAllControls(c);
            }
        }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            ResizeAllControls(this);
        }
        // =====================================================
        private KetNoi ketnoi;
        public static bool CheckUser(string username, string password, string chucvu)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            string sql = "SELECT COUNT(*) FROM TAIKHOAN AS tk " +
                            "JOIN NHANVIEN AS nv ON TK.MANV = nv.MANV " +
                            "WHERE tk.TENDANGNHAP = @UserName AND tk.MATKHAU = @PassWord AND nv.MACV = @MaChucVu AND nv.MAPB = 'PBHCNS'";
            SqlCommand command = new SqlCommand(sql, ketnoi.Connect());
            command.Parameters.AddWithValue("@UserName", username);
            command.Parameters.AddWithValue("@PassWord", password);
            command.Parameters.AddWithValue("@MaChucVu", chucvu);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }
        private void ckb_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_ShowPass.Checked)
            {
                Password.UseSystemPasswordChar = false;
            }
            else
            {
                Password.UseSystemPasswordChar = true;
            }
        }

        private void ckb_Employee_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_Employee.Checked)
            {
                ckb_Manager.Checked = false;
            }
        }

        private void ckb_Manager_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_Manager.Checked)
            {
                ckb_Employee.Checked = false;
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            string UserName = User.Text;
            string PassWord = Password.Text;
            string macv;
            if (ckb_Employee.Checked)
            {
                macv = "CV06";
            }
            else { macv = "CV05"; }
            // Kiểm tra người dùng đã nhập tên đăng nhập và mật khẩu hay chưa
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(PassWord))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra tài khoản và mật khẩu trong cơ sở dữ liệu
            bool isValid = CheckUser(UserName, PassWord, macv);

            if (isValid)
            {
                //Sử dụng truy vấn với tham số để tránh SQL Injection
                /*string sql = "SELECT TENNV, MACV, NHANVIEN.MANV, TENDANGNHAP, MATKHAU FROM TAIKHOAN JOIN NHANVIEN ON TAIKHOAN.MANV = NHANVIEN.MANV " +
                             "WHERE TENDANGNHAP = @UserName AND MATKHAU = @PassWord";*/
                string sql = "SELECT (HONV + ' ' + TENNV) AS HoTen, MACV, NHANVIEN.MANV, TENDANGNHAP, MATKHAU " +
             "FROM TAIKHOAN JOIN NHANVIEN ON TAIKHOAN.MANV = NHANVIEN.MANV " +
             "WHERE TENDANGNHAP = @UserName AND MATKHAU = @PassWord";
                using (SqlCommand command = new SqlCommand(sql, ketnoi.Connect()))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@PassWord", PassWord);

                    // Thực thi và đọc dữ liệu từ cơ sở dữ liệu
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string MANV = reader["MANV"].ToString();
                            Session.MANV = MANV;
                            Session.TenNhanVien = reader["HoTen"].ToString();
             

                            if (ckb_Employee.Checked)
                            {
                                Frm_NV form = new Frm_NV();
                                this.Hide();
                                form.ShowDialog();
                                this.Show();
                            }
                            else if (ckb_Manager.Checked)
                            {
                                FrmQuanLy form = new FrmQuanLy();
                                this.Hide();
                                form.ShowDialog();
                                this.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // ==================== AUTO RESIZE ====================
            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += FrmLogin_Resize;
            // =====================================================
        }
    }
}
