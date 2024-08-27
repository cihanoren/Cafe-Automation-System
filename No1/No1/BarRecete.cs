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
    public partial class BarRecete : Form
    {
        public BarRecete()
        {
            InitializeComponent();
            dataGridView1.BackgroundColor = Color.Navy;
            dataGridView1.DefaultCellStyle.Font = new Font("Sans Serif", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Navy;
        }
        float alisfiyati;
        int urunid;
        private void DataGridViewAlfabetikSırala()
        {
           



            var dataSource = dataGridView1.DataSource as DataTable;

            // DataSource null değilse ve bir DataTable ise devam edin
            if (dataSource != null)
            {
                // DataTable'ı satır bazında alfabetik olarak sıralıyoruz
                var sortedData = dataSource.Rows.Cast<DataRow>()
                                    .OrderBy(row => row["menu"]) // "urunadi" sütununa göre sıralama
                                    .ToList(); // List olarak alıyoruz

                // Eğer sıralanmış veri boş değilse
                if (sortedData.Any())
                {
                    // Sıralanmış verileri DataTable'a geri dönüştürme
                    DataTable sortedDataTable = sortedData.CopyToDataTable();

                    // DataGridView'e yeniden bağlama
                    dataGridView1.DataSource = sortedDataTable;
                    var col = new DataGridViewMergedTextBoxColumn();

                    const string field = "menu";

                    col.HeaderText = field;
                    col.Name = field;
                    col.DataPropertyName = field;

                    int colidx = dataGridView1.Columns[field].Index;
                    dataGridView1.Columns.Remove(field);
                    dataGridView1.Columns.Insert(colidx, col);
                }
                else
                {
                    // Eğer sıralanmış veri yoksa, DataGridView'i boşaltabilir veya başka bir işlem yapabilirsiniz.
                    dataGridView1.DataSource = null;
                }
            }



        }

       
        private float ToplamMalzemeFiyati(string menuAdi)
        {
            float toplamMaliyet = 0;
            Baglanti.baglanti.Open();
            string query = "SELECT SUM(birimmaliyet) FROM bar_recete WHERE menu = @menuAdi";
            SqlCommand command = new SqlCommand(query, Baglanti.baglanti);
            command.Parameters.AddWithValue("@menuAdi", menuAdi);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value && float.TryParse(result.ToString(), out toplamMaliyet))
            {
                Console.WriteLine(toplamMaliyet);
            }
            Baglanti.baglanti.Close();
            return toplamMaliyet;
        }

        private void musteriler_comboBox()
        {
            Baglanti.baglanti.Open();

            SqlCommand goster = new SqlCommand("SELECT id, urunadi,alisfiyati FROM urunler", Baglanti.baglanti);
            SqlDataReader reader = goster.ExecuteReader();

            // ComboBox'a veri ekler
            comboBox1.Items.Clear(); // Önce ComboBox'ı temizle
            comboBox1.DisplayMember = "Key"; // Görünen metni belirle
            comboBox1.ValueMember = "Value"; // Value olarak kullanılacak alanı belirle

            while (reader.Read())
            {
                string urunler = reader["urunadi"].ToString();

                string id = reader["id"].ToString();


                // Her öğeyi eklerken bir KeyValuePair nesnesi olarak ekleyin
                comboBox1.Items.Add(new KeyValuePair<string, int>(urunler, int.Parse(id)));
            }

            Baglanti.baglanti.Close();


        }

        private void listele()
        {

            DataTable dt = Veritabani.Listele("bar_recete", dataGridView1, "", "");

            // Veriyi menu kolonuna göre alfabetik sırala
            DataView dv = dt.DefaultView;
            if (dataGridView1.RowCount == 0)
            {
                // DataGridView boş


                dataGridView1.DataSource = dt;
            }
            else
            {
                // DataGridView dolu
                dv.Sort = "menu ASC"; // veya "menu DESC" for descending order
                dt = dv.ToTable();

                dataGridView1.DataSource = dt;
            }
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["alisfiyati"].Visible = false;
            dataGridView1.Columns["birimmaliyet"].Visible = false;
            dataGridView1.Columns["binlikkullanim"].Visible = false;

            DataGridViewAlfabetikSırala();
            

            musteriler_comboBox();
            dataGridView1.ClearSelection();
            textBox2.Text = "";            
            menuaditb.Text = "";
            


        }

        private bool Varmı(string menuadi, string urunadi)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                // Satırın null olmadığını ve hücre indekslerinin geçerli olup olmadığını kontrol edin
                if (dataGridView1.Rows[i] != null && dataGridView1.Rows[i].Cells.Count > 1 && dataGridView1.Rows[i].Cells[1].Value != null)
                {
                    var cell1 = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (cell1 == menuadi)
                    {
                        for (int j = i; j < dataGridView1.Rows.Count; j++)
                        {
                            // Satırın null olmadığını ve hücre indekslerinin geçerli olup olmadığını kontrol edin
                            if (dataGridView1.Rows[j] != null && dataGridView1.Rows[j].Cells.Count > 2 && dataGridView1.Rows[j].Cells[2].Value != null)
                            {
                                var cell2 = dataGridView1.Rows[j].Cells[2].Value.ToString();

                                if (cell2 == urunadi)
                                {
                                    return true; // Eşleşme bulundu
                                }
                            }
                        }
                    }
                }
            }

            return false; // Eşleşme bulunamadı
        }



        




        private void silbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    // Seçilen satırın ID, maliyet ve menü adını al
                    int seciliID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                    float seciliMaliyet = Convert.ToSingle(dataGridView1.SelectedRows[0].Cells["birimmaliyet"].Value);
                    string menu = dataGridView1.SelectedRows[0].Cells["menu"].Value.ToString();
                    float yeniToplamMaliyet = ToplamMalzemeFiyati(menu);

                    // Veritabanından seçilen veriyi sil
                    Veritabani.Sil("bar_recete", "id", seciliID, "id");

                    // Yeni toplam maliyeti hesapla ve güncelle

                    float guncelToplamMaliyet = yeniToplamMaliyet - seciliMaliyet;

                    // Veritabanında toplam birim maliyeti güncelle
                    SqlCommand guncelleKomutu = new SqlCommand("UPDATE bar_recete SET toplammaliyet = @toplammaliyet WHERE menu = @menu", Baglanti.baglanti);
                    guncelleKomutu.Parameters.AddWithValue("@toplammaliyet", guncelToplamMaliyet);
                    guncelleKomutu.Parameters.AddWithValue("@menu", menu);

                    Baglanti.baglanti.Open();
                    guncelleKomutu.ExecuteNonQuery();

                    MessageBox.Show("Veri başarıyla silindi ve maliyet fiyatı düzenlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Baglanti.baglanti.Close();
                }

                // DataGridView'i güncelle
                listele();
            }


                

        }

        private void cikisbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                // Urün adı hücresinin değerini al
                var urunAdiCellValue = dataGridView1.Rows[selectedRowIndex].Cells["menu"].Value;
                menuaditb.Text = urunAdiCellValue != null ? urunAdiCellValue.ToString() : "";


                // Alış fiyatı hücresinin değerini al
                var alisFiyatiCellValue = dataGridView1.Rows[selectedRowIndex].Cells["urunadi"].Value;
                comboBox1.Text = alisFiyatiCellValue != null ? alisFiyatiCellValue.ToString() : "";


                // Stok hücresinin değerini al
                var stokCellValue = dataGridView1.Rows[selectedRowIndex].Cells["recetegrami"].Value;
                recetegramitb.Text = stokCellValue != null ? stokCellValue.ToString() : "";

                var gramCellValue = dataGridView1.Rows[selectedRowIndex].Cells["binlikkullanim"].Value;
                gramtb.Text = gramCellValue != null ? gramCellValue.ToString() : "";



            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarRecete_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> seciliurun = (KeyValuePair<string, int>)comboBox1.SelectedItem;
            urunid = seciliurun.Value;
        }

        private void recetegramitb_KeyPress(object sender, KeyPressEventArgs e)
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
                if (e.KeyChar != ',' && tb.Text.Contains(",") && tb.Text.Substring(tb.Text.IndexOf(",")).Length >= 4 && !char.IsControl(e.KeyChar))
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

        private void menuaditb_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void recetegramitb_TextChanged(object sender, EventArgs e)
        {

        }

        private void gramtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void kaydetbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(menuaditb.Text) || string.IsNullOrWhiteSpace(recetegramitb.Text) || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    float toplamFiyat = ToplamMalzemeFiyati(menuaditb.Text);
                    float birimmaliyet = 0, binlikh = 0;
                    Baglanti.baglanti.Open();
                    string listele = comboBox1.Text.ToString();
                    SqlCommand komut = new SqlCommand("SELECT alisfiyati FROM urunler WHERE id = @urunid", Baglanti.baglanti);
                    komut.Parameters.AddWithValue("@urunid", urunid);
                    object alisfiyatiObject = komut.ExecuteScalar();
                    if (alisfiyatiObject != null)
                    {
                        alisfiyati = Convert.ToSingle(alisfiyatiObject);
                    }
                    else
                    {
                        MessageBox.Show("Alış fiyatı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    SqlCommand ekle = new SqlCommand("INSERT INTO bar_recete(menu, urunadi, alisfiyati, recetegrami, binlikkullanim, birimmaliyet, toplammaliyet) VALUES(@pmenu, @purunadi, @palisfiyati, @precetegrami, @pbinlikkullanim, @pbirimmaliyet, @ptoplammaliyet)", Baglanti.baglanti);
                    ekle.Parameters.AddWithValue("@pmenu", menuaditb.Text);
                    ekle.Parameters.AddWithValue("@purunadi", comboBox1.Text);
                    ekle.Parameters.AddWithValue("@palisfiyati", alisfiyati);
                    ekle.Parameters.AddWithValue("@precetegrami", recetegramitb.Text);

                    //ekle.Parameters.AddWithValue("@pbinlikkullanim", 1000/recetegramitb.Text);





                    // sabah ekledim hatalıysa sil
                    float binlik;
                    if (float.TryParse(recetegramitb.Text, out binlik) && binlik != 0)
                    {
                        binlikh = 1000 / binlik;
                        ekle.Parameters.AddWithValue("@pbinlikkullanim", binlikh);

                    }
                    else
                    {
                        MessageBox.Show("1000g için kullanım değeri hatalı veya sıfır olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Varmı(menuaditb.Text, listele))
                    {

                        float seciliMaliyet = Convert.ToSingle(dataGridView1.SelectedRows[0].Cells["birimmaliyet"].Value);

                        // Mevcut malzeme güncelleniyor
                        SqlCommand guncelle = new SqlCommand("UPDATE bar_recete SET alisfiyati = @palisfiyati, recetegrami = @precetegrami, binlikkullanim = @pbinlikkullanim, birimmaliyet = @pbirimmaliyet, toplammaliyet = @ptoplammaliyet WHERE menu = @pmenu AND urunadi = @purunadi", Baglanti.baglanti);
                        guncelle.Parameters.AddWithValue("@pmenu", menuaditb.Text);
                        guncelle.Parameters.AddWithValue("@purunadi", comboBox1.Text);
                        guncelle.Parameters.AddWithValue("@palisfiyati", alisfiyati);
                        guncelle.Parameters.AddWithValue("@precetegrami", recetegramitb.Text);

                        
                        if (float.TryParse(recetegramitb.Text, out binlik) && binlik != 0)
                        {
                            binlikh = 1000 / binlik;
                            guncelle.Parameters.AddWithValue("@pbinlikkullanim", binlikh);
                        }
                        else
                        {
                            MessageBox.Show("1000g için kullanım değeri hatalı veya sıfır olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Baglanti.baglanti.Close();
                            return;
                        }

                        if (binlikh != 0)
                        {
                            birimmaliyet = alisfiyati / binlikh;
                            // Sadece yeni birimmaliyet ile toplam birim maliyeti güncelle
                            guncelle.Parameters.AddWithValue("@pbirimmaliyet", birimmaliyet);



                            guncelle.Parameters.AddWithValue("@ptoplammaliyet", (toplamFiyat + birimmaliyet) - seciliMaliyet); // Sadece yeni birimmaliyet ile güncelle
                        }
                        else
                        {
                            MessageBox.Show("Gram değeri hatalı veya sıfır olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Baglanti.baglanti.Close();
                            return;
                        }

                        guncelle.ExecuteNonQuery();


                        SqlCommand guncelleKomutu1 = new SqlCommand("UPDATE bar_recete SET toplammaliyet = @toplammaliyet WHERE menu = @menu", Baglanti.baglanti);
                        guncelleKomutu1.Parameters.AddWithValue("@toplammaliyet", (toplamFiyat + birimmaliyet) - seciliMaliyet);
                        guncelleKomutu1.Parameters.AddWithValue("@menu", menuaditb.Text);


                        guncelleKomutu1.ExecuteNonQuery();






                    }
                    else
                    {



                        if (binlikh != 0)
                        {
                            birimmaliyet = alisfiyati / binlikh;
                            ekle.Parameters.AddWithValue("@pbirimmaliyet", birimmaliyet);
                            ekle.Parameters.AddWithValue("@ptoplammaliyet", toplamFiyat + birimmaliyet);


                        }
                        else
                        {
                            MessageBox.Show("Gram değeri hatalı veya sıfır olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }







                        ekle.ExecuteNonQuery();
                        SqlCommand guncelleKomutu1 = new SqlCommand("UPDATE bar_recete SET toplammaliyet = @toplammaliyet WHERE menu = @menu", Baglanti.baglanti);
                        guncelleKomutu1.Parameters.AddWithValue("@toplammaliyet", (toplamFiyat + birimmaliyet));
                        guncelleKomutu1.Parameters.AddWithValue("@menu", menuaditb.Text);


                        guncelleKomutu1.ExecuteNonQuery();
                    }
                    Baglanti.baglanti.Close();
                    menuaditb.Clear();
                    gramtb.Clear();
                    recetegramitb.Clear();
                    comboBox1.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            listele();
        }

        
        private void Menu_Enter(object sender, EventArgs e)
        {

        }

        private void arabtn_Click(object sender, EventArgs e)
        {
            DataTable dataTable = Veritabani.VeriGetir("bar_recete", "menu", "menu", textBox2.Text, "*");

            dataGridView1.DataSource = dataTable;
        }
    }
}
