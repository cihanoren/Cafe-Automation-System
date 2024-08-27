using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace No1
{
    public partial class IslenmisRecete : Form
    {
        public IslenmisRecete()
        {
            InitializeComponent();
            dataGridView.BackgroundColor = Color.DarkGreen;
            dataGridView.DefaultCellStyle.Font = new Font("Sans Serif", 12);
            dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(207219);
        }
        float alisfiyati;
        int urunid;

        private void IslenmisRecete_Load(object sender, EventArgs e)
        {
            musteriler_comboBox();
            listele();

        }

        private void DataGridViewAlfabetikSırala()
        {
            // DataGridView'in bağlı olduğu DataSource'ı DataTable olarak alıyoruz
            var dataSource = dataGridView.DataSource as DataTable;

            if (dataSource != null)
            {
                // DataTable'ı satır bazında alfabetik olarak sıralıyoruz
                var sortedData = dataSource.Rows.Cast<DataRow>()
                                    .OrderBy(row => row["menu"]) // Column1'e göre sıralama
                                    .CopyToDataTable();

                // Sıralanmış verileri DataGridView'e yeniden bağlama
                dataGridView.DataSource = sortedData;
            }
        }





        private void bos(DataGridView dataGridView)
        {
            // DataGridView'den sütun adlarını al
            List<string> columnNames = dataGridView.Columns.Cast<DataGridViewColumn>().Select(c => c.Name).ToList();

            // name i menu olanlar için döngü
            string columnName="menu";
            int a = 2;

                // Aynı sütun adına sahip olan hücreleri grupla
                var groups = dataGridView.Rows.Cast<DataGridViewRow>()
                                  .GroupBy(row => row.Cells[columnName].Value)
                                  .Where(grp => grp.Count() > 1);

                // Her bir grup için döngü
                foreach (var group in groups)
                {
                    // Bir tanesini boş bırak, diğerlerini boş yap
                    bool isFirst = true;
                    foreach (DataGridViewRow row in group)
                    {
                        if (isFirst)
                        {
                        // Arka plan rengini ayarla
                            if (a % 2 == 0)
                            {
                                row.Cells[columnName].Style.BackColor = Color.Yellow;
                            }
                            else
                            {
                                row.Cells[columnName].Style.BackColor = Color.Green;
                            }

                            isFirst = false;
                        }
                        else
                        {
                        // Diğer hücreleri boş bırak
                        if (a % 2 == 0)
                        {
                            row.Cells[columnName].Style.BackColor = Color.Yellow;
                        }
                        else
                        {
                            row.Cells[columnName].Style.BackColor = Color.Green;
                        }
                        row.Cells[columnName].Value = DBNull.Value;
                    }
                    }
                    a++;
                }
            
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
        
        private void listele() {

            DataTable dt = Veritabani.Listele("islenmis_recete", dataGridView, "", "");

            // Veriyi menu kolonuna göre alfabetik sırala
            DataView dv = dt.DefaultView;
            if (dataGridView.RowCount == 0)
            {
                // DataGridView boş
                

                dataGridView.DataSource = dt;
            }
            else
            {
                // DataGridView dolu
                dv.Sort = "menu ASC"; // veya "menu DESC" for descending order
                dt = dv.ToTable();

                dataGridView.DataSource = dt;
            }

            DataGridViewAlfabetikSırala();
            bos(dataGridView);





        }


       
        private void silbtn_Click(object sender, EventArgs e)
        {

            ///islenmisse göre ayarlanacak

            DataTable dt = Veritabani.Listele("islenmis_recete", dataGridView, "", "");

            if (dataGridView.SelectedRows.Count > 0)
            {
                var seciliID = dataGridView.SelectedRows[0].Cells["id"].Value;

                Veritabani.Sil("islenmis_recete", "id", seciliID);

                // Silme işlemi başarılı olduysa DataGridView'i güncelle
                dt = Veritabani.Listele("islenmis_recete", dataGridView, "", "");
                dataGridView.DataSource = dt;

                // Veriyi menu kolonuna göre alfabetik sırala
                DataView dv = dt.DefaultView;
                dv.Sort = "menu ASC"; // veya "menu DESC" for descending order
                dt = dv.ToTable();
                dataGridView.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Silinecek öge bulunamadı !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            DataGridViewAlfabetikSırala();

        }

        private void cikisbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(menuaditb.Text) || string.IsNullOrWhiteSpace(recetegramitb.Text) || string.IsNullOrWhiteSpace(gramtb.Text) || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Baglanti.baglanti.Open();
                    string listele = comboBox1.Text.ToString();



                    SqlCommand komut = new SqlCommand("SELECT alisfiyati FROM urunler WHERE id = @urunid", Baglanti.baglanti);
                    komut.Parameters.AddWithValue("@urunid", urunid);

                    // ExecuteScalar metodu ile sadece bir değer döndürülecektir.
                    object alisfiyatiObject = komut.ExecuteScalar();

                    if (alisfiyatiObject != null) // Dönen değer null değilse alisfiyati değişkenine atanabilir.
                    {
                        alisfiyati = Convert.ToSingle(alisfiyatiObject);
                    }
                    else
                    {
                        // Eğer sorgudan herhangi bir değer dönmediyse buraya gelebiliriz, bu durumu uygun bir şekilde ele almalısınız.
                        MessageBox.Show("Alış fiyatı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }




                    SqlCommand ekle = new SqlCommand("INSERT INTO islenmis_recete(menu, urunadi, alisfiyati, recetegrami, binlikkullanim, birimmaliyet, toplammaliyet) VALUES(@pmenu, @purunadi, @palisfiyati, @precetegrami, @pbinlikkullanim, @pbirimmaliyet, @ptoplammaliyet)", Baglanti.baglanti);
                    ekle.Parameters.AddWithValue("@pmenu", menuaditb.Text);
                    ekle.Parameters.AddWithValue("@purunadi", comboBox1.Text);
                    ekle.Parameters.AddWithValue("@palisfiyati", alisfiyati);
                    ekle.Parameters.AddWithValue("@precetegrami", recetegramitb.Text);
                    ekle.Parameters.AddWithValue("@pbinlikkullanim", gramtb.Text);


                    
                    
                        float gram;
                        if (float.TryParse(gramtb.Text, out gram) && gram != 0)
                        {
                            float birimmaliyet = alisfiyati / gram;
                            ekle.Parameters.AddWithValue("@pbirimmaliyet", birimmaliyet);

                        }
                        else
                        {
                            MessageBox.Show("Gram değeri hatalı veya sıfır olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                    List<string> columnNames = dataGridView.Columns.Cast<DataGridViewColumn>().Select(c => c.Name).ToList();

                    // name i menu olanlar için döngü
                    string columnName = "birimmaliyet";

                    // Aynı sütun adına sahip olan hücreleri grupla
                    var groups = dataGridView.Rows.Cast<DataGridViewRow>()
                                      .GroupBy(row => row.Cells[columnName].Value)
                                      .Where(grp => grp.Count() > 1);
                    float toplam_maliyet=0;
                    // Her bir grup için döngü
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        // Satırın birimmaliyet hücresinin değerini al ve float'a dönüştür
                        float birimmaliyet;
                        if (float.TryParse(row.Cells[columnName].Value?.ToString(), out birimmaliyet))
                        {
                            // Değer geçerliyse toplam maliyete ekle
                            toplam_maliyet += birimmaliyet;
                        }
                    }





                    ekle.Parameters.AddWithValue("@ptoplammaliyet", toplam_maliyet);

                    ekle.ExecuteNonQuery();

                    Baglanti.baglanti.Close();

                    menuaditb.Clear();
                    gramtb.Clear();
                    recetegramitb.Clear();


                    DataGridViewAlfabetikSırala();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuaditb_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            KeyValuePair<string, int> seciliurun = (KeyValuePair<string, int>)comboBox1.SelectedItem;
             urunid = seciliurun.Value;
          
        }

        private void alisfiyatitb_TextChanged(object sender, EventArgs e)
        {

        }

        private void birimmaliyettb_TextChanged(object sender, EventArgs e)
        {

        }

        private void recetegramitb_TextChanged(object sender, EventArgs e)
        {

        }

        private void gramtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbmtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void Menu_Enter(object sender, EventArgs e)
        {

        }

        private void alisfiyatitb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void recetegramitb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void gramtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void birimmaliyettb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbmtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
