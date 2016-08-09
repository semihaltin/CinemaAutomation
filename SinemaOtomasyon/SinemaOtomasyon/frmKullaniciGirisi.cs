using SinemaOtomasyon.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaOtomasyon
{
    public partial class frmKullaniciGirisi : Form
    {
        public frmKullaniciGirisi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmFilmEkle frm = new frmFilmEkle();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmBiletSatis frm = new frmBiletSatis();
            frm.Show();
        }

        private void frmKullaniciGirisi_Load(object sender, EventArgs e)
        {
            tslKullaniciAdi.Text = Genel.kullaniciadi2;
        }

        private void btnSatisRaporu_Click(object sender, EventArgs e)
        {
            frmSatisRaporlama frm = new frmSatisRaporlama();
            frm.Show();
        }
    }
}
