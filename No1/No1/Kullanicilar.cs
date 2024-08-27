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
    public partial class Kullanicilar : Form
    {
        public Kullanicilar()
        {
            InitializeComponent();
            dataGridView1.BackgroundColor = Color.Navy;
            dataGridView1.DefaultCellStyle.Font = new Font("Sans Serif", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Navy;
            
        }

        private void listele()
        {
            DataTable dt = Veritabani.Listele("kullanici_giris", dataGridView1, "WHERE kullaniciAdi <> 'admin'", "");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;



        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cikisbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kaydetbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(sifretb.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Baglanti.baglanti.Open();

                    SqlCommand ekle = new SqlCommand("INSERT INTO kullanici_giris(kullaniciAdi, sifre) VALUES(@pkullaniciAdi, @psifre)", Baglanti.baglanti);
                    ekle.Parameters.AddWithValue("@pkullaniciAdi", comboBox1.Text);
                    ekle.Parameters.AddWithValue("@psifre", sifretb.Text);

                    ekle.ExecuteNonQuery();

                    Baglanti.baglanti.Close();

                    comboBox1.Text = "";
                    sifretb.Clear();

                    listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            listele();
        }

        private void silbtn_Click(object sender, EventArgs e)
        {
            DataTable dt = Veritabani.Listele("kullanici_giris", dataGridView1, "", "");

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var seciliID = dataGridView1.SelectedRows[0].Cells["id"].Value;
                if (seciliID.ToString() != "1") {

                    Veritabani.Sil("kullanici_giris", "id", seciliID, "id");

                    // Silme işlemi başarılı olduysa DataGridView'i güncelle
                    listele();
                }
                else {

                    MessageBox.Show("Bu Silinemez");


                    listele(); }

                
            }
            else
            {
                MessageBox.Show("Silinecek öge bulunamadı !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            listele();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Kullanicilar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.SelectedRows.Count > 0)
            {
                var seciliID = dataGridView1.CurrentRow.Cells["id"].Value;
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                // Seçilen satırın hücrelerini TextBox'lara aktarır
                comboBox1.Text = dataGridView1.Rows[selectedRowIndex].Cells["kullaniciAdi"].Value.ToString();
                sifretb.Text = dataGridView1.Rows[selectedRowIndex].Cells["sifre"].Value.ToString();
            }








        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
  }

}

