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
    public partial class FrmDepartmanIstatistik : Form
    {
        public FrmDepartmanIstatistik()
        {
            InitializeComponent();
        }
    
        DbisTakipEntities1 db = new DbisTakipEntities1();
        private void FrmDepartmanIstatistik_Load(object sender, EventArgs e)
        {
  
            int bilgiislem = db.TblPersonel.Where(x => x.TblDepartmanlar.Ad == "Bilgi İşlem").Count();
            int Muhasebe = db.TblPersonel.Where(x => x.TblDepartmanlar.Ad == "Muhasebe").Count();
            int danisma = db.TblPersonel.Where(x => x.TblDepartmanlar.Ad == "Danışma").Count();
            int ik = db.TblPersonel.Where(x => x.TblDepartmanlar.Ad == "İnsan Kaynakları").Count();
            int müdür = db.TblPersonel.Where(x => x.TblDepartmanlar.Ad == "Müdür").Count();
            int müdüryrd = db.TblPersonel.Where(x => x.TblDepartmanlar.Ad == "Müdür Yardımcısı").Count();
            int temizlik = db.TblPersonel.Where(x => x.TblDepartmanlar.Ad == "Temizlik").Count();
            int Mutfakyemek = db.TblPersonel.Where(x => x.TblDepartmanlar.Ad == "Mutfak ve Yemek").Count();
            int ulasim = db.TblPersonel.Where(x => x.TblDepartmanlar.Ad == "Ulaşım").Count();
            int Stajyer = db.TblPersonel.Where(x => x.TblDepartmanlar.Ad == "Stajyer").Count();

            chartControl1.Series["Departman"].Points.AddPoint("Bilgi İşlem", bilgiislem);
            chartControl1.Series["Departman"].Points.AddPoint("Muhasebe", Muhasebe);
            chartControl1.Series["Departman"].Points.AddPoint("Danışma",danisma);
            chartControl1.Series["Departman"].Points.AddPoint("İnsan Kaynakları",ik);
            chartControl1.Series["Departman"].Points.AddPoint("Müdür", müdür);
            chartControl1.Series["Departman"].Points.AddPoint("Müdür Yardımcısı", müdüryrd);
            chartControl1.Series["Departman"].Points.AddPoint("Temizlik", temizlik);
            chartControl1.Series["Departman"].Points.AddPoint("Mutfak ve Yemek", Mutfakyemek);
            chartControl1.Series["Departman"].Points.AddPoint("Ulaşım", ulasim);
            chartControl1.Series["Departman"].Points.AddPoint("Stajyer", Stajyer);

        }


    }
}
