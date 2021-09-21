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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
   
        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtkayitDataSet.Bolumler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.bolumlerTableAdapter.Fill(this.yurtkayitDataSet.Bolumler);

        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            bgl.baglan();
            SqlCommand komut = new SqlCommand("insert into  Bolumler (BolumAd) values (@p1)",bgl.baglan());
            komut.Parameters.AddWithValue("@p1", txt_blmad.Text);
            komut.ExecuteNonQuery();
            bgl.baglan().Close();
            MessageBox.Show("Bolum kayıt yapıldı");
            this.bolumlerTableAdapter.Fill(this.yurtkayitDataSet.Bolumler);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string bolumad, bolumid;
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            bolumid = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txt_blmad.Text = bolumad;
            txt_blmid.Text = bolumid;
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            bgl.baglan();
            SqlCommand komut2 = new SqlCommand("delete from bolumler where bolumıd = @p1", bgl.baglan());
            komut2.Parameters.AddWithValue("@p1", txt_blmid.Text);
            komut2.ExecuteNonQuery();
            bgl.baglan().Close();
            MessageBox.Show("Silindi");
            this.bolumlerTableAdapter.Fill(this.yurtkayitDataSet.Bolumler);
        }

        private void btn_güncelle_Click(object sender, EventArgs e)
        {
            bgl.baglan();
            SqlCommand komut3 = new SqlCommand("update Bolumler set bolumad =@p1 where bolumId=@p2", bgl.baglan());
            komut3.Parameters.AddWithValue("@p2", txt_blmid.Text);
            komut3.Parameters.AddWithValue("@p1", txt_blmad.Text);

            komut3.ExecuteNonQuery();
            bgl.baglan().Close();
            MessageBox.Show("Güncellendi");
            this.bolumlerTableAdapter.Fill(this.yurtkayitDataSet.Bolumler);
        }
    }
}
