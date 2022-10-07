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
    public partial class FrmDepartmanlar : Form
    {
        public FrmDepartmanlar()
        {
            InitializeComponent();
        }
       
        DbisTakipEntities1 db = new DbisTakipEntities1();
        void listele()
        {

            var degerler = (from x in db.TblDepartmanlar //x adında sanal degisken olusturma 
                            select new
                            {
                                x.ID,                //degerler kısmı griddte sadece istediğimiz kısımları görmek için.
                                x.Ad
                            }).ToList();

            gridControl1.DataSource = degerler;     //eğer tüm sutunları gormek isteseydik degerler yerine db.Tbldepartmanlar.tolist(); komutunu kullanacaktık.
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString(); //Seçilen ID ve AD'ı text kutularına aktarma.
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
        }

        private void BtnListele_Click_1(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnEkle_Click_1(object sender, EventArgs e)
        {
            if (TxtAd.Text == "")
            {
                XtraMessageBox.Show("Lütfen Departman Adını Giriniz.", "HATA");
            }
            else
            {
                TblDepartmanlar t = new TblDepartmanlar();    //Veri Ekledik
                t.Ad = TxtAd.Text;
                db.TblDepartmanlar.Add(t);
                db.SaveChanges();
                XtraMessageBox.Show("Departman Başarılı Bir Şekilde Oluşturuldu", "BİLGİ", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                listele();
            }
        }

        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            if (TxtID.Text == "")
            {
                XtraMessageBox.Show("Lütfen Silmek İstediğiniz Departmanı Seçiniz", "HATA");
            }
            else
            {
                int x = int.Parse(TxtID.Text);
                var deger = db.TblDepartmanlar.Find(x);
                db.TblDepartmanlar.Remove(deger);
                db.SaveChanges();
                XtraMessageBox.Show("Departman Silme İşlemi Başarılı Bir Şekilde Gerçekleşti. ", "BİLGİ",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        private void BtnGuncelle_Click_1(object sender, EventArgs e)
        {
            if (TxtID.Text == "")
            {
                XtraMessageBox.Show("Lütfen Güncellemek İstediğiniz Departmanı Seçiniz", "HATA");
            }
            else
            {
                int x = int.Parse(TxtID.Text);
                var deger = db.TblDepartmanlar.Find(x);
                deger.Ad = TxtAd.Text;

                db.SaveChanges();
                XtraMessageBox.Show("Departman Güncelleme İşlemi Başarılı Bir Şekilde Gerçekleşti. ", "BİLGİ",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        private void FrmDepartmanlar_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
