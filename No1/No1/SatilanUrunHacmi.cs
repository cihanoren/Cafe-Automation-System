using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace No1
{
    public partial class SatilanUrunHacmi : Form
    {
        public SatilanUrunHacmi()
        {
            InitializeComponent();
        }

        private void SatilanUrunHacmi_Load(object sender, EventArgs e)
        {
            label_gsoter();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mutfak_Click(object sender, EventArgs e)
        {
            MutfakSatilan mutfakSatilan = new MutfakSatilan();
            mutfakSatilan.ShowDialog();
        }

        private void bar_Click(object sender, EventArgs e)
        {
            BarSatilan barSatilan = new BarSatilan();
            barSatilan.ShowDialog();
        }

        private void hazırurun_Click(object sender, EventArgs e)
        {
            HazirUrunSatilan hazirUrunSatilan = new HazirUrunSatilan();
            hazirUrunSatilan.ShowDialog();
        }

        private void cikisbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void label_gsoter()
        {
            label11.Text = "";
            label10.Text = "";
            label8.Text = "";
            label9.Text = "";
            float kar_=0, ciro_1=0, islenmismal=0, toplam_=0;

            Baglanti.baglanti.Open();
            try
            {

                {//bar satilan
                    SqlCommand karZarar = new SqlCommand("select sum(urunsatisindankalankar) from bar_satilanurunhacmi ", Baglanti.baglanti);
                    object kar = karZarar.ExecuteScalar();
                    if (kar != DBNull.Value)
                    {
                        kar_ += Convert.ToSingle(kar);


                    }


                    SqlCommand ciro = new SqlCommand("select sum(satisadetciro) from bar_satilanurunhacmi ", Baglanti.baglanti);
                    object ciro_ = ciro.ExecuteScalar();
                    if (ciro_ != DBNull.Value)
                    {
                        ciro_1 += Convert.ToSingle(ciro_);


                    }


                    SqlCommand toplam = new SqlCommand("select sum(satisadet) from bar_satilanurunhacmi ", Baglanti.baglanti);
                    object toplamo = toplam.ExecuteScalar();
                    if (toplamo != DBNull.Value)
                    {
                        toplam_ = +Convert.ToSingle(toplamo);


                    }



                    SqlCommand mal = new SqlCommand("select sum(satisadet*maliyetfiyati) from bar_satilanurunhacmi ", Baglanti.baglanti);
                    object imal = mal.ExecuteScalar();
                    if (imal != DBNull.Value)
                    {
                        islenmismal += Convert.ToSingle(imal);


                    }

                }



                {//hazır urun satilan

                    SqlCommand karZarar = new SqlCommand("select sum(urunsatisindankalankar) from barhazırurunler_satilanurunhacmi ", Baglanti.baglanti);
                    object kar = karZarar.ExecuteScalar();
                    if (kar != DBNull.Value)
                    {
                        kar_ += Convert.ToSingle(kar);


                    }


                    SqlCommand ciro = new SqlCommand("select sum(satisadetciro) from barhazırurunler_satilanurunhacmi ", Baglanti.baglanti);
                    object ciro_ = ciro.ExecuteScalar();
                    if (ciro_ != DBNull.Value)
                    {
                        ciro_1 += Convert.ToSingle(ciro_);


                    }


                    SqlCommand toplam = new SqlCommand("select sum(satisadet) from barhazırurunler_satilanurunhacmi ", Baglanti.baglanti);
                    object toplamo = toplam.ExecuteScalar();
                    if (toplamo != DBNull.Value)
                    {
                        toplam_ += Convert.ToSingle(toplamo);


                    }



                    SqlCommand mal = new SqlCommand("select sum(satisadet*maliyetfiyati) from barhazırurunler_satilanurunhacmi ", Baglanti.baglanti);
                    object imal = mal.ExecuteScalar();
                    if (imal != DBNull.Value)
                    {
                        islenmismal += Convert.ToSingle(imal);


                    }

                }



                {// mutfak satılan


                    SqlCommand karZarar = new SqlCommand("select sum(urunsatisindankalankar) from mutfak_satilanurunhacmi ", Baglanti.baglanti);
                    object kar = karZarar.ExecuteScalar();
                    if (kar != DBNull.Value)
                    {
                        kar_ += Convert.ToSingle(kar);


                    }


                    SqlCommand ciro = new SqlCommand("select sum(satisadetciro) from mutfak_satilanurunhacmi ", Baglanti.baglanti);
                    object ciro_ = ciro.ExecuteScalar();
                    if (ciro_ != DBNull.Value)
                    {
                        ciro_1 += Convert.ToSingle(ciro_);


                    }


                    SqlCommand toplam = new SqlCommand("select sum(satisadet) from mutfak_satilanurunhacmi ", Baglanti.baglanti);
                    object toplamo = toplam.ExecuteScalar();
                    if (toplamo != DBNull.Value)
                    {
                        toplam_ += Convert.ToSingle(toplamo);


                    }



                    SqlCommand mal = new SqlCommand("select sum(satisadet*maliyetfiyati) from mutfak_satilanurunhacmi ", Baglanti.baglanti);
                    object imal = mal.ExecuteScalar();
                    if (imal != DBNull.Value)
                    {
                        islenmismal += Convert.ToSingle(imal);


                    }





                }

                label8.Text = string.Format("₺" + "{0:0.00} ", kar_);
                label8.BackColor = Color.DarkSeaGreen;

                label9.Text = string.Format("₺" + "{0:0.00} ", ciro_1);
                label9.BackColor = Color.DarkSeaGreen;

                label10.Text = string.Format("₺" + "{0:0.00} ", toplam_);
                label10.BackColor = Color.DarkSeaGreen;

                label11.Text = string.Format("₺" + "{0:0.00} ", islenmismal);
                label11.BackColor = Color.DarkSeaGreen;
            }
            catch (Exception ex)
            {
                // Hata durumunda hata mesajını işleyebilirsiniz
                MessageBox.Show("Hata oluştu: " + ex.Message);
                label8.Text = string.Format("HATA !");
                label8.BackColor = Color.DarkRed;

                label9.Text = string.Format("HATA !");
                label9.BackColor = Color.DarkRed;

                label10.Text = string.Format("HATA !");
                label10.BackColor = Color.DarkRed;

                label11.Text = string.Format("HATA !");
                label11.BackColor = Color.DarkRed;
            }
            finally
            {
                Baglanti.baglanti.Close();
            }





            

        }





        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
