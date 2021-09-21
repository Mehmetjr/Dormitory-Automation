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
namespace Yurt_otomasyonu
{
    public partial class FrmOgrKayıt : Form
    {
        public FrmOgrKayıt()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void FrmOgrKayıt_Load(object sender, EventArgs e)
        {
            //combobax a db den veri çekeceğiz sqldatareader db deki verileri okudu while kısmı yazdırdı
            bgl.baglan();
            SqlCommand komut = new SqlCommand("select bolumad from bolumler", bgl.baglan());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbx_bolum.Items.Add(oku[0].ToString());

            }
            
            bgl.baglan().Close();

            //boş odaları listeleme
            bgl.baglan();
            SqlCommand komut2 = new SqlCommand("select OdaNo from Odalar where OdaKapasite!=OdaAktif", bgl.baglan());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cmb_oda.Items.Add(oku2[0].ToString());
            }

            bgl.baglan().Close();
        }

        private void btn_kayıt_Click(object sender, EventArgs e)
        {

            
                bgl.baglan();
                SqlCommand komut3 = new SqlCommand("insert into ogrenci  (OgrAd,OgrSoyad,OgrTc,OgrTelefon,OgrDogum,OgrBolum,OgrMail,OgrOdaNo,OgrVeliAdSoyad,OgrVeliTelefon,OgrVeliAdres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglan());
                komut3.Parameters.AddWithValue("@p1", txt_ad.Text);
                komut3.Parameters.AddWithValue("@p2", txt_soyad.Text);
                komut3.Parameters.AddWithValue("@p3", msk_tc.Text);
                komut3.Parameters.AddWithValue("@p4", msk_ogrtlf.Text);
                komut3.Parameters.AddWithValue("@p5", msk_tarih.Text);
                komut3.Parameters.AddWithValue("@p6", cmbx_bolum.Text);
                komut3.Parameters.AddWithValue("@p7", txt_mail.Text);
                komut3.Parameters.AddWithValue("@p8", cmb_oda.Text);
                komut3.Parameters.AddWithValue("@p9", txt_veliadsyd.Text);
                komut3.Parameters.AddWithValue("@p10", maskedTextBox1.Text);
                komut3.Parameters.AddWithValue("@p11", rchtxt_adres.Text);
                komut3.ExecuteNonQuery();
                bgl.baglan().Close();
                MessageBox.Show("Kayıt Yapıldı");

                //Ogrid label a çekme
                SqlCommand komut = new SqlCommand("select Ogrid from Ogrenci",bgl.baglan());
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    label12.Text = oku[0].ToString();


                }
                bgl.baglan().Close();

                //Ogr borc alanı oluşturma
                SqlCommand komut4 = new SqlCommand("insert into Borclar1 (Ogrid,OgrAd,OgrSoyad) values (@b1,@b2,@b3)", bgl.baglan());
                komut4.Parameters.AddWithValue("@b1", label12.Text);
                komut4.Parameters.AddWithValue("@b2", txt_ad.Text);
                komut4.Parameters.AddWithValue("@b3",txt_soyad.Text);
                komut4.ExecuteNonQuery();
                bgl.baglan().Close();




            //Oda aktiflik 
            SqlCommand komut5 = new SqlCommand("update Odalar set OdaAktif = OdaAktif + 1 where OdaNo = @oda1", bgl.baglan());
            komut5.Parameters.AddWithValue("@oda1", cmb_oda.Text);
            komut5.ExecuteNonQuery();
            bgl.baglan().Close();
        }
    }
}
