using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using is_takip_proje.Entity;


namespace is_takip_proje.Formlar
{
    public partial class FrmFirmaListesi : Form
    {
        public FrmFirmaListesi()
        {
            InitializeComponent();
        }
        DbisTakipEntities1 db = new DbisTakipEntities1();


        void listele()
        {
            var degerler = (from x in db.TblFirmalar
                            select new
                            {
                                x.ID,
                                x.Ad,
                                x.Yetkili,
                                x.Telefon,
                                x.Mail,
                                x.Sifre,
                                x.Sektor,
                                x.il,
                                x.ilce,
                                x.Adres
                            }).ToList();
            gridControl1.DataSource = degerler;
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblFirmalar t = new TblFirmalar();
            t.Ad = TxtAd.Text;
            t.Yetkili = TxtYetkili.Text;
            t.Telefon = TxtTelefon.Text;
            t.Mail = TxtSifre.Text;
            t.Sektor = TxtSektor.Text;
            t.il = Txtil.Text;
            t.ilce = Txtilce.Text;
            t.Adres = TxtAdres.Text;
            db.TblFirmalar.Add(t);
            db.SaveChanges();
            MessageBox.Show("Firma Başarılı Bir Şekilde Eklendi", "BİLGİ",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void FrmFirmaListesi_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.TblFirmalar.Find(x);
            db.TblFirmalar.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Firma Silme İşlemi Başarılı", "BAŞARILI");
            listele();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("ID"));
            TxtAd.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Ad"));
            TxtYetkili.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Yetkili"));
            TxtTelefon.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Telefon"));
            TxtMail.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Mail"));
            TxtSifre.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Sifre"));
            TxtSektor.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Sektor"));
            Txtil.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("il"));
            Txtilce.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("ilce"));
            TxtAdres.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Adres"));
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.TblFirmalar.Find(x);
            deger.Ad = TxtAd.Text;
            deger.Yetkili = TxtYetkili.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.Mail = TxtMail.Text;
            deger.Sifre = TxtSifre.Text;
            deger.Sektor = TxtSektor.Text;
            deger.il = Txtil.Text;
            deger.ilce = Txtilce.Text;
            deger.Adres = TxtAdres.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Personel Başarılı Bir Şekilde Güncellendi. ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
        private void TxtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 47 && e.KeyChar < 58 || e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == 32) e.Handled = false; else e.Handled = true;
        }
    }
}
