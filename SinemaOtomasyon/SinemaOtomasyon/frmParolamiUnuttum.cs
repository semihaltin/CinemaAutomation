using SinemaOtomasyon.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SinemaOtomasyon.model;

namespace SinemaOtomasyon
{
    public partial class SifreUnuttum : Form
    {
        public SifreUnuttum()
        {
            InitializeComponent();
        }


        SqlConnection conn = new SqlConnection(Genel.connstr);
        private void btnsifreolus_Click(object sender, EventArgs e)
        {
            Genel.kullaniciadi2 = txtkullaniciadi1.Text;
            SqlCommand cmd = new SqlCommand("Select KullaniciAdi,Cevap from CalisanBilgileri where  KullaniciAdi=@kadi  and Cevap=@cevap  ", conn);
            cmd.Parameters.AddWithValue("@kadi", txtkullaniciadi1.Text);

            cmd.Parameters.AddWithValue("@cevap", txtcevap.Text);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {

                while (dr.Read())
                {

                    if (txtkullaniciadi1.Text == dr["KullaniciAdi"].ToString() && txtcevap.Text == dr["Cevap"].ToString())
                    {
                        frmYeniSifreOluştur frm = new frmYeniSifreOluştur();
                        frm.Show();
                    }
                      else if (txtkullaniciadi1.Text != dr["KullaniciAdi"].ToString() || txtcevap.Text != dr["Cevap"].ToString())
                    {
                        MessageBox.Show("olmadı");
                    }


                }
            }


            catch (SqlException ex)
            {
                string mesaj = ex.Message;


            }
            conn.Close();
        }

        private void SifreUnuttum_Load(object sender, EventArgs e)
        {

        }
    }



}
