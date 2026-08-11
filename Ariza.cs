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

namespace CamasirhaneRandevuSistemi_v1
{
    public partial class Ariza : Form
    {
        public Ariza()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=Melih\\SQLEXPRESS;Initial Catalog = CamasirhaneRandevuSistemi; Integrated Security = True";
        void ArizaBildir() 
        {
            string makine = guna2ComboBox1.Text;
            string updateQueryCamasir = @"
            UPDATE Camasir_Makineleri
            SET Durum = 'Arızalı'
            WHERE Camasir_Makine_Kodu = @CamasirMakineKodu";

            string updateQueryKurutma = @"
            UPDATE Kurutma_Makineleri
            SET Durum = 'Arızalı'
            WHERE Kurutma_Makine_Kodu = @KurutmaMakineKodu";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Bağlantıyı aç

                    // Komutu oluştur
                    using (SqlCommand commandcamasir = new SqlCommand(updateQueryCamasir, connection))
                    {
                        // Parametreleri ekle
                        commandcamasir.Parameters.AddWithValue("@CamasirMakineKodu", makine);
                        commandcamasir.ExecuteNonQuery();
                        // Sorguyu çalıştır

                    }
                    using (SqlCommand commandkurutma = new SqlCommand(updateQueryKurutma, connection))
                    {
                        commandkurutma.Parameters.AddWithValue("@KurutmaMakineKodu", makine);
                        commandkurutma.ExecuteNonQuery();
                    }
                    MessageBox.Show("Arıza Bildirdiğiniz İçin Teşekkür Ederiz", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                }
                catch (Exception ex)
                {
                    // Hata durumunda mesaj yazdır
                    MessageBox.Show("Bir hata oluştu: ");
                }
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.Text != "Seçiniz") 
            {
                ArizaBildir();
            }
            else { MessageBox.Show("Lütfen Bir Makine İsmi Seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand); }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
