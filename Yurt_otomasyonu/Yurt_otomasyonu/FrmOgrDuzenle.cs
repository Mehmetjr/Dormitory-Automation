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


namespace Yurt_otomasyonu
{
    public partial class FrmOgrDuzenle : Form
    {
        public FrmOgrDuzenle()
        {
            InitializeComponent();
        }
        SqlBaglanti baglanti = new SqlBaglanti();

        public string id,ad,soyad,tc,telefon,dogum,bolum,mail,oda,veliad,velitelefon,adres;

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Ogrenci where ogrid=@p1 ", baglanti.baglan());
            komut.Parameters.AddWithValue("@p1", txt_ogrid.Text);
            komut.ExecuteNonQuery();
            baglanti.baglan().Close();


            //Oda Aktif Arttır

            SqlCommand komut2 = new SqlCommand("update  Odalar set OdaAktif = OdaAktif-1 where OdaNo=@Oda1 ", baglanti.baglan());
            komut2.Parameters.AddWithValue("@Oda1", cmb_oda.Text);
            komut2.ExecuteNonQuery();
            baglanti.baglan().Close();
        }

        private void btn_kayıt_Click(object sender, EventArgs e)
        {
            try { 
            SqlCommand komut1 = new SqlCommand("update Ogrenci set ograd=@p2,ogrsoyad =@p3 , ogrtc=@p4 , ogrtelefon =  @p5  ,OgrDogum = @p6 , ogrbolum = @p7 , ogrmail = @p8 , ogrOdaNo = @p9 , ogrveliadsoyad = @p10 , OgrVeliTelefon = @p11 , ogrVeliAdres = @p12 where ogrid  = @p1 ",baglanti.baglan());
            komut1.Parameters.AddWithValue("@p1", txt_ogrid.Text);
            komut1.Parameters.AddWithValue("@p2", txt_ad.Text);
            komut1.Parameters.AddWithValue("@p3", txt_soyad.Text);
            komut1.Parameters.AddWithValue("@p4", msk_tc.Text);
            komut1.Parameters.AddWithValue("@p5", msk_ogrtlf.Text);
            komut1.Parameters.AddWithValue("@p6", msk_tarih.Text);
            komut1.Parameters.AddWithValue("@p7", cmbx_bolum.Text);
            komut1.Parameters.AddWithValue("@p8", txt_mail.Text);
            komut1.Parameters.AddWithValue("@p9", cmb_oda.Text);
            komut1.Parameters.AddWithValue("@p10", txt_veliadsyd.Text);
            komut1.Parameters.AddWithValue("@p11", maskedTextBox1.Text);
            komut1.Parameters.AddWithValue("@p12", rchtxt_adres.Text);

            komut1.ExecuteNonQuery();
            baglanti.baglan().Close();

            MessageBox.Show("Güncellendi");
            }
            catch (Exception)
            {
                MessageBox.Show("Hata");
            }


        }

        private void FrmOgrDuzenle_Load(object sender, EventArgs e)
        {
            txt_ogrid.Text = id;
            txt_ad.Text = ad;
            txt_soyad.Text = soyad;
            msk_tc.Text = tc;
            msk_ogrtlf.Text = telefon;
            msk_tarih.Text = dogum;
            cmbx_bolum.Text = bolum;
            txt_mail.Text = mail;
            cmb_oda.Text = oda;
            txt_veliadsyd.Text = veliad;
            maskedTextBox1.Text = velitelefon;
            rchtxt_adres.Text = adres;
        }
    }
}
