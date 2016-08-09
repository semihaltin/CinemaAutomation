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
using System.IO;
using System.Data.SqlClient;

namespace SinemaOtomasyon
{
    public partial class frmFilmEkle : Form
    {
        public frmFilmEkle()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(genel.connstr);    
            
        private void frmFilmEkle_Load(object sender, EventArgs e)
        {
            lvfilmlerigetir.Visible = false;
            
            btnkaydet.Enabled = false;
            btndegistir.Visible = false;
            btnsil.Visible = false;
            btnyeni.Enabled = true;
            this.Top = 0;
            this.Left = 0;
            film f = new film();
            f.filmturugetir(cbfilmturleri);
            f.filmadigetir(cbfilmadigetir);
            SeansSifirla();

        }
        private void cbfilmturleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cbfilmturleri.SelectedItem.ToString());
            film f = new film();
            if (cbfilmturleri.SelectedItem != null)
            {
                f.filmturnogetir(cbfilmturleri.SelectedItem.ToString(), txtfilmturno);
            }

        }       
        private void btnyeni_Click(object sender, EventArgs e)
        {
            btndegistir.Visible = false;
            btnsil.Visible = false;
            lvfilmlerigetir.Visible = false;
            btnkaydet.Enabled = true;
            temizle();


        }

        private void cbvizyondami_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbvizyondami.SelectedItem != null)
            {

                if (cbvizyondami.SelectedItem.ToString() == "Vizyonda")
                {
                    txtvizyondami.Text = true.ToString();
                }
                else if (cbvizyondami.SelectedItem.ToString() == "Vizyonda Değil")
                {
                    txtvizyondami.Text = false.ToString();
                }
            }

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtfilmadi.Text.Trim() == "" || txtfilmsuresi.Text.Trim() == "" || txtfilmturno.Text.Trim() == "" || txtkonu.Text.Trim() == "" || (txtoyuncular1.Text.Trim() == "" && txtoyuncular2.Text.Trim() == "" && txtoyuncular3.Text.Trim() == "") || txtyonetmen.Text.Trim() == "" || txtvizyondami.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen Bilgileri Eksizksiz Giriniz");
            }
            else
            {
                film f = new film();
                f.Filmad = txtfilmadi.Text;
                f.Filmturno = Convert.ToInt32(txtfilmturno.Text);
                f.Konu = txtkonu.Text;
                f.Oyuncular = txtoyuncular1.Text + "," + txtoyuncular2.Text + "," + txtoyuncular3.Text;
                f.Yonetmen = txtyonetmen.Text;
                f.Filmsuresi = Convert.ToInt32(txtfilmsuresi.Text);
                f.Vizyondami = txtvizyondami.Text.ToString();
                if (f.filmekle(f))
                {
                    MessageBox.Show("Film Bilgileriniz Başarıyla Eklenmiştir");
                }
                else
                {
                    MessageBox.Show("Film bilgileri eklenemedi");
                }
            }


        }

        private void btnresimekle_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Aç";

            openFileDialog1.Filter = "Jpeg Dosyası (*.jpg)|*.jpg|Gif Dosyası (*.gif)|*.gif|Png Dosyası (*.png)|*.png|Tif Dosyası (*.tif)|*.tif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {//www.gorselprogramlama.com

                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

                genel.ResimPath = openFileDialog1.FileName.ToString();

            }
        }
        private void temizle()
        {
            txtFilmID.Clear();
            txtfilmadi.Clear();
            txtfilmsuresi.Clear();
            txtfilmturno.Clear();
            txtkonu.Clear();
            txtoyuncular1.Clear();
            txtoyuncular2.Clear();
            txtoyuncular3.Clear();
            txtvizyondami.Clear();
            txtyonetmen.Clear();
            pictureBox1.Image = null;
            cbfilmturleri.SelectedItem = null;
            cbvizyondami.SelectedItem = null;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            btndegistir.Visible = true;
            btnsil.Visible = true;
            lvfilmlerigetir.Visible = true;
            film f = new film();
            lvfilmlerigetir.Items.Clear();
            f.filmlerigetir(lvfilmlerigetir);

        }

        private void lvfilmlerigetir_DoubleClick(object sender, EventArgs e)
        {
           
         
            btndegistir.Enabled = true;
            btnsil.Enabled = true;
            btnkaydet.Enabled = false;
            temizle();
           
                txtFilmID.Text = lvfilmlerigetir.SelectedItems[0].Text;
                if (lvfilmlerigetir.SelectedItems[0].SubItems[7].Text.Trim() != "")
                {
                    resimcagir(Convert.ToInt32(txtFilmID.Text));
                }
                txtfilmadi.Text = lvfilmlerigetir.SelectedItems[0].SubItems[1].Text;
                txtfilmturno.Text = lvfilmlerigetir.SelectedItems[0].SubItems[9].Text;
                txtkonu.Text = lvfilmlerigetir.SelectedItems[0].SubItems[3].Text;                       
                txtvizyondami.Text = lvfilmlerigetir.SelectedItems[0].SubItems[8].Text;
                txtyonetmen.Text = lvfilmlerigetir.SelectedItems[0].SubItems[5].Text;
                txtfilmsuresi.Text = lvfilmlerigetir.SelectedItems[0].SubItems[6].Text;
                cbfilmturleri.SelectedItem = lvfilmlerigetir.SelectedItems[0].SubItems[2].Text;
                string[] dizi = lvfilmlerigetir.SelectedItems[0].SubItems[4].Text.Split(',');
                
                 if (string.IsNullOrWhiteSpace(dizi[0]))
                {

                }
                else
                {
                    txtoyuncular1.Text = dizi[0];
                }
                 if (dizi.Length > 1)
                 {
                     if (string.IsNullOrEmpty(dizi[dizi.Length - 1]))
                     {

                     }

                     else
                     {
                         txtoyuncular2.Text = dizi[1];
                     }
                 }
                if (dizi.Length > 2)
                {
                    if (string.IsNullOrEmpty(dizi[2]))
                    {

                    }
                    else
                    {
                        txtoyuncular3.Text = dizi[2];
                    }

                }

                if (txtvizyondami.Text == "True")
                {
                    cbvizyondami.SelectedIndex = 0;
                }
                else if (txtvizyondami.Text == "False")
                {
                    cbvizyondami.SelectedIndex = 1;
                }
          
     
        }
        public void resimcagir(int id)
        {

            SqlCommand comm = new SqlCommand("select Resim from Filmler where FilmId=@FilmID ", conn);
            Image UyeResim = null;
            comm.Parameters.Add("@FilmID", SqlDbType.Int).Value = id;
            
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        
                        byte[] resim = (byte[])dr[0];
                        MemoryStream ms = new MemoryStream(resim, 0, resim.Length);
                        ms.Write(resim, 0, resim.Length);
                        UyeResim = Image.FromStream(ms, true);
                        pictureBox1.Image = UyeResim;
                      
                    }
                }

                dr.Close();
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;

            }

            finally { conn.Close(); }

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(txtfilmadi.Text + "  ADLI FİLMİ SİLMEK İSİYORMUSUNUZ?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {

                film f = new film();
                if (f.FilmSil(Convert.ToInt32(txtFilmID.Text)))
                {
                    MessageBox.Show("Film Başarıyla Silinmiştir!");
                }
                else
                {
                    MessageBox.Show("Film Silme İşlemi Yapılamamıştır");
                }
                lvfilmlerigetir.Items.Clear();
                f.filmlerigetir(lvfilmlerigetir);
                temizle();
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            lvfilmlerigetir.Visible = false;
        }

        private void btnseansekle_Click(object sender, EventArgs e)
        {
            film f = new film();
            f.SeansSaati = cbSaat.SelectedItem.ToString();
            f.SeansDakikasi = cbDakika.SelectedItem.ToString();
             if (f.SeansVarmi(cbSaat,cbDakika))
                {
                    MessageBox.Show("Seans Var.");
                }
                else
                {
                    MessageBox.Show("Seans yok.");
                }
            SeansSifirla();
            }

        private void btnseanssil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(cbSaat.SelectedItem.ToString()+ ":" +cbDakika.SelectedItem.ToString() + " Seans saatini silmek istiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) ;
            {
               film f = new film();
                f.SeansSaati = cbSaat.SelectedItem.ToString();
                f.SeansDakikasi = cbDakika.SelectedItem.ToString();
                if (f.SeansSil(f))
                {
                    MessageBox.Show("Seans silindi!");
                }
                else
                {
                    MessageBox.Show("Seans Silme İşlemi Gerçekleştirilemedi!");
                }
                //lvfilmlerigetir.Items.Clear();
                //f.filmlerigetir(lvfilmlerigetir);
                //temizle();
            }
        }
        private void SeansSifirla()
        {
            cbSaat.SelectedIndex = 0;
            cbDakika.SelectedIndex = 0;
        }
    }
        
    }



