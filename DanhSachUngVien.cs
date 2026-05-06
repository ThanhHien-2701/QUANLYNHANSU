using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QUANLYNHANSU
{
    public partial class DanhSachUngVien : Form
    {
        private string maDTD;
        private string ngayTao;
        private string nguoiTao;
        public string PdfTempFile { get; private set; }

        public DanhSachUngVien(string maDTD)
        {
            InitializeComponent();
            this.maDTD = maDTD;
            this.ngayTao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            this.nguoiTao = Session.TenNhanVien;
        }

        private void DanhSachUngVien_Load(object sender, EventArgs e)
        {
            LoadReport();
            GeneratePDF();
        }
        public byte[] ExportReportToPDF()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            string connectionString = @"Data Source=MAC-HIENLTT23\SQLEXPRESS;Initial Catalog=QUANLYNHANSU;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC sp_UngVienDat @MaDTD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDTD", maDTD);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                LocalReport lr = new LocalReport();
                lr.ReportPath = "DanhSachUngVien.rdlc";
                lr.DataSources.Clear();
                lr.DataSources.Add(new ReportDataSource("DataUV", dt));

                // THÊM PARAMETERS - ĐẢM BẢO KHÔNG NULL
                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("NgayTao", ngayTao ?? DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                    new ReportParameter("NguoiTao", nguoiTao ?? "")
                };
                lr.SetParameters(parameters);

                Warning[] warnings;
                string[] streams;
                string mimeType, encoding, filenameExtension;

                // Render PDF chuẩn (không deviceInfo lỗi)
                return lr.Render("PDF", null,
                    out mimeType, out encoding, out filenameExtension,
                    out streams, out warnings);
            }
        }
        public string GeneratePDF()
        {
            byte[] pdfBytes = ExportReportToPDF();

            PdfTempFile = Path.Combine(Path.GetTempPath(),
                $"DSUngVien_{maDTD}_{DateTime.Now:yyyyMMddHHmmss}.pdf");

            File.WriteAllBytes(PdfTempFile, pdfBytes);
            return PdfTempFile;
        }

        private void LoadReport()
        {
            string connectionString = @"Data Source=MAC-HIENLTT23\SQLEXPRESS;Initial Catalog=QUANLYNHANSU;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC sp_UngVienDat @MaDTD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDTD", maDTD);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Gắn dữ liệu vào report
                ReportDataSource rds = new ReportDataSource("DataUV", dt); // "DataSet1" phải khớp với trong file .rdlc

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.ReportPath = "DanhSachUngVien.rdlc"; // hoặc @"..\..\DanhSachUngVien.rdlc"
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
