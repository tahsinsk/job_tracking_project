using DevExpress.XtraEditors;
using is_takip_proje.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace is_takip_proje.Login
{
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();
        }

        DbisTakipEntities1 db = new DbisTakipEntities1();


        private void button2_Click(object sender, EventArgs e)
        {
            PersonelGorevFormları.FrmPersonelFormu fr = new PersonelGorevFormları.FrmPersonelFormu();
            fr.Show();
        }

        private void BtnAdmin_Click_1(object sender, EventArgs e)
        {
            var adminvalue = db.TblAdmin.Where(x => x.Kullanici == TxtKullanici.Text && x.Sifre ==
           TxtSifre.Text).FirstOrDefault();
            if (adminvalue != null)
            {
                XtraMessageBox.Show("Hoşgeldiniz", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 fr = new Form1();
                fr.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Hatalı Giriş");
            }
        }

        private void BtnPersonel_Click_1(object sender, EventArgs e)
        {
            var personel = db.TblPersonel.Where(x => x.Mail == TxtKullanici.Text && x.Sifre ==
           TxtSifre.Text).FirstOrDefault();
            if (personel != null)
            {
                XtraMessageBox.Show("Hoşgeldiniz", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PersonelGorevFormları.FrmPersonelFormu fr = new PersonelGorevFormları.FrmPersonelFormu();
                fr.mail = TxtKullanici.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Hatalı Giriş");
            }
        }


        DialogResult cik;
        private void hyperlinkLabelControl4_Click(object sender, EventArgs e)
        {
            cik = XtraMessageBox.Show("Sistemden Çıkılsın mı?", "ÇIKIŞ", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (cik == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Lütfen Yetkili Birime Başvurunuz", "BİLGİ");
        }


        private void hyperlinkLabelControl3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://localhost:44383/login");
        }
    }
}
