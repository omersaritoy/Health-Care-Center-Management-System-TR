using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;

namespace Sağlık_Yönetimi
{
    public partial class Giris : Form
    {
        SqlConnection conn=new SqlConnection();//sqlle bağlantıyı sağlıyoruz
        sqlCon c=new sqlCon();//classı çağırıyoruz
        SqlCommand cmd=new SqlCommand();//sorgu
        DataTable dt=new DataTable();//sql tablosu

        public Giris()
        {
            InitializeComponent();
            conn = c.sql();
          
        }


        private void GirBtn_Click(object sender, EventArgs e)
        {
            string kullanici = KullaniciTb.Text;
            string sifre=SifreTb.Text;

            if (KullaniciTb.Text == "" || SifreTb.Text == "")
                MessageBox.Show("Eksik Bilgi");

            else
            {
                conn.Open();
                cmd=new SqlCommand("select * from AdminTbl where AdminKullanıcıAdi='"+KullaniciTb.Text+"' and Şifre='"+SifreTb.Text+"'",conn);
                SqlDataAdapter sda=new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    MessageBox.Show("Giriş Başarılı!");
                    Hastalar hastalar= new Hastalar();  
                    hastalar.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Giriş Başarısız!");
                }
                conn.Close();
            }





        }

        private void guna2CirclePictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
