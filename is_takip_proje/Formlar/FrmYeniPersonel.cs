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
    public partial class FrmYeniPersonel : Form
    {
        public FrmYeniPersonel()
        {
            InitializeComponent();
        }
        DbisTakipEntities1 db = new DbisTakipEntities1();
        public object XtraMessage { get; private set; }

        void temizle()
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtTelefon.Text = "";
            lookUpEdit1.EditValue = -1;
            TxtRol.Text = "";
            TxtSifre.Text = "";
            TxtDurum.Text = "";
            TxtMail.Text = "";

        }

        private void FrmYeniPersonel_Load(object sender, EventArgs e)
        {
            
            var departmanlar = (from x in db.TblDepartmanlar           //db.TblDepartmanlar.ToList();
                                select new
                                {
                                    x.ID,
                                    x.Ad,
                                }).ToList();

            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.DataSource = departmanlar;
        }

        private void BtnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEkle_Click_1(object sender, EventArgs e)
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
            temizle();
        }

        private void TxtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 47 && e.KeyChar < 58 || e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == 32) e.Handled = false; else e.Handled = true;
        }
    }
}
