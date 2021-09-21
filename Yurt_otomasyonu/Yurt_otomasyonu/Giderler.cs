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
    public partial class Giderler : Form
    {
        public Giderler()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            try { 
            SqlCommand komut = new SqlCommand("insert into Giderler (Elektrik , Su, Doğalgaz , Internet , Personel , Gider) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglan());
            komut.Parameters.AddWithValue("@p1", txt_elektrik.Text);
            komut.Parameters.AddWithValue("@p2", txt_su.Text);
            komut.Parameters.AddWithValue("@p3", txt_doğalgaz.Text);
            komut.Parameters.AddWithValue("@p4", txt_internet.Text);
            komut.Parameters.AddWithValue("@p5", txt_personel.Text);
            komut.Parameters.AddWithValue("@p6", txt_diğer.Text);
            komut.ExecuteNonQuery();
            bgl.baglan().Close();
            MessageBox.Show("Kaydedildi");
            }
            catch (Exception)
            {
                MessageBox.Show("Hata");
            }
        }
    }
}
