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
    public partial class FrmGider : Form
    {
        public FrmGider()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtElektrik.Text == "" || TxtElektrik.Text == string.Empty || TxtSu.Text == "" || TxtSu.Text == string.Empty|| TxtDogalGaz.Text == "" || TxtDogalGaz.Text == string.Empty|| Txtinternet.Text == "" || Txtinternet.Text == string.Empty || TxtGıda.Text == "" || TxtGıda.Text == string.Empty || TxtPersonel.Text == "" || TxtPersonel.Text == string.Empty || TxtDiğer.Text == "" || TxtDiğer.Text == string.Empty)
            {
                MessageBox.Show("Alanlar boş bırakılamaz");

            }
            else
            {
              
                    SqlCommand komut = new SqlCommand("insert into Giderler (Elektrik,Su,Dogalgaz,internet,Gıda,Personel,Diger) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", TxtElektrik.Text);
                    komut.Parameters.AddWithValue("@p2", TxtSu.Text);
                    komut.Parameters.AddWithValue("@p3", TxtDogalGaz.Text);
                    komut.Parameters.AddWithValue("@p4", Txtinternet.Text);
                    komut.Parameters.AddWithValue("@p5", TxtGıda.Text);
                    komut.Parameters.AddWithValue("@p6", TxtPersonel.Text);
                    komut.Parameters.AddWithValue("@p7", TxtDiğer.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Kayıtlar eklendi");
                }
               
            }
            catch 
            {
               ;
            }

        }
    }
}
