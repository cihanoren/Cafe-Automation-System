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

namespace No1
{
    public partial class MutfakRecete : Form
    {
        public MutfakRecete()
        {
            InitializeComponent();
            dataGridView1.BackgroundColor = Color.DarkGreen;
            dataGridView1.DefaultCellStyle.Font = new Font("Sans Serif", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(207219);

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

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
                string fiyati = reader["alisfiyati"].ToString();
                string id = reader["id"].ToString();


                // Her öğeyi eklerken bir KeyValuePair nesnesi olarak ekleyin
                comboBox1.Items.Add(new KeyValuePair<string, int>(urunler, int.Parse(id)));
            }

            Baglanti.baglanti.Close();
            musteriler_comboBox_menu();

        }



        private void musteriler_comboBox_menu()
        {
            Baglanti.baglanti.Open();

            SqlCommand goster = new SqlCommand("SELECT *FROM islenmis_recete", Baglanti.baglanti);
            SqlDataReader reader = goster.ExecuteReader();

            // ComboBox'a veri ekler
           
            comboBox1.DisplayMember = "Key"; // Görünen metni belirle
            comboBox1.ValueMember = "Value"; // Value olarak kullanılacak alanı belirle

            while (reader.Read())
            {
                string urunler = reader["menu"].ToString();
                string id = reader["id"].ToString();


                // Her öğeyi eklerken bir KeyValuePair nesnesi olarak ekleyin
                comboBox1.Items.Add(new KeyValuePair<string, int>(urunler, int.Parse(id)));
            }

            Baglanti.baglanti.Close();

        }


        private void listele()
        {
           
                DataTable dt = Veritabani.Listele("mutfak_recete", dataGridView1, "", "");

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


        }


        private void DataGridViewAlfabetikSırala()
        {
            // DataGridView'in bağlı olduğu DataSource'ı DataTable olarak alıyoruz
            var dataSource = dataGridView1.DataSource as DataTable;

            if (dataSource != null)
            {
                // DataTable'ı satır bazında alfabetik olarak sıralıyoruz
                var sortedData = dataSource.Rows.Cast<DataRow>()
                                    .OrderBy(row => row["menu"]) // Column1'e göre sıralama
                                    .CopyToDataTable();

                // Sıralanmış verileri DataGridView'e yeniden bağlama
                dataGridView1.DataSource = sortedData;
            }
        }






        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ComboBox'tan seçili öğeyi al
            //string selectedUrunAdi = comboBox1.SelectedItem.ToString();

            // Seçili ürünün adını kullanarak diğer verileri alabilir veya başka işlemler yapabilirsiniz
            // Örneğin:
            // alisfiyati'ni getir
           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {

        }
        string alisfiyati;
        private void button1_Click(object sender, EventArgs e)
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

                    // SQL sorgusunu parametreli olarak oluştur
                    string sqlSorgu = "SELECT * FROM urunler WHERE urunadi = @listele";
                    SqlCommand goster = new SqlCommand(sqlSorgu, Baglanti.baglanti);

                    // Parametreyi ekleyerek SQL injection saldırılarından korun
                    goster.Parameters.AddWithValue("@listele", listele);

                    SqlDataReader reader = goster.ExecuteReader();

                    // ComboBox'a veri ekler
                    while (reader.Read())
                    {
                        alisfiyati = reader["alisfiyati"].ToString();
                    }

                    SqlCommand ekle = new SqlCommand("INSERT INTO mutfak_recete(menu, urunadi, alisfiyati, recetegrami, binlikkullanim, birimmaliyet, toplambirimmaliyet) VALUES(@pmenu, @purunadi, @palisfiyati, @precetegrami, @pbinlikkullanim, @pbirimmaliyet, @ptoplambirimmaliyet)", Baglanti.baglanti);
                    ekle.Parameters.AddWithValue("@pmenu", menuaditb.Text);
                    ekle.Parameters.AddWithValue("@purunadi", comboBox1.Text);
                    ekle.Parameters.AddWithValue("@palisfiyati", alisfiyati);
                    ekle.Parameters.AddWithValue("@precetegrami", recetegramitb.Text);
                    ekle.Parameters.AddWithValue("@pbinlikkullanim", gramtb.Text);


                    float alisFiyati;
                    if (float.TryParse(alisfiyati, out alisFiyati))
                    {
                        float gram;
                        if (float.TryParse(gramtb.Text, out gram) && gram != 0)
                        {
                            float birimmaliyet = alisFiyati / gram;
                            ekle.Parameters.AddWithValue("@pbirimmaliyet", birimmaliyet);

                        }
                        else
                        {
                            MessageBox.Show("Gram değeri hatalı veya sıfır olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Alış fiyatı hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }






                    ekle.Parameters.AddWithValue("@ptoplambirimmaliyet", 11.5);

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

        private void cikisbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var seciliID = dataGridView1.CurrentRow.Cells["id"].Value;
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                // Seçilen satırın hücrelerini TextBox'lara aktarır
                menuaditb.Text = dataGridView1.Rows[selectedRowIndex].Cells["menu"].Value.ToString();
                
                gramtb.Text = dataGridView1.Rows[selectedRowIndex].Cells["binlikkullanim"].Value.ToString();
                recetegramitb.Text = dataGridView1.Rows[selectedRowIndex].Cells["recetegrami"].Value.ToString();
               
                comboBox1.Text = dataGridView1.Rows[selectedRowIndex].Cells["urunadi"].Value.ToString();




            }
        }

        private void MutfakRecete_Load(object sender, EventArgs e)
        {
            musteriler_comboBox();
            listele();
            DataGridViewAlfabetikSırala();

        }

        private void silbtn_Click(object sender, EventArgs e)
        {





            DataTable dt = Veritabani.Listele("mutfak_recete", dataGridView1, "", "");

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var seciliID = dataGridView1.SelectedRows[0].Cells["id"].Value;

                Veritabani.Sil("mutfak_recete", "id", seciliID);

                // Silme işlemi başarılı olduysa DataGridView'i güncelle
                dt = Veritabani.Listele("mutfak_recete", dataGridView1, "", "");
                dataGridView1.DataSource = dt;

                // Veriyi menu kolonuna göre alfabetik sırala
                DataView dv = dt.DefaultView;
                dv.Sort = "menu ASC"; // veya "menu DESC" for descending order
                dt = dv.ToTable();
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Silinecek öge bulunamadı !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            DataGridViewAlfabetikSırala();



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

        }
    }
    
}
