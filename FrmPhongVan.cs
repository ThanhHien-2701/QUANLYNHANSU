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
    public partial class FrmPhongVan : Form
    {
        DataTable tblPV;
        DataTable tblUV;
        // ==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================
        public FrmPhongVan()
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

        private void Frm_Resize(object sender, EventArgs e)
        {
            ResizeAllControls(this);
        }
        // =====================================================
        private void LoadMaDTDConHieuLuc(ComboBox comboBox)
        {
            comboBox.Items.Clear(); // Xoá item cũ nếu có

            KetNoi ketnoi = new KetNoi();
            SqlConnection conn = ketnoi.Connect(); // Giả sử phương thức Connect() trả về SqlConnection

            string sql = "SELECT MaDTD FROM DOTTUYENDUNG WHERE NgayKetThuc > GETDATE()";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox.Items.Add(reader["MaDTD"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đợt tuyển dụng: " + ex.Message);
            }
            finally
            {
                conn.Close(); // Đóng kết nối sau khi xong
            }
        }
        private void LoadMaNV_PhongHanhChinh(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            KetNoi ketnoi = new KetNoi();
            SqlConnection conn = ketnoi.Connect(); // Nếu Connect() trả SqlConnection

            string sql = "SELECT MaNV FROM NHANVIEN WHERE MaPB = 'PBHCNS'";
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
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void LoadDataPVGridView()
        {
            string sql;
            sql = "SELECT * FROM DOTPHONGVAN";
            tblPV = Function.ExecuteQuery(sql); //lấy dữ liệu
            dgvDataPV.DataSource = tblPV;
            dgvDataPV.Columns[0].HeaderText = "Mã đợt PV";
            dgvDataPV.Columns[1].HeaderText = "Tên đợt";
            dgvDataPV.Columns[2].HeaderText = "Mã đợt TD";
            dgvDataPV.Columns[3].HeaderText = "Mã nhân viên";
            dgvDataPV.Columns[4].HeaderText = "Số lượng";
            dgvDataPV.Columns[5].HeaderText = "Ngày phỏng vấn";
            
            foreach (DataGridViewColumn column in dgvDataPV.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgvDataPV.AllowUserToAddRows = false;
            dgvDataPV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void dgvDataPV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDataPV.CurrentRow == null || dgvDataPV.CurrentRow.Index == -1)
                return;

            // Lấy Mã đợt phỏng vấn từ dòng được chọn
            string maDPV = dgvDataPV.CurrentRow.Cells["MaDPV"].Value.ToString();

            // Gán dữ liệu lên các control thông tin đợt phỏng vấn
            txtMaDPV.Text = maDPV;
            txtTenDPV.Text = dgvDataPV.CurrentRow.Cells["TenDPV"].Value.ToString();
            cboDottuyen.Text = dgvDataPV.CurrentRow.Cells["MaDTD"].Value.ToString();
            cboMaNV.Text = dgvDataPV.CurrentRow.Cells["MaNV"].Value.ToString();
            txtSoluong.Text = dgvDataPV.CurrentRow.Cells["SoLuongUV"].Value.ToString();
            dtpNgayPV.Value = Convert.ToDateTime(dgvDataPV.CurrentRow.Cells["NgayPV"].Value);

            // Gọi hàm load danh sách ứng viên tham gia theo MaDPV
            LoadUngVienTheoDotPhongVan(maDPV);
            // Kiểm tra và cập nhật trạng thái các control
            KiemTraVaCapNhatTrangThaiControl();
            //txtMaDPV.Enabled = false;
            //cboDottuyen.Enabled = false; // Không cho phép sửa đợt tuyển dụng
            //cboMaNV.Enabled = false; // Không cho phép sửa mã nhân viên
        }
        private void LoadUngVienTheoDotPhongVan(string maDPV)
        {
            string sql = @"
        SELECT UV.MaUV, TenUV, GioiTinh_UV, NgaySinh_UV, Sdt_UV, Email_UV, ViTriUngTuyen, KetQuaPV
        FROM UV_THAMGIA UVTG
        JOIN UNGVIEN UV ON UVTG.MaUV = UV.MaUV
        WHERE UVTG.MaDPV = @MaDPV";

            KetNoi ketnoi = new KetNoi();
            SqlConnection conn = ketnoi.Connect();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDPV", maDPV);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDataUV.DataSource = dt;

                // Thiết lập tiêu đề cột đẹp hơn (tùy bạn)
                dgvDataUV.Columns["MaUV"].HeaderText = "Mã UV";
                dgvDataUV.Columns["TenUV"].HeaderText = "Tên";
                dgvDataUV.Columns["GioiTinh_UV"].HeaderText = "Giới tính";
                dgvDataUV.Columns["NgaySinh_UV"].HeaderText = "Ngày sinh";
                dgvDataUV.Columns["Sdt_UV"].HeaderText = "SĐT";
                dgvDataUV.Columns["Email_UV"].HeaderText = "Email";
                dgvDataUV.Columns["ViTriUngTuyen"].HeaderText = "Vị trí";
                dgvDataUV.Columns["KetQuaPV"].HeaderText = "Kết quả";

                foreach (DataGridViewColumn col in dgvDataUV.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách ứng viên: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void ResetValues()
        {
            txtVitri.Text = "";
            txtMaUV.Text = "";
            txtTenUV.Clear();
            txtVitri.Clear();
            cboDottuyen.Text = "";
            txtMaDPV.Text = "";
            txtTenDPV.Text = "";
            cboDottuyen.SelectedIndex = -1;
            cboKetQua.SelectedIndex = -1;
            txtSoluong.Text = "";
            dtpNgayPV.Value = DateTime.Now;
            cboDottuyen.Enabled = true; // Cho phép chọn lại đợt tuyển dụng
            cboKetQua.Enabled = true; // Cho phép chọn lại nhân viên
        }
        
        private void FrmPhongVan_Load(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();
            LoadMaNV_PhongHanhChinh(cboMaNV);
            cboDottuyen.SelectedIndex = -1; // Đặt giá trị mặc định là không có lựa chọn nào
            LoadMaDTDConHieuLuc(cboDottuyen);
            cboDottuyen.SelectedIndex = -1; // Đặt giá trị mặc định là không có lựa chọn nào
            LoadDataPVGridView();
            cboKetQua.Items.Clear();
            cboKetQua.Items.Add("Đạt");
            cboKetQua.Items.Add("Không đạt");
            cboKetQua.SelectedIndex = -1; // Không chọn trước
            // Thêm sự kiện kiểm tra khi thay đổi ngày
            //dtpNgayPV.ValueChanged += (s, ev) => KiemTraVaCapNhatTrangThaiControl();
            // ==================== AUTO RESIZE ====================
            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += Frm_Resize;
            // =====================================================
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            dgvDataUV.DataSource = null;
            dgvDataUV.Rows.Clear();
            dgvDataUV.Columns.Clear();
            ResetValues();
            FrmPhongVan_Load(this, EventArgs.Empty);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaDPV.Enabled = true;
            cboMaNV.Text = null;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();

            // Gán mã đợt phỏng vấn tự động nếu bạn có hàm tạo mã
            txtMaDPV.Text = Function.TaoMaMoi("MaDPV", "DOTPHONGVAN", "DPV", "", 3);
            //txtMaDPV.Enabled = false; // Không cho phép sửa mã đợt phỏng vấn
            // Kiểm tra bắt buộc
            if (string.IsNullOrWhiteSpace(txtMaDPV.Text))
            {
                MessageBox.Show("Bạn phải nhập mã đợt phỏng vấn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDPV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenDPV.Text))
            {
                MessageBox.Show("Bạn phải nhập tên đợt phỏng vấn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDPV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cboDottuyen.Text.Trim()))
            {
                MessageBox.Show("Bạn phải chọn mã đợt tuyển dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDottuyen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cboMaNV.Text.Trim()))
            {
                MessageBox.Show("Bạn phải chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaNV.Focus();
                return;
            }

            if (!byte.TryParse(txtSoluong.Text.Trim(), out byte soLuongUV))
            {
                MessageBox.Show("Số lượng ứng viên phải là số nguyên từ 0 đến 255.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }

            if (dtpNgayPV.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày phỏng vấn phải từ hôm nay trở đi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayPV.Focus();
                return;
            }

            // Kiểm tra trùng mã (tuỳ bạn có dùng tự sinh mã không)
            string sqlCheck = $"SELECT MaDPV FROM DOTPHONGVAN WHERE MaDPV = N'{txtMaDPV.Text.Trim()}'";
            if (Function.CheckKey(sqlCheck))
            {
                MessageBox.Show("Mã đợt phỏng vấn đã tồn tại, hãy tạo mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDPV.Focus();
                return;
            }

            // Thực hiện thêm
            string sql = "INSERT INTO DOTPHONGVAN (MaDPV, TenDPV, MaDTD, MaNV, SoLuongUV, NgayPV) VALUES (" +
                         $"N'{txtMaDPV.Text.Trim()}'," +
                         $"N'{txtTenDPV.Text.Trim()}'," +
                         $"N'{cboDottuyen.SelectedItem.ToString()}'," +
                         $"N'{cboMaNV.SelectedItem.ToString()}'," +
                         $"{soLuongUV}," +
                         $"'{dtpNgayPV.Value.ToString("yyyy-MM-dd")}')";

            Function.RunSQL(sql);
             MessageBox.Show("Thêm đợt phỏng vấn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDataPVGridView();
            ResetValues();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;

            // Kiểm tra nếu không có điều kiện nào được nhập
            if (string.IsNullOrEmpty(txtMaDPV.Text) &&
                cboDottuyen.SelectedIndex == -1 &&
                cboMaNV.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm (Mã đợt PV, Mã đợt TD hoặc Mã NV)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT * FROM DOTPHONGVAN WHERE 1=1";
            // Mã đợt phỏng vấn
            if (!string.IsNullOrEmpty(txtMaDPV.Text))
                sql += " AND MaDPV LIKE N'%" + txtMaDPV.Text.Trim() + "%'";

            // Mã đợt tuyển dụng
            if (cboDottuyen.SelectedIndex != -1 && !string.IsNullOrEmpty(cboDottuyen.Text))
                sql += " AND MaDTD = N'" + cboDottuyen.Text.ToString() + "'";

            // Mã nhân viên
            if (cboMaNV.SelectedIndex != -1 && !string.IsNullOrEmpty(cboMaNV.Text))
                sql += " AND MaNV = N'" + cboMaNV.Text.ToString() + "'";

            // Thực thi và hiển thị kết quả
            tblPV = Function.ExecuteQuery(sql);
            dgvDataPV.DataSource = tblPV;

            if (tblPV.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy đợt phỏng vấn nào phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Tìm thấy " + tblPV.Rows.Count + " đợt phỏng vấn phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();

            if (tblPV == null || tblPV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenDPV.Text))
            {
                MessageBox.Show("Bạn phải nhập tên đợt phỏng vấn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDPV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cboMaNV.Text.Trim()))
            {
                MessageBox.Show("Bạn phải chọn nhân viên phụ trách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaNV.Focus();
                return;
            }

            if (!byte.TryParse(txtSoluong.Text.Trim(), out byte soLuong))
            {
                MessageBox.Show("Số lượng ứng viên phải là số từ 0 đến 255", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }

  
            if (string.IsNullOrWhiteSpace(txtMaDPV.Text))
            {
                MessageBox.Show("Không xác định được mã đợt phỏng vấn để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sql = "UPDATE DOTPHONGVAN SET " +
                         "TenDPV = N'" + txtTenDPV.Text.Trim() + "', " +
                         "MaDTD = N'" + cboDottuyen.Text.ToString() + "', " +
                         "MaNV = N'" + cboMaNV.Text.ToString() + "', " +
                         "SoLuongUV = " + soLuong + ", " +
                         "NgayPV = '" + dtpNgayPV.Value.ToString("yyyy-MM-dd") + "' " +
                         "WHERE MaDPV = N'" + txtMaDPV.Text.Trim() + "'";

            Function.RunSQL(sql);
            MessageBox.Show("Cập nhật thông tin đợt phỏng vấn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDataPVGridView();
            ResetValues();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            KetNoi ketnoi = new KetNoi();
            ketnoi.Connect();

            if (tblPV == null || tblPV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu để xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaDPV.Text))
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá đợt phỏng vấn này và toàn bộ dữ liệu liên quan không?",
                                "Xác nhận xoá", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string maDPV = txtMaDPV.Text.Trim();

                try
                {
                    // Xóa dữ liệu liên quan trong bảng UV_THAMGIA trước
                    Function.RunSQL("DELETE FROM UV_THAMGIA WHERE MaDPV = N'" + maDPV + "'");

                    // Sau đó xoá đợt phỏng vấn
                    Function.RunSQL("DELETE FROM DOTPHONGVAN WHERE MaDPV = N'" + maDPV + "'");

                    MessageBox.Show("Đã xoá đợt phỏng vấn và các dữ liệu liên quan thành công.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadDataPVGridView();
                    dgvDataUV.DataSource = null; // Xoá danh sách ứng viên hiển thị nếu có
                    ResetValues();
                    btnXoa.Enabled = false;
                    btnSua.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xoá: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvDataUV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDataUV.CurrentRow == null || dgvDataUV.CurrentRow.Index == -1)
                return;
            txtMaUV.Text = dgvDataUV.CurrentRow.Cells["MaUV"].Value.ToString();
            txtTenUV.Text = dgvDataUV.CurrentRow.Cells["TenUV"].Value.ToString();
            txtVitri.Text = dgvDataUV.CurrentRow.Cells["ViTriUngTuyen"].Value.ToString();
            cboKetQua.Text = dgvDataUV.CurrentRow.Cells["KetQuaPV"].Value.ToString();
        }
        private void btnXoaUV_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(txtMaUV.Text) || string.IsNullOrEmpty(txtMaDPV.Text))
            {
                MessageBox.Show("Vui lòng chọn ứng viên để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maUV = txtMaUV.Text.Trim();
            string maDPV = txtMaDPV.Text.Trim();

            try
            {
                // Lấy ngày phỏng vấn
                string sqlNgay = $"SELECT NgayPV FROM DOTPHONGVAN WHERE MaDPV = N'{maDPV}'";
                DataTable dtNgay = Function.ExecuteQuery(sqlNgay);

                if (dtNgay.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đợt phỏng vấn!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime ngayPV = Convert.ToDateTime(dtNgay.Rows[0]["NgayPV"]);
                DateTime homNay = DateTime.Today;

                // Xử lý theo trạng thái
                if (ngayPV == homNay)
                {
                    // ĐANG DIỄN RA - KHÔNG CHO XÓA
                    MessageBox.Show("Đợt phỏng vấn đang diễn ra!\nKhông thể xóa ứng viên.",
                        "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool canDelete = false;
                string confirmMessage = "";

                if (ngayPV < homNay)
                {
                    // ĐÃ DIỄN RA - CHỈ XÓA KHÔNG ĐẠT
                    string sqlKetQua = $"SELECT KetQuaPV FROM UV_THAMGIA WHERE MaUV = N'{maUV}' AND MaDPV = N'{maDPV}'";
                    DataTable dtKetQua = Function.ExecuteQuery(sqlKetQua);

                    if (dtKetQua.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy thông tin ứng viên!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string ketQua = dtKetQua.Rows[0]["KetQuaPV"].ToString().Trim();

                    if (ketQua.Equals("Đạt", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Không thể xóa ứng viên ĐẠT!", "Không thể xóa",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    canDelete = true;
                    confirmMessage = $"Đợt phỏng vấn đã diễn ra.\n" +
                                   $"Ứng viên có kết quả: {ketQua}\n\n" +
                                   $"Xác nhận xóa ứng viên KHÔNG ĐẠT?";
                }
                else // ngayPV > homNay
                {
                    // CHƯA DIỄN RA - XÓA BÌNH THƯỜNG
                    canDelete = true;
                    confirmMessage = "Đợt phỏng vấn chưa diễn ra.\n\n" +
                                   "Xác nhận xóa ứng viên này?";
                }

                // Xác nhận và thực hiện xóa
                if (canDelete)
                {
                    DialogResult result = MessageBox.Show(confirmMessage, "Xác nhận xóa",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        KetNoi ketnoi = new KetNoi();
                        SqlConnection conn = ketnoi.Connect();

                        try
                        {
                            string sql = "DELETE FROM UV_THAMGIA WHERE MaUV = @MaUV AND MaDPV = @MaDPV";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@MaUV", maUV);
                            cmd.Parameters.AddWithValue("@MaDPV", maDPV);

                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                MessageBox.Show("✅ Đã xóa ứng viên thành công!", "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadUngVienTheoDotPhongVan(maDPV);
                                txtMaUV.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy bản ghi để xóa.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ResetValues();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDPV.Text))
            {
                MessageBox.Show("Bạn chưa chọn đợt phỏng vấn!");
                return;
            }

            string maDTD = txtMaDPV.Text;
            // Mở form gửi mail và truyền file PDF
            FrmMail guiMail = new FrmMail();
            guiMail.ShowDialog();
        }

        private void btn_TimUV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDPV.Text))
            {
                MessageBox.Show("Vui lòng chọn đợt phỏng vấn trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDPV = txtMaDPV.Text.Trim();
            string sql = @"
        SELECT UV.MaUV, TenUV, GioiTinh_UV, NgaySinh_UV, Sdt_UV, Email_UV, 
               ViTriUngTuyen, KetQuaPV
        FROM UV_THAMGIA TG
        JOIN UNGVIEN UV ON TG.MaUV = UV.MaUV
        WHERE TG.MaDPV = @MaDPV
    ";

            // Tìm theo Mã UV
            if (!string.IsNullOrWhiteSpace(txtMaUV.Text))
                sql += " AND UV.MaUV LIKE N'%" + txtMaUV.Text.Trim() + "%'";

            // Tìm theo Tên UV
            if (!string.IsNullOrWhiteSpace(txtTenUV.Text))
                sql += " AND TenUV LIKE N'%" + txtTenUV.Text.Trim() + "%'";

            // Tìm theo Vị trí ứng tuyển
            if (!string.IsNullOrWhiteSpace(txtVitri.Text))
                sql += " AND ViTriUngTuyen LIKE N'%" + txtVitri.Text.Trim() + "%'";

            // Tìm theo Kết quả phỏng vấn
            if (!string.IsNullOrWhiteSpace(cboKetQua.Text))
                sql += " AND KetQuaPV = N'" + cboKetQua.Text.Trim() + "'";


            KetNoi ketnoi = new KetNoi();
            SqlConnection conn = ketnoi.Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDPV", maDPV);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDataUV.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy ứng viên phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Tìm thấy " + dt.Rows.Count + " ứng viên phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void KiemTraVaCapNhatTrangThaiControl()
        {
            // Kiểm tra nếu có ngày phỏng vấn được chọn
            if (string.IsNullOrEmpty(txtMaDPV.Text))
            {
                // Nếu chưa chọn đợt phỏng vấn, enable tất cả trừ mã
                txtMaDPV.Enabled = false;
                cboDottuyen.Enabled = false;
                txtTenDPV.Enabled = true;
                cboMaNV.Enabled = true;
                txtSoluong.Enabled = true;
                dtpNgayPV.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                return;
            }

            // Lấy ngày phỏng vấn từ DateTimePicker
            DateTime ngayPV = dtpNgayPV.Value.Date;
            DateTime today = DateTime.Today;

            // Luôn disable mã đợt PV và mã đợt tuyển dụng
            txtMaDPV.Enabled = false;
            cboDottuyen.Enabled = false;

            if (ngayPV < today)
            {
                // Ngày phỏng vấn đã qua - Disable tất cả các control
                txtTenDPV.Enabled = false;
                cboMaNV.Enabled = false;
                txtSoluong.Enabled = false;
                dtpNgayPV.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                // Disable các control của ứng viên
                txtMaUV.Enabled = true;
                txtTenUV.Enabled = true;
                txtVitri.Enabled = true;
                cboKetQua.Enabled = true; // Vẫn cho phép cập nhật kết quả
                btnXoaUV.Enabled = true;
            }
            else
            {
                // Ngày phỏng vấn chưa diễn ra - Enable các control (trừ mã DPV và mã DTD)
                txtTenDPV.Enabled = true;
                cboMaNV.Enabled = true;
                txtSoluong.Enabled = true;
                dtpNgayPV.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                // Enable các control của ứng viên
                txtMaUV.Enabled = true; // Mã UV chỉ hiển thị, không cho sửa
                txtTenUV.Enabled = true; // Tên UV chỉ hiển thị
                txtVitri.Enabled = true; // Vị trí chỉ hiển thị
                cboKetQua.Enabled = true;
                btnXoaUV.Enabled = true;
            }
        }

    }
}
