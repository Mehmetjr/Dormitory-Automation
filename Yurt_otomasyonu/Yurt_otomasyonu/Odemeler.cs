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
    public partial class Odemeler : Form
    {
        public Odemeler()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();
        private void button1_Click(object sender, EventArgs e)
        {


            //ödenen tutardan kalan tutarı düşme
            int ödenen, kalan,yeniborc;
            ödenen = Convert.ToInt16(txt_ödenen.Text);
            kalan = Convert.ToInt16(txt_kalan.Text);
            yeniborc = kalan - ödenen;
            txt_kalan.Text = yeniborc.ToString();

            //güncelleme

            SqlCommand komut1 = new SqlCommand("update Borclar1 set  OgrKalanBorc = @p1 where Ogrid=@p2", bgl.baglan());
            komut1.Parameters.AddWithValue("@p2", txt_ogrid.Text);
            komut1.Parameters.AddWithValue("@p1", txt_kalan.Text);
            komut1.ExecuteNonQuery();
            bgl.baglan().Close();

            this.borclar1TableAdapter.Fill(this.yurtkayitDataSet2.Borclar1);
            MessageBox.Show("Borc Ödendi");



            //Kasayı doldurma

            SqlCommand komut2 = new SqlCommand("insert into Kasa (Odemeay,miktar) values (@k1,@k2)", bgl.baglan());
            komut2.Parameters.AddWithValue("@k1", txt_ay.Text);
            komut2.Parameters.AddWithValue("@k2", txt_ödenen.Text);
            komut2.ExecuteNonQuery();
            bgl.baglan().Close();
        }

        private void Odemeler_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtkayitDataSet2.Borclar1' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.borclar1TableAdapter.Fill(this.yurtkayitDataSet2.Borclar1);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string id, ad, soyad, kalan;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalan = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txt_ogrid.Text = id;
            txt_ogrAd.Text = ad;
            txt_soyad.Text = soyad;
            txt_kalan.Text = kalan;
       
        

        }
    }
}
 