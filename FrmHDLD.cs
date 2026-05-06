using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    public partial class FrmHDLD : Form
    {
        DataTable tblHDLD;
        private Button btnConHan;
        private Button btnHetHan;
        // ==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================

        public FrmHDLD()
        {
            InitializeComponent();

        }
        private void ResetValues()
        {
            txtMaHD.Text = "";
            cboManv.Text = "";
            txtTenhopdong.Text = "";
            cboManv.SelectedIndex = -1;
            cboLoaiHD.SelectedIndex = -1;
            dtpNgayKy.Value = DateTime.Now;
            dtpNgayHieuLuc.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
            
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
        public void LoadDataGridView()
        {
            string sql = "SELECT * FROM HOPDONGLAODONG";
            tblHDLD = Function.ExecuteQuery(sql);
            dgvData.DataSource = tblHDLD;

            dgvData.Columns[0].HeaderText = "Mã hợp đồng";
            dgvData.Columns[1].HeaderText = "Tên hợp đồng";
            dgvData.Columns[2].HeaderText = "Loại hợp đồng";
            dgvData.Columns[3].HeaderText = "Ngày ký";
            dgvData.Columns[4].HeaderText = "Ngày hiệu lực";
            dgvData.Columns[5].HeaderText = "Ngày hết hạn";
            dgvData.Columns[6].HeaderText = "Mã nhân viên";

            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgvData.AllowUserToAddRows = false;
            dgvData.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void SetButtonStyles()
        {
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.BackColor = Color.DarkRed;
            btnXoa.ForeColor = Color.White;
        }
        private void FrmHopDongLaoDong_Load(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            

            btnThem.Enabled = true;
            
            btnXoa.Enabled = true;
            txtMaHD.Enabled = false;
            Function.FillCombo("SELECT MANV FROM NHANVIEN WHERE MANV NOT IN ('NV001', 'NV004', 'NV033')",cboManv,"MANV","MANV");
            cboLoaiHD.Items.Clear();
            dtpNgayKy.Checked = false;

            // Thêm thủ công các loại hợp đồng
            cboLoaiHD.Items.Add("Chính thức");
            cboLoaiHD.Items.Add("Thử việc");
            cboLoaiHD.Items.Add("Thời vụ");

            cboManv.SelectedIndex = -1;
            cboLoaiHD.SelectedIndex = -1;

            LoadDataGridView();

            // Thêm 3 nút vào khung chức năng (panel/groupbox chứa các nút Thêm/Tìm/Xóa/Refresh)
            AddFilterButtonsToActionsPanel();
            SetButtonStyles();
            // ==================== AUTO RESIZE ====================
            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += FrmHDLD_Resize;
            // =====================================================
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.CurrentRow == null || dgvData.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("Không có dữ liệu trong ô đang chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gán dữ liệu từ các ô của dòng đang chọn vào các điều khiển tương ứng
            txtMaHD.Text = dgvData.CurrentRow.Cells["MaHD"].Value.ToString();
            txtTenhopdong.Text = dgvData.CurrentRow.Cells["TenHD"].Value.ToString();
            cboManv.Text = dgvData.CurrentRow.Cells["MANV"].Value.ToString();

            // ComboBox cho loại hợp đồng
            if (dgvData.CurrentRow.Cells["LoaiHD"].Value != null)
                cboLoaiHD.SelectedItem = dgvData.CurrentRow.Cells["LoaiHD"].Value.ToString();

            // Các DateTimePickers
            if (DateTime.TryParse(dgvData.CurrentRow.Cells["NgayKyKet"].Value.ToString(), out DateTime ngayKy))
                dtpNgayKy.Value = ngayKy;

            if (DateTime.TryParse(dgvData.CurrentRow.Cells["NgayBatDau"].Value.ToString(), out DateTime ngayBD))
                dtpNgayHieuLuc.Value = ngayBD;

            if (DateTime.TryParse(dgvData.CurrentRow.Cells["NgayKetThuc"].Value.ToString(), out DateTime ngayKT))
                dtpNgayKetThuc.Value = ngayKT;

            // Kích hoạt các nút liên quan
            
            btnXoa.Enabled = true;
            cboManv.Enabled = false;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu nhập trong các control
            

            // Thiết lập lại trạng thái nút
            btnThem.Enabled = true;
            
            btnXoa.Enabled = true;
            txtMaHD.Enabled = false;
            cboManv.Enabled = true;
            dtpNgayKy.Checked = false;
            ResetValues();
            // Tải lại dữ liệu vào DataGridView
            LoadDataGridView();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM HOPDONGLAODONG WHERE 1=1";

            // Các điều kiện lọc khác
            if (!string.IsNullOrWhiteSpace(txtMaHD.Text))
                sql += " AND MaHD LIKE N'%" + txtMaHD.Text.Trim() + "%'";

            if (!string.IsNullOrWhiteSpace(txtTenhopdong.Text))
                sql += " AND TenHD LIKE N'%" + txtTenhopdong.Text.Trim() + "%'";

            if (cboLoaiHD.SelectedIndex != -1)
                sql += " AND LoaiHD = N'" + cboLoaiHD.SelectedItem.ToString() + "'";

            if (dtpNgayKy.Checked)
            {
                sql += " AND NgayKyKet = '" + dtpNgayKy.Value.ToString("yyyy-MM-dd") + "'";
            }

            // Thực thi truy vấn
            tblHDLD = Function.ExecuteQuery(sql);

            if (tblHDLD.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy bản ghi nào thỏa điều kiện.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Tìm thấy " + tblHDLD.Rows.Count + " bản ghi.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvData.DataSource = tblHDLD;
        }

        // Lọc theo trạng thái: true = còn hạn; false = hết hạn
        private void LocTheoTrangThai(bool conHan)
        {
            string sql = "SELECT * FROM HOPDONGLAODONG";
            if (conHan)
                sql += " WHERE GETDATE() BETWEEN NgayBatDau AND NgayKetThuc";
            else
                sql += " WHERE GETDATE() > NgayKetThuc";

            tblHDLD = Function.ExecuteQuery(sql);
            dgvData.DataSource = tblHDLD;

            if (tblHDLD.Rows.Count == 0)
            {
                MessageBox.Show("Không có hợp đồng phù hợp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Thêm các nút lọc vào đúng khu vực "Chức năng"
        private void AddFilterButtonsToActionsPanel()
        {
            // Lấy container của khu vực chức năng theo parent của btnThem
            Control actionsPanel = btnXoa?.Parent ?? this;

            // Khởi tạo nút (nếu chưa có)
            if (btnConHan == null)
            {
                btnConHan = new Button();
                btnConHan.Text = "Hợp đồng còn hạn";
                btnConHan.FlatStyle = FlatStyle.System;
                btnConHan.Click += (s, ev) => LocTheoTrangThai(true);
                actionsPanel.Controls.Add(btnConHan);
            }

            if (btnHetHan == null)
            {
                btnHetHan = new Button();
                btnHetHan.Text = "Hợp đồng hết hạn";
                btnHetHan.FlatStyle = FlatStyle.System;
                btnHetHan.Click += (s, ev) => LocTheoTrangThai(false);
                actionsPanel.Controls.Add(btnHetHan);
            }

            // Bố trí: đặt ngay dưới hàng nút hiện có (Thêm/Tìm/Xóa/Refresh)
            // Căn theo vị trí các nút sẵn có
            var baseLeft = btnXoa.Left;
            var rowTop = btnShow.Bottom + 8; // btnShow = Refresh

            btnConHan.Size = btnXoa.Size;
            btnHetHan.Size = btnTimKiem.Size;

            btnConHan.Location = new Point(baseLeft, rowTop);
            btnHetHan.Location = new Point(btnTimKiem.Left, rowTop);

            // Đưa các nút lên trên cùng trong panel chức năng
            btnConHan.BringToFront();
            btnHetHan.BringToFront();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            txtMaHD.Text = Function.TaoMaMoi("MAHD", "HOPDONGLAODONG", "HD", "", 4);
            // Kiểm tra bắt buộc
            
            if (string.IsNullOrWhiteSpace(txtTenhopdong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenhopdong.Focus();
                return;
            }

            if (cboManv.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiHD.Focus();
                return;
            }

            if (cboLoaiHD.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiHD.Focus();
                return;
            }

            DateTime ngayKy = dtpNgayKy.Value;
            DateTime ngayBatDau = dtpNgayHieuLuc.Value;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value;

            // ❗ Kiểm tra ngày ký <= ngày bắt đầu
            if (ngayKy > ngayBatDau)
            {
                MessageBox.Show("Ngày ký kết phải nhỏ hơn hoặc bằng ngày bắt đầu.",
                                "Lỗi thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ❗ Kiểm tra ngày bắt đầu <= ngày kết thúc
            if (ngayBatDau >= ngayKetThuc)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.",
                                "Lỗi thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Kiểm tra trùng mã hợp đồng
            string sqlCheck = "SELECT MaHD FROM HOPDONGLAODONG WHERE MaHD = N'" + txtMaHD.Text.Trim() + "'";
            /*if (Function.CheckKey(sqlCheck))
            {
                MessageBox.Show("Mã hợp đồng đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHD.Focus();
                return;
            }
            else
            {*/
                // Tạo câu truy vấn thêm
                string sql = "INSERT INTO HOPDONGLAODONG(MaHD, TenHD, NgayKyKet, NgayBatDau, NgayKetThuc, LoaiHD, MaNV) VALUES (" +
                             "N'" + txtMaHD.Text.Trim() + "', " +
                             "N'" + txtTenhopdong.Text.Trim() + "', " +
                             "'" + ngayKy.ToString("yyyy-MM-dd") + "', " +
                             "'" + ngayBatDau.ToString("yyyy-MM-dd") + "', " +
                             "'" + ngayKetThuc.ToString("yyyy-MM-dd") + "', " +
                             "N'" + cboLoaiHD.SelectedItem.ToString() + "', " +
                             "N'" + cboManv.Text.Trim() + "')";
                try
                {
                    Function.RunSQL(sql); // Nếu lỗi SQL xảy ra, sẽ nhảy vào catch
                    MessageBox.Show("Đã thêm hợp đồng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    ResetValues();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            ResetValues();
            }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            // Kiểm tra mã hợp đồng đã được chọn chưa
            string sqlCheckDate = "SELECT NgayKetThuc FROM HOPDONGLAODONG WHERE MaHD = N'" + txtMaHD.Text.Trim() + "'";
            DataTable dt = Function.ExecuteQuery(sqlCheckDate);
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần xóa trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime ngayKetThuc = Convert.ToDateTime(dt.Rows[0]["NgayKetThuc"]);
            DateTime homNay = DateTime.Now.Date; // Chỉ lấy phần ngày, bỏ giờ

            // Kiểm tra: Chỉ cho phép xóa nếu hợp đồng đã hết hạn
            if (ngayKetThuc >= homNay)
            {
                MessageBox.Show("Hợp đồng vẫn còn hạn! Không cho phép xóa!",
                                "Không thể xóa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }


            // Hỏi xác nhận người dùng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hợp đồng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                string sql = "DELETE FROM HOPDONGLAODONG WHERE MaHD = N'" + txtMaHD.Text.Trim() + "'";
                Function.RunSQL(sql);

                MessageBox.Show("Xóa hợp đồng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView();
                ResetValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
