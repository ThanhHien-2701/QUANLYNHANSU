using Microsoft.Reporting.WinForms;
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
    public partial class DSNhanVien : Form
    {
        private string ngayTao;
        private string nguoiTao;
        // ==================== AUTO RESIZE ====================
        /*Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        Rectangle originalFormSize;*/
        // =====================================================
        public DSNhanVien()
        {
            InitializeComponent();
            this.ngayTao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            this.nguoiTao = Session.TenNhanVien;
            // Đặt ReportViewer tự động full màn hình
            reportViewer1.Dock = DockStyle.Fill;


        }
        public DSNhanVien(string ngayTao, string nguoiTao)
        {
            InitializeComponent();
            this.ngayTao = ngayTao;
            this.nguoiTao = nguoiTao;
            reportViewer1.Dock = DockStyle.Fill;
        }
        // ==================== AUTO RESIZE ====================
       /* private void StoreOriginalSizes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                //originalControlBounds[c] = c.Bounds;
                if (!originalControlBounds.ContainsKey(c))
                {
                    originalControlBounds[c] = c.Bounds;
                }
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
                // KIỂM TRA trước khi sử dụng
                if (originalControlBounds.ContainsKey(c))
                {
                    Rectangle original = originalControlBounds[c];
                    c.SetBounds(
                        (int)(original.X * xRatio),
                        (int)(original.Y * yRatio),
                        (int)(original.Width * xRatio),
                        (int)(original.Height * yRatio)
                    );
                }

                if (c.Controls.Count > 0)
                    ResizeAllControls(c);
            }
        }

        private void Frm_Resize(object sender, EventArgs e)
        {
            ResizeAllControls(this);
        }
        // =====================================================*/
        private void DSNhanVien_Load(object sender, EventArgs e)
        {
            // ==================== AUTO RESIZE ====================
            /*originalFormSize = this.Bounds;
            StoreOriginalSizes(this);
            this.Resize += Frm_Resize;*/
            // =====================================================

            LoadReport();

        }
        private void LoadReport()
        {
            string connectionString = @"Data Source=MAC-HIENLTT23\SQLEXPRESS;Initial Catalog=QUANLYNHANSU;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC sp_ThongTinNhanVien";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Gắn dữ liệu vào report
                ReportDataSource rds = new ReportDataSource("DataSet1", dt); // "DataSet1" phải khớp với trong file .rdlc

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.ReportPath = "DSNhanVien.rdlc"; // hoặc @"..\..\DanhSachUngVien.rdlc"
                                                                          // *** THÊM PARAMETERS VÀO REPORTVIEWER ***
                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("NgayTao", ngayTao ?? DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                    new ReportParameter("NguoiTao", nguoiTao ?? "")
                };
                reportViewer1.LocalReport.SetParameters(parameters);

                reportViewer1.RefreshReport();
            }
        }
    }
}
