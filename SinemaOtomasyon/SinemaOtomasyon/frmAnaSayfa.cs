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
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Genel.connstr);
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifreUnuttum frm = new SifreUnuttum();
            frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Genel.kullaniciadi2 = txtkullaniciadi.Text; ;
            if (txtkullaniciadi.Text.Trim() != "" && txtsifre.Text.Trim() != "")
            {
                if (rbyonetici.Checked)
                {
                    if (txtkullaniciadi.Text == "nesrinulgay" && txtsifre.Text == "123456" || txtkullaniciadi.Text == "semihaltin" && txtsifre.Text == "789456" || txtkullaniciadi.Text == "handenuresen" && txtsifre.Text == "741852")
                    {
                        frmYoneticiGirisi frm = new frmYoneticiGirisi();
                        frm.Show();

                    }

                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya Şifre Hatalı", "UYARI");

                    }
                }

                else if (rbcalisan.Checked)
                {
                    SqlCommand cmd = new SqlCommand("Select * from CalisanBilgileri where KullaniciAdi=@ad and Sifre=@sifre", conn);
                    cmd.Parameters.AddWithValue("@ad", txtkullaniciadi.Text);
                    cmd.Parameters.AddWithValue("@sifre", txtsifre.Text);
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    try
                    {
                        if (dr.HasRows)
                        {
                            frmKullaniciGirisi frm = new frmKullaniciGirisi();
                            frm.Show();

                        }
                        else
                        {

                            MessageBox.Show("Kullanıcı adı veya Şifre Hatalı", "UYARI");
                        }
                    }
                    catch (SqlException ex)
                    {
                        string hata = ex.Message;
                    }
                    finally
                    {
                        dr.Close(); conn.Close();
                    }
                }
            
            }
            else
            {

                MessageBox.Show("Kullanıcı Adı ve Şifre boş bırakılamaz", "UYARI");
            }
            Temizle();
        }
        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            
        }

        private void rbyonetici_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbcalisan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void Temizle()
        {
            txtkullaniciadi.Clear();
            txtsifre.Clear();


        }
    }
}
