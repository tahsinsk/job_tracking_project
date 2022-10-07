﻿using is_takip_proje.Entity;
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
    public partial class FrmCagriKabul : Form
    {
        public FrmCagriKabul()
        {
            InitializeComponent();
        }
        DbisTakipEntities1 db = new DbisTakipEntities1();
        public string mail2;
        private void FrmCagriKabul_Load(object sender, EventArgs e)
        {
            var personelid = db.TblPersonel.Where(x => x.Mail == mail2).Select(y => y.ID).FirstOrDefault();

            gridControl1.DataSource = (from x in db.TblCagrilar
                                       select new
                                       {
                                           x.ID,
                                           x.TblFirmalar.Ad,
                                           x.TblFirmalar.Telefon,
                                           x.TblFirmalar.Mail,
                                           x.Aciklama,
                                           x.CagriPersonel,
                                           x.Durum
                                       }
                           ).Where(y => y.Durum == true && y.CagriPersonel == personelid).ToList();
            gridView1.Columns["Durum"].Visible = false;
            gridView1.Columns["CagriPersonel"].Visible = false;

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmCagriDetayGirisi fr = new FrmCagriDetayGirisi();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }
    }
}
