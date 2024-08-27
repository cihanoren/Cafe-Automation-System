using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace No1
{
    public partial class MutfakRecete : Form
    {
        public MutfakRecete()
        {
            InitializeComponent();
            dataGridView1.BackgroundColor = Color.Navy;
            dataGridView1.DefaultCellStyle.Font = new Font("Sans Serif", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Navy;




        }
        float alisfiyati, top_;
        int urunid1, urunid2;
        bool ayniDegerVarMi = false;
        private void musteriler_comboBox()
        {

            if (Baglanti.baglanti.State == System.Data.ConnectionState.Open)
            {
                Baglanti.baglanti.Close();
            }
            comboBox1.Items.Clear();
            Baglanti.baglanti.Open();



            SqlCommand goster = new SqlCommand("SELECT * FROM urunler", Baglanti.baglanti);
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
        private float ToplamMalzemeFiyati(string menuAdi)
        {
            float toplamMaliyet = 0;
            Baglanti.baglanti.Open();
            string query = "SELECT SUM(birimmaliyet) FROM mutfak_recete WHERE menu = @menuAdi";
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



        private void musteriler_comboBox_islenmis()
        {
            Baglanti.baglanti.Open();
            comboBox2.Items.Clear();

            SqlCommand goster = new SqlCommand(@"
                SELECT id, menu, toplammaliyet 
                FROM islenmis_recete AS ir1 
                WHERE toplammaliyet = (
                    SELECT MAX(toplammaliyet) 
                    FROM islenmis_recete AS ir2 
                    WHERE ir1.menu = ir2.menu
                )", Baglanti.baglanti);

            SqlDataReader reader = goster.ExecuteReader();

            comboBox2.DisplayMember = "Key"; // Görünen metni belirle
            comboBox2.ValueMember = "Value"; // Value olarak kullanılacak alanı belirle

            while (reader.Read())
            {
                string urunler = reader["menu"].ToString();
                int id = Convert.ToInt32(reader["id"]);

                // Her öğeyi eklerken bir KeyValuePair nesnesi olarak ekleyin
                comboBox2.Items.Add(new KeyValuePair<string, int>(urunler, id));
            }

            Baglanti.baglanti.Close();




        }


        private void listele()
        {

            DataTable dt = Veritabani.Listele("mutfak_recete", dataGridView1, "", "");


            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["alisfiyati"].Visible = true;//false olcak
            dataGridView1.Columns["birimmaliyet"].Visible = true;//false olcak
            dataGridView1.Columns["binlikkullanim"].Visible = false;





            DataGridViewAlfabetikSırala();
            musteriler_comboBox();
            musteriler_comboBox_islenmis();
            dataGridView1.ClearSelection();
            menuaditb.Text = "";
            recetegramitb.Text = "";





        }






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
























        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(menuaditb.Text) || string.IsNullOrWhiteSpace(recetegramitb.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(comboBox1.Text) == false)
                    {
                        float toplamFiyat = ToplamMalzemeFiyati(menuaditb.Text);
                        
                        float birimmaliyet = 0, binlikh = 0;
                        Baglanti.baglanti.Open();
                        string listele = comboBox1.Text.ToString();
                        SqlCommand komut = new SqlCommand("SELECT alisfiyati FROM urunler WHERE id = @urunid", Baglanti.baglanti);
                        komut.Parameters.AddWithValue("@urunid", urunid1);
                        object alisfiyatiObject = komut.ExecuteScalar();
                        if (alisfiyatiObject != null)
                        {
                            alisfiyati = Convert.ToSingle(alisfiyatiObject);
                        }
                        else
                        {
                            MessageBox.Show("Alış fiyatı bulunamadı. cmb1 hatalı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        if (Varmı(menuaditb.Text, listele))
                        {
                            float seciliMaliyet = Convert.ToSingle(dataGridView1.SelectedRows[0].Cells["birimmaliyet"].Value);
                            // Mevcut malzeme güncelleniyor
                            SqlCommand guncelle = new SqlCommand("UPDATE mutfak_recete SET alisfiyati = @palisfiyati, recetegrami = @precetegrami, binlikkullanim = @pbinlikkullanim, birimmaliyet = @pbirimmaliyet, toplambirimmaliyet = @ptoplammaliyet WHERE menu = @pmenu AND urunadi = @purunadi", Baglanti.baglanti);
                            guncelle.Parameters.AddWithValue("@pmenu", menuaditb.Text);
                            guncelle.Parameters.AddWithValue("@purunadi", comboBox1.Text);
                            guncelle.Parameters.AddWithValue("@palisfiyati", alisfiyati);
                            guncelle.Parameters.AddWithValue("@precetegrami", recetegramitb.Text);

                            float binlik;
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
                                guncelle.Parameters.AddWithValue("@ptoplammaliyet", (toplamFiyat+birimmaliyet)- seciliMaliyet);
                                
                            }
                            else
                            {
                                MessageBox.Show("Gram değeri hatalı veya sıfır olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Baglanti.baglanti.Close();
                                return;
                            }

                            guncelle.ExecuteNonQuery();
                            // Veritabanında toplam birim maliyeti güncelle
                            SqlCommand guncelleKomutu1 = new SqlCommand("UPDATE mutfak_recete SET toplambirimmaliyet = @toplambirimmaliyet WHERE menu = @menu", Baglanti.baglanti);
                            guncelleKomutu1.Parameters.AddWithValue("@toplambirimmaliyet", (toplamFiyat + birimmaliyet) - seciliMaliyet);
                            guncelleKomutu1.Parameters.AddWithValue("@menu", menuaditb.Text);

                           
                            guncelleKomutu1.ExecuteNonQuery();

                            //MessageBox.Show("Veri başarıyla silindi ve maliyet fiyatı düzenlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            MessageBox.Show("Mevcut malzeme güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {


                            {
                                SqlCommand ekle = new SqlCommand("INSERT INTO mutfak_recete(menu, urunadi, alisfiyati, recetegrami, binlikkullanim, birimmaliyet, toplambirimmaliyet) VALUES(@pmenu, @purunadi, @palisfiyati, @precetegrami, @pbinlikkullanim, @pbirimmaliyet, @ptoplammaliyet)", Baglanti.baglanti);
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

                                SqlCommand guncelleKomutu1 = new SqlCommand("UPDATE mutfak_recete SET toplambirimmaliyet = @toplambirimmaliyet WHERE menu = @menu", Baglanti.baglanti);
                                guncelleKomutu1.Parameters.AddWithValue("@toplambirimmaliyet", birimmaliyet + toplamFiyat);
                                guncelleKomutu1.Parameters.AddWithValue("@menu", menuaditb.Text);


                                guncelleKomutu1.ExecuteNonQuery();
                            }
                        }

                        Baglanti.baglanti.Close();
                        menuaditb.Clear();
                        gramtb.Clear();
                        recetegramitb.Clear();
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                    }


                    //


                    else if (string.IsNullOrWhiteSpace(comboBox2.Text) == false)
                    {

                        float toplamFiyat = ToplamMalzemeFiyati(menuaditb.Text);
                        float birimmaliyet = 0, binlikh = 0;
                        Baglanti.baglanti.Open();
                        string listele = comboBox2.Text.ToString();
                        SqlCommand komut = new SqlCommand("SELECT sum(recetegrami) FROM islenmis_recete WHERE menu = @menu", Baglanti.baglanti);
                        SqlCommand komut_ = new SqlCommand("SELECT max(toplammaliyet) FROM islenmis_recete WHERE menu = @pmenu", Baglanti.baglanti);
                        komut.Parameters.AddWithValue("@menu", listele);
                        komut_.Parameters.AddWithValue("@pmenu", listele);
                        object alisfiyatiObject = komut.ExecuteScalar();
                        object top = komut_.ExecuteScalar();

                        if (alisfiyatiObject != null && top != null)
                        {
                            float alisfiyati = Convert.ToSingle(alisfiyatiObject);
                            float top_ = Convert.ToSingle(top);

                            if (Varmı(menuaditb.Text, listele))
                            {
                                // Mevcut malzeme güncelleniyor
                                float seciliMaliyet = Convert.ToSingle(dataGridView1.SelectedRows[0].Cells["birimmaliyet"].Value);
                                SqlCommand guncelle = new SqlCommand("UPDATE mutfak_recete SET alisfiyati = @palisfiyati, recetegrami = @precetegrami, binlikkullanim = @pbinlikkullanim, birimmaliyet = @pbirimmaliyet, toplambirimmaliyet = @ptoplammaliyet WHERE menu = @pmenu AND urunadi = @purunadi", Baglanti.baglanti);
                                guncelle.Parameters.AddWithValue("@pmenu", menuaditb.Text);
                                guncelle.Parameters.AddWithValue("@purunadi", comboBox2.Text);
                                guncelle.Parameters.AddWithValue("@palisfiyati", alisfiyati);
                                guncelle.Parameters.AddWithValue("@precetegrami", recetegramitb.Text);

                                if (float.TryParse(recetegramitb.Text, out float binlik) && binlik != 0)
                                {
                                    binlikh = 1000 / binlik;
                                    guncelle.Parameters.AddWithValue("@pbinlikkullanim", binlikh);

                                    birimmaliyet = alisfiyati / binlikh;
                                    guncelle.Parameters.AddWithValue("@pbirimmaliyet", birimmaliyet);
                                    guncelle.Parameters.AddWithValue("@ptoplammaliyet", (toplamFiyat + birimmaliyet) - seciliMaliyet);

                                    guncelle.ExecuteNonQuery();

                                    SqlCommand guncelleKomutu1 = new SqlCommand("UPDATE mutfak_recete SET toplambirimmaliyet = @toplambirimmaliyet WHERE menu = @menu", Baglanti.baglanti);
                                    guncelleKomutu1.Parameters.AddWithValue("@toplambirimmaliyet", (toplamFiyat + birimmaliyet) - seciliMaliyet);
                                    guncelleKomutu1.Parameters.AddWithValue("@menu", menuaditb.Text);


                                    guncelleKomutu1.ExecuteNonQuery();
                                    MessageBox.Show("Mevcut malzeme güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("1000g için kullanım değeri hatalı veya sıfır olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                SqlCommand ekle = new SqlCommand("INSERT INTO mutfak_recete(menu, urunadi, alisfiyati, recetegrami, binlikkullanim, birimmaliyet, toplambirimmaliyet) VALUES(@pmenu, @purunadi, @palisfiyati, @precetegrami, @pbinlikkullanim, @pbirimmaliyet, @ptoplammaliyet)", Baglanti.baglanti);
                                ekle.Parameters.AddWithValue("@pmenu", menuaditb.Text);
                                ekle.Parameters.AddWithValue("@purunadi", comboBox2.Text);
                                ekle.Parameters.AddWithValue("@palisfiyati", (top_ / alisfiyati) * 1000);
                                ekle.Parameters.AddWithValue("@precetegrami", recetegramitb.Text);

                                if (float.TryParse(recetegramitb.Text, out float binlik) && binlik != 0)
                                {
                                    binlikh = 1000 / binlik;
                                    ekle.Parameters.AddWithValue("@pbinlikkullanim", binlikh);

                                    birimmaliyet = alisfiyati / binlikh;
                                    ekle.Parameters.AddWithValue("@pbirimmaliyet", birimmaliyet);
                                    ekle.Parameters.AddWithValue("@ptoplammaliyet", toplamFiyat + birimmaliyet);

                                    ekle.ExecuteNonQuery();
                                    SqlCommand guncelleKomutu1 = new SqlCommand("UPDATE mutfak_recete SET toplambirimmaliyet = @toplambirimmaliyet WHERE menu = @menu", Baglanti.baglanti);
                                    guncelleKomutu1.Parameters.AddWithValue("@toplambirimmaliyet", birimmaliyet + toplamFiyat);
                                    guncelleKomutu1.Parameters.AddWithValue("@menu", menuaditb.Text);


                                    guncelleKomutu1.ExecuteNonQuery();
                                    // MessageBox.Show("Yeni malzeme eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("1000g için kullanım değeri hatalı veya sıfır olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Alış fiyatı bulunamadı. cmb2 hatalı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        Baglanti.baglanti.Close();
                        menuaditb.Clear();
                        gramtb.Clear();
                        recetegramitb.Clear();
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        // İkinci comboBox'ın seçimini de temizle



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            listele();

        }






        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cikisbtn_Click(object sender, EventArgs e)
        {
            this.Close();
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
                // var alisFiyatiCellValue = dataGridView1.Rows[selectedRowIndex].Cells["urunadi"].Value;
                //comboBox1.Text = alisFiyatiCellValue != null ? alisFiyatiCellValue.ToString() : "";


                // Stok hücresinin değerini al
                var stokCellValue = dataGridView1.Rows[selectedRowIndex].Cells["recetegrami"].Value;
                recetegramitb.Text = stokCellValue != null ? stokCellValue.ToString() : "";

                var gramCellValue = dataGridView1.Rows[selectedRowIndex].Cells["binlikkullanim"].Value;
                gramtb.Text = gramCellValue != null ? gramCellValue.ToString() : "";



            }

        }

        private void MutfakRecete_Load(object sender, EventArgs e)
        {

            listele();



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

                    // Veritabanından seçilen veriyi sil
                    float yeniToplamMaliyet = ToplamMalzemeFiyati(menu);
                    Veritabani.Sil("mutfak_recete", "id", seciliID, "id");

                    // Yeni toplam maliyeti hesapla ve güncelle
                    
                    float guncelToplamMaliyet = yeniToplamMaliyet - seciliMaliyet;

                    // Veritabanında toplam birim maliyeti güncelle
                    SqlCommand guncelleKomutu = new SqlCommand("UPDATE mutfak_recete SET toplambirimmaliyet = @toplambirimmaliyet WHERE menu = @menu", Baglanti.baglanti);
                    guncelleKomutu.Parameters.AddWithValue("@toplambirimmaliyet", guncelToplamMaliyet);
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
            else
            {
                MessageBox.Show("Silinecek öge bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();
            musteriler_comboBox();

        }

        private void Menu_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            KeyValuePair<string, int> seciliurun = (KeyValuePair<string, int>)comboBox1.SelectedItem;
            urunid1 = seciliurun.Value;
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

        private void menuaditb_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void recetegramitb_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void gramtb_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
                comboBox2.Visible = true;
                comboBox1.Visible = false;
                comboBox1.Text = "";
            }
            else
            {
                comboBox2.Visible = false;
                radioButton2.Checked = true;
                comboBox1.Visible = true;
                comboBox2.Text = "";



            }
        }

        private void menuaditb_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dataTable = Veritabani.VeriGetir("mutfak_recete", "menu", "menu", textBox1.Text, "*");

            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Sadece hücre boyama olayını işle
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    // Satırın null olmadığını kontrol edin
                    if (dataGridView1.Rows[i] != null && dataGridView1.Rows[i + 1] != null)
                    {
                        // Hücrelerin null olmadığını kontrol edin ve hücre indekslerinin geçerli olduğundan emin olun
                        if (dataGridView1.Rows[i].Cells.Count > 1 && dataGridView1.Rows[i + 1].Cells.Count > 1 &&
                            dataGridView1.Rows[i].Cells[1].Value != null && dataGridView1.Rows[i + 1].Cells[1].Value != null)
                        {
                            var cell1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            var cell2 = dataGridView1.Rows[i + 1].Cells[1].Value.ToString();

                            if (cell1 == cell2)
                            {
                                // Hücre indeksinin geçerli olduğundan emin olun
                                if (dataGridView1.Rows[i].Cells.Count > 7)
                                {
                                    // İki satırın ilk hücrelerindeki değerler eşitse, ilk satırın 5. hücresinin yazı rengini beyaz yap
                                    //* dataGridView1.Rows[i].Cells[7].Style.ForeColor = Color.White;

                                    // Hücre yazı rengini arka plan rengiyle aynı yapma
                                    if (e.RowIndex == i && e.ColumnIndex == 7)
                                    {
                                        //* e.PaintBackground(e.CellBounds, true);
                                        //* e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.CellBounds);
                                        //* e.Handled = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> seciliurun = (KeyValuePair<string, int>)comboBox2.SelectedItem;
            urunid2 = seciliurun.Value;
        }
    }

}
