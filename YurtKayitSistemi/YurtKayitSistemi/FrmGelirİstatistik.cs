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
    public partial class FrmGelirİstatistik : Form
    {
        public FrmGelirİstatistik()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

        private void FrmGelirİstatistik_Load(object sender, EventArgs e)
        {
            //Kasadaki toplam tutar
            SqlCommand komut = new SqlCommand("Select Sum(OdemeMiktarı) from Kasa", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                LblPara.Text= oku[0].ToString() + "TL";
            }
            bgl.baglanti().Close();


            //Tekrarsız olarak ayları listeleme
            SqlCommand komut2 = new SqlCommand("Select distinct(OdemeAy) from Kasa",bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while(oku2.Read())
            {
                CmbAy.Items.Add(oku2[0].ToString());
            }

            bgl.baglanti().Close();

            //Aylık kazanç manuel
            /*  this.chart1.Series["Aylık"].Points.AddXY("Mayıs",15);
              this.chart1.Series["Aylık"].Points.AddY(22);
              this.chart1.Series["Aylık"].Points.AddY(13);
            */
            //Grafiklere veri çekme
            SqlCommand komut4 = new SqlCommand("Select  OdemeAy,sum(OdemeMiktarı) From Kasa group by OdemeAy", bgl.baglanti());
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                this.chart1.Series["Aylık"].Points.AddXY(oku4[0], oku4[1]);
            }
            bgl.baglanti().Close();
        }

        private void CmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select sum(OdemeMiktarı) From Kasa where OdemeAy=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbAy.Text);
            SqlDataReader oku =komut.ExecuteReader();
            while(oku.Read()) 
            {
                LblAyKazanc.Text = oku[0].ToString();   
            }
            bgl.baglanti().Close();
        }
    }
}
