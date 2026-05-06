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
    public partial class FrmUngVien : Form
    {
        DataTable tblUngVien;
        // ==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================

        public FrmUngVien()
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

        private void FrmUngVien_Resize(object sender, EventArgs e)
        {
            ResizeAllControls(this);
        }
        // =====================================================
        private void ResetValues()
        {
            txtMaUngVien.Text = "";
            txtTenUngVien.Text = "";
            txtHoUV.Text = "";
            cboGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            mtbDienThoai.Text = "";
            txtEmail.Text = "";
        }
        public void LoadDataGridView()
        {
            string sql = "SELECT * FROM UNGVIEN";
            tblUngVien = Function.ExecuteQuery(sql);
            dgvData.DataSource = tblUngVien;
            dgvData.Columns[0].HeaderText = "Mã ứng viên";
            dgvData.Columns[1].HeaderText = "Họ đệm";
            dgvData.Columns[2].HeaderText = "Tên ứng viên";
            dgvData.Columns[3].HeaderText = "Giới tính";
            dgvData.Columns[4].HeaderText = "Ngày sinh";
            dgvData.Columns[5].HeaderText = "Số điện thoại";
            dgvData.Columns[6].HeaderText = "Email";

            foreach (DataGridViewColumn column in dgvData.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvData.AllowUserToAddRows = false;
            dgvData.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void FrmUngVien_Load(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            txtMaUngVien.Enabled = true;
            LoadDataGridView();
            LoadChuyenMon();
            cboNamKinhNghiem.SelectedIndex = 0; // Mặc định "Tất cả"
            ResetValues();
            // ==================== AUTO RESIZE ====================
            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += FrmUngVien_Resize;
            // =====================================================
        }

        private void LoadChuyenMon()
        {
            cboChuyenMon.Items.Clear();
            cboChuyenMon.Items.Add("Tất cả");
            
            // Load từ LOAIBANGCAP
            string sqlBC = "SELECT DISTINCT TenBC FROM LOAIBANGCAP ORDER BY TenBC";
            DataTable dtBC = Function.ExecuteQuery(sqlBC);
            foreach (DataRow row in dtBC.Rows)
            {
                cboChuyenMon.Items.Add(row["TenBC"].ToString());
            }
            
            // Load từ LOAICHUNGCHI
            string sqlCC = "SELECT DISTINCT TenCC FROM LOAICHUNGCHI ORDER BY TenCC";
            DataTable dtCC = Function.ExecuteQuery(sqlCC);
            foreach (DataRow row in dtCC.Rows)
            {
                string tenCC = row["TenCC"].ToString();
                if (!cboChuyenMon.Items.Contains(tenCC))
                {
                    cboChuyenMon.Items.Add(tenCC);
                }
            }
            
            cboChuyenMon.SelectedIndex = 0; // Mặc định "Tất cả"
        }
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.CurrentRow == null) return;

            txtMaUngVien.Text = dgvData.CurrentRow.Cells["MaUV"].Value.ToString();
            txtHoUV.Text = dgvData.CurrentRow.Cells["HoUV"].Value.ToString();
            txtTenUngVien.Text = dgvData.CurrentRow.Cells["TenUV"].Value.ToString();
            string gioiTinh = dgvData.CurrentRow.Cells["GioiTinh_UV"].Value.ToString();
            cboGioiTinh.SelectedIndex = gioiTinh == "Nam" ? 0 : 1;
            dtpNgaySinh.Text = dgvData.CurrentRow.Cells["NgaySinh_UV"].Value.ToString();
            mtbDienThoai.Text = dgvData.CurrentRow.Cells["Sdt_UV"].Value.ToString();
            txtEmail.Text = dgvData.CurrentRow.Cells["Email_UV"].Value.ToString();
            txtMaUngVien.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadDataGridView();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            txtMaUngVien.Text = Function.TaoMaMoi("MaUV", "UngVien", "UV", "", 5);
            txtMaUngVien.Enabled = false;
            if (string.IsNullOrEmpty(txtTenUngVien.Text.Trim()) || string.IsNullOrEmpty(txtHoUV.Text.Trim()) ||
                string.IsNullOrEmpty(txtEmail.Text.Trim()) || string.IsNullOrEmpty(mtbDienThoai.Text.Trim()) ||
                cboGioiTinh.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin và chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string check = "SELECT SDT_UV FROM UNGVien WHERE SDT_UV=N'" + mtbDienThoai.Text.Trim() + "'";
            if (Function.CheckKey(check))
            {
                MessageBox.Show("Đã có thông tin về sdt này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
                return;
            }
            else
            {
                string sql = $"INSERT INTO UNGVIEN (MaUV, HoUV, TenUV, GioiTinh_UV, NgaySinh_UV, Sdt_UV, Email_UV) " +
                             $"VALUES (N'{txtMaUngVien.Text}', N'{txtHoUV.Text}', N'{txtTenUngVien.Text}', " +
                             $"N'{cboGioiTinh.SelectedItem}', '{dtpNgaySinh.Value:yyyy-MM-dd}', " +
                             $"'{mtbDienThoai.Text}', N'{txtEmail.Text}')";

                Function.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
                
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            if (string.IsNullOrEmpty(txtMaUngVien.Text))
            {
                MessageBox.Show("Bạn chưa chọn ứng viên để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string sql = $"UPDATE UNGVIEN SET " +
                             $"HoUV = N'{txtHoUV.Text}', " +
                             $"TenUV = N'{txtTenUngVien.Text}', " +
                             $"GioiTinh_UV = N'{cboGioiTinh.SelectedItem}', " +
                             $"NgaySinh_UV = '{dtpNgaySinh.Value:yyyy-MM-dd}', " +
                             $"Sdt_UV = '{mtbDienThoai.Text}', " +
                             $"Email_UV = N'{txtEmail.Text}' " +
                             $"WHERE MaUV = N'{txtMaUngVien.Text}'";

                Function.RunSQL(sql);
                MessageBox.Show("Đã cập nhật ứng viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                ResetValues();
            }
                
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            try
            {
                if (tblUngVien.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtMaUngVien.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Bạn có muốn xóa toàn bộ dữ liệu liên quan đến ứng viên này không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string maUV = txtMaUngVien.Text.Trim();

                    // Xóa dữ liệu liên quan trước
                    Function.RunSQL("DELETE FROM CHUNGCHI_UV WHERE MaUV = N'" + maUV + "'");
                    Function.RunSQL("DELETE FROM BANGCAP_UV WHERE MaUV = N'" + maUV + "'");
                    Function.RunSQL("DELETE FROM UV_THAMGIA WHERE MaUV = N'" + maUV + "'");
                    
                    // Cuối cùng xóa bảng chính
                    Function.RunSQL("DELETE FROM UNGVIEN WHERE MaUV = N'" + maUV + "'");

                    MessageBox.Show("Đã xóa ứng viên và các thông tin liên quan.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    ResetValues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            try
            {
                string sql = "SELECT * FROM UNGVIEN WHERE 1=1";

                if (!string.IsNullOrEmpty(txtMaUngVien.Text.Trim()))
                    sql += " AND MaUV LIKE N'%" + txtMaUngVien.Text.Trim() + "%'";

                if (!string.IsNullOrEmpty(txtTenUngVien.Text.Trim()))
                    sql += " AND TenUV LIKE N'%" + txtTenUngVien.Text.Trim() + "%'";

                if (!string.IsNullOrEmpty(txtHoUV.Text.Trim()))
                    sql += " AND HoUV LIKE N'%" + txtHoUV.Text.Trim() + "%'";

                if (cboGioiTinh.SelectedIndex >= 0)
                    sql += " AND GioiTinh_UV = N'" + cboGioiTinh.SelectedItem + "'";

                if (!string.IsNullOrEmpty(mtbDienThoai.Text.Trim()) && mtbDienThoai.Text.Trim() != "__________")
                    sql += " AND Sdt_UV LIKE N'%" + mtbDienThoai.Text.Trim() + "%'";

                if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
                    sql += " AND Email_UV LIKE N'%" + txtEmail.Text.Trim() + "%'";

                tblUngVien = Function.ExecuteQuery(sql);

                if (tblUngVien.Rows.Count == 0)
                    MessageBox.Show("Không có bản ghi phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Tìm thấy " + tblUngVien.Rows.Count + " bản ghi phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvData.DataSource = tblUngVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            try
            {
                bool locNamKN = cboNamKinhNghiem.SelectedIndex > 0;
                bool locChuyenMon = cboChuyenMon.SelectedIndex > 0;
                
                string sql = "";
                string yearCondition = "";
                
                // Nếu cả 2 đều là "Tất cả" thì load toàn bộ
                if (!locNamKN && !locChuyenMon)
                {
                    LoadDataGridView();
                    return;
                }

                // Xác định điều kiện năm kinh nghiệm
                if (locNamKN)
                {
                    string selectedRange = cboNamKinhNghiem.SelectedItem.ToString();
                    switch (selectedRange)
                    {
                        case "0 - 2 năm":
                            yearCondition = "DATEDIFF(YEAR, bc.NamTN, GETDATE()) BETWEEN 0 AND 2";
                            break;
                        case "3 - 5 năm":
                            yearCondition = "DATEDIFF(YEAR, bc.NamTN, GETDATE()) BETWEEN 3 AND 5";
                            break;
                        case "6 - 10 năm":
                            yearCondition = "DATEDIFF(YEAR, bc.NamTN, GETDATE()) BETWEEN 6 AND 10";
                            break;
                        case "Trên 10 năm":
                            yearCondition = "DATEDIFF(YEAR, bc.NamTN, GETDATE()) > 10";
                            break;
                    }
                }

                // Xây dựng SQL dựa trên điều kiện
                if (locNamKN && locChuyenMon)
                {
                    // Lọc cả 2 điều kiện
                    string chuyenMon = cboChuyenMon.SelectedItem.ToString();
                    sql = @"SELECT DISTINCT uv.* 
                            FROM UNGVIEN uv
                            INNER JOIN BANGCAP_UV bc ON bc.MaUV = uv.MaUV
                            WHERE " + yearCondition + @" 
                            AND (EXISTS (SELECT 1 FROM BANGCAP_UV bc2 
                                        INNER JOIN LOAIBANGCAP lbc ON bc2.MaBC = lbc.MaBC 
                                        WHERE bc2.MaUV = uv.MaUV AND lbc.TenBC = N'" + chuyenMon + @"')
                                OR EXISTS (SELECT 1 FROM CHUNGCHI_UV cc 
                                        INNER JOIN LOAICHUNGCHI lcc ON cc.MaCC = lcc.MaCC 
                                        WHERE cc.MaUV = uv.MaUV AND lcc.TenCC = N'" + chuyenMon + @"'))";
                }
                else if (locNamKN)
                {
                    // Chỉ lọc theo năm kinh nghiệm
                    sql = @"SELECT DISTINCT uv.* 
                            FROM UNGVIEN uv
                            INNER JOIN BANGCAP_UV bc ON bc.MaUV = uv.MaUV
                            WHERE " + yearCondition;
                }
                else if (locChuyenMon)
                {
                    // Chỉ lọc theo chuyên môn
                    string chuyenMon = cboChuyenMon.SelectedItem.ToString();
                    sql = @"SELECT DISTINCT uv.* 
                            FROM UNGVIEN uv
                            WHERE (EXISTS (SELECT 1 FROM BANGCAP_UV bc 
                                        INNER JOIN LOAIBANGCAP lbc ON bc.MaBC = lbc.MaBC 
                                        WHERE bc.MaUV = uv.MaUV AND lbc.TenBC = N'" + chuyenMon + @"')
                                OR EXISTS (SELECT 1 FROM CHUNGCHI_UV cc 
                                        INNER JOIN LOAICHUNGCHI lcc ON cc.MaCC = lcc.MaCC 
                                        WHERE cc.MaUV = uv.MaUV AND lcc.TenCC = N'" + chuyenMon + @"'))";
                }

                DataTable dt = Function.ExecuteQuery(sql);
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy ứng viên phù hợp với điều kiện lọc đã chọn.", 
                                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                dgvData.DataSource = dt;
                dgvData.Columns[0].HeaderText = "Mã ứng viên";
                dgvData.Columns[1].HeaderText = "Họ đệm";
                dgvData.Columns[2].HeaderText = "Tên ứng viên";
                dgvData.Columns[3].HeaderText = "Giới tính";
                dgvData.Columns[4].HeaderText = "Ngày sinh";
                dgvData.Columns[5].HeaderText = "Số điện thoại";
                dgvData.Columns[6].HeaderText = "Email";
                
                foreach (DataGridViewColumn column in dgvData.Columns)
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboNamKinhNghiem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cboChuyenMon_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void lbl_duongdan_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
