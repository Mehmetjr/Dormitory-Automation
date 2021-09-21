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
    public partial class Adminekle : Form
    {
        public Adminekle()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void Adminekle_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtkayitDataSet6.Admin' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.adminTableAdapter.Fill(this.yurtkayitDataSet6.Admin);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilen = dataGridView1.SelectedCells[0].RowIndex;
            string id, ad, soyad;
            id = dataGridView1.Rows[seçilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[seçilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[seçilen].Cells[2].Value.ToString();

            txt_id.Text = id;
            txt_ad.Text = ad;
            txt_sifre.Text = soyad;
        }

        private void btn_kayıt_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("insert into Admin (yöneticiad,yöneticisifre) values (@p1,@p2)", bgl.baglan());
            komut1.Parameters.AddWithValue("@p1",txt_ad.Text);
            komut1.Parameters.AddWithValue("@p2", txt_sifre.Text);
            komut1.ExecuteNonQuery();
            bgl.baglan().Close();
            this.adminTableAdapter.Fill(this.yurtkayitDataSet6.Admin);
            MessageBox.Show("Kayıt Yapıldı"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("delete from Admin where YoneticiId = @p1", bgl.baglan());
            komut2.Parameters.AddWithValue("@p1", txt_id.Text);
            komut2.ExecuteNonQuery();
            bgl.baglan().Close();
            this.adminTableAdapter.Fill(this.yurtkayitDataSet6.Admin);
            MessageBox.Show("Kayıt Silindi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("update Admin set yöneticiad = @p2 ,yöneticisifre=@p3  where YoneticiId = @p1", bgl.baglan());
            komut3.Parameters.AddWithValue("@p1", txt_id.Text);
            komut3.Parameters.AddWithValue("@p2", txt_ad.Text);
            komut3.Parameters.AddWithValue("@p3", txt_sifre.Text);
            komut3.ExecuteNonQuery();
            bgl.baglan().Close();
            this.adminTableAdapter.Fill(this.yurtkayitDataSet6.Admin);
            MessageBox.Show("Kayıt Güncellendi");
        }
    }
}
