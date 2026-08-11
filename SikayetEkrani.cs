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
    public partial class SikayetEkrani : Form
    {
        public SikayetEkrani()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=Melih\\SQLEXPRESS;Initial Catalog = CamasirhaneRandevuSistemi; Integrated Security = True";
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string konu = textBox1.Text;
            string aciklama = richTextBox1.Text;

            if (konu == "" || aciklama == "") { MessageBox.Show(
                "Konu ve açıklama boş olamaz",
                "UYARI",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning); }
            else { Ekle(); Listele(); MessageBox.Show("İşlem Başarılı"); }

        }

        void Ekle() 
        {
            string konu = textBox1.Text;
            string aciklama = richTextBox1.Text;
            DateTime dateTime = DateTime.Now;
            string tarih = dateTime.ToString("yyy-MM-dd");

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Geri_Bildirim (Bildirim_Tarihi , Konu , Aciklama) VALUES (@Bildirim_Tarihi , @Konu , @Aciklama)", sqlConnection);
            cmd.Parameters.Add("@Bildirim_Tarihi", tarih);
            cmd.Parameters.Add("@Konu", konu);
            cmd.Parameters.Add("@Aciklama", aciklama);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public void Listele() 
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataAdapter vericek = new SqlDataAdapter("SELECT * FROM Geri_Bildirim", sqlConnection);
            DataSet ds = new DataSet();
            vericek.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            sqlConnection.Close();
        }

        int secilenkayit;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenkayit = guna2DataGridView1.SelectedCells[0].RowIndex;
            
            
            textBox1.Text = guna2DataGridView1.Rows[secilenkayit].Cells[2].Value.ToString();
            richTextBox1.Text = guna2DataGridView1.Rows[secilenkayit].Cells[3].Value.ToString();
        }
    }
}
