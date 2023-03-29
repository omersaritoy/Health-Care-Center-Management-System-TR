using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sağlık_Yönetimi
{
    internal class Fonk
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConStr;

        public Fonk()
        {
            
            ConStr = @"Server=.\SQLEXPRESS;Database=SaglikYonetimiDB;Trusted_Connection=True";
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;

        }
 
        public DataTable GetData(string sorgu)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(sorgu, Con);
            sda.Fill(dt);
            return dt;
        }

        public int SetData(string sorgu)
        {
            int Cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Cmd.CommandText = sorgu;
            Cnt=Cmd.ExecuteNonQuery();
            Con.Close();
            return Cnt;

        }

    }
}
