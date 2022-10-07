using DevExpress.XtraEditors;
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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }
    
        DbisTakipEntities1 db = new DbisTakipEntities1();

        void temizle()
        {
            TxtID.Text = "";
            TxtDepartmanAdi.Text = "";
        }
        private void BtnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtDepartmanAdi.Text == "")
            {
                XtraMessageBox.Show("Lütfen Departman Adını Giriniz");
            }
            else
            {
                TblDepartmanlar t = new TblDepartmanlar();
                t.Ad = TxtDepartmanAdi.Text.Trim();
                db.TblDepartmanlar.Add(t);
                db.SaveChanges();
                XtraMessageBox.Show("Departman başarılı bir şekilde oluşturulmuştur", "BİLGİ",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();
            }
        }
    }
}
