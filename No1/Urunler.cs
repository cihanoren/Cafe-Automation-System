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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
            // DataGridView özellikleri ayarlanıyor
            dataGridView1.BackgroundColor = Color.Green;
            dataGridView1.DefaultCellStyle.Font = new Font("Sans Serif", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.DarkGreen;
        }
        private void InitializeDataGridView()
        {

        }
        private void listele()
        {
            DataTable dt = Veritabani.Listele("urunler", dataGridView1, "", "");
            dataGridView1.DataSource = dt;
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
                    Baglanti.baglanti.Open();

                    SqlCommand ekle = new SqlCommand("INSERT INTO urunler(urunadi, alisfiyati) VALUES(@purunadi, @palisfiyati)", Baglanti.baglanti);
                    ekle.Parameters.AddWithValue("@purunadi", urunaditb.Text);
                    ekle.Parameters.AddWithValue("@palisfiyati", alisfiyatitb.Text);

                    ekle.ExecuteNonQuery();

                    Baglanti.baglanti.Close();

                    urunaditb.Clear();
                    alisfiyatitb.Clear();

                    listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            listele();
        }

        private void silbtn_Click_1(object sender, EventArgs e)
        {


            DataTable dt = Veritabani.Listele("urunler", dataGridView1, "", "");

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var seciliID = dataGridView1.SelectedRows[0].Cells["id"].Value;

                Veritabani.Sil("urunler", "id", seciliID);

                // Silme işlemi başarılı olduysa DataGridView'i güncelle
                dt = Veritabani.Listele("urunler", dataGridView1, "", "");
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Silinecek öge bulunamadı !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void urunaditb_TextChanged(object sender, EventArgs e)
        {

        }



        private void alisfiyatitb_TextChanged(object sender, EventArgs e)
        {

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
            var seciliID = dataGridView1.CurrentRow.Cells["id"].Value;
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                // Seçilen satırın hücrelerini TextBox'lara aktarır
                urunaditb.Text = dataGridView1.Rows[selectedRowIndex].Cells["urunadi"].Value.ToString();
                alisfiyatitb.Text = dataGridView1.Rows[selectedRowIndex].Cells["alisfiyati"].Value.ToString();


            }
        }

        private void alisfiyatitb_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
