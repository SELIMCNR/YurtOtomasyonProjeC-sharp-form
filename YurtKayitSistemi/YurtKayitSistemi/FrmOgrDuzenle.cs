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

namespace YurtKayitSistemi
{
    public partial class FrmOgrDuzenle : Form
    {
        public FrmOgrDuzenle()
        {
            InitializeComponent();
        }

        public string id,ad,soyad,TC,telefon,dogum,bolum;

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from Ogrenci where ogrid=@k1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@k1", txtOgrİdi.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt silindi");

            //Oda kontenjanı artırma
            SqlCommand komutoda = new SqlCommand("update odalar set OdaAktif=OdaAktif-1 where OdaNo=@oda", bgl.baglanti());
            komutoda.Parameters.AddWithValue("@oda",CmbOdaNo.Text);
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        public string mail, odano, veliad, velitel, adres;
        
        SqlBaglantim bgl = new SqlBaglantim();
        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (  TxtOgrAd.Text == "" || TxtOgrAd.Text == string.Empty || TxtOgrSoyad.Text == "" || TxtOgrSoyad.Text == string.Empty || MskTc.Text == "" || MskTc.Text == string.Empty || MskOgrTelefon.Text == "" || MskOgrTelefon.Text == string.Empty || MskDogum.Text == "" || MskDogum.Text == string.Empty  || txtMail.Text == "" || txtMail.Text== string.Empty || txtVeliAdSoyad.Text =="" || txtVeliAdSoyad.Text == string.Empty || MskVeliTelefon.Text == "" || MskVeliTelefon.Text == string.Empty || RchAdres.Text =="" ||RchAdres.Text == string.Empty  )
            {
                MessageBox.Show("Alanlar boş bırakılamaz");

            }
            else
            {
             
                    SqlCommand komut = new SqlCommand("update Ogrenci set OgrAd = @p2 , OgrSoyad=@p3 , OgrTc = @p4,OgrTelefon=@p5,OgrDogum=@p6,OgrBolum=@p7,OgrMail=@p8,OgrOdaNo=@p9,OgrVeliAdSoyad=@p10,OgrVeliTelefon=@p11,OgrVeliAdres=@p12  where Ogrid=@p1 ", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", txtOgrİdi.Text);
                    komut.Parameters.AddWithValue("@p2", TxtOgrAd.Text);
                    komut.Parameters.AddWithValue("@p3", TxtOgrSoyad.Text);
                    komut.Parameters.AddWithValue("@p4", MskTc.Text);
                    komut.Parameters.AddWithValue("@p5", MskOgrTelefon.Text);
                    komut.Parameters.AddWithValue("@p6", MskDogum.Text);
                    komut.Parameters.AddWithValue("@p7", CmbBolum.Text);
                    komut.Parameters.AddWithValue("@p8", txtMail.Text);
                    komut.Parameters.AddWithValue("@p9", CmbOdaNo.Text);
                    komut.Parameters.AddWithValue("@p10", txtVeliAdSoyad.Text);
                    komut.Parameters.AddWithValue("@p11", MskVeliTelefon.Text);
                    komut.Parameters.AddWithValue("@p12", RchAdres.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Kayıt Güncellendi");
                }
              
            }
            catch
            {
                ;
            }

        }

      
        private void FrmOgrDuzenle_Load(object sender, EventArgs e)
        {
            txtOgrİdi.Text = id;
            TxtOgrAd.Text = ad;
            TxtOgrSoyad.Text = soyad;
            MskTc.Text = TC;
            MskOgrTelefon.Text = telefon;
            MskDogum.Text = dogum;
            CmbBolum.Text = bolum;
            txtMail.Text = mail;
            CmbOdaNo.Text = odano;
            txtVeliAdSoyad.Text = veliad;
            MskVeliTelefon.Text = velitel;
            RchAdres.Text = adres;
        }

       
    }
}
