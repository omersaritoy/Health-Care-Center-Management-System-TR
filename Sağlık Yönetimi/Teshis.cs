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
    public partial class Teshis : Form
    {
        Fonk Con;
        public Teshis()
        {
            InitializeComponent();
            Con= new Fonk();
            HastaGoster();
            TestGoster();
            TeshisGoster();

        }
        private void MaliyetGoster()
        {
            string sorgu = "Select *from TestTbl Where TestNo={0}";
            sorgu=string.Format(sorgu,TestCb.SelectedValue.ToString());
            foreach (DataRow item in Con.GetData(sorgu).Rows)
            {
                MaliyetTb.Text = item["TestMaliyet"].ToString();
            }


        }
        private void HastaGoster()
        {
            string sorgu = "Select *from HastaTbl";
            HastaCb.DisplayMember=Con.GetData(sorgu).Columns["HaAdı"].ToString();
            HastaCb.ValueMember = Con.GetData(sorgu).Columns["HaKod"].ToString();
            HastaCb.DataSource = Con.GetData(sorgu);
        }
        private void TestGoster()
        {
            string sorgu = "Select *from TestTbl";
            TestCb.DisplayMember = Con.GetData(sorgu).Columns["TestAdı"].ToString();
            TestCb.ValueMember = Con.GetData(sorgu).Columns["TestNo"].ToString();
            TestCb.DataSource = Con.GetData(sorgu);
        }
        private void KaydetBtn_Click(object sender, EventArgs e)
        {
            if (HastaCb.SelectedIndex== -1 || MaliyetTb.Text=="" || SonucTb.Text== "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                string Tarihi = TeshisTarih.Value.Date.ToString();
                int Hasta= Convert.ToInt32(HastaCb.SelectedValue.ToString());
                int Test = Convert.ToInt32(TestCb.SelectedValue.ToString());
                int maliyet = Convert.ToInt32(MaliyetTb.Text);
                string sonuc = SonucTb.Text;
                string sorgu = "insert into TeshisTbl values('{0}',{1},{2},{3},'{4}')";
                sorgu = string.Format(sorgu, Tarihi, Hasta, Test, maliyet, sonuc);
                
                Con.SetData(sorgu);
                TeshisGoster();
                Temizle();
                MessageBox.Show("Teşhis Eklendi!");
            }
        }
        private void TeshisGoster()
        {
            string sorgu = "Select *from TeshisTbl";
            TeshisListDGV.DataSource=Con.GetData(sorgu);
        }
        private void Temizle()
        {
            MaliyetTb.Text = "";
            SonucTb.Text = "";
            TestCb.SelectedIndex = -1;
            HastaCb.SelectedIndex = -1;
        }

        private void guna2CirclePictureBox7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TestCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MaliyetGoster();
        }
        int current = 0;
        private void TeshisListDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TeshisTarih.Text = TeshisListDGV.SelectedRows[0].Cells[1].Value.ToString();
            HastaCb.SelectedItem = TeshisListDGV.SelectedRows[0].Cells[2].Value.ToString();
            TestCb.SelectedItem= TeshisListDGV.SelectedRows[0].Cells[3].Value.ToString();
            MaliyetTb.Text = TeshisListDGV.SelectedRows[0].Cells[4].Value.ToString();
            SonucTb.Text = TeshisListDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (MaliyetTb.Text == "")
            {
                current = 0;
            }
            else
            {
                current = Convert.ToInt32(TeshisListDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void SilBtn_Click(object sender, EventArgs e)
        {
            if (current==0)
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {

                string sonuc = SonucTb.Text;
                string sorgu = "Delete from  TeshisTbl where TeshNo={0}";
                sorgu = string.Format(sorgu, current);

                Con.SetData(sorgu);
                TeshisGoster();
                Temizle();
                MessageBox.Show("Teşhis Silindi!");
            }
        }

        private void GuncelleBtn_Click(object sender, EventArgs e)
        {
            if (HastaCb.SelectedIndex == -1 || MaliyetTb.Text == "" || SonucTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                string Tarihi = TeshisTarih.Value.Date.ToString();
                int Hasta = Convert.ToInt32(HastaCb.SelectedValue.ToString());
                int Test = Convert.ToInt32(TestCb.SelectedValue.ToString());
                int maliyet = Convert.ToInt32(MaliyetTb.Text);
                string sonuc = SonucTb.Text;
                string sorgu = "Update TeshisTbl set TeshTarih='{0}',Hasta={1},Test={2},Maliyet={3},Sonuc='{4}' where TeshNo={5}";
                sorgu = string.Format(sorgu, Tarihi, Hasta, Test, maliyet, sonuc,current);

                Con.SetData(sorgu);
                TeshisGoster();
                Temizle();
                MessageBox.Show("Teşhis Guncellendi!");
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
