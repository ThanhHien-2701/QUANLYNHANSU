using System;
using System.Collections;
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
using System.Xml.Linq;
using static QUANLYNHANSU.Function;

namespace QUANLYNHANSU
{
    public partial class FrmNhanVien : Form
    {
        DataTable tblNV;
        string sql;
        private KetNoi ketnoi;
        public bool ShowPathLabel { get; set; } = true;
        // ==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================
        public FrmNhanVien()
        {
            InitializeComponent();
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

        private void FrmHDLD_Resize(object sender, EventArgs e)
        {
            ResizeAllControls(this);
        }
        // =====================================================
        private void ResetValues()
        {
            txtHoNV.Text = "";
            txtTenNhanVien.Text = "";
            txtMaNhanVien.Text = "";
            ckbGioiTinh.Checked = false;
            txtHeso.Text = "";
            txtEmail.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayVaoLam.Value = DateTime.Now;
            txtCCCD.Text = "";
            txtDiaChi.Text = "";
            mtbDienThoai.Text = "";
            txtNganHang.Text = "";
            txtSotk.Text = "";
            cboChucVu.SelectedIndex = -1;
            cboLoainv.SelectedIndex = -1;
            cboPhongban.SelectedIndex = -1;
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM NHANVIEN";
            tblNV = Function.ExecuteQuery(sql); //lấy dữ liệu
            dgvData.DataSource = tblNV;
            dgvData.Columns[0].HeaderText = "Mã nhân viên";
            dgvData.Columns[1].HeaderText = "Họ nhân viên";
            dgvData.Columns[2].HeaderText = "Tên NV";
            dgvData.Columns[3].HeaderText = "CCCD";
            dgvData.Columns[4].HeaderText = "Giới tính";
            dgvData.Columns[5].HeaderText = "Ngày sinh";
            dgvData.Columns[6].HeaderText = "Điện thoại";
            dgvData.Columns[7].HeaderText = "Email";
            dgvData.Columns[8].HeaderText = "Địa chỉ";
            dgvData.Columns[9].HeaderText = "Mã chức vụ";
            dgvData.Columns[10].HeaderText = "Mã phòng ban";
            dgvData.Columns[11].HeaderText = "Mã loại";
            dgvData.Columns[12].HeaderText = "Ngày vào làm";
            dgvData.Columns[13].HeaderText = "Hệ số lương";
            dgvData.Columns[14].HeaderText = "Số TK";
            dgvData.Columns[15].HeaderText = "Tên NH";
            foreach (DataGridViewColumn column in dgvData.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgvData.AllowUserToAddRows = false;
            dgvData.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            // Maximized form
            this.WindowState = FormWindowState.Maximized;

            // Auto scroll
            this.AutoScroll = true;
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            label1.Visible = ShowPathLabel;
            txtMaNhanVien.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            Function.FillCombo("SELECT * FROM ChucVu", cboChucVu, "MACV", "TENCV");
            Function.FillCombo("SELECT * FROM PhongBan", cboPhongban, "MAPB", "TENPB");
            Function.FillCombo("SELECT * FROM LoaiNhanVien", cboLoainv, "MALOAI", "TENLOAINV");
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE MACV LIKE N'%CV06%'", KetNoi.sqlConn))
            {
                txtSoLuongNhanVien.Text = command.ExecuteScalar().ToString();
            }

            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE MACV LIKE N'%CV05%'", KetNoi.sqlConn))
            {
                txtSoLuongQuanLy.Text = command.ExecuteScalar().ToString();
            }
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE MACV LIKE N'%CV03%'", KetNoi.sqlConn))
            {
                txtSoluongTruongPhong.Text = command.ExecuteScalar().ToString();
            }
            KetNoi.sqlConn.Close();
            cboChucVu.SelectedIndex = -1;
            cboPhongban.SelectedIndex = -1;
            cboLoainv.SelectedIndex = -1;
            LoadDataGridView();
            // ==================== AUTO RESIZE ====================
            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += FrmHDLD_Resize;
            // =====================================================
        }
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.CurrentCell == null || dgvData.CurrentCell.Value == null)
            {
                MessageBox.Show("Ô không có dữ liệu hoặc danh sách rỗng !");
                return;
            }
            txtHoNV.Text = dgvData.CurrentRow.Cells["HONV"].Value.ToString();
            txtTenNhanVien.Text = dgvData.CurrentRow.Cells["TENNV"].Value.ToString();
            txtMaNhanVien.Text = dgvData.CurrentRow.Cells["MANV"].Value.ToString();
            if (dgvData.CurrentRow.Cells["GIOITINH"].Value.ToString() == "Nam") ckbGioiTinh.Checked = true;
            else ckbGioiTinh.Checked = false;
            cboChucVu.SelectedValue = dgvData.CurrentRow.Cells["MACV"].Value.ToString();
            cboPhongban.SelectedValue = dgvData.CurrentRow.Cells["MAPB"].Value.ToString();
            cboLoainv.SelectedValue = dgvData.CurrentRow.Cells["MALOAI"].Value.ToString();
            txtHeso.Text = dgvData.CurrentRow.Cells["HESOLUONG"].Value.ToString();
            txtEmail.Text = dgvData.CurrentRow.Cells["Email_NV"].Value.ToString();
            dtpNgayVaoLam.Text = dgvData.CurrentRow.Cells["NGAYVAOLAM"].Value.ToString();
            dtpNgaySinh.Text = dgvData.CurrentRow.Cells["NGAYSINH"].Value.ToString();
            txtCCCD.Text = dgvData.CurrentRow.Cells["CCCD"].Value.ToString();
            txtDiaChi.Text = dgvData.CurrentRow.Cells["DIACHI"].Value.ToString();
            mtbDienThoai.Text = dgvData.CurrentRow.Cells["SDT_NV"].Value.ToString();
            txtSotk.Text = dgvData.CurrentRow.Cells["STK"].Value.ToString();
            txtNganHang.Text = dgvData.CurrentRow.Cells["TENNH"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            txtMaNhanVien.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();

            txtMaNhanVien.Text = Function.TaoMaMoi("MANV", "NhanVien", "NV","", 3);
            string sql;
            if (txtMaNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                return;
            }
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhanVien.Focus();
                return;
            }
            if (txtHoNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập họ nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoNV.Focus();
                return;
            }
            if (cboChucVu.SelectedValue == null || string.IsNullOrEmpty(cboChucVu.SelectedValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn chức vụ trước khi thực hiện chức năng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboPhongban.SelectedValue == null || string.IsNullOrEmpty(cboPhongban.SelectedValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn phòng ban trước khi thực hiện chức năng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboLoainv.SelectedValue == null || string.IsNullOrEmpty(cboLoainv.SelectedValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn loại nhân viên trước khi thực hiện chức năng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtHeso.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập hệ số lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHeso.Focus();
                return;
            }

            if (!decimal.TryParse(txtHeso.Text.Trim(), out decimal heSoLuong))
            {
                MessageBox.Show("Hệ số lương phải là một số hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHeso.Focus();
                return;
            }

            if (heSoLuong < 0 || heSoLuong > 9.99m)
            {
                MessageBox.Show("Hệ số lương phải nằm trong khoảng từ 0 đến 9.99", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHeso.Focus();
                return;
            }

            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (txtCCCD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số căn cước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }
            else if (txtCCCD.Text.Trim().Length != 12 || !txtCCCD.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("Số căn cước phải gồm đúng 12 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (mtbDienThoai.Text == " ")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbDienThoai.Focus();
                return;
            }
            if (dtpNgaySinh.Text == "  ")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return;
            }
            if (dtpNgayVaoLam.Text == "  ")
            {
                MessageBox.Show("Bạn phải nhập ngày vào làm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayVaoLam.Focus();
                return;
            }
            if ((dtpNgayVaoLam.Value - dtpNgaySinh.Value).TotalDays / 365.25 < 18)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi trở lên tại thời điểm vào làm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return;
            }
            if (txtSotk.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập STK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSotk.Focus();
                return;
            }
            if (txtNganHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thông tin ngân hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNganHang.Focus();
                return;
            }

            sql = "SELECT CCCD FROM NhanVien WHERE CCCD=N'" + txtCCCD.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Đã có thông tin về căn cước của công dân này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                txtMaNhanVien.Text = "";
                return;
            }
            
            sql = "SELECT STK FROM NhanVien WHERE STK=N'" + txtSotk.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Đã có số tài khoản này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                txtMaNhanVien.Text = "";
                return;
            }
            sql = "INSERT INTO NhanVien(MANV, HONV, TENNV, CCCD, GIOITINH, NGAYSINH, SDT_NV, EMAIL_NV, DIACHI, MACV, MAPB, MALOAI, NGAYVAOLAM, HESOLUONG, STK, TenNH) VALUES " +
                    "(N'" + txtMaNhanVien.Text.Trim() + "'," +
                    "N'" + txtHoNV.Text.Trim() + "'," +
                    "N'" + txtTenNhanVien.Text.Trim() + "'," +
                    "N'" + txtCCCD.Text.Trim() + "'," +
                    "N'" + (ckbGioiTinh.Checked ? "Nam" : "Nữ") + "'," +
                    "'" + dtpNgaySinh.Value.ToString("yyyy-MM-dd") + "'," +
                    "'" + mtbDienThoai.Text.Trim() + "'," +
                    "N'" + txtEmail.Text.Trim() + "'," +
                    "N'" + txtDiaChi.Text.Trim() + "'," +
                    "N'" + cboChucVu.SelectedValue.ToString() + "'," +
                    "N'" + cboPhongban.SelectedValue.ToString() + "'," +
                    "N'" + cboLoainv.SelectedValue.ToString() + "'," +
                    "'" + dtpNgayVaoLam.Value.ToString("yyyy-MM-dd") + "','" + 
                        txtHeso.Text.Trim() + "'," +
                    "N'" + txtSotk.Text.Trim() + "'," +
                    "N'" + txtNganHang.Text.Trim() + "')";

            Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            FrmNhanVien_Load(this, EventArgs.Empty);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            string sql;

            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa toàn bộ dữ liệu liên quan đến nhân viên này không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string maNV = txtMaNhanVien.Text.Trim();

                // Xóa dữ liệu liên quan trong các bảng phụ
                Function.RunSQL("DELETE FROM CHUNGCHI_NV WHERE MaNV = N'" + maNV + "'");
                Function.RunSQL("DELETE FROM BANGCAP_NV WHERE MaNV = N'" + maNV + "'");
                Function.RunSQL("DELETE FROM BANGCHAMCONG WHERE MaNV = N'" + maNV + "'");
                Function.RunSQL("DELETE FROM DOTTUYENDUNG WHERE MaNV = N'" + maNV + "'");
                Function.RunSQL("DELETE FROM DOTPHONGVAN WHERE MaNV = N'" + maNV + "'");
                Function.RunSQL("DELETE FROM HOPDONGLAODONG WHERE MaNV = N'" + maNV + "'");
                Function.RunSQL("DELETE FROM BANGLUONG WHERE MaNV = N'" + maNV + "'");
                Function.RunSQL("DELETE FROM TAIKHOAN WHERE MaNV = N'" + maNV + "'");
                Function.RunSQL("DELETE FROM NGHIPHEP WHERE MaNV = N'" + maNV + "'");
                Function.RunSQL("DELETE FROM KYLUAT WHERE MaNV = N'" + maNV + "'");
                Function.RunSQL("DELETE FROM KHENTHUONG WHERE MaNV = N'" + maNV + "'");
                // Cuối cùng mới xóa nhân viên
                Function.RunSQL("DELETE FROM NHANVIEN WHERE MaNV = N'" + maNV + "'");

                MessageBox.Show("Đã xóa toàn bộ thông tin nhân viên và các dữ liệu liên quan.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ResetValues();
            FrmNhanVien_Load(this, EventArgs.Empty);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;

            if (string.IsNullOrEmpty(txtMaNhanVien.Text) &&
                string.IsNullOrEmpty(txtCCCD.Text) &&
                cboChucVu.SelectedIndex == -1 &&
                cboPhongban.SelectedIndex == -1 &&
                cboLoainv.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm (Mã NV, CCCD, Chức vụ, Phòng ban hoặc Loại NV)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bắt đầu tạo truy vấn SQL
            sql = "SELECT * FROM NhanVien WHERE 1=1";

            // Mã nhân viên
            if (!string.IsNullOrEmpty(txtMaNhanVien.Text))
                sql += " AND MANV LIKE N'%" + txtMaNhanVien.Text.Trim() + "%'";

            // CCCD
            if (!string.IsNullOrEmpty(txtCCCD.Text))
                sql += " AND CCCD LIKE N'%" + txtCCCD.Text.Trim() + "%'";

            // Mã phòng ban
            if (cboPhongban.SelectedValue != null && cboPhongban.SelectedIndex != -1)
                sql += " AND MAPB = N'" + cboPhongban.SelectedValue.ToString() + "'";

            // Mã loại nhân viên
            if (cboLoainv.SelectedIndex != -1 && cboLoainv.SelectedValue != null && !string.IsNullOrEmpty(cboLoainv.SelectedValue.ToString()))
                sql += " AND MALOAI = N'" + cboLoainv.SelectedValue.ToString() + "'";

            // Thực thi truy vấn và lấy kết quả
            tblNV = Function.ExecuteQuery(sql);

            // Thông báo kết quả
            if (tblNV.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Có " + tblNV.Rows.Count + " bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Gán dữ liệu vào DataGridView
            dgvData.DataSource = tblNV;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();

            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtHoNV.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập họ nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoNV.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTenNhanVien.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhanVien.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }

            if (string.IsNullOrEmpty(mtbDienThoai.Text.Trim()) || mtbDienThoai.Text == "__________")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbDienThoai.Focus();
                return;
            }

            if (dtpNgaySinh.Value == DateTime.MinValue)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return;
            }

            if (dtpNgayVaoLam.Value == DateTime.MinValue)
            {
                MessageBox.Show("Bạn phải nhập ngày vào làm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayVaoLam.Focus();
                return;
            }

            if ((dtpNgayVaoLam.Value - dtpNgaySinh.Value).TotalDays / 365.25 < 18)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi trở lên tại thời điểm vào làm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return;
            }

            if (!decimal.TryParse(txtHeso.Text.Trim(), out decimal heSoLuong))
            {
                MessageBox.Show("Hệ số lương phải là một số hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHeso.Focus();
                return;
            }

            if (heSoLuong < 0 || heSoLuong > 9.99m)
            {
                MessageBox.Show("Hệ số lương phải nằm trong khoảng từ 0 đến 9.99", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHeso.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCCCD.Text.Trim()) || txtCCCD.Text.Trim().Length != 12 || !txtCCCD.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("Số căn cước phải gồm đúng 12 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            if (cboChucVu.SelectedValue == null || string.IsNullOrEmpty(cboChucVu.SelectedValue.ToString()) ||
                cboPhongban.SelectedValue == null || string.IsNullOrEmpty(cboPhongban.SelectedValue.ToString()) ||
                cboLoainv.SelectedValue == null || string.IsNullOrEmpty(cboLoainv.SelectedValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ chức vụ, phòng ban và loại nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSotk.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập STK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSotk.Focus();
                return;
            }
            if (txtNganHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thông tin ngân hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNganHang.Focus();
                return;
            }

            string sql = "UPDATE NhanVien SET " +
                    "HONV = N'" + txtHoNV.Text.Trim() + "', " +
                    "TENNV = N'" + txtTenNhanVien.Text.Trim() + "', " +
                    "GIOITINH = N'" + (ckbGioiTinh.Checked ? "Nam" : "Nữ") + "', " +
                    "NGAYSINH = '" + dtpNgaySinh.Value.ToString("yyyy-MM-dd") + "', " +
                    "SDT_NV = '" + mtbDienThoai.Text.Trim() + "', " +
                    "EMAIL_NV = N'" + txtEmail.Text.Trim() + "', " +
                    "DIACHI = N'" + txtDiaChi.Text.Trim() + "', " +
                    "CCCD = N'" + txtCCCD.Text.Trim() + "', " +
                    "MACV = N'" + cboChucVu.SelectedValue.ToString() + "', " +
                    "MAPB = N'" + cboPhongban.SelectedValue.ToString() + "', " +
                    "MALOAI = N'" + cboLoainv.SelectedValue.ToString() + "', " +
                    "NGAYVAOLAM = '" + dtpNgayVaoLam.Value.ToString("yyyy-MM-dd") + "', " +
                    "HESOLUONG = " + txtHeso.Text.Trim() + ", " +
                    "STK = N'" + txtSotk.Text.Trim() + "', " +
                    "TenNH = N'" + txtNganHang.Text.Trim() + "' " +
                    "WHERE MANV = N'" + txtMaNhanVien.Text.Trim() + "'";


            MessageBox.Show("Đã cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            FrmNhanVien_Load(this, EventArgs.Empty);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // Gọi form báo cáo, truyền mã đợt tuyển
            DSNhanVien frm = new DSNhanVien();
            frm.Show(); // hoặc frm.Show() nếu bạn muốn form không chặn luồng chính
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
