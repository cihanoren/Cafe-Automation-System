using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace No1
{
    internal class Baglanti
    {
        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-83AGMDV\\MSSQLSERVER61;Initial Catalog=cafedata;Integrated Security=True"); 
        
    }

    public class Veritabani
    {
        public static DataTable Listele(string tableName, DataGridView dataGridView1, string condition = "", string kısıtlandirma = "")
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(Baglanti.baglanti.ConnectionString))
                {
                    connection.Open();

                    string columns = string.IsNullOrEmpty(kısıtlandirma) ? "*" : kısıtlandirma;
                    string query = $"SELECT {columns} FROM {tableName} {condition}";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        dataAdapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }

            return dataTable;
        }


        /////////////////

        public static DataTable VeriGetir(string tabloAdi, string sorguSart, string sorguParametreAdi, string sorguParametreDeger)
        {
            DataTable yeniDataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(Baglanti.baglanti.ConnectionString))
                {
                    connection.Open();

                    // SQL sorgusu oluşturuluyor
                    string query = $"SELECT * FROM {tabloAdi} WHERE {sorguSart} LIKE @{sorguParametreAdi}";

                    // SqlCommand ve SqlParameter kullanarak güvenli sorgu oluşturuluyor
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // SqlParameter ekleniyor ve değeri atanıyor
                        command.Parameters.AddWithValue($"@{sorguParametreAdi}", $"%{sorguParametreDeger}%");

                        // SqlDataAdapter ile veriler çekiliyor
                        SqlDataAdapter adtr = new SqlDataAdapter(command);
                        adtr.Fill(yeniDataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }

            return yeniDataTable;
        }


        ////////////


        public static void Sil(string tabloAdi, string idParametreAdi, object seciliID)
        {
            try
            {
                Baglanti.baglanti.Open();

                // Kaydın varlığını kontrol etmek için bir sorgu oluşturuluyor
                string kontrolSorgusu = $"SELECT COUNT(*) FROM {tabloAdi} WHERE id = @{idParametreAdi}";

                using (SqlCommand kontrolKomut = new SqlCommand(kontrolSorgusu, Baglanti.baglanti))
                {
                    kontrolKomut.Parameters.AddWithValue($"@{idParametreAdi}", seciliID);

                    int kayitSayisi = Convert.ToInt32(kontrolKomut.ExecuteScalar());

                    // Kayıt varsa silme işlemi yapılıyor
                    if (kayitSayisi > 0)
                    {
                        // Silme için SQL sorgusu oluşturuluyor
                        string silSorgusu = $"DELETE FROM {tabloAdi} WHERE id = @{idParametreAdi}";

                        using (SqlCommand silKomut = new SqlCommand(silSorgusu, Baglanti.baglanti))
                        {
                            // Parametre ekleniyor
                            silKomut.Parameters.AddWithValue($"@{idParametreAdi}", seciliID);

                            // Silme sorgusu çalıştırılıyor
                            silKomut.ExecuteNonQuery();
                        }

                        MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Silinecek bir kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Baglanti.baglanti.Close();
            }
        }


        public static void Guncelle(string tabloAdi, string idParametreAdi, object seciliID, string yeniUrunAdi, decimal yeniFiyat, string yeniKategoriAdi = null)
        {
            try
            {
                Baglanti.baglanti.Open();

                // Güncelleme için SQL sorgusu oluşturuluyor
                string guncelleSorgusu = $"UPDATE {tabloAdi} SET urunAdi = @pYeniUrunAdi, katagoriAdi = @pYeniKatagoriAdi, fiyati = @pYeniFiyati WHERE id = @{idParametreAdi}";

                using (SqlCommand guncelleKomut = new SqlCommand(guncelleSorgusu, Baglanti.baglanti))
                {
                    // Parametreler ekleniyor
                    guncelleKomut.Parameters.AddWithValue("@pYeniUrunAdi", yeniUrunAdi);
                    guncelleKomut.Parameters.AddWithValue("@pYeniKatagoriAdi", yeniKategoriAdi);
                    guncelleKomut.Parameters.AddWithValue("@pYeniFiyati", yeniFiyat);
                    guncelleKomut.Parameters.AddWithValue($"@{idParametreAdi}", seciliID);

                    // Güncelleme sorgusu çalıştırılıyor
                    guncelleKomut.ExecuteNonQuery();
                }

                MessageBox.Show("Ürün başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Baglanti.baglanti.Close();
            }
        }






    }




}
