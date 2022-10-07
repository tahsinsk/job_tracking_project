using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_takip_proje.PersonelGorevFormları
{
    public partial class FrmPersonelFormu : Form
    {
        public FrmPersonelFormu()
        {
            InitializeComponent();
        }
        public string mail;

        PersonelGorevFormları.FrmAktifGorevler fr;
        private void BtnAktifGorevler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new PersonelGorevFormları.FrmAktifGorevler();
                fr.MdiParent = this;
                fr.Show();

            }
        }

       
        PersonelGorevFormları.FrmPasifGorevler fr1;
        private void BtnPasifGorevler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr1 == null || fr1.IsDisposed)
            {
                fr1 = new PersonelGorevFormları.FrmPasifGorevler();
                fr1.MdiParent = this;
                fr1.Show();
            }
        }
      
        
        PersonelGorevFormları.FrmCagriKabul fr2;
        private void BtnCagriListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new PersonelGorevFormları.FrmCagriKabul();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }

        private void FrmPersonelFormu_Load(object sender, EventArgs e)
        {
            this.Text = "Personel Paneli | "+ "Personel: " + mail.ToString();
        }

        private void FrmPersonelFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
