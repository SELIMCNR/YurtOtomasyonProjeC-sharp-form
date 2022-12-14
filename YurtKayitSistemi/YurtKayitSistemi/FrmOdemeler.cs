using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;// SqlKutuphanesi

namespace YurtKayitSistemi
{
    public partial class FrmOdemeler : Form
    {
        public FrmOdemeler()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();



        private void FrmOdemeler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet2.Borclar' table. You can move, or remove it, as needed.
            this.borclarTableAdapter.Fill(this.yurtOtomasyonDataSet2.Borclar);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            string id, ad, soyad, kalan;
            secilen= dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalan= dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            TxtAd.Text = ad;
            TxtSoyad.Text= soyad;
            txtKalan.Text = kalan;
            Txtİdi.Text = id;
        }

        private void OdemeAl_Click(object sender, EventArgs e)
        {

            if (TxtAd.Text == "" || TxtAd.Text == string.Empty || TxtSoyad.Text == "" || TxtSoyad.Text == string.Empty || txtKalan.Text == "" || txtKalan.Text == string.Empty || Txtİdi.Text == "" || Txtİdi.Text == string.Empty|| TxtOdenenay.Text =="" || TxtOdenenay.Text==string.Empty || TxtOdenen.Text=="" || TxtOdenen.Text==string.Empty)
            {
                MessageBox.Show("Alanlar boş bırakılamaz");

            }
            else
            {
                //Ödenen tutarı kalan tutardan düşme 
                int odenen, kalan, yeniBorc;
                odenen = Convert.ToInt16(TxtOdenen.Text);
                kalan = Convert.ToInt16(txtKalan.Text);
                yeniBorc = kalan - odenen;
                txtKalan.Text = yeniBorc.ToString();

                //Yeni tutarı veri tabanına kaydetme
                SqlCommand komut = new SqlCommand("update Borclar set  OgrKalanBorc=@p1 where Ogrid=@p2", bgl.baglanti());
                komut.Parameters.Add("@p2", Txtİdi.Text);
                komut.Parameters.AddWithValue("@p1", txtKalan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Borç ödendi");
                this.borclarTableAdapter.Fill(this.yurtOtomasyonDataSet2.Borclar);


                //Kasa tablosuna eklem yap
                SqlCommand komut2 = new SqlCommand("insert into Kasa (OdemeAy,OdemeMiktarı) values (@k1,@k2)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@k1", TxtOdenenay.Text);
                komut2.Parameters.AddWithValue("@k2", TxtOdenen.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
        }
    }
}
