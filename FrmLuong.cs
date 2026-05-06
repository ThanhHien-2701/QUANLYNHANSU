using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace QUANLYNHANSU
{
    public partial class FrmLuong : Form
    {
        DataTable tblLuong;
        // ==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================
        public FrmLuong()
        {
            InitializeComponent();
        }
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

        private void FrmLuong_Resize(object sender, EventArgs e)
        {
            ResizeAllControls(this);
        }
        // =====================================================
        public void LoadDataGridView()
        {
            string sql = "SELECT MaBangLuong, LuongCoBan, CS_Thuong, PhuCap, KhauTru, ThucLanh, MaNV, NgayNhanLuong FROM BANGLUONG";
            tblLuong = Function.ExecuteQuery(sql);
            dgvData.DataSource = tblLuong;

            dgvData.Columns[0].HeaderText = "Mã bảng lương";
            dgvData.Columns[1].HeaderText = "Lương cơ bản";
            dgvData.Columns[2].HeaderText = "Chỉ số thưởng";
            dgvData.Columns[3].HeaderText = "Phụ cấp";
            dgvData.Columns[4].HeaderText = "Khấu trừ";
            dgvData.Columns[5].HeaderText = "Thực lãnh";
            dgvData.Columns[6].HeaderText = "Mã nhân viên";
            dgvData.Columns[7].HeaderText = "Ngày nhận lương";

            foreach (DataGridViewColumn col in dgvData.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvData.AllowUserToAddRows = false;
            dgvData.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void FrmLuong_Load(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            LoadComboBoxThang();
            LoadComboBoxNam();
            LoadDataGridView();
            // ==================== AUTO RESIZE ====================
            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += FrmLuong_Resize;
            // =====================================================
        }

        private void LoadComboBoxThang()
        {
            cboThang.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i.ToString("D2")); // 01 -> 12
            }
            cboThang.SelectedItem = DateTime.Now.Month.ToString("D2");
        }

        private void LoadComboBoxNam()
        {
            cboNam.Items.Clear();
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear - 5; year <= currentYear + 5; year++)
            {
                cboNam.Items.Add(year.ToString());
            }
            cboNam.SelectedItem = currentYear.ToString();
        }
        private void btn_Loc_Click(object sender, EventArgs e)
        {
            if (cboThang.SelectedItem == null || cboNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ tháng và năm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string thang = cboThang.SelectedItem.ToString();
            string nam = cboNam.SelectedItem.ToString();

            string sql = "SELECT * FROM BANGLUONG " +
                         "WHERE MONTH(NgayNhanLuong) = " + thang + " AND YEAR(NgayNhanLuong) = " + nam;

            DataTable dt = Function.ExecuteQuery(sql);
            dgvData.DataSource = dt;

            // Đếm số dòng hiển thị (nếu có txtSoLuong)
            
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu lương trong tháng/năm được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadComboBoxThang();  // đưa tháng về hiện tại
            LoadComboBoxNam();    // đưa năm về hiện tại
            FrmLuong_Load(sender, e); // nạp lại dữ liệu bảng lương
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.csv";
                saveFileDialog.Title = "Lưu bảng lương ra Excel";
                saveFileDialog.FileName = $"BangLuong_{cboThang.SelectedItem}_{cboNam.SelectedItem}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        // Ghi header với BOM UTF-8 để Excel đọc đúng tiếng Việt
                        sw.Write("\uFEFF");
                        
                        // Ghi tiêu đề
                        sw.WriteLine("BẢNG LƯƠNG NHÂN VIÊN");
                        sw.WriteLine($"Tháng: {cboThang.SelectedItem} / Năm: {cboNam.SelectedItem}");
                        sw.WriteLine($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                        sw.WriteLine();

                        // Ghi header các cột
                        for (int i = 0; i < dgvData.Columns.Count; i++)
                        {
                            if (i > 0) sw.Write(",");
                            sw.Write("\"" + dgvData.Columns[i].HeaderText + "\"");
                        }
                        sw.WriteLine();

                        // Ghi dữ liệu
                        foreach (DataGridViewRow row in dgvData.Rows)
                        {
                            for (int i = 0; i < dgvData.Columns.Count; i++)
                            {
                                if (i > 0) sw.Write(",");
                                string value = row.Cells[i].Value?.ToString() ?? "";
                                // Escape dấu ngoặc kép và thay thế dấu phẩy
                                value = value.Replace("\"", "\"\"");
                                sw.Write("\"" + value + "\"");
                            }
                            sw.WriteLine();
                        }
                    }

                    MessageBox.Show($"Đã xuất bảng lương thành công!\nFile: {saveFileDialog.FileName}", 
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Mở file vừa tạo
                    Process.Start(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
