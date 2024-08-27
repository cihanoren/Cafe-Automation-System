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
    public partial class Anamenu : Form
    {
        public Anamenu()
        {
            InitializeComponent();
        }

      
        private void Mutfak_Click(object sender, EventArgs e)
        {
            MutfakRecete mutfakRecete = new MutfakRecete();
            mutfakRecete.ShowDialog();
        }

        private void Bar_Click(object sender, EventArgs e)
        {
            BarRecete barRecete = new BarRecete();
            barRecete.ShowDialog();
        }

        private void AySonu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Üzerinde çalışıyoruz pek yakında sizlerle");
        }

        private void SatilanUrun_Click(object sender, EventArgs e)
        {
            SatilanUrunHacmi satilanUrunHacmi = new SatilanUrunHacmi();
            satilanUrunHacmi.ShowDialog();
        }

        private void Islenmis_Click(object sender, EventArgs e)
        {
            IslenmisRecete IslenmisRecete = new IslenmisRecete();
            IslenmisRecete.ShowDialog();

        }

        private void kullanicilar_Click(object sender, EventArgs e)
        {
            Kullanicilar kullanicilar = new Kullanicilar();
            kullanicilar.ShowDialog();
        }

        private void Cikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Urunler_Click(object sender, EventArgs e)
        {
            Urunler urunler = new Urunler();
            urunler.ShowDialog();
        }
    }
}
