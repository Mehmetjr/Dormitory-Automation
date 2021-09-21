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
    public partial class GiderDüzenle : Form
    {




        SqlBaglanti bgl = new SqlBaglanti();
        public string id, elektrik, su, internet, diger, doğalgaz, personel;

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update giderler set Elektrik = @p2 , su =@p3, Doğalgaz = @p4 , Internet = @p5 , personel = @p6 , gider = @p7 where OdemeId = @p1",bgl.baglan());
            komut.Parameters.AddWithValue("@p1", txt_id.Text);
            komut.Parameters.AddWithValue("@p2", txt_elektrik.Text);
            komut.Parameters.AddWithValue("@p3", txt_su.Text);
            komut.Parameters.AddWithValue("@p4", txt_doğalgaz.Text);
            komut.Parameters.AddWithValue("@p5", txt_internet.Text);
            komut.Parameters.AddWithValue("@p6", txt_personel.Text);
            komut.Parameters.AddWithValue("@p7", txt_diğer.Text);
            komut.ExecuteNonQuery();
            bgl.baglan().Close();
            MessageBox.Show("Güncellendi");
        }

        public GiderDüzenle()
        {
            InitializeComponent();
        }

        private void GiderDüzenle_Load(object sender, EventArgs e)
        {
            txt_id.Text = id;
            txt_elektrik.Text = elektrik;
            txt_su.Text = su;
            txt_doğalgaz.Text = doğalgaz;
            txt_internet.Text = internet;
            txt_personel.Text = personel;
            txt_diğer.Text = diger;
        }
    }
}
