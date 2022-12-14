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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace YurtKayitSistemi
{
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet.Bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);

        }
       
        private void PcbBolumEkle_Click(object sender, EventArgs e)
        {


            try
            {
                if (txtBolumadi.Text == "" || txtBolumadi.Text == string.Empty)
                {
                    MessageBox.Show("Alanlar boş bırakılamaz");

                }
                else
                {
                    SqlCommand komut1 = new SqlCommand("insert into Bolumler (BolumAd) values (@p1)", bgl.baglanti());
                    komut1.Parameters.AddWithValue("@p1", txtBolumadi.Text);
                    komut1.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Bölüm Eklendi");
                    this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);
                }
            }
            catch
            {
                MessageBox.Show("Hata oluştu yeniden deneyin");
            }

          
        }

        private void PcbBolumSil_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlCommand komut2 = new SqlCommand("delete from bolumler where Bolumid=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1",TxtBolumidi.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme işlemi gerçekleşti");
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);
            }
            catch (Exception)
            {
                MessageBox.Show("Hata,işlem gerçekleşmedi");
            }

        }
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, bolumad;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

            TxtBolumidi.Text = id;
            txtBolumadi.Text = bolumad;

        }

        private void PcbBolumDuzenle_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtBolumadi.Text == "" || txtBolumadi.Text == string.Empty)
                {
                    MessageBox.Show("Alanlar boş bırakılamaz");

                }
                else
                {
                    SqlCommand komut2 = new SqlCommand("update Bolumler Set Bolumad =@p1 where Bolumid=@p2", bgl.baglanti());
                    komut2.Parameters.AddWithValue("@p2", TxtBolumidi.Text); //seçili bölümü değiştir
                    komut2.Parameters.AddWithValue("@p1", txtBolumadi.Text);
                    komut2.ExecuteNonQuery(); // işlemi yapma
                    bgl.baglanti().Close();
                    MessageBox.Show("Güncelleme gerçekleşti");
                    this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler); // güncelleme işlemi 

                }
            }
            catch
            {
                MessageBox.Show("Hata");
            }

            }
    }
}
