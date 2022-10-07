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
    public partial class FrmFirmaİstatistik : Form
    {
        public FrmFirmaİstatistik()
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
                                x.Sektor

                            }).ToList();
            gridControl1.DataSource = degerler;
        }
        private void FrmFirmaİstatistik_Load(object sender, EventArgs e)
        {
            listele();

            int egitim = db.TblFirmalar.Where(x => x.Sektor == "Eğitim").Count();
            int turizm = db.TblFirmalar.Where(x => x.Sektor == "Turizm").Count();
            int bankacılık = db.TblFirmalar.Where(x => x.Sektor == "Bankacılık").Count();
            int Gıda = db.TblFirmalar.Where(x => x.Sektor == "Gıda").Count();

            chartControl1.Series["Firma"].Points.AddPoint("Eğitim", egitim);
            chartControl1.Series["Firma"].Points.AddPoint("Turizm", turizm);
            chartControl1.Series["Firma"].Points.AddPoint("Bankacılık", bankacılık);
            chartControl1.Series["Firma"].Points.AddPoint("Gıda", Gıda);

            LblToplamFirma.Text = db.TblFirmalar.Count().ToString();
        }
    }
}
