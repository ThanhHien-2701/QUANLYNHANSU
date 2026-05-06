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
    public partial class FrmPhongBan_QL : Form
    {
        DataTable tblPhongBan;
        private ComboBox cboMaPBThongKe;
        private Label lblTongNVTheoPB;
        //==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================

        public FrmPhongBan_QL()
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

        private void Frm_Resize(object sender, EventArgs e)
        {
            ResizeAllControls(this);
        }
        // =====================================================
        private void ResetValues()
        {
            txtMaPB.Text = "";
            txtTenphongban.Text = "";
            txtMota.Text = "";
            txtMaPB.Enabled = true;
            cboMaPBThongKe.Text = null;
        }
        public void LoadDataGridView()
        {
            string sql = "SELECT * FROM PHONGBAN";
            tblPhongBan = Function.ExecuteQuery(sql);
            dgvData.DataSource = tblPhongBan;

            dgvData.Columns[0].HeaderText = "Mã phòng ban";
            dgvData.Columns[1].HeaderText = "Tên phòng ban";
            dgvData.Columns[2].HeaderText = "Mô tả";

            foreach (DataGridViewColumn col in dgvData.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvData.AllowUserToAddRows = false;
            dgvData.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void FrmPhongBan_QL_Load(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            txtMaPB.Enabled = true;
            LoadDataGridView();
            ResetValues();
            // ==================== AUTO RESIZE ====================
            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += Frm_Resize;
            // =====================================================

            // Nạp danh sách mã phòng ban cho ComboBox thống kê (trong Designer)
            try
            {
                Function.FillCombo("SELECT MaPB, TenPB FROM PHONGBAN", cboMaPBThongKe, "MaPB", "MaPB");
                cboMaPBThongKe.SelectedIndex = -1;
                cboMaPBThongKe.SelectionChangeCommitted += (s, e2) => UpdateSoLuongTheoPhongBan();
            }
            catch { /* ignore */ }
        }
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.CurrentRow == null) return;

            txtMaPB.Text = dgvData.CurrentRow.Cells["MaPB"].Value.ToString();
            txtTenphongban.Text = dgvData.CurrentRow.Cells["TenPB"].Value.ToString();
            txtMota.Text = dgvData.CurrentRow.Cells["MoTa"].Value.ToString();

            txtMaPB.Enabled = false;
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
            try
            {
                KetNoi ketnoi = new KetNoi();
                ketnoi.Connect();

                if (string.IsNullOrEmpty(txtMaPB.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng nhập mã phòng ban.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (string.IsNullOrEmpty(txtTenphongban.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng nhập tên hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtMaPB.Text.Length != 6)
                {
                    MessageBox.Show("Mã phòng ban phải có đúng 6 ký tự.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string check = "SELECT MAPB FROM PHONGBAN WHERE MAPB=N'" + txtMaPB.Text.Trim() + "'";
                if (Function.CheckKey(check))
                {
                    MessageBox.Show("Đã có thông tin này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaPB.Text = "";
                    ResetValues();
                    return;
                }

                string sql = $"INSERT INTO PHONGBAN (MaPB, TenPB, MoTa) VALUES (" +
                             $"N'{txtMaPB.Text.ToUpper()}', N'{txtTenphongban.Text}', N'{txtMota.Text}')";

                Function.RunSQL(sql);
                MessageBox.Show("Đã thêm phòng ban!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView();
                ResetValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();

            try
            {
                if (tblPhongBan.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtMaPB.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string mapb = txtMaPB.Text.Trim(); // <-- khai báo sau khi dùng
                //--- KIỂM TRA PHÒNG BAN CÓ NHÂN VIÊN HAY KHÔNG ---
                string sqlCheck = "SELECT COUNT(*) FROM NHANVIEN WHERE MaPB = @MaPB";
                SqlCommand cmd = new SqlCommand(sqlCheck, KetNoi.sqlConn);
                cmd.Parameters.AddWithValue("@MaPB", mapb);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Không thể xóa! Phòng ban này đang có nhân viên.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa phòng ban này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Function.RunSQL("DELETE FROM NHANVIEN WHERE MaPB = N'" + mapb + "'");
                    Function.RunSQL("DELETE FROM PHONGBAN WHERE MaPB = N'" + mapb + "'");

                    MessageBox.Show("Đã xóa phòng ban.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                    ResetValues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                KetNoi ketnoi = new KetNoi();
                ketnoi.Connect();

                if (string.IsNullOrEmpty(txtMaPB.Text))
                {
                    MessageBox.Show("Bạn chưa chọn phòng ban để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                string sql = $"UPDATE PHONGBAN SET " +
                             $"TenPB = N'{txtTenphongban.Text}', " +
                             $"MoTa = N'{txtMota.Text}' " +
                             $"WHERE MaPB = N'{txtMaPB.Text}'";

                Function.RunSQL(sql);
                MessageBox.Show("Đã cập nhật thông tin phòng ban!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView();
                ResetValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();

            try
            {
                string sql = "SELECT * FROM PHONGBAN WHERE 1=1";

                if (!string.IsNullOrEmpty(txtMaPB.Text.Trim()))
                    sql += " AND MaPB LIKE N'%" + txtMaPB.Text.Trim() + "%'";

                if (!string.IsNullOrEmpty(txtTenphongban.Text.Trim()))
                    sql += " AND TenPB LIKE N'%" + txtTenphongban.Text.Trim() + "%'";

                if (!string.IsNullOrEmpty(txtMota.Text.Trim()))
                    sql += " AND MoTa LIKE N'%" + txtMota.Text.Trim() + "%'";

                tblPhongBan = Function.ExecuteQuery(sql);

                if (tblPhongBan.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy bản ghi nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Tìm thấy " + tblPhongBan.Rows.Count + " bản ghi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvData.DataSource = tblPhongBan;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== LOGIC: THỐNG KÊ SỐ LƯỢNG NHÂN VIÊN THEO PHÒNG BAN ==========

        private void UpdateSoLuongTheoPhongBan()
        {
            if (cboMaPBThongKe.SelectedValue == null || cboMaPBThongKe.SelectedIndex == -1)
            {
                lblTongNVTheoPB.Text = "Tổng NV: -";
                return;
            }

            string ma = cboMaPBThongKe.SelectedValue.ToString();
            string sql = $"SELECT COUNT(*) AS C FROM NHANVIEN WHERE MaPB = N'{ma}'";
            try
            {
                DataTable dt = Function.ExecuteQuery(sql);
                int count = 0;
                if (dt.Rows.Count > 0) int.TryParse(dt.Rows[0][0].ToString(), out count);
                lblTongNVTheoPB.Text = $"Tổng NV ( {ma} ): {count}";
                if (count == 0)
                {
                    MessageBox.Show("Phòng ban này hiện chưa có nhân viên.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
