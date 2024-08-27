using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace No1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void kullancicomboBax()
        {
            try
            {
                Baglanti.baglanti.Open();
                SqlCommand goster = new SqlCommand("SELECT kullaniciAdi FROM kullanici_giris WHERE kullaniciAdi <> 'admin'", Baglanti.baglanti);
                SqlDataReader reader = goster.ExecuteReader();

                while (reader.Read())
                {
                    string adi = reader["kullaniciAdi"].ToString();
                    comboBox1.Items.Add(adi);
                }
            }
            catch (Exception ex)
            {
                // Hata işleme: hatayı loglayabilir veya kullanıcıya mesaj gösterebilirsiniz
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            finally
            {
                if (Baglanti.baglanti.State == System.Data.ConnectionState.Open)
                {
                    Baglanti.baglanti.Close();
                }
            }


        }
        private bool giriskontrol(string kullanciadi,string sifre)
        {
            bool dogrulandı = false;
            Baglanti.baglanti.Open();
            SqlCommand kontrol = new SqlCommand("select count (*) from kullanici_giris where kullaniciAdi=@pkullaniciAdi and sifre=@psifre", Baglanti.baglanti);
            kontrol.Parameters.AddWithValue("@pkullaniciAdi", kullanciadi);
            kontrol.Parameters.AddWithValue("@psifre", sifre);
            int kullancisayisi = (int)kontrol.ExecuteScalar();
            if (kullancisayisi > 0)
            {
                dogrulandı=true;

            }
            Baglanti.baglanti.Close();
            return dogrulandı;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            string kulaniciadi = comboBox1.Text;
            string sifre = sifretb.Text;
            if (giriskontrol(kulaniciadi,sifre))
            {
                Anamenu anamenu = new Anamenu();
                anamenu.ShowDialog();
                this.Close();
            }
            else if(kulaniciadi=="admin"&& sifre== "AcM26.27.24")
            {
                Anamenu anamenu = new Anamenu();
                anamenu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullancı adı veya şifre hatalıdır");
            }
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cikisbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sifretb_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kullancicomboBax();
        }
    }
}
