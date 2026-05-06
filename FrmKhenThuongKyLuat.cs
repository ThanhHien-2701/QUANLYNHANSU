using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
	public partial class FrmKhenThuongKyLuat : Form
	{
		private DataTable _dsNhanVien;
		private DataTable _dsTieuChi;
        private DataTable tblKTKL;
        // ==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================

        public FrmKhenThuongKyLuat()
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

        private void FrmKTKL_Resize(object sender, EventArgs e)
        {
            ResizeAllControls(this);
        }
        // =====================================================

        private void FrmKhenThuongKyLuat_Load(object sender, EventArgs e)
		{
			LoadComboData();
			LoadGrid();
            // ==================== AUTO RESIZE ====================
            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += FrmKTKL_Resize;
            // =====================================================
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			txtMa.Enabled = false;
        }

        private void LoadComboData()
		{
			_dsNhanVien = Function.ExecuteQuery("SELECT MaNV, HoNV + ' ' + TenNV AS HoTen FROM dbo.NHANVIEN ORDER BY MaNV");
			if (!_dsNhanVien.Columns.Contains("Display"))
			{
				_dsNhanVien.Columns.Add("Display", typeof(string));
				foreach (DataRow row in _dsNhanVien.Rows)
				{
					row["Display"] = $"{row["MaNV"]} - {row["HoTen"]}";
				}
			}
			cboMaNV.DataSource = _dsNhanVien;
			cboMaNV.DisplayMember = "Display";
			cboMaNV.ValueMember = "MaNV";
			cboMaNV.SelectedIndex = -1;

			_dsTieuChi = Function.ExecuteQuery("SELECT MaTC, TenTC, Loai FROM dbo.TIEUCHI ORDER BY MaTC");
			if (!_dsTieuChi.Columns.Contains("Display"))
			{
				_dsTieuChi.Columns.Add("Display", typeof(string));
				foreach (DataRow row in _dsTieuChi.Rows)
				{
					row["Display"] = $"{row["MaTC"]} - {row["TenTC"]}";
				}
			}
			ApplyTieuChiFilter();
			cboMaTC.SelectedIndex = -1;
		}

		private void ApplyTieuChiFilter(string maTcToSelect = null)
		{
			if (_dsTieuChi == null)
			{
				return;
			}

			DataView view = new DataView(_dsTieuChi);
			if (cboLoai.SelectedItem != null)
			{
				string loai = cboLoai.SelectedItem.ToString();
				view.RowFilter = $"Loai = '{loai}'";
			}
			else
			{
				view.RowFilter = string.Empty;
			}

			cboMaTC.DataSource = view;
			cboMaTC.DisplayMember = "Display";
			cboMaTC.ValueMember = "MaTC";

			if (!string.IsNullOrEmpty(maTcToSelect))
			{
				cboMaTC.SelectedValue = maTcToSelect;
			}
			else if (cboLoai.SelectedIndex == -1)
			{
				cboMaTC.SelectedIndex = -1;
			}
		}

		private void LoadGrid(string where = "")
		{
			string sql = @"SELECT 'KT' AS Loai, MaKT AS Ma, MaNV, MaTC, NgayKT AS Ngay,SoTien, GhiChu FROM dbo.KHENTHUONG
							 UNION ALL
							 SELECT 'KL' AS Loai, MaKL AS Ma, MaNV, MaTC, NgayKL AS Ngay,SoTien, GhiChu FROM dbo.KYLUAT
							 ORDER BY Ngay DESC";
			if (!string.IsNullOrWhiteSpace(where)) sql += " " + where;
            tblKTKL = Function.ExecuteQuery(sql);
            dgv.DataSource = tblKTKL;

            dgv.Columns[0].HeaderText = "Loại";
            dgv.Columns[1].HeaderText = "Mã KT/KL";
            dgv.Columns[2].HeaderText = "Nhân viên";
            dgv.Columns[3].HeaderText = "Tiêu chí";
            dgv.Columns[4].HeaderText = "Ngày thực hiện";
            dgv.Columns[5].HeaderText = "Số tiền";
			dgv.Columns[6].HeaderText = "Ghi chú";

            foreach (DataGridViewColumn c in dgv.Columns)
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.AllowUserToAddRows = false;
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

		private void ClearInputs()
		{
			txtMa.Text = "";
			txtMa.Enabled = false;
			cboLoai.SelectedIndex = -1;
			cboMaNV.SelectedIndex = -1;
			ApplyTieuChiFilter();
			cboMaTC.SelectedIndex = -1;
			dtpNgay.Value = DateTime.Today;
			txt_Sotien.Text = "";
			txtGhiChu.Text = "";
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			// Kiểm tra loại trước
			if (cboLoai.SelectedIndex < 0)
			{
				MessageBox.Show("Vui lòng chọn Loại (Khen thưởng hoặc Kỷ luật) trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				cboLoai.Focus();
				return;
			}

			// Tự động tạo mã nếu chưa có
			if (string.IsNullOrWhiteSpace(txtMa.Text))
			{
				string loai = cboLoai.SelectedItem.ToString();
				string prefix = loai == "KhenThuong" ? "KT" : "KL";
				string tableName = loai == "KhenThuong" ? "KHENTHUONG" : "KYLUAT";
				string columnID = loai == "KhenThuong" ? "MaKT" : "MaKL";

				txtMa.Text = Function.TaoMaMoi(columnID, tableName, prefix, "", 3);
			}

			// Kiểm tra các trường còn lại
			if (cboMaNV.SelectedIndex < 0)
			{
				MessageBox.Show("Vui lòng chọn Nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				cboMaNV.Focus();
				return;
			}

			if (cboMaTC.SelectedIndex < 0)
			{
				MessageBox.Show("Vui lòng chọn Tiêu chí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				cboMaTC.Focus();
				return;
			}

			// Thực hiện thêm
			try
			{
				if (cboLoai.SelectedItem.ToString() == "KhenThuong")
				{
					string sql = @"INSERT INTO dbo.KHENTHUONG(MaKT, MaNV, MaTC, NgayKT, SoTien, GhiChu)
                           VALUES (@Ma, @MaNV, @MaTC, @Ngay, @SoTien, @GhiChu)";
					using (SqlConnection conn = new SqlConnection(Function.chuoiketnoi))
					using (SqlCommand cmd = new SqlCommand(sql, conn))
					{
						cmd.Parameters.AddWithValue("@Ma", txtMa.Text.Trim());
						cmd.Parameters.AddWithValue("@MaNV", cboMaNV.SelectedValue.ToString());
						cmd.Parameters.AddWithValue("@MaTC", cboMaTC.SelectedValue.ToString());
						cmd.Parameters.AddWithValue("@Ngay", dtpNgay.Value.Date);
						cmd.Parameters.AddWithValue("@SoTien", string.IsNullOrWhiteSpace(txt_Sotien.Text) ? (object)DBNull.Value : decimal.Parse(txt_Sotien.Text.Trim()));
						cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrWhiteSpace(txtGhiChu.Text) ? (object)DBNull.Value : txtGhiChu.Text.Trim());
						conn.Open();
						cmd.ExecuteNonQuery();

					}
                    MessageBox.Show("Thông tin khen thưởng của nhân viên đã được thêm vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else // KyLuat
				{
					string sql = @"INSERT INTO dbo.KYLUAT(MaKL, MaNV, MaTC, NgayKL, SoTien, GhiChu)
                           VALUES (@Ma, @MaNV, @MaTC, @Ngay, @SoTien, @GhiChu)";
					using (SqlConnection conn = new SqlConnection(Function.chuoiketnoi))
					using (SqlCommand cmd = new SqlCommand(sql, conn))
					{
						cmd.Parameters.AddWithValue("@Ma", txtMa.Text.Trim());
						cmd.Parameters.AddWithValue("@MaNV", cboMaNV.SelectedValue.ToString());
						cmd.Parameters.AddWithValue("@MaTC", cboMaTC.SelectedValue.ToString());
						cmd.Parameters.AddWithValue("@Ngay", dtpNgay.Value.Date);
						cmd.Parameters.AddWithValue("@SoTien", string.IsNullOrWhiteSpace(txt_Sotien.Text) ? (object)DBNull.Value : decimal.Parse(txt_Sotien.Text.Trim()));
						cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrWhiteSpace(txtGhiChu.Text) ? (object)DBNull.Value : txtGhiChu.Text.Trim());
						conn.Open();
						cmd.ExecuteNonQuery();
					}
                    MessageBox.Show("Thông tin kỷ luật của nhân viên đã được thêm vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


                LoadGrid();
				ClearInputs();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtMa.Text) || cboLoai.SelectedIndex < 0 || cboMaNV.SelectedIndex < 0 || cboMaTC.SelectedIndex < 0)
			{
				MessageBox.Show("Chọn bản ghi để sửa và đảm bảo đã chọn Nhân viên, Tiêu chí.");
				return;
			}

			if (cboLoai.SelectedItem.ToString() == "KhenThuong")
			{
				string sql = @"UPDATE dbo.KHENTHUONG
							   SET MaNV=@MaNV, MaTC=@MaTC, NgayKT=@Ngay, SoTien=@SoTien, GhiChu=@GhiChu
							   WHERE MaKT=@Ma";
				using (SqlConnection conn = new SqlConnection(Function.chuoiketnoi))
				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@Ma", txtMa.Text.Trim());
					cmd.Parameters.AddWithValue("@MaNV", cboMaNV.SelectedValue.ToString());
					cmd.Parameters.AddWithValue("@MaTC", cboMaTC.SelectedValue.ToString());
					cmd.Parameters.AddWithValue("@Ngay", dtpNgay.Value.Date);
                    cmd.Parameters.AddWithValue("@SoTien", string.IsNullOrWhiteSpace(txt_Sotien.Text) ? (object)DBNull.Value : decimal.Parse(txt_Sotien.Text.Trim()));
                    cmd.Parameters.AddWithValue("@GhiChu", (object)txtGhiChu.Text.Trim() ?? DBNull.Value);
					conn.Open();
					cmd.ExecuteNonQuery();
				}
                MessageBox.Show("Thông tin khen thưởng của nhân viên đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
			{
				string sql = @"UPDATE dbo.KYLUAT
							   SET MaNV=@MaNV, MaTC=@MaTC, NgayKL=@Ngay, SoTien=@SoTien, GhiChu=@GhiChu
							   WHERE MaKL=@Ma";
				using (SqlConnection conn = new SqlConnection(Function.chuoiketnoi))
				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@Ma", txtMa.Text.Trim());
					cmd.Parameters.AddWithValue("@MaNV", cboMaNV.SelectedValue.ToString());
					cmd.Parameters.AddWithValue("@MaTC", cboMaTC.SelectedValue.ToString());
					cmd.Parameters.AddWithValue("@Ngay", dtpNgay.Value.Date);
                    cmd.Parameters.AddWithValue("@SoTien", string.IsNullOrWhiteSpace(txt_Sotien.Text) ? (object)DBNull.Value : decimal.Parse(txt_Sotien.Text.Trim()));
                    cmd.Parameters.AddWithValue("@GhiChu", (object)txtGhiChu.Text.Trim() ?? DBNull.Value);
					conn.Open();
					cmd.ExecuteNonQuery();
				}
                MessageBox.Show("Thông tin kỷ luật của nhân viên đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
			ClearInputs();
            LoadGrid();
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtMa.Text) || cboLoai.SelectedIndex < 0)
			{
				MessageBox.Show("Chọn bản ghi để xóa.");
				return;
			}

			if (MessageBox.Show("Xác nhận xóa thông tin?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				return;

			string tbl = cboLoai.SelectedItem.ToString() == "KhenThuong" ? "KHENTHUONG" : "KYLUAT";
			string key = tbl == "KHENTHUONG" ? "MaKT" : "MaKL";
			string sql = $"DELETE FROM dbo.{tbl} WHERE {key}=@Ma";
			using (SqlConnection conn = new SqlConnection(Function.chuoiketnoi))
			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@Ma", txtMa.Text.Trim());
				conn.Open();
				cmd.ExecuteNonQuery();
			}
            MessageBox.Show("Đã xóa thành công thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadGrid();
			ClearInputs();
		}

		private void btnLamMoi_Click(object sender, EventArgs e)
		{
			ClearInputs();
			LoadGrid();
		}

		private void btnTim_Click(object sender, EventArgs e)
		{
			
            string key = txtTimMa.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                LoadGrid();
                return;
            }

            string sql = @"SELECT 'KT' AS Loai, MaKT AS Ma, MaNV, MaTC, NgayKT AS Ngay, SoTien, GhiChu FROM dbo.KHENTHUONG WHERE MaKT=@Ma
                   UNION ALL
                   SELECT 'KL' AS Loai, MaKL AS Ma, MaNV, MaTC, NgayKL AS Ngay, SoTien, GhiChu FROM dbo.KYLUAT WHERE MaKL=@Ma";

            using (SqlConnection conn = new SqlConnection(Function.chuoiketnoi))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@Ma", key);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

                if (dt.Rows.Count > 0)
                {
					MessageBox.Show($"Đã tìm thấy {dt.Rows.Count} kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin với mã này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

		private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;
			DataGridViewRow row = dgv.Rows[e.RowIndex];
			string loaiDisplay = row.Cells["Loai"].Value.ToString() == "KT" ? "KhenThuong" : "KyLuat";
			cboLoai.SelectedItem = loaiDisplay;
			txtMa.Text = row.Cells["Ma"].Value.ToString();
			cboMaNV.SelectedValue = row.Cells["MaNV"].Value.ToString();
			ApplyTieuChiFilter(row.Cells["MaTC"].Value.ToString());
			DateTime ngay;
			if (DateTime.TryParse(row.Cells["Ngay"].Value.ToString(), out ngay))
			{
				dtpNgay.Value = ngay;
			}
            // Hiển thị số tiền
            // Xử lý Số tiền (cho phép NULL)
            if (row.Cells["SoTien"].Value != null && row.Cells["SoTien"].Value != DBNull.Value)
            {
                txt_Sotien.Text = row.Cells["SoTien"].Value.ToString();
            }
            else
            {
                txt_Sotien.Text = "";
            }
            txtGhiChu.Text = row.Cells["GhiChu"].Value == null ? "" : row.Cells["GhiChu"].Value.ToString();
			cboMaNV.Enabled = false;
			cboLoai.Enabled = false;
		}
        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoai.SelectedIndex >= 0)
            {
                string loai = cboLoai.SelectedItem.ToString();
                string prefix = "";
                string tableName = "";
                string columnID = "";

                if (loai == "KhenThuong")
                {
                    prefix = "KT";
                    tableName = "KHENTHUONG";
                    columnID = "MaKT";
                }
                else if (loai == "KyLuat")
                {
                    prefix = "KL";
                    tableName = "KYLUAT";
                    columnID = "MaKL";
                }

                // Tạo mã tự động
                if (!string.IsNullOrEmpty(prefix))
                {
                    txtMa.Text = Function.TaoMaMoi(columnID, tableName, prefix, "", 4);
                    txtMa.Enabled = false;
                }
            }

            // Lọc tiêu chí theo loại
            ApplyTieuChiFilter();
        }

        private void label1_Click(object sender, EventArgs e)
        {
			this.Close();
        }

    }
}

