using SinemaOtomasyon.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SinemaOtomasyon.model;

namespace SinemaOtomasyon
{
    public partial class frmYeniSifreOluştur : Form
    {
        public frmYeniSifreOluştur()
        {
            InitializeComponent();
        }

        Calisan c = new Calisan();
        private void btnSifreyiOlustur_Click(object sender, EventArgs e)
        {
            if (txtkullanciadi.Text.Trim() != "" && txtyenisifre.Text.Trim() != "" && txtsifretekrar.Text.Trim() != "")
            {
                if (txtyenisifre.Text == txtsifretekrar.Text)
                {
                    if (c.SifreYenile(txtkullanciadi.Text, txtyenisifre.Text))
                    {
                        MessageBox.Show("Yeni Şifre Oluşturuldu");

                    }

                }
                else
                {
                    MessageBox.Show("Şifreler Birbirleriyle Uyuşmadı");
                }
            }
            else
            {
                MessageBox.Show("Şifre ve Yeni Şifre Boş Bırakılamaz");


            }
        }

        private void frmYeniSifreOluştur_Load(object sender, EventArgs e)
        {
            txtkullanciadi.Text = Genel.kullaniciadi2;

        }

        private void txtkullanciadi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
