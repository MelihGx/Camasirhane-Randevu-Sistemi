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
    public partial class TeknikBilgi : Form
    {
        public TeknikBilgi()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =C:\\Users\\melha\\source\\repos\\CamasirhaneRandevuSistemi_v1\\CamasirhaneRandevuSistemi_v1\\CamasirhaneRandevu.mdf; Integrated Security = True";
        SqlConnection baglanti;
        void CM_Listele() 
        {
            baglanti = new SqlConnection(connectionString);
            baglanti.Open();
            SqlDataAdapter vericek = new SqlDataAdapter("SELECT * FROM Camasir_Makineleri",baglanti);
            DataSet ds = new DataSet();
            vericek.Fill(ds);
            guna2DataGridView2.DataSource = ds.Tables[0];
            baglanti.Close();

        }

        void CM_Bakım_Tarihi_Listele() 
        {
            baglanti = new SqlConnection(connectionString);
            baglanti.Open();
            SqlDataAdapter vericek = new SqlDataAdapter("SELECT * FROM Camasir_Makineleri_Bakım", baglanti);
            DataSet ds = new DataSet();
            vericek.Fill(ds);
            guna2DataGridView2.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        void KM_Listele() 
        {
            baglanti = new SqlConnection(connectionString);
            baglanti.Open();
            SqlDataAdapter vericek = new SqlDataAdapter("SELECT * FROM Kurutma_Makineleri", baglanti);
            DataSet ds = new DataSet();
            vericek.Fill(ds);
            guna2DataGridView2.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        void KM_Bakım_Tarihi_Listele() 
        {
            baglanti = new SqlConnection(connectionString);
            baglanti.Open();
            SqlDataAdapter vericek = new SqlDataAdapter("SELECT * FROM Kurutma_Makineleri_Bakım", baglanti);
            DataSet ds = new DataSet();
            vericek.Fill(ds);
            guna2DataGridView2.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CM_Listele();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            CM_Bakım_Tarihi_Listele();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            KM_Listele();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            KM_Bakım_Tarihi_Listele();
        }
    }

}
