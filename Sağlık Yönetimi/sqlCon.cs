using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sağlık_Yönetimi
{
    internal class sqlCon
    {
        public SqlConnection sql()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=.\SQLEXPRESS;Database=SaglikYonetimiDB;Trusted_Connection=True";
            return con;
        }
    }
}
