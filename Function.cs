using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    internal class Function
    {
        public static string chuoiketnoi = @"Data Source=MAC-HIENLTT23\SQLEXPRESS;Initial Catalog=QUANLYNHANSU;Integrated Security=True;TrustServerCertificate=True";

        public static int ExecuteNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection sqlConn = new SqlConnection(chuoiketnoi))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                data = cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
            return data;
        }
        public static DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(chuoiketnoi))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                sqlConn.Close();
            }
            return dt;
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            using (SqlConnection sqlConn = new SqlConnection(chuoiketnoi))
            {
                sqlConn.Open();
                using (SqlDataAdapter dap = new SqlDataAdapter(sql, sqlConn))
                {
                    DataTable table = new DataTable();
                    dap.Fill(table);

                    cbo.DataSource = table;          // Gán DataTable làm nguồn dữ liệu cho ComboBox
                    cbo.ValueMember = ma;            // Cột giá trị của ComboBox (thường là mã hoặc ID)
                    cbo.DisplayMember = ten;         // Cột hiển thị của ComboBox (thường là tên hoặc mô tả)
                }
            }
        }
        public static string TaoMaMoi(string ID, string TableName, string prefix, string ma, int numberLength)
        {
            // Loại bỏ dấu cách trong selectedCategory
            string selectedCategory = prefix + ma.Trim();

            string lastCode = string.Empty;

            // Truy vấn cơ sở dữ liệu để tìm mã lớn nhất hiện có với `selectedCategory`
            string sql = $"SELECT TOP 1 {ID} FROM {TableName} WHERE {ID} LIKE '{selectedCategory}%' ORDER BY {ID} DESC";

            using (SqlConnection sqlConn = new SqlConnection(chuoiketnoi))
            {
                sqlConn.Open();
                using (SqlCommand command = new SqlCommand(sql, sqlConn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Đọc mã lớn nhất nếu có
                        if (reader.Read())
                        {
                            lastCode = reader[ID].ToString();
                        }
                    }
                }
            }

            // Gọi hàm GenerateNextCode để tạo mã mới dựa trên mã lớn nhất
            return GenerateNextCode(lastCode, selectedCategory, numberLength);
        }

        //Tạo mã kế tiếp từ mã cuối
        public static string GenerateNextCode(string lastCode, string selectedCategory, int numberLength)
        {
            selectedCategory = selectedCategory.Trim();

            if (string.IsNullOrEmpty(lastCode))
            {
                // Tạo mã bắt đầu với phần số có độ dài tùy chỉnh
                return selectedCategory + new string('0', numberLength - 1) + "1";
            }

            // Tìm phần ký tự và phần số từ mã cuối cùng
            string categoryPart = lastCode.Substring(0, selectedCategory.Length).Trim();
            string numberPart = lastCode.Substring(selectedCategory.Length).Trim();

            if (int.TryParse(numberPart, out int lastNumber))
            {
                int newNumber = lastNumber + 1;

                // Đảm bảo phần số có đúng độ dài do người dùng quy định
                string newCode = categoryPart + newNumber.ToString("D" + numberLength);
                return newCode;
            }

            return string.Empty;
        }
        public static void RunSQL(string sql)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(chuoiketnoi))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(sql, sqlConn);
                    cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực thi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static bool CheckKey(string sql)
        {
            using (SqlConnection sqlConn = new SqlConnection(chuoiketnoi))
            {
                sqlConn.Open();
                SqlDataAdapter dap = new SqlDataAdapter(sql, sqlConn);
                DataTable table = new DataTable();
                dap.Fill(table);
                if (table.Rows.Count > 0)
                    return true;
                else return false;
            }
        }
        public class DBBackup
        {
            private string connectionString;

            public DBBackup()
            {
                // LUÔN lấy chuỗi kết nối từ Function.chuoiketnoi
                connectionString = @"Data Source=MAC-HIENLTT23\SQLEXPRESS;
                             Initial Catalog=master;
                             Integrated Security=True;
                             TrustServerCertificate=True";
            }
        }
    }
}
