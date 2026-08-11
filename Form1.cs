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

namespace CamasirhaneRandevuSistemi_v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        AnaSayfa form2 = new AnaSayfa();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            form2.ShowDialog();
          
        }
        string kullanıcı_tc;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            kullanıcı_tc = maskedTextBox1.Text;
            SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =C:\\Users\\melha\\source\\repos\\CamasirhaneRandevuSistemi_v1\\CamasirhaneRandevuSistemi_v1\\CamasirhaneRandevu.mdf; Integrated Security = True");
            conn.Open();
            SqlCommand komut = new SqlCommand("select * from kullanici where tc = @tc and sifre = @sifre",conn);
            komut.Parameters.AddWithValue("@tc" , maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@sifre" , textBox1.Text);
            SqlDataReader reader = komut.ExecuteReader();

            if (reader.Read())
            {
                conn.Close();
                AnaSayfa anaSayfa = new AnaSayfa();
                Form1 form = new Form1();
                anaSayfa.TcGoster(kullanıcı_tc);
                anaSayfa.Kullanici_Bilgi_Goster(kullanıcı_tc);
                form.Hide();
                anaSayfa.ShowDialog();
                
            }
            else { MessageBox.Show("Tc veya Şifre Hatalı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            conn.Close();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak İstiyor musunuz?","Çıkış",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            Application.Exit();
            
        }
    }
}
