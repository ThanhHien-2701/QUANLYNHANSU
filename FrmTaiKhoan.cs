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

namespace QUANLYNHANSU
{
    public partial class FrmTaiKhoan : Form
    {
        DataTable tblTK;
        //==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================

        public FrmTaiKhoan()
        {
            InitializeComponent();
        }

        //==================== AUTO RESIZE ====================
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

        private void FrmTaiKhoan_Resize(object sender, EventArgs e)
        {
            ResizeAllControls(this);
        }
        // =====================================================
        public void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM TAIKHOAN";
            tblTK = Function.ExecuteQuery(sql); //lấy dữ liệu
            dgvData.DataSource = tblTK;
            dgvData.Columns[0].HeaderText = "Tên đăng nhập";
            dgvData.Columns[1].HeaderText = "Mật khẩu";
            dgvData.Columns[2].HeaderText = "Mã nhân viên";
            dgvData.Columns[3].HeaderText = "Mã tài khoản";
            
            foreach (DataGridViewColumn column in dgvData.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgvData.AllowUserToAddRows = false;
            dgvData.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadMaNVChuaCoTaiKhoan()
        {
            string sql = @"SELECT MaNV FROM NHANVIEN WHERE MaNV NOT IN (SELECT MaNV FROM TAIKHOAN)";

            DataTable dt = Function.ExecuteQuery(sql); // dùng hàm bạn có sẵn

            cboManv.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cboManv.Items.Add(row["MaNV"].ToString());
            }

            cboManv.SelectedIndex = -1; // không chọn gì sẵn
        }
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.CurrentRow == null || dgvData.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("Không có dữ liệu trong ô đang chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gán giá trị từ dòng được chọn lên các control
            txtMa.Text = dgvData.CurrentRow.Cells["MaTK"].Value.ToString();
            txtTaikhoan.Text = dgvData.CurrentRow.Cells["TenDangNhap"].Value.ToString();
            txtMatkhau.Text = dgvData.CurrentRow.Cells["Matkhau"].Value.ToString();
            cboManv.Text = dgvData.CurrentRow.Cells["MaNV"].Value.ToString();
            //cboManv.SelectedItem = null;
            // Disable cboMaNV để tránh thay đổi mã nhân viên trong khi sửa
            cboManv.Enabled = false;
            txtMa.Enabled = false;
        }
        private void ResetValues()
        {
            // Xóa toàn bộ nội dung
            txtMa.Text = "";
            txtTaikhoan.Text = "";
            txtMatkhau.Text = "";

            // Bật lại chế độ nhập cho tất cả
            txtMa.Enabled = true;
            txtTaikhoan.Enabled = true;
            txtMatkhau.Enabled = true;
            cboManv.Enabled = true;
            cboManv.Text = null;

            // Load đầy đủ lại danh sách nhân viên
            LoadMaNVChuaCoTaiKhoan();

            // Đặt combobox về rỗng
            cboManv.SelectedIndex = -1;

            // Bỏ chọn DataGridView
            dgvData.ClearSelection();
        }
        private string BoDauTiengViet(string input)
        {
            string normalized = input.Normalize(System.Text.NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in normalized)
            {
                var uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(System.Text.NormalizationForm.FormC).Replace("đ", "d").Replace("Đ", "D");
        }
        private void btnTao_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            if (cboManv.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = cboManv.SelectedItem.ToString();
            string sql = "SELECT TenNV, CCCD FROM NHANVIEN WHERE MaNV = N'" + maNV + "'";
            DataTable dt = Function.ExecuteQuery(sql);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hoTen = dt.Rows[0]["TenNV"].ToString();
            string cccd = dt.Rows[0]["CCCD"].ToString();

            if (cccd.Length < 4)
            {
                MessageBox.Show("CCCD không hợp lệ để tạo mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenKhongDau = BoDauTiengViet(hoTen).Replace(" ", "");
            string taiKhoan = tenKhongDau + maNV.Substring(maNV.Length - 3);
            string matKhau = tenKhongDau + cccd.Substring(cccd.Length - 6);

            txtTaikhoan.Text = taiKhoan;
            txtMatkhau.Text = matKhau;
        }
        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadMaNVChuaCoTaiKhoan();
            // ==================== AUTO RESIZE ====================
            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += FrmTaiKhoan_Resize;
            // =====================================================
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            if (cboManv.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtTaikhoan.Text) || string.IsNullOrWhiteSpace(txtMatkhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenDangNhap = txtTaikhoan.Text.Trim();
            string matKhau = txtMatkhau.Text.Trim();
            string maNV = cboManv.SelectedItem.ToString();

            string sqlCheck_TK = $"SELECT * FROM TAIKHOAN WHERE Tendangnhap = N'{tenDangNhap}'";
            string sqlCheck_MK = $"SELECT * FROM TAIKHOAN WHERE Matkhau = N'{matKhau}'";

            if (Function.CheckKey(sqlCheck_TK))
            {
                MessageBox.Show("Tên tài khoản đã tồn tại. Vui lòng nhập thông tin khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (Function.CheckKey(sqlCheck_MK))
            {
                MessageBox.Show("Mật khẩu đã tồn tại. Vui lòng nhập thông tin khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            // ====== TẠO MÃ TÀI KHOẢN MỚI (QUAN TRỌNG) ======
            string maTK = Function.TaoMaMoi("MaTK", "TAIKHOAN", "TK", "", 3);

            // ====== CÂU LỆNH THÊM DỮ LIỆU ======
            string sqlInsert =
                $"INSERT INTO TAIKHOAN (MaTK, Tendangnhap, Matkhau, MaNV) " +
                $"VALUES (N'{maTK}', N'{tenDangNhap}', N'{matKhau}', N'{maNV}')";

            //string sqlInsert = $"INSERT INTO TAIKHOAN (Tendangnhap, Matkhau, MaNV) VALUES (N'{tenDangNhap}', N'{matKhau}', N'{maNV}')";

            Function.RunSQL(sqlInsert);
            MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView(); // hoặc LoadTaiKhoan()
            ResetValues();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaikhoan.Text) || string.IsNullOrWhiteSpace(txtMatkhau.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Lấy dữ liệu người dùng nhập
            string tenDangNhap = txtTaikhoan.Text.Trim();
            string matKhau = txtMatkhau.Text.Trim();
            string maTK = txtMa.Text.Trim(); // Mã tài khoản để biết đang sửa bản ghi nào

            // --- KIỂM TRA TÊN ĐĂNG NHẬP TRÙNG (trừ chính nó) ---
            string sqlCheck_TK =
                $"SELECT * FROM TAIKHOAN WHERE Tendangnhap = N'{tenDangNhap}' AND MaTK <> '{maTK}'";

            // --- KIỂM TRA MẬT KHẨU TRÙNG (trừ chính nó) ---
            string sqlCheck_MK =
                $"SELECT * FROM TAIKHOAN WHERE Matkhau = N'{matKhau}' AND MaTK <> '{maTK}'";

            if (Function.CheckKey(sqlCheck_TK))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Function.CheckKey(sqlCheck_MK))
            {
                MessageBox.Show("Mật khẩu đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- UPDATE THÔNG TIN ---
            string sqlUpdate =
                $"UPDATE TAIKHOAN SET Tendangnhap = N'{tenDangNhap}', Matkhau = N'{matKhau}' WHERE MaTK = '{maTK}'";

            Function.RunSQL(sqlUpdate);

            MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView();
            ResetValues();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaikhoan.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // LỖI CŨ: Bạn dùng txtMatkhau thay vì txtTaikhoan
            string tenDangNhap = txtTaikhoan.Text.Trim(); // ← SỬA LẠI ĐÂY

            // Kiểm tra tài khoản có tồn tại không
            string sqlCheck = $"SELECT * FROM TAIKHOAN WHERE Tendangnhap = N'{tenDangNhap}'";

            if (!Function.CheckKey(sqlCheck))
            {
                MessageBox.Show("Không tìm thấy tài khoản để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa
            if (MessageBox.Show($"Bạn có chắc muốn xóa tài khoản '{tenDangNhap}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sqlDelete = $"DELETE FROM TAIKHOAN WHERE Tendangnhap = N'{tenDangNhap}'";
                Function.RunSQL(sqlDelete);

                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView(); 
                ResetValues();
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            string dk = "1=1";

            if (!string.IsNullOrWhiteSpace(txtTaikhoan.Text))
                dk += $" AND Tendangnhap LIKE N'%{txtTaikhoan.Text.Trim()}%'";

            if (!string.IsNullOrWhiteSpace(txtMa.Text))
                dk += $" AND MaTK LIKE N'%{txtMa.Text.Trim()}%'";

            string sql = "SELECT * FROM TAIKHOAN WHERE " + dk;

            DataTable dt = Function.ExecuteQuery(sql);
            dgvData.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Có " + dt.Rows.Count + " bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataGridView();       // load lại danh sách tài khoản
            LoadMaNVChuaCoTaiKhoan();// load lại nhân viên chưa có tài khoản
            ResetValues();        // clear form
            txtMa.Enabled = true;
            cboManv.SelectedIndex = -1;
        }

        private void lbl_duongdan_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
