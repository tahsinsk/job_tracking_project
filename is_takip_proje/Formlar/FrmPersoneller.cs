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
//using DevExpress.XtraEditors;

namespace is_takip_proje.Formlar
{
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }
    
        DbisTakipEntities1 db = new DbisTakipEntities1();

        public object XtraMessage { get; private set; }

        void Personeller()
        {
            var degerler = (from x in db.TblPersonel
                            select new
                            {
                                x.ID,
                                x.Ad,
                                x.Soyad,
                                x.Mail,
                                x.Telefon,
                                departman = x.TblDepartmanlar.Ad,
                                x.Durum,
                                x.Rol,
                                x.Sifre
                            });
            gridControl1.DataSource = degerler.Where(x => x.Durum == true).ToList();
        }

        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            Personeller();
            var departmanlar = (from x in db.TblDepartmanlar           //db.TblDepartmanlar.ToList();
                                select new
                                {
                                    x.ID,
                                    x.Ad
                                }).ToList();

            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.DataSource = departmanlar;
           
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Personeller();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblPersonel t = new TblPersonel();
            t.Ad = TxtAd.Text;
            t.Soyad = TxtSoyad.Text;
            t.Mail = TxtMail.Text;
            t.Telefon = TxtTelefon.Text;
            t.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            t.Rol = TxtRol.Text;
            t.Sifre = TxtSifre.Text;
             t.Durum = true;
            db.TblPersonel.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Yeni Personel Kaydı Başarılı Bir Şekilde Gerçekleşti.", "BİLGİ"
            , MessageBoxButtons.OK, MessageBoxIcon.Information);
            Personeller();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var x = int.Parse(TxtID.Text);
            var deger = db.TblPersonel.Find(x);
            db.TblPersonel.Remove(deger);
            //deger.Durum = false;
            db.SaveChanges();
            XtraMessageBox.Show("Personel Başarılı Bir Şekilde Silindi. Silinen Personel Listesinden Tüm " +
                "Silinen Personel Bilgilerine Ulaşabilirsiniz..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Personeller();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            TxtTelefon.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Telefon"));
            //lookUpEdit1.EditValue = gridView1.GetFocusedRowCellValue("departman").ToString();
            lookUpEdit1.Text = Convert.ToString( gridView1.GetFocusedRowCellValue("departman"));
            TxtDurum.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Durum"));
            TxtSifre.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Sifre"));
            TxtRol.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Rol"));
           
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.TblPersonel.Find(x);
            deger.Ad = TxtAd.Text;
            deger.Soyad = TxtSoyad.Text;
            deger.Mail = TxtMail.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            deger.Rol = TxtRol.Text;
            deger.Sifre = TxtSifre.Text;
            deger.Durum = true;
            db.SaveChanges();
            XtraMessageBox.Show("Personel Başarılı Bir Şekilde Güncellendi. ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Personeller();
        }

        private void TxtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 47 && e.KeyChar < 58 || e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == 32) e.Handled = false; else e.Handled = true;
        }
    }
}
