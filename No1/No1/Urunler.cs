using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace No1
{
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
            // DataGridView özellikleri ayarlanıyor
            dataGridView1.BackgroundColor = Color.Navy;
            dataGridView1.DefaultCellStyle.Font = new Font("Sans Serif", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Navy;
        }
        private void InitializeDataGridView()
        {

        }

        private void listele()
        {
            



            DataTable dt = Veritabani.Listele("urunler", dataGridView1, "", "");


            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;






            DataGridViewAlfabetikSırala();
            dataGridView1.ClearSelection();
            urunaditb.Text = "";
            alisfiyatitb.Text = "";
            kgtb.Text = "";







        }

      




     
        private void Urunler_Load(object sender, EventArgs e)
        {
            listele();
        }


        private void kaydet_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(urunaditb.Text) || string.IsNullOrWhiteSpace(alisfiyatitb.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                try
                {
                    int sayac = 0;
                    if (string.IsNullOrWhiteSpace(urunaditb.Text) || string.IsNullOrWhiteSpace(alisfiyatitb.Text))

                    {
                        var seciliID = dataGridView1.SelectedRows[0].Cells["id"].Value;

                        MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Baglanti.baglanti.Open();
                        SqlCommand komut = new SqlCommand("SELECT id FROM urunler WHERE id = @purunid", Baglanti.baglanti);
                        komut.Parameters.AddWithValue("@purunid", seciliID );
                        object alisfiyatiObject = komut.ExecuteScalar();
                    }
                    else
                    {
                        Baglanti.baglanti.Open();
                        string urunadi = urunaditb.Text.Trim();

                        SqlCommand denetle = new SqlCommand("SELECT urunadi, alisfiyati, stok FROM urunler WHERE urunadi = @urunadi", Baglanti.baglanti);
                        denetle.Parameters.AddWithValue("@urunadi", urunadi);
                        SqlDataReader oku = denetle.ExecuteReader();
                        sayac++;
                        if (oku.HasRows)
                        {
                            DialogResult result = MessageBox.Show("Bu ürün zaten mevcut " +
                                "(diğer sayfalarda bu ürünü güncelleyin)", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                            if (result == DialogResult.OK)
                            {
                                oku.Read(); // İlk satırı oku
                                float stok = Convert.ToSingle(oku["stok"]);
                                float galisfiyati = Convert.ToSingle(oku["alisfiyati"]);

                                Baglanti.baglanti.Close();
                                float alisFiyati;
                                if (float.TryParse(alisfiyatitb.Text, out alisFiyati))
                                {
                                    float kg;

                                    if (float.TryParse(kgtb.Text, out kg) && kg > 0)
                                    {                                       
                                        
                                        float yeniStok = stok + kg;

                                        float sonuc = ((alisFiyati + (galisfiyati)) / yeniStok ) ;

                                        Baglanti.baglanti.Open();
                                        SqlCommand ekle = new SqlCommand("UPDATE urunler SET stok = @stok ,alisfiyati= @alisfiyati WHERE urunadi = @urunadi", Baglanti.baglanti);
                                        ekle.Parameters.AddWithValue("@urunadi", urunadi);
                                        ekle.Parameters.AddWithValue("@stok", yeniStok);
                                        ekle.Parameters.AddWithValue("@alisfiyati", sonuc);
                                        ekle.ExecuteNonQuery();

                                        Baglanti.baglanti.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Kilo işleminde hatalı bir işlem yaptınız ");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Çevirme sırasında bir takım hatalar meydana geldi");
                                }
                                }
                        }
                        else
                        {
                            float alisFiyati;
                            if (float.TryParse(alisfiyatitb.Text, out alisFiyati))
                            {
                                float kg;
                                if (float.TryParse(kgtb.Text, out kg) && kg > 0)
                                {
                                    Baglanti.baglanti.Close();

                                    Baglanti.baglanti.Open();
                                    float sonuc = alisFiyati / kg;

                                    SqlCommand ekle = new SqlCommand("INSERT INTO urunler(urunadi, alisfiyati, stok) VALUES(@urunadi, @alisfiyati, @stok)", Baglanti.baglanti);
                                    ekle.Parameters.AddWithValue("@urunadi", urunadi);
                                    ekle.Parameters.AddWithValue("@alisfiyati", sonuc);
                                    ekle.Parameters.AddWithValue("@stok", kg);
                                    ekle.ExecuteNonQuery();

                                    Baglanti.baglanti.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Kilo işleminde hatalı bir işlem yaptınız ");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Çevirme sırasında bir takım hatalar meydana geldi");
                            }
                        }

                        Baglanti.baglanti.Close();
                        urunaditb.Clear();
                        alisfiyatitb.Clear();
                        kgtb.Clear();
                        listele();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }


           
            private void silbtn_Click_1(object sender, EventArgs e)
        {



         



            if (dataGridView1.SelectedRows.Count > 0)
            {
                

                var seciliID = dataGridView1.SelectedRows[0].Cells["urunadi"].Value;

                Veritabani.Sil("urunler", "urunadi", seciliID, "urunadi");

                // Silme işlemi başarılı olduysa DataGridView'i güncelle
                listele();

            }
            else
            {
                MessageBox.Show("Silinecek öge bulunamadı !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            listele();


        }




        private void DataGridViewAlfabetikSırala()
        {
            var dataSource = dataGridView1.DataSource as DataTable;

            // DataSource null değilse ve bir DataTable ise devam edin
            if (dataSource != null)
            {
                // DataTable'ı satır bazında alfabetik olarak sıralıyoruz
                var sortedData = dataSource.Rows.Cast<DataRow>()
                                    .OrderBy(row => row["urunadi"]) // "urunadi" sütununa göre sıralama
                                    .ToList(); // List olarak alıyoruz

                // Eğer sıralanmış veri boş değilse
                if (sortedData.Any())
                {
                    // Sıralanmış verileri DataTable'a geri dönüştürme
                    DataTable sortedDataTable = sortedData.CopyToDataTable();

                    // DataGridView'e yeniden bağlama
                    dataGridView1.DataSource = sortedDataTable;
                }
                else
                {
                    // Eğer sıralanmış veri yoksa, DataGridView'i boşaltabilir veya başka bir işlem yapabilirsiniz.
                    dataGridView1.DataSource = null;
                }
            }


        }








        private void Cikis_Click_1(object sender, EventArgs e)
        {
            
            this.Close();
         
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                
                // Alış fiyatı hücresinin değerini al
                var alisFiyatiCellValue = dataGridView1.Rows[selectedRowIndex].Cells[1].Value;
                urunaditb.Text = alisFiyatiCellValue != null ? alisFiyatiCellValue.ToString() : "";


                // Stok hücresinin değerini al
                var stokCellValue =dataGridView1.Rows[selectedRowIndex].Cells[2].Value;
                alisfiyatitb.Text = stokCellValue != null ? stokCellValue.ToString() : "";

                var gramCellValue = dataGridView1.Rows[selectedRowIndex].Cells[3].Value;
                kgtb.Text = gramCellValue != null ? gramCellValue.ToString() : "";



            


            }
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void alisfiyatitb_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void urunaditb_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void alisfiyatitb_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = true; // Diğer tüm karakterleri engelle
            }
        }




        private void kgtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void kgtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox tb = sender as System.Windows.Forms.TextBox;

            // Virgül (',') karakterinin yalnızca bir kez basılmasını ve sonrasında en fazla 3 basamak yazılmasını kontrol et
            if (e.KeyChar == ',' && tb.Text.Contains(","))
            {
                e.Handled = true; // İkinci virgülü engelle
            }
            else if (e.KeyChar == ',' || char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                // Virgül veya sayısal karakter veya kontrol karakteri (ör. Backspace) ise işlemi devam ettir
                if (e.KeyChar != ',' && tb.Text.Contains(",") && tb.Text.Substring(tb.Text.IndexOf(",")).Length >= 4 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Virgül sonrası 3 basamak sınırını aşarsa işlemi engelle
                }
                else
                {
                    e.Handled = false;
                }
            }
            else
            {
                e.Handled = true; // Diğer tüm karakterleri engelle
            }

        }

        private void urunaditb_HideSelectionChanged(object sender, EventArgs e)
        {

        }

     
        private void arabtn_Click(object sender, EventArgs e)
        {
            string urun = textBox2.Text;
            if (urun != "")
            {
                DataTable dataTable = Veritabani.VeriGetir("urunler", "urunadi", "urunadi", urun, "urunadi,alisfiyati,stok");

                dataGridView1.DataSource = dataTable;
            }
            else
            {
                listele();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
