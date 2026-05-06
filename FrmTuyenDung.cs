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
using System.Net;
using System.Net.Mail;


namespace QUANLYNHANSU
{
    public partial class FrmTuyenDung : Form
    {
        // ==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================
        public FrmTuyenDung()
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
        private void FrmTuyenDung_Resize(object sender, EventArgs e)
        {
            ResizeAllControls(this);
        }
        // =====================================================
        private void CapNhatTrangThaiControlTheoNgay(DateTime ngayBD, DateTime ngayKT)
        {
            DateTime homNay = DateTime.Today;

            bool hetHan = ngayBD < homNay && ngayKT < homNay;
            bool batDauRoi = ngayBD < homNay && ngayKT >= homNay;
            bool chuaBatDau = ngayBD >= homNay && ngayKT >= homNay;

            // Đợt đã kết thúc => Disable toàn bộ
            if (hetHan)
            {
                txtMaDTD.Enabled = false;
                cboManv.Enabled = false;
                txtVitri.Enabled = false;
                cboMaPB.Enabled = false;
                txtSoluong.Enabled = false;
                dtpNgayBatDau.Enabled = false;
                dtpNgayKetThuc.Enabled = false;
            }
            // Đợt đang diễn ra => Disable ngày bắt đầu
            else if (batDauRoi)
            {
                txtMaDTD.Enabled = false;
                cboManv.Enabled = true;
                txtVitri.Enabled = false;
                cboMaPB.Enabled = false;
                txtSoluong.Enabled = true;
                dtpNgayBatDau.Enabled = false;
                dtpNgayKetThuc.Enabled = true;
            }
            // Đợt chưa diễn ra => Enable toàn bộ
            else if (chuaBatDau)
            {
                txtMaDTD.Enabled = false;
                cboManv.Enabled = true;
                txtVitri.Enabled = true;
                cboMaPB.Enabled = true;
                txtSoluong.Enabled = true;
                dtpNgayBatDau.Enabled = true;
                dtpNgayKetThuc.Enabled = true;
            }
        }

        
        private void LoadMaNV_PhongKT(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            KetNoi ketnoi = new KetNoi();
            SqlConnection conn = ketnoi.Connect();

            string sql = "SELECT MaNV FROM NHANVIEN WHERE MaPB = 'PBHCNS' AND MACV = 'CV05'"; // Phòng kế toán

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox.Items.Add(reader["MaNV"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên kế toán: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void dgvDataDTD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDataDTD.CurrentRow == null || dgvDataDTD.CurrentRow.Index == -1) return;

            txtMaDTD.Text = dgvDataDTD.CurrentRow.Cells["MaDTD"].Value.ToString();
            cboManv.Text = dgvDataDTD.CurrentRow.Cells["MaNV"].Value.ToString();
            txtVitri.Text = dgvDataDTD.CurrentRow.Cells["ViTriCanTuyen"].Value.ToString();
            cboMaPB.Text = dgvDataDTD.CurrentRow.Cells["PhongBan"].Value.ToString();
            txtSoluong.Text = dgvDataDTD.CurrentRow.Cells["SoLuongTuyen"].Value.ToString();

            DateTime ngayBD = Convert.ToDateTime(dgvDataDTD.CurrentRow.Cells["NgayBatDau"].Value);
            DateTime ngayKT = Convert.ToDateTime(dgvDataDTD.CurrentRow.Cells["NgayKetThuc"].Value);
            dtpNgayBatDau.Value = ngayBD;
            dtpNgayKetThuc.Value = ngayKT;

            CapNhatTrangThaiControlTheoNgay(ngayBD, ngayKT);
            LoadDataPhongVanTheoDotTuyenDung(txtMaDTD.Text);
        }
        private void LoadDataPhongVanTheoDotTuyenDung(string maDTD)
        {
            string sql = "SELECT * FROM DOTPHONGVAN WHERE MaDTD = N'" + maDTD + "'";
            DataTable tblPhongVan = Function.ExecuteQuery(sql);

            dgvDataDPV.DataSource = tblPhongVan;

            if (dgvDataDPV.Columns.Count > 0)
            {
                dgvDataDPV.Columns["MaDPV"].HeaderText = "Mã đợt PV";
                dgvDataDPV.Columns["TenDPV"].HeaderText = "Tên đợt";
                dgvDataDPV.Columns["MaDTD"].HeaderText = "Mã đợt tuyển";
                dgvDataDPV.Columns["MaNV"].HeaderText = "Nhân viên PV";
                dgvDataDPV.Columns["SoLuongUV"].HeaderText = "Số lượng UV";
                dgvDataDPV.Columns["NgayPV"].HeaderText = "Ngày PV";

                foreach (DataGridViewColumn col in dgvDataDPV.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                dgvDataDPV.AllowUserToAddRows = false;
                dgvDataDPV.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void LoadDataTuyenDungGrid(bool hideDeleted = true)
        {
            string sql = "SELECT * FROM DOTTUYENDUNG";

            DataTable dt = Function.ExecuteQuery(sql);
            dgvDataDTD.DataSource = dt;
            dgvDataDTD.DataSource = dt;

            dgvDataDTD.Columns[0].HeaderText = "Mã đợt tuyển";
            dgvDataDTD.Columns[1].HeaderText = "Mã nhân viên";
            dgvDataDTD.Columns[2].HeaderText = "Vị trí cần tuyển";
            dgvDataDTD.Columns[3].HeaderText = "Phòng ban";
            dgvDataDTD.Columns[4].HeaderText = "Số lượng";
            dgvDataDTD.Columns[5].HeaderText = "Ngày bắt đầu";
            dgvDataDTD.Columns[6].HeaderText = "Ngày kết thúc";

            foreach (DataGridViewColumn column in dgvDataDTD.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvDataDTD.AllowUserToAddRows = false;
            dgvDataDTD.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadPhongBanToComboBox()
        {
            string sql = "SELECT DISTINCT PhongBan FROM DOTTUYENDUNG";
            DataTable dt = Function.ExecuteQuery(sql);
            cboMaPB.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cboMaPB.Items.Add(row["PhongBan"].ToString());
            }
        }
        private void dgvDataPhongVan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDataDPV.CurrentRow == null || dgvDataDPV.CurrentRow.Index == -1)
                return;

            // Lấy dòng hiện tại
            DataGridViewRow row = dgvDataDPV.CurrentRow;

            // Gán dữ liệu lên các control
            txtMaDPV.Text = row.Cells["MaDPV"].Value.ToString();
            txtTenDPV.Text = row.Cells["TenDPV"].Value.ToString();
           
            txtManv.Text = row.Cells["MaNV"].Value.ToString();

            if (DateTime.TryParse(row.Cells["NgayPV"].Value.ToString(), out DateTime ngayPV))
            {
                dtpNgayPV.Value = ngayPV;
            }
            else
            {
                dtpNgayPV.Value = DateTime.Today;
            }
        }

        private void ResetValues()
        {
            // Thông tin đợt tuyển dụng
            txtMaDTD.Clear();
            cboManv.SelectedIndex = -1;
            txtVitri.Clear();
            cboMaPB.SelectedIndex = -1;
            txtSoluong.Clear();
            dtpNgayBatDau.Value = DateTime.Today;
            dtpNgayKetThuc.Value = DateTime.Today;

            // Thông tin đợt phỏng vấn
            txtMaDPV.Clear();
            txtTenDPV.Clear();
            txtManv.Text = "";
            dtpNgayPV.Value = DateTime.Today;

            // Enable lại các control đợt tuyển dụng sau khi reset
            txtMaDTD.Enabled = true;
            cboManv.Enabled = true;
            txtVitri.Enabled = true;
            cboMaPB.Enabled = true;
            txtSoluong.Enabled = true;
            dtpNgayBatDau.Enabled = true;
            dtpNgayKetThuc.Enabled = true;


            // Xoá chọn trong dgv
            dgvDataDTD.ClearSelection();
            dgvDataDPV.ClearSelection();
            cboManv.Text = null;
        }
        private void FrmTuyenDung_Load(object sender, EventArgs e)
        {
            LoadDataTuyenDungGrid(hideDeleted : false);
            LoadMaNV_PhongKT(cboManv);
            LoadPhongBanToComboBox();
            ResetValues();
            // ==================== AUTO RESIZE ====================
            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += FrmTuyenDung_Resize;
            // =====================================================
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            txtMaDTD.Text = Function.TaoMaMoi("MADTD", "DOTTUYENDUNG", "DTD", "", 3);
            string maDTD = txtMaDTD.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtMaDTD.Text))
            {
                MessageBox.Show("Vui lòng nhập mã đợt tuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm ngày
            DateTime ngayBD = dtpNgayBatDau.Value.Date;
            DateTime ngayKT = dtpNgayKetThuc.Value.Date;
            DateTime homNay = DateTime.Today;

            if (ngayBD < homNay)
            {
                MessageBox.Show("Ngày bắt đầu phải từ hôm nay trở đi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ngayKT <= ngayBD)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            // Kiểm tra mã đã tồn tại
            string sqlCheck = $"SELECT MaDTD FROM DOTTUYENDUNG WHERE MaDTD = N'{maDTD}'";
            if (Function.CheckKey(sqlCheck))
            {
                MessageBox.Show("Mã đợt tuyển đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $@"INSERT INTO DOTTUYENDUNG (MaDTD, MaNV, ViTriCanTuyen, PhongBan, SoLuongTuyen, NgayBatDau, NgayKetThuc) VALUES (N'{maDTD}', N'{cboManv.Text}', N'{txtVitri.Text}', N'{cboMaPB.Text}', {txtSoluong.Text}, 
                '{ngayBD:yyyy-MM-dd}', '{ngayKT:yyyy-MM-dd}')";

            Function.RunSQL(sql);
            MessageBox.Show("Thêm đợt tuyển thành công!", "Thông báo");

            LoadDataTuyenDungGrid(hideDeleted: false);
            ResetValues();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            if (string.IsNullOrWhiteSpace(txtMaDTD.Text))
            {
                MessageBox.Show("Vui lòng chọn đợt tuyển để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime ngayBD = dtpNgayBatDau.Value.Date;
            DateTime ngayKT = dtpNgayKetThuc.Value.Date;
            DateTime homNay = DateTime.Today;
            if (ngayBD > homNay)
            {
                if (ngayBD <= homNay)
                {
                    MessageBox.Show("Ngày bắt đầu phải sau hôm nay!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ngayKT <= homNay)
                {
                    MessageBox.Show("Ngày kết thúc phải sau hôm nay!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } else if (ngayKT < homNay)
            {
                MessageBox.Show("Ngày kết thúc phải sau hôm nay!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    

            string sql = $@"UPDATE DOTTUYENDUNG SET MaNV = N'{cboManv.Text}',ViTriCanTuyen = N'{txtVitri.Text}',PhongBan = N'{cboMaPB.Text}',
                            SoLuongTuyen = {txtSoluong.Text},NgayBatDau = '{dtpNgayBatDau.Value:yyyy-MM-dd}',NgayKetThuc = '{ngayKT:yyyy-MM-dd}'
                            WHERE MaDTD = N'{txtMaDTD.Text.Trim()}'";

            Function.RunSQL(sql);
            MessageBox.Show("Cập nhật đợt tuyển thành công!", "Thông báo");

            LoadDataTuyenDungGrid(hideDeleted: false);
            ResetValues();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            if (string.IsNullOrWhiteSpace(txtMaDTD.Text))
            {
                MessageBox.Show("Vui lòng chọn đợt tuyển cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đợt tuyển này không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string maDTD = txtMaDTD.Text.Trim();
            DateTime ngayBD = Convert.ToDateTime(dgvDataDTD.CurrentRow.Cells["NgayBatDau"].Value);
            DateTime ngayKT = Convert.ToDateTime(dgvDataDTD.CurrentRow.Cells["NgayKetThuc"].Value);
            DateTime homNay = DateTime.Today;

            // KHÔNG CHO XÓA NẾU ĐANG DIỄN RA
            if (ngayBD <= homNay && homNay <= ngayKT)
            {
                MessageBox.Show("Không thể xóa đợt tuyển đang diễn ra!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Đếm số lượng dữ liệu liên quan
                string sqlCountDPV = $"SELECT COUNT(*) FROM DOTPHONGVAN WHERE MaDTD = N'{maDTD}'";
                DataTable dtDPV = Function.ExecuteQuery(sqlCountDPV);
                int soLuongDPV = dtDPV.Rows.Count > 0 ? Convert.ToInt32(dtDPV.Rows[0][0]) : 0;

                string sqlCountUV = $@"
            SELECT COUNT(*) 
            FROM UV_THAMGIA
            WHERE MaDPV IN (SELECT MaDPV FROM DOTPHONGVAN WHERE MaDTD = N'{maDTD}')";
                DataTable dtUV = Function.ExecuteQuery(sqlCountUV);
                int soLuongUV = dtUV.Rows.Count > 0 ? Convert.ToInt32(dtUV.Rows[0][0]) : 0;

                // Tạo thông báo
                string trangThai = (ngayKT < homNay) ? "đã kết thúc" : "chưa bắt đầu";
                string thongBao = $"Đợt tuyển này {trangThai}.\n\n";
                thongBao += "Bạn có chắc chắn muốn xóa không?";

                if (result == DialogResult.Yes)
                {

                    // Bước 1: Xóa ứng viên
                    string sqlDeleteUV = $@"
                DELETE FROM UV_THAMGIA 
                WHERE MaDPV IN (
                    SELECT MaDPV FROM DOTPHONGVAN WHERE MaDTD = N'{maDTD}'
                )";
                    Function.RunSQL(sqlDeleteUV);

                    // Bước 2: Xóa đợt phỏng vấn
                    string sqlDeleteDPV = $"DELETE FROM DOTPHONGVAN WHERE MaDTD = N'{maDTD}'";
                    Function.RunSQL(sqlDeleteDPV);

                    // Bước 3: Xóa đợt tuyển dụng
                    string sqlDeleteDTD = $"DELETE FROM DOTTUYENDUNG WHERE MaDTD = N'{maDTD}'";
                    Function.RunSQL(sqlDeleteDTD);

                    // Thông báo thành công
                    string successMsg = $"✅ Đã xóa thành công:\n";
                    successMsg += $"   • Đợt tuyển: {maDTD}\n";

                    MessageBox.Show(successMsg, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadDataTuyenDungGrid(hideDeleted: false);
                    ResetValues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataTuyenDungGrid();
            ResetValues();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder("SELECT * FROM DOTTUYENDUNG WHERE 1=1");

            if (!string.IsNullOrWhiteSpace(txtMaDTD.Text))
                sql.AppendFormat(" AND MaDTD LIKE N'%{0}%'", txtMaDTD.Text.Trim());

            if (cboManv.SelectedIndex != -1)
                sql.AppendFormat(" AND MaNV = N'{0}'", cboManv.Text.Trim());

            if (!string.IsNullOrWhiteSpace(txtVitri.Text))
                sql.AppendFormat(" AND ViTriCanTuyen LIKE N'%{0}%'", txtVitri.Text.Trim());

            if (cboMaPB.SelectedIndex != -1)
                sql.AppendFormat(" AND PhongBan = N'{0}'", cboMaPB.Text.Trim());

            // Nếu muốn lọc cả theo ngày bắt đầu hoặc ngày kết thúc
            DateTime start = dtpNgayBatDau.Value.Date;
            DateTime end = dtpNgayKetThuc.Value.Date;

            if (start != DateTime.Today || end != DateTime.Today)
            {
                sql.AppendFormat(" AND NgayBatDau >= '{0:yyyy-MM-dd}' AND NgayKetThuc <= '{1:yyyy-MM-dd}'", start, end);
            }

            DataTable dt = Function.ExecuteQuery(sql.ToString());

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Tìm thấy " + dt.Rows.Count + " bản ghi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDataDTD.DataSource = dt;
                dgvDataDPV.DataSource = null;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDataDTD.DataSource = null;
                dgvDataDPV.DataSource = null;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDTD.Text))
            {
                MessageBox.Show("Vui lòng nhập mã đợt tuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi form báo cáo, truyền mã đợt tuyển
            DanhSachUngVien frm = new DanhSachUngVien(txtMaDTD.Text.Trim());
            frm.Show(); // hoặc frm.Show() nếu bạn muốn form không chặn luồng chính
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDTD.Text))
            {
                MessageBox.Show("Bạn chưa chọn đợt tuyển!");
                return;
            }

            string maDTD = txtMaDTD.Text;

            // Tạo form danh sách để xuất PDF
            DanhSachUngVien formDS = new DanhSachUngVien(maDTD);
            string pdfPath = formDS.GeneratePDF();   // <-- LẤY FILE PDF TỰ ĐỘNG

            // Mở form gửi mail và truyền file PDF
            FrmMail guiMail = new FrmMail(pdfPath);
            guiMail.ShowDialog();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
