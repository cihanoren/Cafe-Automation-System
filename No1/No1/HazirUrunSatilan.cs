using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace No1
{
    public partial class HazirUrunSatilan : Form
    {
        public HazirUrunSatilan()
        {
            InitializeComponent();
            dataGridView1.BackgroundColor = Color.Navy;
            dataGridView1.DefaultCellStyle.Font = new Font("Sans Serif", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Navy;

        }

        private void HazirUrunSatilan_Load(object sender, EventArgs e)
        {
            listele();
        }

        int urunid;
        float satisfiyati_1;


        private void listele()
        {

            DataTable dt = Veritabani.Listele("barhazırurunler_satilanurunhacmi", dataGridView1, "", "");

            // Veriyi urun kolonuna göre alfabetik sırala
            DataView dv = dt.DefaultView;
            if (dataGridView1.RowCount == 0)
            {
                // DataGridView boş


                dataGridView1.DataSource = dt;
            }
            else
            {
                // DataGridView dolu
                dv.Sort = "satilanurun ASC"; // veya "urun DESC" for descending order
                dt = dv.ToTable();

                dataGridView1.DataSource = dt;
            }
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["maliyetfarki"].Visible = false;





            label_gsoter();
            urunler_comboBox();
            DataGridViewAlfabetikSırala();

            kar_zarar();
        }


        private void label_gsoter()////
        {
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            
            Baglanti.baglanti.Open();
            try
            {
                SqlCommand karZarar = new SqlCommand("select sum(urunsatisindankalankar) from barhazırurunler_satilanurunhacmi ", Baglanti.baglanti);
                object kar = karZarar.ExecuteScalar();
                if (kar != DBNull.Value)
                {
                    float kar_ = Convert.ToSingle(kar);
                    label6.Text = string.Format("₺" + "{0:0.00} ", kar_);
                    label6.BackColor = Color.DarkSeaGreen;

                }


                SqlCommand ciro = new SqlCommand("select sum(satisadetciro) from barhazırurunler_satilanurunhacmi ", Baglanti.baglanti);
                object ciro_ = ciro.ExecuteScalar();
                if (ciro_ != DBNull.Value)
                {
                    float ciro_1 = Convert.ToSingle(ciro_);
                    label7.Text = string.Format("₺" + "{0:0.00} ", ciro_1);
                    label7.BackColor = Color.DarkSeaGreen;

                }


                SqlCommand toplam = new SqlCommand("select sum(satisadet) from barhazırurunler_satilanurunhacmi ", Baglanti.baglanti);
                object toplamo = toplam.ExecuteScalar();
                if (toplamo != DBNull.Value)
                {
                    float toplam_ = Convert.ToSingle(toplamo);
                    label8.Text = string.Format("₺" + "{0:0.00} ", toplam_);
                    label8.BackColor = Color.DarkSeaGreen;

                }



                SqlCommand mal = new SqlCommand("select sum(satisadet*maliyetfiyati) from barhazırurunler_satilanurunhacmi ", Baglanti.baglanti);
                object imal = mal.ExecuteScalar();
                if (imal != DBNull.Value)
                {
                    float islenmismal = Convert.ToSingle(imal);
                    label9.Text = string.Format("₺" + "{0:0.00} ", islenmismal);
                    label9.BackColor = Color.DarkSeaGreen;

                }
            }



            catch (Exception ex)
            {
                // Hata durumunda hata mesajını işleyebilirsiniz
                MessageBox.Show("Hata oluştu: " + ex.Message);
                label8.Text = string.Format("HATA !");
                label8.BackColor = Color.DarkRed;

                label9.Text = string.Format("HATA !");
                label9.BackColor = Color.DarkRed;

                label6.Text = string.Format("HATA !");
                label6.BackColor = Color.DarkRed;

                label7.Text = string.Format("HATA !");
                label7.BackColor = Color.DarkRed;
            }
            finally
            {
                Baglanti.baglanti.Close();
            }

        }





        private void kar_zarar()
        {
            // DataGridView'e özel bir sütun ekleyelim
            // Silinmesi istenen sütunun adı
            string columnName = "KAR ZARAR";
            string onerılen = "ONENRILEN SATIS";



            // DataGridView'da belirtilen adla bir sütun var mı kontrol et
            if (dataGridView1.Columns.Contains(columnName))
            {
                // Sütun varsa, kaldır
                dataGridView1.Columns.Remove(columnName);
            }
            if (dataGridView1.Columns.Contains(onerılen))
            {
                // Sütun varsa, kaldır
                dataGridView1.Columns.Remove(onerılen);
            }

            dataGridView1.Columns.Add("KAR ZARAR", "KAR ZARAR");
            dataGridView1.Columns.Add("ONENRILEN SATIS", "ONENRILEN SATIS");

            // Seçili satırların index'lerini alıyoruz
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int rowIndex = i;

                // Seçilen satırdaki 'satisfiyati' ve 'maliyetfiyati' değerlerini çekiyoruz
                float satisFiyati = 0;
                float maliyetFiyati = 0;

                if (!float.TryParse(dataGridView1.Rows[rowIndex].Cells["satisfiyati"].Value.ToString(), out satisFiyati) ||
                    !float.TryParse(dataGridView1.Rows[rowIndex].Cells["maliyetfiyati"].Value.ToString(), out maliyetFiyati))
                {
                    MessageBox.Show("Hata: Satış fiyatı veya maliyet fiyatı geçerli bir sayı değil.");
                    continue; // Hata olduğunda diğer satırları işlememek için continue kullanıyoruz
                }
                float satisfiyati = maliyetFiyati * 4;
                // Karlılık oranını hesapla
                float karliklikOrani = satisFiyati / maliyetFiyati;

                // Kar zarar oranını virgülden sonra iki basamak göstererek formatlayalım
                string formattedKarZararOrani = string.Format("%" + "{0:.##}", karliklikOrani*100);
                string yukariOkSimge = "⇧  ";

                string asagiOkEmoji = "⬇️  "; // Aşağı ok emojisi
                string yatayOkEmoji = "↔️  "; // Yatay ok emojisi


                // Kar zarar oranını hücreye yazdırıyoruz


                // Karlılık oranına göre hücrenin arka plan rengini ayarlayalım
                if (karliklikOrani >= 3.0f) // 300'ün yüzde cinsinden karşılığı 3.0 olacaktır
                {
                    // Hücrenin arka plan rengini yeşil yap
                    dataGridView1.Rows[rowIndex].Cells["KAR ZARAR"].Style.BackColor = Color.Green;
                    dataGridView1.Rows[rowIndex].Cells["KAR ZARAR"].Style.ForeColor = Color.White;

                    dataGridView1.Rows[rowIndex].Cells["KAR ZARAR"].Style.Font = new Font(dataGridView1.Font.FontFamily, 12f, FontStyle.Bold);

                    dataGridView1.Rows[rowIndex].Cells["KAR ZARAR"].Value = yukariOkSimge + formattedKarZararOrani;
                    // dataGridView1.Rows[rowIndex].Cells["ONENRILEN SATIS"].Value = satisfiyati;



                }
                else if (karliklikOrani >= 2.0f && karliklikOrani <= 3.0f) // 200 ve 300'ün yüzde cinsinden karşılığı 2.0 ve 3.0 olacaktır
                {
                    // Hücrenin arka plan rengini turuncu yap
                    dataGridView1.Rows[rowIndex].Cells["KAR ZARAR"].Style.BackColor = Color.Gray;
                    dataGridView1.Rows[rowIndex].Cells["KAR ZARAR"].Style.ForeColor = Color.White;
                    dataGridView1.Rows[rowIndex].Cells["KAR ZARAR"].Style.Font = new Font(dataGridView1.Font.FontFamily, 12f, FontStyle.Bold);

                    dataGridView1.Rows[rowIndex].Cells["KAR ZARAR"].Value = yatayOkEmoji + formattedKarZararOrani;
                    dataGridView1.Rows[rowIndex].Cells["ONENRILEN SATIS"].Value = satisfiyati;
                }
                else if (karliklikOrani < 2.0f) // 200'ün yüzde cinsinden karşılığı 2.0 olacaktır
                {
                    // Hücrenin arka plan rengini kırmızı yap
                    dataGridView1.Rows[rowIndex].Cells["KAR ZARAR"].Style.BackColor = Color.Red;
                    dataGridView1.Rows[rowIndex].Cells["KAR ZARAR"].Style.Font = new Font(dataGridView1.Font.FontFamily, 12f, FontStyle.Bold);

                    dataGridView1.Rows[rowIndex].Cells["KAR ZARAR"].Value = asagiOkEmoji + formattedKarZararOrani;
                    dataGridView1.Rows[rowIndex].Cells["ONENRILEN SATIS"].Value = satisfiyati;
                }

            }


        }



        private void DataGridViewAlfabetikSırala()
        {
            // DataGridView'in bağlı olduğu DataSource'ı DataTable olarak alıyoruz
            var dataSource = dataGridView1.DataSource as DataTable;

            // DataSource null değilse ve bir DataTable ise devam edin
            if (dataSource != null)
            {
                // DataTable'ı satır bazında alfabetik olarak sıralıyoruz
                var sortedData = dataSource.Rows.Cast<DataRow>()
                                    .OrderBy(row => row["satilanurun"]) // "urunadi" sütununa göre sıralama
                                    .ToList(); // List olarak alıyoruz

                // Eğer sıralanmış veri boş değilse
                if (sortedData.Any())
                {
                    // Sıralanmış verileri DataTable'a geri dönüştürme
                    DataTable sortedDataTable = sortedData.CopyToDataTable();


                }
                else
                {
                    // Eğer sıralanmış veri yoksa, DataGridView'i boşaltabilir veya başka bir işlem yapabilirsiniz.
                    dataGridView1.DataSource = null;
                }
            }
        }



        private void urunler_comboBox()
        {
            Baglanti.baglanti.Open();
            comboBox1.Items.Clear();

            SqlCommand goster = new SqlCommand("SELECT id, urunadi, alisfiyati FROM urunler ", Baglanti.baglanti);
            SqlDataReader reader = goster.ExecuteReader();

            comboBox1.DisplayMember = "Key"; // Görünen metni belirle
            comboBox1.ValueMember = "Value"; // Value olarak kullanılacak alanı belirle

            while (reader.Read())
            {
                string urunler = reader["urunadi"].ToString();
                int id = Convert.ToInt32(reader["id"]);


                // Her öğeyi eklerken bir KeyValuePair nesnesi olarak ekleyin
                comboBox1.Items.Add(new KeyValuePair<string, int>(urunler, id));
            }

            Baglanti.baglanti.Close();



        }








        private void cikisbtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> seciliurun = (KeyValuePair<string, int>)comboBox1.SelectedItem;
            urunid = seciliurun.Value;
            Baglanti.baglanti.Open();

            SqlCommand getir = new SqlCommand("SELECT alisfiyati FROM urunler WHERE id = @pid", Baglanti.baglanti);
            getir.Parameters.AddWithValue("@pid", urunid);

            // ExecuteScalar metodu ile tek bir değer döndürülür
            object maliyetFiyatiObject = getir.ExecuteScalar();

            Baglanti.baglanti.Close();

            // Dönen değeri float'a dönüştürerek maliyetFiyati değişkenine atayabilirsiniz
            if (maliyetFiyatiObject != null && float.TryParse(maliyetFiyatiObject.ToString(), out float maliyetFiyati))
            {


                // Başarıyla dönüştürüldü
                satisfiyati_1 = maliyetFiyati * 4;
                string ali_cihan_meti = string.Format("{0:0.00}", maliyetFiyati);
                satisfiyatitb.Text = $"Önerilen satış fiyatı : {ali_cihan_meti}";
                // Metni gri yap
                satisfiyatitb.ForeColor = Color.Gray;

                // Metni soluk yap
                Font currentFont = satisfiyatitb.Font;
                satisfiyatitb.Font = new Font(currentFont.FontFamily, currentFont.Size, FontStyle.Italic);

            }
            else
            {
                // Dönüştürme başarısız oldu, bir hata var demektir
                // Uygun bir işlem yapılmalı, örneğin bir hata mesajı gösterilmeli
                MessageBox.Show("Veri çekerken sıkıntı yaşandı");
            }
        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(satisadetitb.Text) || string.IsNullOrWhiteSpace(satisfiyatitb.Text) || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> kontrol = new List<string>();
            Baglanti.baglanti.Open();
            string listele_1 = comboBox1.Text.ToString();
            SqlCommand cmd = new SqlCommand("SELECT satilanurun FROM barhazırurunler_satilanurunhacmi", Baglanti.baglanti);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                kontrol.Add(rdr.GetString(0));
            }

            Baglanti.baglanti.Close();
            if (!kontrol.Contains(listele_1))
            {



                float satisadet = 0, satisfiyati = 0, toplambirimmaliyet = 0;

                if (!float.TryParse(satisadetitb.Text, out satisadet) || !float.TryParse(this.satisfiyatitb.Text, out satisfiyati))
                {
                    MessageBox.Show("Lütfen geçerli bir sayı girin.123", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    Baglanti.baglanti.Open();
                    string listele = comboBox1.Text.ToString();
                    SqlCommand komut = new SqlCommand("SELECT alisfiyati FROM urunler WHERE id = @urunid", Baglanti.baglanti);
                    komut.Parameters.AddWithValue("@urunid", urunid);
                    object alisfiyatiObject = komut.ExecuteScalar();
                    if (alisfiyatiObject != null)
                    {
                        toplambirimmaliyet = Convert.ToSingle(alisfiyatiObject);
                    }
                    else
                    {
                        MessageBox.Show("Alış fiyatı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SqlCommand ekle = new SqlCommand("INSERT INTO barhazırurunler_satilanurunhacmi(satilanurun, satisadet, maliyetfiyati, satisfiyati, satisadetciro, urunsatisindankalankar, maliyetfarki) VALUES(@psatilanurun, @psatisadet, @pmaliyetfiyati, @psatisfiyati, @psatisadetciro, @purunsatisindankalankar, @psatisvemaliyetfarki)", Baglanti.baglanti);
                    ekle.Parameters.AddWithValue("@psatilanurun", comboBox1.Text);
                    ekle.Parameters.AddWithValue("@psatisadet", satisadet);
                    ekle.Parameters.AddWithValue("@pmaliyetfiyati", toplambirimmaliyet);
                    ekle.Parameters.AddWithValue("@psatisfiyati", satisfiyati);
                    ekle.Parameters.AddWithValue("@psatisadetciro", (satisadet * satisfiyati));
                    ekle.Parameters.AddWithValue("@purunsatisindankalankar", ((satisadet * satisfiyati) - (toplambirimmaliyet * satisadet)));
                    ekle.Parameters.AddWithValue("@psatisvemaliyetfarki", (satisfiyati - toplambirimmaliyet));

                    ekle.ExecuteNonQuery();
                    Baglanti.baglanti.Close();




                    satisadetitb.Text = "";
                    satisfiyatitb.Text = "";
                    comboBox1.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                // bunun hesabı nasıl yapılacakkkk
                /* Baglanti.baglanti.Open();
                float satisadet_1=0, maliyetfiyati_1=0, satisfiyati_1=0, satisadetciro_1=0, urunsatisindankalankar_1=0, satisvemaliyetfarki_1=0;
                string ad = comboBox1.Text.ToString();
                SqlCommand cmd_1 = new SqlCommand("SELECT satisadet, maliyetfiyati, satisfiyati, satisadetciro, urunsatisindankalankar, satisvemaliyetfarki FROM mutfak_satilanurunhacmi where satilanurun=@payni", Baglanti.baglanti);
                cmd_1.Parameters.AddWithValue("@payni", ad);

                SqlDataReader oku = cmd_1.ExecuteReader();
                while (oku.Read())
                {
                    satisadet_1 = oku.GetFloat(0);
                    maliyetfiyati_1 = oku.GetFloat(1);
                    satisfiyati_1=oku.GetFloat(2);
                    satisadetciro_1 = oku.GetFloat(3);
                    urunsatisindankalankar_1=oku.GetFloat(4);
                    satisvemaliyetfarki_1=oku.GetFloat(5);

                }

                Baglanti.baglanti.Close();
               */






                float satisadet = 0, satisfiyati = 0, toplambirimmaliyet = 0;

                if (!float.TryParse(satisadetitb.Text, out satisadet) || !float.TryParse(this.satisfiyatitb.Text, out satisfiyati))
                {
                    MessageBox.Show("Lütfen geçerli bir sayı girin.123", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    Baglanti.baglanti.Open();
                    string listele = comboBox1.Text.ToString();
                    SqlCommand komut = new SqlCommand("SELECT alisfiyati FROM urunler WHERE id = @urunid", Baglanti.baglanti);
                    komut.Parameters.AddWithValue("@urunid", urunid);
                    object alisfiyatiObject = komut.ExecuteScalar();
                    if (alisfiyatiObject != null)
                    {
                        toplambirimmaliyet = Convert.ToSingle(alisfiyatiObject);
                    }
                    else
                    {
                        MessageBox.Show("Alış fiyatı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SqlCommand ekle = new SqlCommand("UPDATE barhazırurunler_satilanurunhacmi SET satisadet = @psatisadet, maliyetfiyati = @pmaliyetfiyati, satisfiyati = @psatisfiyati, satisadetciro = @psatisadetciro, urunsatisindankalankar = @purunsatisindankalankar, maliyetfarki = @psatisvemaliyetfarki WHERE satilanurun = @psatilanurun", Baglanti.baglanti);
                    ekle.Parameters.AddWithValue("@urunid", urunid);
                    ekle.Parameters.AddWithValue("@psatilanurun", comboBox1.Text);
                    ekle.Parameters.AddWithValue("@psatisadet", satisadet);
                    ekle.Parameters.AddWithValue("@pmaliyetfiyati", toplambirimmaliyet);
                    ekle.Parameters.AddWithValue("@psatisfiyati", satisfiyati);
                    ekle.Parameters.AddWithValue("@psatisadetciro", (satisadet * satisfiyati));
                    ekle.Parameters.AddWithValue("@purunsatisindankalankar", ((satisadet * satisfiyati) - (toplambirimmaliyet * satisadet)));
                    ekle.Parameters.AddWithValue("@psatisvemaliyetfarki", (satisfiyati - toplambirimmaliyet));

                    ekle.ExecuteNonQuery();
                    Baglanti.baglanti.Close();




                    satisadetitb.Text = "";
                    satisfiyatitb.Text = "";
                    comboBox1.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }







            }
            listele();
        }

        private void satisadetitb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void satisfiyatitb_KeyPress(object sender, KeyPressEventArgs e)
        {

            System.Windows.Forms.TextBox tb = sender as System.Windows.Forms.TextBox;

            // Virgül (',') karakterinin yalnızca bir kez basılmasını ve sonrasında en fazla 2 basamak yazılmasını kontrol et
            if (e.KeyChar == ',' && tb.Text.Contains(","))
            {
                e.Handled = true; // İkinci virgülü engelle
            }
            else if (e.KeyChar == ',' || char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                // Virgül veya sayısal karakter veya kontrol karakteri (ör. Backspace) ise işlemi devam ettir
                if (e.KeyChar != ',' && tb.Text.Contains(",") && tb.Text.Substring(tb.Text.IndexOf(",")).Length >= 3 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Virgül sonrası 2 basamak sınırını aşarsa işlemi engelle
                }
                else
                {
                    e.Handled = false;
                }
            }
            else
            {
                e.Handled = true; // Yukarıdaki koşullar sağlanmazsa, girdiyi engelle
            }

        }

        private void satisfiyatitb_Click(object sender, EventArgs e)
        {
            satisfiyatitb.Text = "";
            satisfiyatitb.ForeColor = Control.DefaultForeColor;



            satisfiyatitb.Font = Control.DefaultFont;
        }

        private void silbt_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var seciliID = dataGridView1.SelectedRows[0].Cells["id"].Value;

                Veritabani.Sil("barhazırurunler_satilanurunhacmi", "id", seciliID, "id");

                // Silme işlemi başarılı olduysa DataGridView'i güncelle
                listele();
            }
            else
            {
                MessageBox.Show("Silinecek öge bulunamadı !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            listele();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
