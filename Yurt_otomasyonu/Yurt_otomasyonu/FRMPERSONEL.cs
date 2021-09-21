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
    public partial class FRMPERSONEL : Form
    {
        public FRMPERSONEL()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void FRMPERSONEL_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtkayitDataSet7.Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.personelTableAdapter.Fill(this.yurtkayitDataSet7.Personel);

        }

        private void btn_kayıt_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("insert into Personel (PersonelAdSoyad,PErsonelDepartmen) values (@p1,@p2)", bgl.baglan());
            komut1.Parameters.AddWithValue("@p1",txt_ad.Text);
            komut1.Parameters.AddWithValue("@p2", txt_görev.Text);
            komut1.ExecuteNonQuery();
            bgl.baglan().Close();
            this.personelTableAdapter.Fill(this.yurtkayitDataSet7.Personel);
            MessageBox.Show("Kayıt Yapıldı");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("delete from Personel  where PersonelId = @p1", bgl.baglan());
            komut1.Parameters.AddWithValue("@p1", txt_id.Text);
            komut1.ExecuteNonQuery();
            bgl.baglan().Close();
            this.personelTableAdapter.Fill(this.yurtkayitDataSet7.Personel);
            MessageBox.Show("Kayıt Silindi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Update Personel set PersonelAdSoyad=@p2,PErsonelDepartmen=@p3  where PersonelId = @p1", bgl.baglan());
            komut1.Parameters.AddWithValue("@p1", txt_id.Text);
            komut1.Parameters.AddWithValue("@p2", txt_ad.Text);
            komut1.Parameters.AddWithValue("@p3", txt_görev.Text);
            komut1.ExecuteNonQuery();
            bgl.baglan().Close();
            this.personelTableAdapter.Fill(this.yurtkayitDataSet7.Personel);
            MessageBox.Show("Kayıt Güncellendi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string id , ad, görev;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            görev = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            txt_id.Text = id;
            txt_ad.Text = ad;
            txt_görev.Text = görev;
        }
    }
}
