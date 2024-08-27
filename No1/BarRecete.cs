using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void cikisbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarRecete_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
