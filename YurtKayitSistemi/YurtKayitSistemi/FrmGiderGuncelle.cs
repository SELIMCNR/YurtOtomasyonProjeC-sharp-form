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
    public partial class FrmGiderGuncelle : Form
    {
        public FrmGiderGuncelle()
        {
            InitializeComponent();
        }
        public string elektrik ,su ,dogalgaz,gida,diger,internet,personel,id;

        SqlBaglantim bgl = new SqlBaglantim();
  

        private void FrmGiderGuncelle_Load(object sender, EventArgs e)
        {
            TxtGiderid.Text=id;
            TxtElektrik.Text = elektrik;
            TxtGıda.Text = gida;
            TxtSu.Text = su;
            TxtPersonel.Text = personel;
            Txtinternet.Text =internet;
            TxtDogalGaz.Text = dogalgaz;
            TxtDiger.Text = diger;

        }
        private void Btn_Guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtElektrik.Text == "" || TxtElektrik.Text == string.Empty || TxtSu.Text == "" || TxtSu.Text == string.Empty || TxtDogalGaz.Text == "" || TxtDogalGaz.Text == string.Empty || Txtinternet.Text == "" || Txtinternet.Text == string.Empty || TxtGıda.Text == "" || TxtGıda.Text == string.Empty || TxtPersonel.Text == "" || TxtPersonel.Text == string.Empty || TxtDiger.Text == "" || TxtDiger.Text == string.Empty)
            {
                MessageBox.Show("Alanlar boş bırakılamaz");

            }
            else
            {
              
                    SqlCommand komut = new SqlCommand("update Giderler set Elektrik=@p2,Su=@p3,Doğalgaz=@p4,internet=@p5,Gıda=@p6,Personel=@p7,Diger=@p8 where  Odemeid=@p1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", TxtGiderid.Text);
                    komut.Parameters.AddWithValue("@p2", TxtElektrik.Text);
                    komut.Parameters.AddWithValue("@p3", TxtSu.Text);
                    komut.Parameters.AddWithValue("@p4", TxtDogalGaz.Text);
                    komut.Parameters.AddWithValue("@p5", Txtinternet.Text);
                    komut.Parameters.AddWithValue("@p6", TxtGıda.Text);
                    komut.Parameters.AddWithValue("@p7", TxtPersonel.Text);
                    komut.Parameters.AddWithValue("@p8", TxtDiger.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Güncelleme yapıldı");
                }

              
            }
            catch 
            {
               ;
            }
        }
    }
}
