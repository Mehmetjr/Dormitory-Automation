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
    public partial class Admingiris : Form
    {
        public Admingiris()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select *from admin where YöneticiAd=@p1 and YöneticiSifre=@p2", bgl.baglan());
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
                lbl_uyarı.Visible = true;
            }
            else
            {
                lbl_uyarı.Visible = false;
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
      
            bgl.baglan().Close();
        }
    }
}
