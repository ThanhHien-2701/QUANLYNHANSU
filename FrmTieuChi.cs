using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
	public partial class FrmTieuChi : Form
	{
        //==================== AUTO RESIZE ====================
        Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;
        // =====================================================

        public FrmTieuChi()
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

        private void FrmTieuChi_Load(object sender, EventArgs e)
		{
			LoadGrid();
            // ==================== AUTO RESIZE ====================
            originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += Frm_Resize;
            // =====================================================
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			txtMa.Enabled = false;
        }

        private void LoadGrid()
		{
			DataTable dt = Function.ExecuteQuery("SELECT MaTC, TenTC, Loai, MoTa FROM dbo.TIEUCHI ORDER BY MaTC");
			dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "Mã tiêu chí";
            dgv.Columns[1].HeaderText = "Tên tiêu chí";
            dgv.Columns[2].HeaderText = "Loại tiêu chí";
			dgv.Columns[3].HeaderText = "Mô tả";
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["MoTa"].Value != null &&
                    row.Cells["MoTa"].Value.ToString().Contains("Ngưng"))
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.DefaultCellStyle.Font = new Font("Times New Roman", 9, FontStyle.Bold);
                }
            }
        }

		private void ClearInputs()
		{
			txtMa.Text = "";
			txtTen.Text = "";
			cboLoai.SelectedIndex = -1;
			txtMoTa.Text = "";
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
            string sql;
            // Kiểm tra loại trước tiên
            if (cboLoai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn Loại trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoai.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTen.Text) || cboLoai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập Mã, Tên và chọn Loại.");
                return;
            }

            // Tạo mã tự động dựa trên loại
            string prefix = "";
            string loai = cboLoai.SelectedItem.ToString();

            if (loai.Equals("KhenThuong", StringComparison.OrdinalIgnoreCase) ||
                loai.Equals("KhenThuong", StringComparison.OrdinalIgnoreCase))
            {
                prefix = "TCKT";
            }
            else if (loai.Equals("KyLuat", StringComparison.OrdinalIgnoreCase) ||
                     loai.Equals("KyLuat", StringComparison.OrdinalIgnoreCase))
            {
                prefix = "TCKL";
            }
            // Sử dụng hàm TaoMaMoi có sẵn
            string maMoi = Function.TaoMaMoi("MaTC", "TIEUCHI", prefix, "", 2);
            txtMa.Text = maMoi;

            sql = @"INSERT INTO dbo.TIEUCHI(MaTC, TenTC, Loai, MoTa) 
						   VALUES (@Ma, @Ten, @Loai, @MoTa)";
			using (SqlConnection conn = new SqlConnection(Function.chuoiketnoi))
			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
                cmd.Parameters.AddWithValue("@Ma", maMoi);
                cmd.Parameters.AddWithValue("@Ten", txtTen.Text.Trim());
				cmd.Parameters.AddWithValue("@Loai", cboLoai.SelectedItem.ToString());
				cmd.Parameters.AddWithValue("@MoTa", (object)txtMoTa.Text.Trim() ?? DBNull.Value);
				conn.Open();
				cmd.ExecuteNonQuery();
			}
            MessageBox.Show("Thêm thông tin tiêu chí thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LoadGrid();
			ClearInputs();
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtMa.Text))
			{
				MessageBox.Show("Chọn bản ghi để sửa.");
				return;
			}
			string sql = @"UPDATE dbo.TIEUCHI SET TenTC=@Ten, Loai=@Loai, MoTa=@MoTa WHERE MaTC=@Ma";
			using (SqlConnection conn = new SqlConnection(Function.chuoiketnoi))
			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@Ma", txtMa.Text.Trim());
				cmd.Parameters.AddWithValue("@Ten", txtTen.Text.Trim());
				cmd.Parameters.AddWithValue("@Loai", cboLoai.SelectedItem == null ? (object)DBNull.Value : cboLoai.SelectedItem.ToString());
				cmd.Parameters.AddWithValue("@MoTa", (object)txtMoTa.Text.Trim() ?? DBNull.Value);
				conn.Open();
				cmd.ExecuteNonQuery();
                int rows = cmd.ExecuteNonQuery();

                // Thông báo chỉ hiển thị khi thực sự có bản ghi được cập nhật
                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật bản ghi thành công!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có bản ghi nào được cập nhật!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
			LoadGrid();
		}

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                MessageBox.Show("Chọn bản ghi để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maTC = txtMa.Text.Trim();

            if (MessageBox.Show("Bạn có chắc muốn xoá tiêu chí này?",
                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes)
                return;

            // 1. Kiểm tra tiêu chí có dữ liệu liên kết không
            string sqlCheckLienKet = @"
    SELECT (
        (SELECT COUNT(*) FROM KHENTHUONG WHERE MaTC = @MaTC) +
        (SELECT COUNT(*) FROM KYLUAT     WHERE MaTC = @MaTC)
    ) AS TotalCount";

            int count = 0;
            using (SqlConnection conn = new SqlConnection(Function.chuoiketnoi))
            using (SqlCommand cmd = new SqlCommand(sqlCheckLienKet, conn))
            {
                cmd.Parameters.AddWithValue("@MaTC", maTC);
                conn.Open();
                count = (int)cmd.ExecuteScalar();
            }

            // 2. Nếu có liên kết -> không được xóa, chỉ cập nhật mô tả
            if (count > 0)
            {
                string sqlUpdate = @"UPDATE TIEUCHI 
                             SET MoTa = N'Ngưng áp dụng' 
                             WHERE MaTC = @MaTC";

                using (SqlConnection conn = new SqlConnection(Function.chuoiketnoi))
                using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTC", maTC);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Tiêu chí đã được sử dụng nên không thể xoá.\nĐã cập nhật trạng thái thành 'Ngưng áp dụng'.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadGrid();
                ClearInputs();
                return;
            }
            try
            {
                // Thực hiện xóa tiêu chí
                string sqlDelete = "DELETE FROM TIEUCHI WHERE MaTC = @MaTC";

                using (SqlConnection conn = new SqlConnection(Function.chuoiketnoi))
                using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTC", maTC);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa tiêu chí thành công!",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LoadGrid();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tiêu chí cần xóa.",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tiêu chí: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
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
                MessageBox.Show("Vui lòng nhập mã tiêu chí để tìm kiếm!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                txtTimMa.Focus();
                return;
            }

			using (SqlConnection conn = new SqlConnection(Function.chuoiketnoi))
			using (SqlCommand cmd = new SqlCommand("SELECT MaTC, TenTC, Loai, MoTa FROM dbo.TIEUCHI WHERE MaTC=@Ma", conn))
			using (SqlDataAdapter da = new SqlDataAdapter(cmd))
			{
				cmd.Parameters.AddWithValue("@Ma", key);
				DataTable dt = new DataTable();
				da.Fill(dt);
				dgv.DataSource = dt;
                // Hiển thị số lượng bản ghi tìm thấy
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show($"Tìm thấy {dt.Rows.Count} bản ghi phù hợp!",
                                    "Kết quả",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bản ghi nào!",
                                    "Kết quả",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
		}

		private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;
			DataGridViewRow row = dgv.Rows[e.RowIndex];
			txtMa.Text = row.Cells["MaTC"].Value.ToString();
			txtTen.Text = row.Cells["TenTC"].Value.ToString();
			cboLoai.SelectedItem = row.Cells["Loai"].Value.ToString();
			txtMoTa.Text = row.Cells["MoTa"].Value == null ? "" : row.Cells["MoTa"].Value.ToString();
            cboLoai.Enabled = false;
		}

        private void label1_Click(object sender, EventArgs e)
        {
			this.Close();
        }
    }
}

