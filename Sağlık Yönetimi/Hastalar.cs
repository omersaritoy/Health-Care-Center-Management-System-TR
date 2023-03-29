using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sağlık_Yönetimi
{
    public partial class Hastalar : Form
    {
        Fonk Con;
        public Hastalar()
        {
            InitializeComponent();
            Con = new Fonk();
            HastaGoruntuleme();
        }
        private void HastaGoruntuleme()
        {
            string sorgu = "Select *from HastaTbl";
            HastaListDGV.DataSource= Con.GetData(sorgu);
        }
        private void KaydetBtn_Click(object sender, EventArgs e)
        {
            if (HaAdiTb.Text == "" || HaTelfTb.Text == "" || HaAddTb.Text == "" || HaCinsCb.SelectedIndex == -1)
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                string hasta = HaAdiTb.Text;
                string cinsiyet = HaCinsCb.SelectedItem.ToString(); 
                DateTime dogumT=DTTp.Value.Date;
                string telefon = HaTelfTb.Text;
                string Adres=HaAddTb.Text;
                string sorgu = "insert into HastaTbl values('{0}','{1}','{2}','{3}','{4}')";
                sorgu = string.Format(sorgu, hasta, cinsiyet, dogumT, telefon, Adres);
               // var sorgu2 = $"insert into HastaTbl values('{hasta}','{cinsiyet}','{dogumT}','{telefon}','{Adres}')";
                Con.SetData(sorgu);
                HastaGoruntuleme();
                MessageBox.Show("Hasta Eklendi!");
            }
        }

        private void GuncelleBtn_Click(object sender, EventArgs e)
        {
            if (HaAdiTb.Text == "" || HaTelfTb.Text == "" || HaAddTb.Text == "" || HaCinsCb.SelectedIndex == -1)
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                string hasta = HaAdiTb.Text;
                string cinsiyet = HaCinsCb.SelectedItem.ToString();
                DateTime dogumT = DTTp.Value.Date;
                string telefon = HaTelfTb.Text;
                string Adres = HaAddTb.Text;
                string sorgu = "Update HastaTbl set HaAdı='{0}',HaCin='{1}',HaDT='{2}',HaTel='{3}',HaAdr='{4}' where HaKod='{5}'";
                sorgu = string.Format(sorgu, hasta, cinsiyet, dogumT, telefon, Adres,current);
                // var sorgu2 = $"insert into HastaTbl values('{hasta}','{cinsiyet}','{dogumT}','{telefon}','{Adres}')";
                Con.SetData(sorgu);
                HastaGoruntuleme();
                Temizle();
                MessageBox.Show("Hasta Güncellendi!");
            }

        }

        private void guna2CirclePictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int current = 0;//anlık
        private void HastaListDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HaAdiTb.Text = HastaListDGV.SelectedRows[0].Cells[1].Value.ToString();
            HaCinsCb.SelectedItem = HastaListDGV.SelectedRows[0].Cells[2].Value.ToString();
            DTTp.Text = HastaListDGV.SelectedRows[0].Cells[3].Value.ToString();
            HaTelfTb.Text = HastaListDGV.SelectedRows[0].Cells[4].Value.ToString();
            HaAddTb.Text = HastaListDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (HaAddTb.Text == "")
            {
                current = 0;
            }
            else
            {
                current=Convert.ToInt32(HastaListDGV.SelectedRows[0].Cells[0].Value.ToString());
            }


        }

        private void SilBtn_Click(object sender, EventArgs e)
        {
            if (current==0)
            {
                MessageBox.Show("Hasta Seçin Lütfen!");
            }
            else
            {
                
                string sorgu = "Delete from HastaTbl where HaKod='{0}'";
                sorgu = string.Format(sorgu,current);
                // var sorgu2 = $"insert into HastaTbl values('{hasta}','{cinsiyet}','{dogumT}','{telefon}','{Adres}')";
                Con.SetData(sorgu);
                HastaGoruntuleme();
                Temizle();
                MessageBox.Show("Hasta Silindi!");
            }
        }
        private void Temizle()
        {
            HaAdiTb.Text = "";
            HaCinsCb.SelectedIndex = -1;
            HaTelfTb.Text = "";
            HaAddTb.Text = ""; 
        }

        private void guna2CirclePictureBox6_Click(object sender, EventArgs e)
        {
            Giris obj=new Giris();
            obj.Show();
            this.Hide();

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Hastalar obj=new Hastalar();
            obj.Show(); 
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            Testler obj=new Testler();
            obj.Show();
            this.Hide();
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            Teshis teshis = new Teshis();
            teshis.Show();
            this.Hide();

        }
    }
}
