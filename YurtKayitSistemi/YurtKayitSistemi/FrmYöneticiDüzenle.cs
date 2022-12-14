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

namespace YurtKayitSistemi
{
    public partial class FrmYöneticiDüzenle : Form
    {
        public FrmYöneticiDüzenle()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet6.Yoneticiler' table. You can move, or remove it, as needed.
            this.yoneticilerTableAdapter.Fill(this.yurtOtomasyonDataSet6.Yoneticiler);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtKullaniciAd.Text == "" || TxtKullaniciAd.Text == string.Empty || TxtSifre.Text== "" ||TxtSifre.Text == string.Empty)
            {
                MessageBox.Show("Alanlar boş bırakılamaz");

            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into Yoneticiler (YoneticiAd,YoneticiSifre) values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yönetici eklendi");
                this.yoneticilerTableAdapter.Fill(this.yurtOtomasyonDataSet6.Yoneticiler);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ad, sifre,id;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            sifre = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            TxtKullaniciAd.Text = ad;
            TxtSifre.Text = sifre;
            TxtYoneticİd.Text = id;
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Yoneticiler where Yoneticiid=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtYoneticİd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Silme işlemi Gerçekleşti");
            this.yoneticilerTableAdapter.Fill(this.yurtOtomasyonDataSet6.Yoneticiler);
        }

        private void BtnDüzenle_Click(object sender, EventArgs e)
        {
            if (TxtKullaniciAd.Text == "" || TxtKullaniciAd.Text == string.Empty || TxtSifre.Text == "" || TxtSifre.Text == string.Empty)
            {
                MessageBox.Show("Alanlar boş bırakılamaz");

            }
            else
            {
                SqlCommand komut = new SqlCommand("update Yoneticiler set YoneticiAd=@p1,YoneticiSifre=@p2 where Yoneticiid=@p3", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
                komut.Parameters.AddWithValue("@p3", TxtYoneticİd.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Güncelleme gerçekleşti");
                this.yoneticilerTableAdapter.Fill(this.yurtOtomasyonDataSet6.Yoneticiler);
            }
        }
    }
}
