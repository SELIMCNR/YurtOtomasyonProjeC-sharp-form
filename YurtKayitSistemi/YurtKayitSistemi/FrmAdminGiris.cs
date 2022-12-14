using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayitSistemi
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        private void Btn_GirisYap_Click(object sender, EventArgs e)
        {
            if(TxtKullaniciAd.Text=="admin1234" && TxtSifre.Text == "1234")
            {
                frmAnaForm fr = new frmAnaForm();
                fr.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız");
            }
        }
    }
}
