using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    public partial class FrmNghiPhep : Form
    {
        private DataTable tblNP;
        // ==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================

        public FrmNghiPhep()
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

        private void FrmNP_Resize(object sender, EventArgs e)
        {
            ResizeAllControls(this);
        }
        // =====================================================
        private void FrmNghiPhep_Load(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();

            // Nạp NV cho combobox MaNV
            try
            {
                Function.FillCombo("SELECT MaNV, (HoNV + N' ' + TenNV) AS HoTen FROM NHANVIEN",
                    cboMaNV, "MaNV", "MaNV");
                cboMaNV.SelectedIndex = -1;
            }
            catch { }

            // Trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Chờ duyệt", "Được duyệt", "Từ chối" });
            cboTrangThai.SelectedIndex = 0;

            cbbLocTrangThai.Items.Clear();
            cbbLocTrangThai.Items.AddRange(new object[] { "Tất cả", "Chờ duyệt", "Được duyệt", "Từ chối" });
            cbbLocTrangThai.SelectedIndex = 0;

            txtMaNP.Enabled = false;
            dtpTuNgay.Checked = false;
            dtpDenNgay.Checked = false;

            LoadGrid();
            ResetInputs();
            // ==================== AUTO RESIZE ====================
            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += FrmNP_Resize;
            // =====================================================
        }

        private void LoadGrid(string where = "")
        {
            string sql = "SELECT MaNP, MaNV, TuNgay, DenNgay, LyDo, TrangThai FROM NGHIPHEP";
            if (!string.IsNullOrWhiteSpace(where)) sql += " " + where;
            tblNP = Function.ExecuteQuery(sql);
            dgvData.DataSource = tblNP;

            dgvData.Columns[0].HeaderText = "Mã nghỉ phép";
            dgvData.Columns[1].HeaderText = "Mã nhân viên";
            dgvData.Columns[2].HeaderText = "Từ ngày";
            dgvData.Columns[3].HeaderText = "Đến ngày";
            dgvData.Columns[4].HeaderText = "Lý do";
            dgvData.Columns[5].HeaderText = "Trạng thái";

            foreach (DataGridViewColumn c in dgvData.Columns)
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvData.AllowUserToAddRows = false;
            dgvData.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetInputs()
        {
            txtMaNP.Text = "";
            cboMaNV.SelectedIndex = -1;
            dtpTuNgay.Checked = false;
            dtpDenNgay.Checked = false;
            txtLyDo.Clear();
            cboTrangThai.SelectedIndex = 0;
            txtMaNP.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetInputs();
            FrmNghiPhep_Load(this, EventArgs.Empty);
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.CurrentRow == null) return;
            txtMaNP.Text = dgvData.CurrentRow.Cells["MaNP"].Value.ToString();
            cboMaNV.SelectedValue = dgvData.CurrentRow.Cells["MaNV"].Value.ToString();
            if (DateTime.TryParse(dgvData.CurrentRow.Cells["TuNgay"].Value.ToString(), out DateTime tu))
                dtpTuNgay.Value = tu;
            if (DateTime.TryParse(dgvData.CurrentRow.Cells["DenNgay"].Value.ToString(), out DateTime den))
                dtpDenNgay.Value = den;
            txtLyDo.Text = dgvData.CurrentRow.Cells["LyDo"].Value.ToString();
            cboTrangThai.SelectedItem = dgvData.CurrentRow.Cells["TrangThai"].Value.ToString();
            txtMaNP.Enabled = false;
            cboMaNV.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            txtMaNP.Text = Function.TaoMaMoi("MaNP", "NGHIPHEP", "NP", "", 3);

            if (cboMaNV.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string check = $"SELECT MaNP FROM NGHIPHEP WHERE MaNP = N'{txtMaNP.Text.Trim()}'";
            if (Function.CheckKey(check))
            {
                MessageBox.Show("Mã nghỉ phép đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $"INSERT INTO NGHIPHEP(MaNP, MaNV, TuNgay, DenNgay, LyDo, TrangThai) VALUES(" +
                         $"N'{txtMaNP.Text.Trim()}', N'{cboMaNV.SelectedValue}', " +
                         $"'{dtpTuNgay.Value:yyyy-MM-dd}', '{dtpDenNgay.Value:yyyy-MM-dd}', " +
                         $"N'{txtLyDo.Text.Trim()}', N'{cboTrangThai.SelectedItem}')";
            Function.RunSQL(sql);
            MessageBox.Show("Thêm thông tin nghỉ phép thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGrid();
            ResetInputs();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNP.Text))
            {
                MessageBox.Show("Vui lòng chọn bản ghi để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $"UPDATE NGHIPHEP SET MaNV = N'{cboMaNV.SelectedValue}', " +
                         $"TuNgay = '{dtpTuNgay.Value:yyyy-MM-dd}', DenNgay = '{dtpDenNgay.Value:yyyy-MM-dd}', " +
                         $"LyDo = N'{txtLyDo.Text.Trim()}', TrangThai = N'{cboTrangThai.SelectedItem}' " +
                         $"WHERE MaNP = N'{txtMaNP.Text.Trim()}'";
            Function.RunSQL(sql);
            MessageBox.Show("Cập nhật thông tin nghỉ phép thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGrid();
            ResetInputs();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNP.Text))
            {
                MessageBox.Show("Vui lòng chọn bản ghi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn xóa bản ghi này không?", "Xác nhận",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;

            string sql = $"DELETE FROM NGHIPHEP WHERE MaNP = N'{txtMaNP.Text.Trim()}'";
            Function.RunSQL(sql);
            MessageBox.Show("Đã xóa thông tin nghỉ phép.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGrid();
            ResetInputs();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM NGHIPHEP WHERE 1=1";
            if (!string.IsNullOrWhiteSpace(txtMaNP.Text))
                sql += $" AND MaNP LIKE N'%{txtMaNP.Text.Trim()}%'";
            // Tìm theo mã nhân viên
            if (cboMaNV.SelectedIndex != -1)
                sql += $" AND MaNV = N'{cboMaNV.SelectedValue}'";
            if (dtpTuNgay.Checked)
                sql += $" AND TuNgay >= '{dtpTuNgay.Value:yyyy-MM-dd}'";
            if (dtpDenNgay.Checked)
                sql += $" AND DenNgay <= '{dtpDenNgay.Value:yyyy-MM-dd}'";
  
            tblNP = Function.ExecuteQuery(sql);

            if (tblNP.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy bản ghi nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Tìm thấy " + tblNP.Rows.Count + " bản ghi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvData.DataSource = tblNP;
        }

        private void cbbLocTrangThai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbbLocTrangThai.SelectedIndex <= 0)
            {
                LoadGrid();
                return;
            }
            string tt = cbbLocTrangThai.SelectedItem.ToString();
            LoadGrid($"WHERE TrangThai = N'{tt}'");
            if (tblNP.Rows.Count == 0)
                MessageBox.Show("Không có dữ liệu với trạng thái đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


