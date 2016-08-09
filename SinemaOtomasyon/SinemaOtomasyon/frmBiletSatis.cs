using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SinemaOtomasyon.model;
using System.Data.SqlClient;
using System.IO;
using SinemaOtomasyon.Class;

namespace SinemaOtomasyon
{
    public partial class frmBiletSatis : Form
    {
        public frmBiletSatis()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Genel.connstr);
        private void frmBiletSatis_Load(object sender, EventArgs e)
        {
            film f = new film();
            seans s = new seans();
             lvSalonsec.Enabled = false;

            f.filmadigetir(cbvizyondafilmgetir);
            btnBiletAl.Enabled = false;
            resimcagir();
           
        


        }

        private void cbvizyondafilmgetir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbvizyondafilmgetir.SelectedItem != null)
            {
                film f = (film)cbvizyondafilmgetir.SelectedItem;
               
                txtvizyonFilmID.Text = f.Filmid.ToString();
                seans s = new seans();
                Salon sa = new Salon();
                s.FilmSeansVizyonGetir(Convert.ToInt32(txtvizyonFilmID.Text), lbSeansSaatleri);
                sa.FilmSalonVizyonGetir(Convert.ToInt32(txtvizyonFilmID.Text), lvSalonsec);
                lvsecilenler.Items.Add(cbvizyondafilmgetir.SelectedItem.ToString());
                cbvizyondafilmgetir.Enabled = false;
                txtFilmAdiGetir.Text = cbvizyondafilmgetir.SelectedItem.ToString();
            }
           
           

                



        }

        private void lbSeansSaatleri_DoubleClick(object sender, EventArgs e)
        {
            //txtsenassaatvizyon.Text = lbSeansSaatleri.SelectedItem.ToString();
        }

        private void lbSeansSaatleri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void salonvizyoncagir(int filmID, string baslangicSaati)
        {
           //SqlCommand comm=new SqlCommand("select SalonAd from Film_Salon inner join Salonlar on Film_Salon.SalonID=Salonlar.SalonID inner join Seans_Filmler on Seans_Filmler.FilmID=Film_Salon.FilmID inner join Seanslar on Seanslar.SeansID=Seans_Filmler.SeansID where BaslangicSaati=@baslangicsaati and Film_Salon.FilmID=@filmID


        }

        private void lbSeansSaatleri_DoubleClick_1(object sender, EventArgs e)
        {
            lvsecilenler.Items[0].SubItems.Add(lbSeansSaatleri.SelectedItem.ToString());

            lvSalonsec.Enabled = true;
            lbSeansSaatleri.Enabled = false;
        }

        private void lvSalonsec_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void temizle()
        {
            txtvizyonFilmID.Clear();
            cbvizyondafilmgetir.SelectedItem =null;
            lbSeansSaatleri.Items.Clear();
            lvSalonsec.Items.Clear();
            lvsecilenler.Items.Clear();
            cbvizyondafilmgetir.Focus();
            lbSeansSaatleri.Enabled = true;
            btnBiletAl.Enabled = false;
            cbvizyondafilmgetir.Enabled = true;
            txtFilmAdiGetir.Clear();



        }

        private void btnyenile_Click(object sender, EventArgs e)
        {
            
            temizle();
           

        }

        private void btnBiletAl_Click(object sender, EventArgs e)
        {
            Genel.SalonID = Convert.ToInt32(lvsecilenler.Items[0].SubItems[3].Text);
            Genel.seans = lvsecilenler.Items[0].SubItems[1].Text;
            Genel.salon = lvsecilenler.Items[0].SubItems[2].Text;
            Genel.FilmAdi = txtFilmAdiGetir.Text;
            Salonsec sa = new Salonsec();
        

            frmSalonSec frm = new frmSalonSec();
            frm.Show();
            

            
        }
        
        public void resimcagir()
        {

           SqlCommand comm = new SqlCommand("select Resim,FilmID from Filmler where Silindi=0 and Vizyonda=1", conn);
           Image UyeResim = null;
           Image UyeResim1 = null;
           Image UyeResim2= null;
           Image UyeResim3 = null;
           Image UyeResim4 = null;
           Image UyeResim5 = null;

            //comm.Parameters.Add("@FilmID", SqlDbType.Int).Value = id

            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr=comm.ExecuteReader();   

  
            int i=0;
       
            try

            {
                while (dr.Read())
                {

                    if (i == 0)
                    {

                        byte[] resim = null;
                        resim = (byte[])dr["Resim"];
                        MemoryStream ms = new MemoryStream(resim, 0, resim.Length);
                        ms.Write(resim, 0, resim.Length);
                        UyeResim = Image.FromStream(ms, true);
                        pictureBox1.Image = UyeResim;
                        textBox1.Text = dr["FilmID"].ToString();


                    }
                    else if (i == 1)
                    {
                        Byte[] resim2 = (Byte[])dr["Resim"];
                        MemoryStream ms2 = new MemoryStream(resim2, 0, resim2.Length);
                        ms2.Write(resim2, 0, resim2.Length);
                        UyeResim1 = Image.FromStream(ms2, true);
                        pictureBox2.Image = UyeResim1;
                        textBox2.Text = dr["FilmID"].ToString();
                    }

                    else if (i == 2)
                    {
                        Byte[] resim3 = (Byte[])dr["Resim"];
                        MemoryStream ms3 = new MemoryStream(resim3, 0, resim3.Length);
                        ms3.Write(resim3, 0, resim3.Length);
                        UyeResim2 = Image.FromStream(ms3, true);
                        pictureBox3.Image = UyeResim2;
                        textBox3.Text = dr["FilmID"].ToString();
                    }
                    else if (i == 3)
                    {
                        Byte[] resim4 = (Byte[])dr["Resim"];
                        MemoryStream ms4 = new MemoryStream(resim4, 0, resim4.Length);
                        ms4.Write(resim4, 0, resim4.Length);
                        UyeResim3 = Image.FromStream(ms4, true);
                        pictureBox4.Image = UyeResim3;
                        textBox4.Text = dr["FilmID"].ToString();
                    }
                    else if (i == 4)
                    {
                        Byte[] resim5 = (Byte[])dr["Resim"];
                        MemoryStream ms5 = new MemoryStream(resim5, 0, resim5.Length);
                        ms5.Write(resim5, 0, resim5.Length);
                        UyeResim4 = Image.FromStream(ms5, true);
                        pictureBox5.Image = UyeResim4;
                        textBox5.Text = dr["FilmID"].ToString();
                    }
                    else if (i == 5)
                    {
                        Byte[] resim6 = (Byte[])dr["Resim"];
                        MemoryStream ms6 = new MemoryStream(resim6, 0, resim6.Length);
                        ms6.Write(resim6, 0, resim6.Length);
                        UyeResim5 = Image.FromStream(ms6, true);
                        pictureBox6.Image = UyeResim5;
                        textBox6.Text = dr["FilmID"].ToString();
                    }


                    i++;

                }
                dr.Close();
           }
        
        

                
            
            catch (SqlException ex)
            {

                string hata = ex.Message;

            }
           

            finally { conn.Close(); }

        }



     
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            film f = new film();
            txtvizyonFilmID.Text = textBox1.Text;
            f.filmadigetir(Convert.ToInt32(txtvizyonFilmID.Text), cbvizyondafilmgetir);
            cbvizyondafilmgetir.SelectedIndex = 0;
            f.filmadigetir(cbvizyondafilmgetir);

        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {

            film f = new film();
            txtvizyonFilmID.Text = textBox2.Text;
            f.filmadigetir(Convert.ToInt32(txtvizyonFilmID.Text), cbvizyondafilmgetir);
            cbvizyondafilmgetir.SelectedIndex = 0;
            f.filmadigetir(cbvizyondafilmgetir);
            
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            film f = new film();
            txtvizyonFilmID.Text = textBox3.Text;
            f.filmadigetir(Convert.ToInt32(txtvizyonFilmID.Text), cbvizyondafilmgetir);
            cbvizyondafilmgetir.SelectedIndex = 0;
            f.filmadigetir(cbvizyondafilmgetir);
        }

        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {
            film f = new film();
            txtvizyonFilmID.Text = textBox4.Text;
            f.filmadigetir(Convert.ToInt32(txtvizyonFilmID.Text), cbvizyondafilmgetir);
            cbvizyondafilmgetir.SelectedIndex = 0;
            f.filmadigetir(cbvizyondafilmgetir);
        }

        private void pictureBox5_DoubleClick(object sender, EventArgs e)
        {
            film f = new film();
            txtvizyonFilmID.Text = textBox5.Text;
            f.filmadigetir(Convert.ToInt32(txtvizyonFilmID.Text), cbvizyondafilmgetir);
            cbvizyondafilmgetir.SelectedIndex = 0;
            f.filmadigetir(cbvizyondafilmgetir);

        }

        private void pictureBox6_DoubleClick(object sender, EventArgs e)
        {
            film f = new film();
            txtvizyonFilmID.Text = textBox6.Text;
            f.filmadigetir(Convert.ToInt32(txtvizyonFilmID.Text), cbvizyondafilmgetir);
            cbvizyondafilmgetir.SelectedIndex = 0;
            f.filmadigetir(cbvizyondafilmgetir);
        }

        private void txtFilmAdiGetir_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvSalonsec_DoubleClick_1(object sender, EventArgs e)
        {
            lvsecilenler.Items[0].SubItems.Add(lvSalonsec.SelectedItems[0].Text);
            lvsecilenler.Items[0].SubItems.Add(lvSalonsec.SelectedItems[0].SubItems[1].Text);
            lvSalonsec.Enabled = false;
            btnBiletAl.Enabled = true;

        }

        private void lvsecilenler_DoubleClick(object sender, EventArgs e)
        {
           
        }

       
    }
}
