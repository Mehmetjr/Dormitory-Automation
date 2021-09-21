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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("select sum(miktar) from Kasa", bgl.baglan());
            SqlDataReader oku1 = komut1.ExecuteReader();

            while (oku1.Read())
            {
                lblpara.Text = oku1[0].ToString() + "TL";

            }
            bgl.baglan().Close();

            //Tekrarsız Ay getirme

            SqlCommand komut2 = new SqlCommand("select distinct(Odemeay) from Kasa", bgl.baglan());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox1.Items.Add(oku2[0].ToString());
            }
            bgl.baglan().Close();

            //Aylık Kazanç Veri tabanı veri çekme
            SqlCommand command = new SqlCommand("select Odemeay , sum(miktar) from kasa group by Odemeay", bgl.baglan());
            SqlDataReader read = command.ExecuteReader();
            while (read.Read()) {
                //Ay ve para chart a girdi
                this.chart1.Series["Aylık"].Points.AddXY(read[0],read[1]);
            
            }
            bgl.baglan().Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("select sum(miktar) from Kasa where Odemeay=@p1", bgl.baglan());
            komut3.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                lbl_ay.Text = oku3[0].ToString();
            }
            bgl.baglan().Close();
        }

        private void lbl_ay_Click(object sender, EventArgs e)
        {

        }
    }
}
