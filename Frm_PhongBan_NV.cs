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
    public partial class Frm_PhongBan_NV : Form
    {
        DataTable tblPhongBan;
        // ==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================

        public Frm_PhongBan_NV()
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
        public void LoadDataGridView()
        {
            string sql = "SELECT TENPB, MANV, HONV, TENNV, GIOITINH, SDT_NV, EMAIL_NV FROM NHANVIEN JOIN PHONGBAN ON NHANVIEN.MAPB=PHONGBAN.MAPB";
            tblPhongBan = Function.ExecuteQuery(sql);
            dgvData.DataSource = tblPhongBan;

            dgvData.Columns[0].HeaderText = "Tên phòng ban";
            dgvData.Columns[1].HeaderText = "Mã nhân viên";
            dgvData.Columns[2].HeaderText = "Họ nhân viên";
            dgvData.Columns[3].HeaderText = "Tên nhân viên";
            dgvData.Columns[4].HeaderText = "Giới tính";
            dgvData.Columns[5].HeaderText = "Số điện thoại";
            dgvData.Columns[6].HeaderText = "Email";

            foreach (DataGridViewColumn col in dgvData.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvData.AllowUserToAddRows = false;
            dgvData.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void FrmPhongBan_NV_Load(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            Function.FillCombo("SELECT * FROM PhongBan", cboPhongban, "MAPB", "TENPB");
            cboPhongban.SelectedIndex = -1;
            LoadDataGridView();
            // ==================== AUTO RESIZE ====================
            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += FrmUngVien_Resize;
            // =====================================================
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();

            try
            {
                string sql = "SELECT TENPB, MANV, HONV, TENNV, GIOITINH, SDT_NV, EMAIL_NV FROM " +
                    "NHANVIEN JOIN PHONGBAN ON NHANVIEN.MAPB=PHONGBAN.MAPB WHERE 1=1";


                if (!string.IsNullOrEmpty(cboPhongban.Text.Trim()))
                    sql += " AND TenPB LIKE N'%" + cboPhongban.Text.Trim() + "%'";

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

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
            cboPhongban.SelectedIndex = -1;
        }
    }
}
