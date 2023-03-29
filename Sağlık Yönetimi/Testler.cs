using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Sağlık_Yönetimi
{
    public partial class Testler : Form
    {

        Fonk Con;
        public Testler()
        {
            InitializeComponent();
            Con=new Fonk();
            TestGoster();
        }
        private void TestGoster()
        {
            string sorgu = "Select *from TestTbl";
            TestListDGV.DataSource= Con.GetData(sorgu);
        }

        private void KaydetBtn_Click(object sender, EventArgs e)
        {
            if (TAdiTb.Text == "" || TMaliyetTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                string TsAdi = TAdiTb.Text;
                int maliyet = Convert.ToInt32(TMaliyetTb.Text);
                string sorgu = "insert into TestTbl values('{0}','{1}')";
                sorgu = string.Format(sorgu, TsAdi, maliyet);
                // var sorgu2 = $"insert into HastaTbl values('{hasta}','{cinsiyet}','{dogumT}','{telefon}','{Adres}')";
                Con.SetData(sorgu);
                TestGoster();
                MessageBox.Show("Test Eklendi!");
            }
        }
        private void Temizle()
        {
            TAdiTb.Text = "";
            TMaliyetTb.Text = "";

        }

        private void guna2CirclePictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int current = 0;
        private void TestListDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TAdiTb.Text = TestListDGV.SelectedRows[0].Cells[1].Value.ToString();
            TMaliyetTb.Text = TestListDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (TAdiTb.Text == "")
            {
                current = 0;
            }
            else
            {
                current = Convert.ToInt32(TestListDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void GuncelleBtn_Click(object sender, EventArgs e)
        {
            if (TAdiTb.Text == "" || TMaliyetTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                string TeAdi = TAdiTb.Text;
                int TeMaliyet = Convert.ToInt32(TMaliyetTb.Text);
                string sorgu = "Update TestTbl set TestAdı='{0}',TestMaliyet={1} where TestNo={2}";
                sorgu = string.Format(sorgu, TeAdi,TeMaliyet, current);
                Con.SetData(sorgu);
                TestGoster();
                Temizle();
                MessageBox.Show("Test Güncellendi!");
            }
        }

        private void SilBtn_Click(object sender, EventArgs e)
        {
            if (current==0)
            {
                MessageBox.Show("Lütfen Sileceğiniz Testi Seçiniz!");
            }
            else
            {

                string sorgu = "Delete from TestTbl where TestNo={0}";
                sorgu = string.Format(sorgu, current);
                Con.SetData(sorgu);
                TestGoster();
                Temizle();
                MessageBox.Show("Test Silindi!");
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Hastalar obj = new Hastalar();
            obj.Show();
            this.Hide();
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            Testler obj = new Testler();
            obj.Show();
            this.Hide();
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            Teshis teshis = new Teshis();
            teshis.Show();
            this.Hide();
        }

        private void guna2CirclePictureBox6_Click(object sender, EventArgs e)
        {
            Giris obj = new Giris();
            obj.Show();
            this.Hide();
        }
    }
}
