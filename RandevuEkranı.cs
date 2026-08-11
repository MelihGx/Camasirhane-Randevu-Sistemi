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
    public partial class RandevuEkranı : Form
    {
        public RandevuEkranı()
        {
            InitializeComponent();
        }
        public void VeriCek(string makine_kod)
        {
            SqlConnection baglanti = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =C:\\Users\\melha\\source\\repos\\CamasirhaneRandevuSistemi_v1\\CamasirhaneRandevuSistemi_v1\\CamasirhaneRandevu.mdf; Integrated Security = True");
            baglanti.Open();
            SqlDataAdapter vericek = new SqlDataAdapter($"select camasir_makine_kodu , ad , soyad , baslangic_tarihi , bitis_tarihi from randevu where camasir_makine_kodu ='{makine_kod}'", baglanti);
            DataSet ds = new DataSet();
            vericek.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();

        }

        public void FormKapa() 
        {
            this.Hide();
        }

        
    }
}
