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
using System.Linq.Expressions;

namespace YurtKayitSistemi
{
    public partial class FrmOgrKayit : Form
    {
        public FrmOgrKayit()
        {
            InitializeComponent();
        }

        /*Sql server bağlantısı ve tablodan veri çekme*/
        
       SqlBaglantim bgl = new SqlBaglantim();
        private void Form1_Load(object sender, EventArgs e)
        {/*Bölümleri Listeleme Komutları*/
       
            SqlCommand komut = new SqlCommand("Select BolumAd From Bolumler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                CmbBolum.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();

            /*Boş odaları listeleme*/
      
            SqlCommand komut2 = new SqlCommand("Select OdaNo From Odalar where OdaKapasite != OdaAktif ", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbOdaNo.Items.Add(oku2[0].ToString());


            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            
                
               
                    //Öğrenci bilgilerini kayıt etme komutları 
                    if (TxtOgrAd.Text == "" || TxtOgrAd.Text == string.Empty || TxtOgrSoyad.Text == "" || TxtOgrSoyad.Text == string.Empty || MskTc.Text == "" || MskTc.Text == string.Empty || MskOgrTelefon.Text == "" || MskOgrTelefon.Text == string.Empty || MskDogum.Text == "" || MskDogum.Text == string.Empty || txtMail.Text == "" || txtMail.Text == string.Empty || txtVeliAdSoyad.Text == "" || txtVeliAdSoyad.Text == string.Empty || MskVeliTelefon.Text == "" || MskVeliTelefon.Text == string.Empty || RchAdres.Text == "" || RchAdres.Text == string.Empty)
                {
                    MessageBox.Show("Alanlar boş bırakılamaz");

                }
                else
                {
                


                        SqlCommand komutkaydet = new SqlCommand("insert into Ogrenci (OgrAd,OgrSoyad,OgrTc,OgrTelefon,OgrDogum,OgrBolum,OgrMail,OgrOdaNo,OgrVeliAdSoyad,OgrVeliTelefon,OgrVeliAdres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti()); // eklemeler yap
                        komutkaydet.Parameters.AddWithValue("@p1", TxtOgrAd.Text); // alanlara ekler
                        komutkaydet.Parameters.AddWithValue("@p2", TxtOgrSoyad.Text);
                        komutkaydet.Parameters.AddWithValue("@p3", MskTc.Text);
                        komutkaydet.Parameters.AddWithValue("@p4", MskOgrTelefon.Text);
                        komutkaydet.Parameters.AddWithValue("@p5", MskDogum.Text);
                        komutkaydet.Parameters.AddWithValue("@p6", CmbBolum.Text);
                        komutkaydet.Parameters.AddWithValue("@p7", txtMail.Text);
                        komutkaydet.Parameters.AddWithValue("@p8", CmbOdaNo.Text);
                        komutkaydet.Parameters.AddWithValue("@p9", txtVeliAdSoyad.Text);
                        komutkaydet.Parameters.AddWithValue("@p10", MskVeliTelefon.Text);
                        komutkaydet.Parameters.AddWithValue("@p11", RchAdres.Text);
                        komutkaydet.ExecuteNonQuery(); // Sorgular üzerinde değişiklikleri yapar
                        bgl.baglanti().Close();
                        MessageBox.Show("Kayıt başarılı bir şekilde eklendi");

                        //Öğrenci id labela ekleme
                        SqlCommand komut = new SqlCommand("select Ogrid from Ogrenci", bgl.baglanti());
                        SqlDataReader oku = komut.ExecuteReader();
                        while (oku.Read())
                        {
                            label12.Text = oku[0].ToString();
                        }
                        bgl.baglanti().Close();

                        //Öğrenci Borç alanı oluşturma
                        SqlCommand komutkaydet2 = new SqlCommand("insert into Borclar (OgrAd,OgrSoyad) values (@b2,@b3)", bgl.baglanti());
                        komutkaydet2.Parameters.AddWithValue("@b2", TxtOgrAd.Text);
                        komutkaydet2.Parameters.AddWithValue("@b3", TxtOgrSoyad.Text);
                        komutkaydet2.ExecuteNonQuery();
                        bgl.baglanti().Close();


                        //Öğrenci oda kontenjanı artırma
                        SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif = OdaAktif+1 where OdaNo = @oda", bgl.baglanti());
                        komutoda.Parameters.AddWithValue("@oda", CmbOdaNo.Text);
                        komutoda.ExecuteNonQuery();
                        bgl.baglanti().Close();

                    }
                   
                     }

        private void txtVeliAdSoyad_TextChanged(object sender, EventArgs e)
        {

        }
    }
        

    }




        //Data Source=DESKTOP-6G93D3J\\SQLEXPRESS;Initial Catalog=YurtOtomasyon;Integrated Security=True   
    

