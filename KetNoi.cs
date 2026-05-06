using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU
{
    internal class KetNoi
    {
        private string strcon = (@"Data Source=MAC-HIENLTT23\SQLEXPRESS;Initial Catalog=QUANLYNHANSU;Integrated Security=True;");
        public static SqlConnection sqlConn;
        public SqlConnection Connect()
        {
            sqlConn = new SqlConnection(strcon);
            sqlConn.Open();
            return sqlConn;
        }
        public SqlConnection Disconnect()
        {
            if (sqlConn.State == ConnectionState.Open)
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
            return sqlConn;
        }
    }
}
