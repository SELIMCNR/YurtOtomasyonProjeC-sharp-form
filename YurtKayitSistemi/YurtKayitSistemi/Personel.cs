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
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();

        private void Personel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet7.Personel' table. You can move, or remove it, as needed.
            this.personelTableAdapter.Fill(this.yurtOtomasyonDataSet7.Personel);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtPersonelAd.Text == "" || TxtPersonelAd.Text == string.Empty || TxtPersonelGrv.Text == "" || TxtPersonelGrv.Text == string.Empty )
            {
                MessageBox.Show("Alanlar boş bırakılamaz");

            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into Personel (PersonelAdSoyad,PersonelDepartman) values(@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtPersonelAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtPersonelGrv.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt eklendi");
                this.personelTableAdapter.Fill(this.yurtOtomasyonDataSet7.Personel);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ad, id, departman;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            departman = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            TxtPersonelİd.Text = id;
            TxtPersonelAd.Text = ad;
            TxtPersonelGrv.Text = departman;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            

            SqlCommand komut = new SqlCommand("delete from Personel where Personelİd=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtPersonelİd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Silme işlemi Gerçekleşti");
            this.personelTableAdapter.Fill(this.yurtOtomasyonDataSet7.Personel);
        }

        private void BtnDüzenle_Click(object sender, EventArgs e)
        {
            if (TxtPersonelAd.Text == "" || TxtPersonelAd.Text == string.Empty || TxtPersonelGrv.Text == "" || TxtPersonelGrv.Text == string.Empty)
            {
                MessageBox.Show("Alanlar boş bırakılamaz");

            }
            else
            {
                SqlCommand komut = new SqlCommand("update Personel set PersonelAdSoyad=@p1,PersonelDepartman=@p2 where Personelİd=@p3", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtPersonelAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtPersonelGrv.Text);
                komut.Parameters.AddWithValue("@p3", TxtPersonelİd.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Güncelleme gerçekleşti");
                this.personelTableAdapter.Fill(this.yurtOtomasyonDataSet7.Personel);
            }
        }

      
    }
}
