using Guna.UI2.WinForms;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace CamasirhaneRandevuSistemi_v1
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        public string kullanici_tc;
        //string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =C:\\Users\\melha\\source\\repos\\CamasirhaneRandevuSistemi_v1\\CamasirhaneRandevuSistemi_v1\\CamasirhaneRandevu.mdf; Integrated Security = True";
        //string connectionString = "Data Source=Melih\\SQLEXPRESS;Integrated Security=True";
        //string connectionString = "Data Source=Melih\\SQLEXPRESS;Initial Catalog=CamasirhaneRandevuSistemi;Integrated Security=True";
        string connectionString = "Data Source=Melih\\SQLEXPRESS;Initial Catalog = CamasirhaneRandevuSistemi; Integrated Security = True";

        RandevuEkranı randevuEkranı;
        int hayat = 0;
        public string secilenkayitno;
        string makine_kodu;
        string kolon_adi;
        string tablo_adi;
        
        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            
        }

        public void TcGoster(string tc) 
        {
            guna2HtmlLabel23.Text = tc;
        }

        public void Kullanici_Bilgi_Goster(string tc) //Tc ye göre bilgileri labellaara yazar
        {
            SqlConnection baglanti = new SqlConnection(connectionString);
            baglanti.Open();
            string query = @"
                SELECT Ad, Soyad,Blok, Oda_No, Yatak_No
                FROM Kullanici_Bilgi
                WHERE TC = @TC";
            SqlCommand command = new SqlCommand(query, baglanti);
            command.Parameters.AddWithValue("@TC", tc);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                guna2HtmlLabel6.Text = reader["Ad"].ToString();         
                guna2HtmlLabel7.Text = reader["Soyad"].ToString();       
                guna2HtmlLabel8.Text = reader["Blok"].ToString();
                guna2HtmlLabel9.Text = reader["Oda_No"].ToString();     
                guna2HtmlLabel10.Text = reader["Yatak_No"].ToString();
            }
            else { MessageBox.Show("veri yok"); }
            baglanti.Close();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

            makine_kodu = "ÇM-1";
            kolon_adi = "camasir_makine_kodu";
            tablo_adi = "cm_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            makine_kodu = "ÇM-2";
            kolon_adi = "camasir_makine_kodu";
            tablo_adi = "cm_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            //RandevuFormAc("ÇM-3");
            
            makine_kodu = "ÇM-3";
            kolon_adi = "camasir_makine_kodu";
            tablo_adi = "cm_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            makine_kodu = "ÇM-4";
            kolon_adi = "camasir_makine_kodu";
            tablo_adi = "cm_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            makine_kodu = "ÇM-5";
            kolon_adi = "camasir_makine_kodu";
            tablo_adi = "cm_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
            makine_kodu = "ÇM-6";
            kolon_adi = "camasir_makine_kodu";
            tablo_adi = "cm_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //PanelAc("ÇM-7", "camasir_makine_kodu", "cm_randevu");
            makine_kodu = "ÇM-7";
            kolon_adi = "camasir_makine_kodu";
            tablo_adi = "cm_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
            makine_kodu = "ÇM-8";
            kolon_adi = "camasir_makine_kodu";
            tablo_adi = "cm_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
            makine_kodu = "ÇM-9";
            kolon_adi = "camasir_makine_kodu";
            tablo_adi = "cm_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            makine_kodu = "ÇM-10";
            kolon_adi = "camasir_makine_kodu";
            tablo_adi = "cm_randevu";
            PanelAc(makine_kodu,kolon_adi,tablo_adi);
           
        }
        void RandevuEkraniGoster(string makine_kodu)
        {
            randevuEkranı = new RandevuEkranı();
            if (hayat > 0) { randevuEkranı.FormKapa(); }

            randevuEkranı.Show();
            randevuEkranı.Location = new Point(550, 315);
            randevuEkranı.FormBorderStyle = FormBorderStyle.FixedDialog;
            randevuEkranı.VeriCek(makine_kodu);
        }

        void PanelAc(string makine_adi, string kolon_ismi, string tablo_ismi) 
        {
            guna2DataGridView1.Visible = true;
            guna2DataGridView1.Enabled = false;
            LabelGoster();
            //textBox1.Text = makine_adi;
            PaneleVeriCek(makine_adi); 
        }

        

        void PaneleVeriCek(string makine_kod)  //Makine koduna göre o makinenin randevu bilgilerini tarihe göre sıralayıp gösterir
        {
            SqlConnection baglanti = new SqlConnection(connectionString);
            baglanti.Open();
            //SqlDataAdapter vericek = new SqlDataAdapter($"select camasir_makine_kodu , ad , soyad , islem_tarihi , baslangic_saati , bitis_saati from camasir_makine_randevu where camasir_makine_kodu ='{makine_kod}'", baglanti);
            SqlDataAdapter vericek = new SqlDataAdapter($"SELECT {kolon_adi}, ad, soyad, Islem_tarihi, baslangic_saati, bitis_saati , durum FROM {tablo_adi} WHERE {kolon_adi} = '{makine_kod}' ORDER BY Islem_tarihi ASC, baslangic_saati ASC", baglanti);
                    
            DataSet ds = new DataSet();
            vericek.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        void LabelGoster() 
        {
            guna2HtmlLabel11.Visible = true;
            guna2HtmlLabel12.Visible = true;
            guna2HtmlLabel13.Visible = true;
            guna2HtmlLabel14.Visible = true;
            guna2HtmlLabel15.Visible = true;
            guna2HtmlLabel16.Visible = true;
            guna2HtmlLabel17.Visible = true;
            guna2HtmlLabel18.Visible = true;
            guna2HtmlLabel19.Visible = true;
            guna2HtmlLabel20.Visible = true;
            guna2HtmlLabel21.Visible = true;
            guna2HtmlLabel22.Visible = true;

            guna2DateTimePicker1.Visible = true;
            
            guna2ComboBox1.Visible = true;
            guna2ComboBox2.Visible = true;
            guna2ComboBox3.Visible = true;
            guna2ComboBox4.Visible = true;

            guna2Button6.Visible = false;
            guna2Button7.Visible = false;
            guna2Button2.Visible = true;
            guna2Button8.Visible = true;

        }

        void LabelGizle() 
        {
            guna2HtmlLabel11.Visible = false;
            guna2HtmlLabel12.Visible = false;
            guna2HtmlLabel13.Visible = false;
            guna2HtmlLabel14.Visible = false;
            guna2HtmlLabel15.Visible = false;
            guna2HtmlLabel16.Visible = false;
            guna2HtmlLabel17.Visible = false;
            guna2HtmlLabel18.Visible = false;
            guna2HtmlLabel19.Visible = false;
            guna2HtmlLabel20.Visible = false;
            guna2HtmlLabel21.Visible = false;
            guna2HtmlLabel22.Visible = false;

            guna2DateTimePicker1.Visible = false;
            
            guna2ComboBox1.Visible = false;
            guna2ComboBox2.Visible = false;
            guna2ComboBox3.Visible = false;
            guna2ComboBox4.Visible = false;

            guna2Button2.Visible = false;
            guna2Button6.Visible = false;
            guna2Button7.Visible = false;
            guna2Button8.Visible = false;

            guna2DataGridView1.Visible = false;

        }

        void randevu_label_goster() 
        {
            guna2HtmlLabel11.Visible = true;
            guna2HtmlLabel12.Visible = true;
            guna2HtmlLabel13.Visible = true;
            guna2HtmlLabel14.Visible = true;
            guna2HtmlLabel15.Visible = true;
            guna2HtmlLabel22.Visible = true;
            guna2Button6.Visible=true;
            guna2Button7.Visible=true;
        }
        void Tarih_Saat() 
        {
            int baslangic_saat = Convert.ToInt16(guna2ComboBox1.Text);
            int baslangic_dakika = Convert.ToInt16(guna2ComboBox2.Text);
            int bitis_saat = Convert.ToInt16(guna2ComboBox3.Text);
            int bitis_dakika = Convert.ToInt16(guna2ComboBox4.Text);

            int randevu_zamani = ((bitis_saat - baslangic_saat) * 60) + (bitis_dakika - baslangic_dakika);

            DateTime dateTime = DateTime.Now;
            DateTime selectedDate = guna2DateTimePicker1.Value;
            string format = selectedDate.ToString("yyyy-MM-dd");
            textBox3.Text = format;
            textBox2.Text = randevu_zamani.ToString();
            //textBox4.Text = dateTime.ToString();

            if (true)
            {
                if (selectedDate <= dateTime)
                {
                    textBox3.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                    MessageBox.Show("Seçilen Tarih Geçmiş Bir Tarihde Olamaz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    if (randevu_zamani > 120)
                    {
                        textBox3.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                        MessageBox.Show("En Fazla 2 Saat kullanabilirsin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (randevu_zamani < 20 && randevu_zamani >= 0)
                        {
                            textBox3.Text = "";
                            textBox2.Text = "";
                            textBox4.Text = "";
                            MessageBox.Show("En Az 20 Dakika kullanabilirsin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (randevu_zamani < 0)
                            {
                                textBox3.Text = "";
                                textBox2.Text = "";
                                textBox4.Text = "";
                                MessageBox.Show("Saat Seçimleri Hatalı. Tekra Düzenleyiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                textBox3.Text = format;
                                textBox2.Text = randevu_zamani.ToString();
                                textBox4.Text = dateTime.ToString();
                                textBox5.Text = guna2ComboBox1.Text + ":" + guna2ComboBox2.Text + ":00";
                                textBox6.Text = guna2ComboBox3.Text + ":" + guna2ComboBox4.Text + ":00";
                                DialogResult onay = MessageBox.Show("Randevu Bilgilerini Onaylıyor musunuz?", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (onay == DialogResult.Yes)
                                {
                                    if (tablo_adi == "cm_randevu")
                                    {
                                        randevu_ekle();
                                    }
                                    if (tablo_adi == "km_randevu")
                                    {
                                        kurutma_randevu_ekle();
                                    }
                                    PaneleVeriCek(makine_kodu);
                                }

                            }
                        }
                    }
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Tarih_Saat();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Tarih_Saat();

        }

        private void guna2HtmlLabel18_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LabelGizle();
            Ariza ariza = new Ariza();
            ariza.ShowDialog();

        }

        private void guna2Button5_Click(object sender, EventArgs e) //TEKNİK BİLGİ AL
        {
            LabelGizle();
            TeknikBilgi teknikBilgi = new TeknikBilgi();
            teknikBilgi.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e) //ŞİKAYET KUTUSU
        {
            LabelGizle(); 
            SikayetEkrani sikayetEkrani = new SikayetEkrani();
            sikayetEkrani.Listele();
            sikayetEkrani.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e) //Randevu Butonu
        {
            LabelGizle();
            //RandevuGoster(guna2HtmlLabel6.Text , guna2HtmlLabel7.Text);
            TumRandevulariGoster(guna2HtmlLabel6.Text, guna2HtmlLabel7.Text);
            guna2DataGridView1.Enabled = true;
            randevu_label_goster();
        }

        

        void TumRandevulariGoster(string ad, string soyad) //İki tabloyu birleştirerek ad ve soyada göre listeler 
        {
            SqlConnection baglanti = new SqlConnection( connectionString);
            baglanti.Open();
            string query = $@"
            SELECT 
                Camasir_Makine_Kodu AS Makine_Kodu,
                Ad,
                Soyad,
                Islem_Tarihi,
                Baslangic_Saati,
                Bitis_Saati,
                Durum
                
            FROM 
                CM_Randevu
            WHERE
            ad = '{ad}' AND soyad = '{soyad}' 
            UNION ALL
            SELECT 
                Kurutma_Makine_Kodu AS Makine_Kodu,
                Ad,
                Soyad,
                Islem_Tarihi,
                Baslangic_Saati,
                Bitis_Saati,
                Durum
                
            FROM 
                KM_Randevu
            WHERE
            ad = '{ad}' AND soyad = '{soyad}' 
            ORDER BY Islem_tarihi ASC, baslangic_saati ASC";
            SqlDataAdapter vericek = new SqlDataAdapter(query,baglanti);
            DataSet ds = new DataSet();
            vericek.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
            guna2DataGridView1.Visible = true;
        }
        

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)  //CellSelect Butonu
        {
            int secilenkayit = guna2DataGridView1.SelectedCells[0].RowIndex;
            secilenkayitno = guna2DataGridView1.Rows[secilenkayit].Cells[0].Value.ToString();
            textBox12.Text = guna2DataGridView1.Rows[secilenkayit].Cells[0].Value.ToString();
            textBox7.Text = guna2DataGridView1.Rows[secilenkayit].Cells[1].Value.ToString();                           
            textBox8.Text = guna2DataGridView1.Rows[secilenkayit].Cells[2].Value.ToString();
            textBox9.Text = guna2DataGridView1.Rows[secilenkayit].Cells[3].Value.ToString(); 
            textBox10.Text = guna2DataGridView1.Rows[secilenkayit].Cells[4].Value.ToString();
            textBox11.Text = guna2DataGridView1.Rows[secilenkayit].Cells[5].Value.ToString();

            
            string tarih_value = textBox9.Text;
            
            DateTime parsetarih = DateTime.Parse(tarih_value);
            string formattedDate = parsetarih.ToString("yyyy-MM-dd");

            // TextBox'a yeniden yaz
            textBox9.Text = formattedDate;

        }

        private void guna2Button8_Click(object sender, EventArgs e)  //TARİHE GÖRE SIRALA
        {
            DateTime selectedDate = guna2DateTimePicker1.Value;
            string format = selectedDate.ToString("yyyy-MM-dd");
            textBox1.Text = format;
            string camasirkolon = "camasir_makine_kodu";
            string kurutmakolon = "kurutma_makine_kodu";
            if (tablo_adi == "cm_randevu") 
            {
                tarihe_gore_sirala(format,camasirkolon, tablo_adi);
            }
            if (tablo_adi == "km_randevu") 
            {
                tarihe_gore_sirala(format, kurutmakolon, tablo_adi);
            }


            //tarihe_gore_sirala(format); //tarihe göre sırala
        }

        void tarihe_gore_sirala(string format, string makine_kolonu , string tablo_adi) 
        {

            SqlConnection baglanti = new SqlConnection(connectionString);
            baglanti.Open();
            //SqlDataAdapter vericek = new SqlDataAdapter($"select camasir_makine_kodu , ad , soyad , islem_tarihi , baslangic_saati , bitis_saati from camasir_makine_randevu where camasir_makine_kodu ='{makine_kod}'", baglanti);
            SqlDataAdapter vericek = new SqlDataAdapter($"SELECT {makine_kolonu}, ad, soyad, Islem_tarihi, baslangic_saati, bitis_saati , durum FROM {tablo_adi} WHERE {makine_kolonu} = '{makine_kodu}' AND CAST(Islem_tarihi AS DATE) = '{format}'  ORDER BY Islem_tarihi ASC, baslangic_saati ASC", baglanti);

            DataSet ds = new DataSet();
            vericek.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
            guna2DataGridView1.Visible = true;
        }

        

        
        void randevu_ekle() 
        {
            SqlConnection baglanti = new SqlConnection(connectionString);
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into cm_randevu (camasir_makine_kodu, ad, soyad , TC , Islem_tarihi, baslangic_saati, bitis_saati) values (@camasir_makine_kodu, @ad, @soyad,@TC, @islem_tarihi, @baslangic_saati, @bitis_saati)", baglanti);
            cmd.Parameters.Add("@camasir_makine_kodu", makine_kodu);
            cmd.Parameters.Add("@ad", guna2HtmlLabel6.Text);
            cmd.Parameters.Add("@soyad", guna2HtmlLabel7.Text);
            cmd.Parameters.Add("@islem_tarihi", textBox3.Text);
            cmd.Parameters.Add("@baslangic_saati", textBox5.Text);
            cmd.Parameters.Add("@bitis_saati", textBox6.Text);
            cmd.Parameters.Add("@TC" , guna2HtmlLabel23.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }
        void kurutma_randevu_ekle()
        {
            SqlConnection baglanti = new SqlConnection(connectionString);
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into km_randevu (kurutma_makine_kodu, ad, soyad,TC, Islem_tarihi, baslangic_saati, bitis_saati) values (@camasir_makine_kodu, @ad, @soyad,@TC, @islem_tarihi, @baslangic_saati, @bitis_saati)", baglanti);
            cmd.Parameters.Add("@camasir_makine_kodu", makine_kodu);
            cmd.Parameters.Add("@ad", guna2HtmlLabel6.Text);
            cmd.Parameters.Add("@soyad", guna2HtmlLabel7.Text);
            cmd.Parameters.Add("@islem_tarihi", textBox3.Text);
            cmd.Parameters.Add("@baslangic_saati", textBox5.Text);
            cmd.Parameters.Add("@bitis_saati", textBox6.Text);
            cmd.Parameters.Add("@TC", guna2HtmlLabel23.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }

        private void guna2Button7_Click(object sender, EventArgs e)  //İŞLEM TAMAMLA BUTONU
        {
            DialogResult onay = MessageBox.Show("Tamamlama İşlemini Onaylıyormsunuz?", "ONAYLA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                if (tablo_adi == "cm_randevu")
                {
                    Islem_Tamamla();
                    TumRandevulariGoster(guna2HtmlLabel6.Text, guna2HtmlLabel7.Text);
                }
                if (tablo_adi == "km_randevu")
                {
                    Kurutma_Islem_Tamamla();
                    TumRandevulariGoster(guna2HtmlLabel6.Text, guna2HtmlLabel7.Text);
                }
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e) //DELETE
        {
            DialogResult onay = MessageBox.Show("Randevu Kaldırma İşlemini Onaylıyormsunuz?", "ONAYLA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                Delete_Islemi();
                TumRandevulariGoster(guna2HtmlLabel6.Text, guna2HtmlLabel7.Text);
            }
        }

        

        void Islem_Tamamla() 
        {
            string updateQuery = @"
            UPDATE CM_Randevu
            SET Durum = 'Tamamlandı'
            WHERE Camasir_Makine_Kodu = @CamasirMakineKodu
              AND Ad = @Ad
              AND Soyad = @Soyad
              AND Islem_Tarihi = @IslemTarihi
              AND Baslangic_Saati = @BaslangicSaati";
            string camasirMakineKodu = textBox12.Text;
            string ad = textBox7.Text;
            string soyad = textBox8.Text;
            string islemTarihi = textBox9.Text; // Tarih formatı: "yyyy-MM-dd"
            string baslangicSaati = textBox10.Text; // Saat formatı: "HH:mm:ss"

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Bağlantıyı aç

                    // Komutu oluştur
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@CamasirMakineKodu", camasirMakineKodu);
                        command.Parameters.AddWithValue("@Ad", ad);
                        command.Parameters.AddWithValue("@Soyad", soyad);
                        command.Parameters.AddWithValue("@IslemTarihi", islemTarihi); // Tarih formatında ekle
                        command.Parameters.AddWithValue("@BaslangicSaati", baslangicSaati); // Saat formatında ekle

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        // Kullanıcıya bilgi ver
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Basarili");
                        }
                        else
                        {
                            MessageBox.Show("Eşleşen bir kayıt bulunamadı.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesaj yazdır
                    MessageBox.Show("Bir hata oluştu: ");
                }
            }

        }
        void Kurutma_Islem_Tamamla()
        {
            string updateQuery = @"
            UPDATE KM_Randevu
            SET Durum = 'Tamamlandı'
            WHERE Kurutma_Makine_Kodu = @KurutmaMakineKodu
              AND Ad = @Ad
              AND Soyad = @Soyad
              AND Islem_Tarihi = @IslemTarihi
              AND Baslangic_Saati = @BaslangicSaati";
            string KurutmaMakineKodu = textBox12.Text;
            string ad = textBox7.Text;
            string soyad = textBox8.Text;
            string islemTarihi = textBox9.Text; // Tarih formatı: "yyyy-MM-dd"
            string baslangicSaati = textBox10.Text; // Saat formatı: "HH:mm:ss"

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Bağlantıyı aç

                    // Komutu oluştur
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@KurutmaMakineKodu", KurutmaMakineKodu);
                        command.Parameters.AddWithValue("@Ad", ad);
                        command.Parameters.AddWithValue("@Soyad", soyad);
                        command.Parameters.AddWithValue("@IslemTarihi", islemTarihi); // Tarih formatında ekle
                        command.Parameters.AddWithValue("@BaslangicSaati", baslangicSaati); // Saat formatında ekle

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        // Kullanıcıya bilgi ver
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Basarili");
                        }
                        else
                        {
                            MessageBox.Show("Eşleşen bir kayıt bulunamadı.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesaj yazdır
                    MessageBox.Show("Bir hata oluştu: ");
                }
            }
        }

        void Delete_Islemi()
        {
            string deleteQuerycamasir = @"
            DELETE FROM cm_randevu
            WHERE camasir_makine_kodu = @KurutmaMakineKodu
              AND Ad = @Ad
              AND Soyad = @Soyad
              AND Islem_Tarihi = @IslemTarihi
              AND Baslangic_Saati = @BaslangicSaati";
            string deleteQuerykurutma = @"
            DELETE FROM km_randevu
            WHERE kurutma_makine_kodu = @KurutmaMakineKodu
              AND Ad = @Ad
              AND Soyad = @Soyad
              AND Islem_Tarihi = @IslemTarihi
              AND Baslangic_Saati = @BaslangicSaati";
            string MakineKodu = textBox12.Text;
            string ad = textBox7.Text;
            string soyad = textBox8.Text;
            string islemTarihi = textBox9.Text; // Tarih formatı: "yyyy-MM-dd"
            string baslangicSaati = textBox10.Text; // Saat formatı: "HH:mm:ss"

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Bağlantıyı aç

                    // Komutu oluştur
                    using (SqlCommand commandcamasir = new SqlCommand(deleteQuerycamasir, connection))
                    {
                        // Parametreleri ekle
                        commandcamasir.Parameters.AddWithValue("@KurutmaMakineKodu", MakineKodu);
                        commandcamasir.Parameters.AddWithValue("@Ad", ad);
                        commandcamasir.Parameters.AddWithValue("@Soyad", soyad);
                        commandcamasir.Parameters.AddWithValue("@IslemTarihi", islemTarihi); // Tarih formatında ekle
                        commandcamasir.Parameters.AddWithValue("@BaslangicSaati", baslangicSaati); // Saat formatında ekle
                        commandcamasir.ExecuteNonQuery();
                        // Sorguyu çalıştır

                    }
                    using (SqlCommand commandkurutma = new SqlCommand(deleteQuerykurutma, connection)) 
                    {
                        commandkurutma.Parameters.AddWithValue("@KurutmaMakineKodu", MakineKodu);
                        commandkurutma.Parameters.AddWithValue("@Ad", ad);
                        commandkurutma.Parameters.AddWithValue("@Soyad", soyad);
                        commandkurutma.Parameters.AddWithValue("@IslemTarihi", islemTarihi); // Tarih formatında ekle
                        commandkurutma.Parameters.AddWithValue("@BaslangicSaati", baslangicSaati); // Saat formatın
                        commandkurutma.ExecuteNonQuery();
                    }
                    
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesaj yazdır
                    MessageBox.Show("Bir hata oluştu: ");
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {

            makine_kodu = "KM-1";
            kolon_adi = "kurutma_makine_kodu";
            tablo_adi = "km_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button12_Click(object sender, EventArgs e)
        {
           
            makine_kodu = "KM-2";
            kolon_adi = "kurutma_makine_kodu";
            tablo_adi = "km_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
            makine_kodu = "KM-3";
            kolon_adi = "kurutma_makine_kodu";
            tablo_adi = "km_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            
            makine_kodu = "KM-5";
            kolon_adi = "kurutma_makine_kodu";
            tablo_adi = "km_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
            makine_kodu = "KM-6";
            kolon_adi = "kurutma_makine_kodu";
            tablo_adi = "km_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button17_Click(object sender, EventArgs e)
        {
           
            makine_kodu = "KM-7";
            kolon_adi = "kurutma_makine_kodu";
            tablo_adi = "km_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            
            makine_kodu = "KM-8";
            kolon_adi = "kurutma_makine_kodu";
            tablo_adi = "km_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            
            makine_kodu = "KM-9";
            kolon_adi = "kurutma_makine_kodu";
            tablo_adi = "km_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            
            makine_kodu = "KM-10";
            kolon_adi = "kurutma_makine_kodu";
            tablo_adi = "km_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            
            makine_kodu = "KM-4";
            kolon_adi = "kurutma_makine_kodu";
            tablo_adi = "km_randevu";
            PanelAc(makine_kodu, kolon_adi, tablo_adi);
        }


        string l = "leyla şahin";



        //EN SON Kurutma Makinelerini entegre etmeye çalışıyordun





    }
}
