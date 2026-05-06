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
    public partial class FrmChamCong : Form
    {
        DataTable tblChamcong;
        // ==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================
        bool isLoading = true;

        public FrmChamCong()
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

        private void FrmChamCong_Resize(object sender, EventArgs e)
        {
            ResizeAllControls(this);
        }
        // =====================================================
        public void LoadDataGridView()
        {
            string sql = "SELECT BCC.MaBCC, BCC.NgayChamCong, BCC.GioVaoLam, BCC.GioTanLam, " +
                         "BCC.MaNV, NV.HoNV + ' ' + NV.TenNV AS HoTen " +
                         "FROM BANGCHAMCONG BCC " +
                         "INNER JOIN NHANVIEN NV ON BCC.MaNV = NV.MaNV " +
                         "ORDER BY BCC.NgayChamCong DESC, BCC.MaBCC";
            tblChamcong = Function.ExecuteQuery(sql);
            dgvData.DataSource = tblChamcong;

            if (dgvData.Columns.Count > 0)
            {
                dgvData.Columns[0].HeaderText = "Mã chấm công";
                if (dgvData.Columns.Count > 1) dgvData.Columns[1].HeaderText = "Ngày chấm công";
                if (dgvData.Columns.Count > 2) dgvData.Columns[2].HeaderText = "Giờ vào";
                if (dgvData.Columns.Count > 3) dgvData.Columns[3].HeaderText = "Giờ ra";
                if (dgvData.Columns.Count > 4) dgvData.Columns[4].HeaderText = "Mã nhân viên";
                if (dgvData.Columns.Count > 5) dgvData.Columns[5].HeaderText = "Họ tên";
            }

            foreach (DataGridViewColumn col in dgvData.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvData.AllowUserToAddRows = false;
            dgvData.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadComboBoxThang()
        {
            cboThang.Items.Clear();
            cboThang.Items.Add("Tất cả");
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i.ToString("D2"));
            }
            cboThang.SelectedIndex = 0;
        }

        private void LoadComboBoxNam()
        {
            cboNam.Items.Clear();
            cboNam.Items.Add("Tất cả");
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear - 5; year <= currentYear + 1; year++)
            {
                cboNam.Items.Add(year.ToString());
            }
            cboNam.SelectedIndex = 0;
        }

        private void LoadComboBoxMaNV()
        {
            string sql = "SELECT MaNV, MaNV + ' - ' + HoNV + ' ' + TenNV AS DisplayText FROM NHANVIEN ORDER BY MaNV";
            Function.FillCombo(sql, cboMaNV, "MaNV", "DisplayText");
            if (cboMaNV.Items.Count > 0)
                cboMaNV.SelectedIndex = 0;
        }

        private void ResetValues()
        {
            txtMaBCC.Text = "";
            dtpNgayChamCong.Value = DateTime.Now;
            dtpNgayChamCong.Checked = false;
            dtpGioVao.Value = DateTime.Today.AddHours(8).AddMinutes(0);
            dtpGioRa.Value = DateTime.Today.AddHours(17).AddMinutes(0);
            if (cboMaNV.Items.Count > 0)
                cboMaNV.SelectedIndex = 0;
            txtMaBCC.Enabled = false;
        }

        private void FrmChamCong_Load(object sender, EventArgs e)
        {
            isLoading = true;   // Bắt đầu load
            LoadComboBoxThang();
            LoadComboBoxNam();
            LoadComboBoxMaNV();
            LoadDataGridView();
            ResetValues();
            // ==================== AUTO RESIZE ====================
            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += FrmChamCong_Resize;
            // =====================================================
            isLoading = false;  // Đã load xong
        }
        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT BCC.MaBCC, BCC.NgayChamCong, BCC.GioVaoLam, BCC.GioTanLam, " +
                             "BCC.MaNV, NV.HoNV + ' ' + NV.TenNV AS HoTen " +
                             "FROM BANGCHAMCONG BCC " +
                             "INNER JOIN NHANVIEN NV ON BCC.MaNV = NV.MaNV " +
                             "WHERE 1=1";

                if (cboThang.SelectedItem != null && cboThang.SelectedItem.ToString() != "Tất cả")
                {
                    sql += " AND MONTH(BCC.NgayChamCong) = " + cboThang.SelectedItem.ToString();
                }

                if (cboNam.SelectedItem != null && cboNam.SelectedItem.ToString() != "Tất cả")
                {
                    sql += " AND YEAR(BCC.NgayChamCong) = " + cboNam.SelectedItem.ToString();
                }

                if (dtpNgayChamCong.Checked)
                {
                    sql += " AND BCC.NgayChamCong = '" + dtpNgayChamCong.Value.ToString("yyyy-MM-dd") + "'";
                }

                string thang = cboThang.SelectedItem.ToString();
                string nam = cboNam.SelectedItem.ToString();

                sql += " ORDER BY BCC.NgayChamCong DESC, BCC.MaBCC";

                DataTable dt = Function.ExecuteQuery(sql);
                dgvData.DataSource = dt;
                txtSoluong.Text = dt.Rows.Count.ToString();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu chấm công theo tiêu chí đã chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtpNgayChamCong_ValueChanged(object sender, EventArgs e)
        {
            // Tự động tạo lại mã khi thay đổi ngày
            string ngay = dtpNgayChamCong.Value.ToString("ddMMyy");
            txtMaBCC.Text = Function.TaoMaMoi("MaBCC", "BANGCHAMCONG", "CC" + ngay, "", 3);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadComboBoxThang();
            LoadComboBoxNam();
            dtpNgayChamCong.Checked = false;
            txtSoluong.Text = "";
            LoadDataGridView();
            ResetValues();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ngay = dtpNgayChamCong.Value.ToString("ddMMyy");
            txtMaBCC.Text = Function.TaoMaMoi("MaBCC", "BANGCHAMCONG", "CC" + ngay, "", 3);
            if (txtMaBCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chấm công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaBCC.Focus();
                return;
            }

            if (cboMaNV.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaNV.Focus();
                return;
            }

            if (dtpGioRa.Value <= dtpGioVao.Value)
            {
                MessageBox.Show("Giờ ra phải lớn hơn giờ vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpGioRa.Focus();
                return;
            }

            string sql = "INSERT INTO BANGCHAMCONG(MaBCC, NgayChamCong, GioVaoLam, GioTanLam, MaNV) " +
                         "VALUES(N'" + txtMaBCC.Text.Trim() + "', '" + dtpNgayChamCong.Value.ToString("yyyy-MM-dd") + "', " +
                         "'" + dtpGioVao.Value.ToString("HH:mm:ss") + "', '" + dtpGioRa.Value.ToString("HH:mm:ss") + "', " +
                         "N'" + cboMaNV.SelectedValue.ToString() + "')";

            if (Function.CheckKey("SELECT MaBCC FROM BANGCHAMCONG WHERE MaBCC = N'" + txtMaBCC.Text.Trim() + "'"))
            {
                MessageBox.Show("Mã chấm công này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaBCC.Focus();
                return;
            }

            Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            MessageBox.Show("Đã thêm chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaBCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn bản ghi để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMaNV.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaNV.Focus();
                return;
            }

            if (dtpGioRa.Value <= dtpGioVao.Value)
            {
                MessageBox.Show("Giờ ra phải lớn hơn giờ vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpGioRa.Focus();
                return;
            }

            string sql = "UPDATE BANGCHAMCONG SET " +
                         "NgayChamCong = '" + dtpNgayChamCong.Value.ToString("yyyy-MM-dd") + "', " +
                         "GioVaoLam = '" + dtpGioVao.Value.ToString("HH:mm:ss") + "', " +
                         "GioTanLam = '" + dtpGioRa.Value.ToString("HH:mm:ss") + "', " +
                         "MaNV = N'" + cboMaNV.SelectedValue.ToString() + "' " +
                         "WHERE MaBCC = N'" + txtMaBCC.Text.Trim() + "'";

            Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            MessageBox.Show("Đã cập nhật chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaBCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn bản ghi để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM BANGCHAMCONG WHERE MaBCC = N'" + txtMaBCC.Text.Trim() + "'";
                Function.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
                MessageBox.Show("Đã xóa chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboMaNV.Enabled = false;
            if (dgvData.Rows.Count == 0)
                return;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];
                txtMaBCC.Text = row.Cells[0].Value?.ToString() ?? "";
                
                if (row.Cells[1].Value != null && DateTime.TryParse(row.Cells[1].Value.ToString(), out DateTime ngayCham))
                {
                    dtpNgayChamCong.Value = ngayCham;
                    dtpNgayChamCong.Checked = true;
                }

                if (row.Cells[2].Value != null)
                {
                    string gioVao = row.Cells[2].Value.ToString();
                    if (TimeSpan.TryParse(gioVao, out TimeSpan timeVao))
                    {
                        dtpGioVao.Value = DateTime.Today.Add(timeVao);
                    }
                }

                if (row.Cells[3].Value != null)
                {
                    string gioRa = row.Cells[3].Value.ToString();
                    if (TimeSpan.TryParse(gioRa, out TimeSpan timeRa))
                    {
                        dtpGioRa.Value = DateTime.Today.Add(timeRa);
                    }
                }

                if (row.Cells[4].Value != null)
                {
                    string maNV = row.Cells[4].Value.ToString();
                    for (int i = 0; i < cboMaNV.Items.Count; i++)
                    {
                        DataRowView drv = (DataRowView)cboMaNV.Items[i];
                        if (drv["MaNV"].ToString() == maNV)
                        {
                            cboMaNV.SelectedIndex = i;
                            break;
                        }
                    }
                }

                txtMaBCC.Enabled = false;
            }
        }

    }
}

