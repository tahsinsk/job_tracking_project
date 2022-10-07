using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using is_takip_proje.Entity;

namespace is_takip_proje.Formlar
{
    public partial class FrmYeniFirma : Form
    {
        public FrmYeniFirma()
        {
            InitializeComponent();
        }

        DbisTakipEntities1 db = new DbisTakipEntities1();

        void temizle()
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtYetkili.Text = "";
            TxtTelefon.Text = "";
            TxtMail.Text = "";
            TxtSifre.Text = "";
            TxtSektor.Text = "";
            Txtil.Text = "";
            Txtilce.Text = "";
            TxtAdres.Text = "";
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEkle_Click_1(object sender, EventArgs e)
        {
            try
            {
                TblFirmalar t = new TblFirmalar();
                t.Ad = TxtAd.Text.Trim();
                t.Yetkili = TxtYetkili.Text.Trim();
                t.Telefon = TxtTelefon.Text.Trim();
                t.Mail = TxtMail.Text.Trim();
                t.Sifre = TxtSifre.Text.Trim();
                t.Sektor = TxtSektor.Text.Trim();
                t.il = Txtil.Text.Trim();
                t.ilce = Txtilce.Text.Trim();
                t.Adres = TxtAdres.Text.Trim();
                db.TblFirmalar.Add(t);
                db.SaveChanges();
                MessageBox.Show("Firma Başarılı Bir Şekilde Eklendi", "BİLGİ",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();
            }

            catch
            {
                MessageBox.Show("BİÇİM HATASI", "HATA");
            }
        }

        private void TxtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 47 && e.KeyChar < 58 || e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == 32) e.Handled = false; else e.Handled = true;
        }
    }
}
