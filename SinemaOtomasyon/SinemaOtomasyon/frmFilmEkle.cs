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
using SinemaOtomasyon.Class;

namespace SinemaOtomasyon
{
    public partial class frmFilmEkle : Form
    {
        public frmFilmEkle()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Genel.connstr);    
            
        private void frmFilmEkle_Load(object sender, EventArgs e)
        {
            tslKullaniciAdi.Text = Genel.kullaniciadi2;

            lvfilmlerigetir.Visible = false;
        
            btnkaydet.Enabled = false;
            btndegistir.Visible = false;
            btnsil.Visible = false;
            btnyeni.Enabled = true;
            this.Top = 0;
            this.Left = 0;
            film f = new film();
            seans s = new seans();
            Salon sa = new Salon();
            f.filmadigetir(cbFilmAdiGetir);
            f.filmadigetir(cbFilmAdiGetir2);
            f.filmturugetir(cbfilmturleri);
           
            s.senaslarigetir(lvseanslar);
            s.FilmSeansGetir(lvFilmSeansGetir);
            txtSeanssil.Visible = false;
            sa.salonlariGetir(lvsalonlarigetir);
            sa.FilmSalonGetir(lvFilmSalonGetir);


            Sorgulama sm = new Sorgulama();
            sm.FilmSeansGetir(cbSeansaGore);
            sm.FilmSalonGetir(cbSalonaGore);
            cbSeansaGore.SelectedIndex = 0;
            cbSalonaGore.SelectedIndex = 0;
            sm.FilmleriGetir(lvDetayliListe);

            

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
                    f.filmadigetir(cbFilmAdiGetir);
                    f.filmadigetir(cbFilmAdiGetir2);
                    temizle();

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

                Genel.ResimPath = openFileDialog1.FileName.ToString();

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
                seans s = new seans();
                Salon sa = new Salon();
                film f = new film();
                if (f.FilmSil(Convert.ToInt32(txtFilmID.Text)))
                {
                    MessageBox.Show("Film Başarıyla Silinmiştir!");
                    if (s.FilmSeansSil(Convert.ToInt32(txtFilmID.Text)))
                    {
                        MessageBox.Show("Filme Eklediğniz Seanslar Silindi", "Dikkat!");
                        s.FilmSeansGetir(lvFilmSeansGetir);
                    }
                    else
                    {
                        MessageBox.Show("Filme Eklediğniz Seanslar Silinemedi", "Dikkat!");
                    }
                    if (sa.FilmSalonSil(Convert.ToInt32(txtFilmID.Text)))
                    {
                        MessageBox.Show("Filme Eklediğniz Salonlar Silindi", "Dikkat!");
                        sa.FilmSalonGetir(lvFilmSalonGetir);
                    }
                    else
                    {
                        MessageBox.Show("Filme Eklediğniz Salonlar Silinemedi", "Dikkat!");
                    }

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void btnseansekle_Click(object sender, EventArgs e)
        {
            if (cbsaat.SelectedItem == null || cbdakika.SelectedItem == null)
            {
                MessageBox.Show("önce saat ve dakika seçmelisiniz!");
            }
            else
            {
                seans s = new seans();
                if (s.seansvarmi(cbsaat.Text, cbdakika.Text))
                {
                    MessageBox.Show("Aynı Seans Zaten Var!");
                }
                else
                {
                    s.Seanssaati = cbsaat.Text;
                    s.Seansdakikasi = cbdakika.Text;
                    if (s.seansekle(s))
                    {
                        
                        MessageBox.Show("Seans Eklendi!");
                        s.senaslarigetir(lvseanslar);
                        cbsaat.SelectedItem = null;
                        cbdakika.SelectedItem = null;
                    }
                    else
                    {
                        MessageBox.Show("Seans Eklenemedi");
                    }

                }
            }
          
        }

        private void lvseanslar_DoubleClick(object sender, EventArgs e)
        {
            txtSeanssil.Text = lvseanslar.SelectedItems[0].SubItems[1].Text;
            txtSeansSaati.Text = lvseanslar.SelectedItems[0].SubItems[1].Text;
            txtSeansID.Text = lvseanslar.SelectedItems[0].Text;
            txtSeanssil.Visible = true;

        
        }

        private void cbFilmAdiGetir_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void cbFilmAdiGetir_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            film f = (film)cbFilmAdiGetir.SelectedItem;
            txtFilmID2.Text = f.Filmid.ToString();
          
        }

        private void btnFilmeSeansEkle_Click(object sender, EventArgs e)
        {
          
            seans s = new seans();
                if (s.FilmSeansVarmi(Convert.ToInt32(txtFilmID2.Text), Convert.ToInt32(txtSeansID.Text)))
                {
                    MessageBox.Show("Eklemek Istediğiniz Filmde Aynı Seans Vardır!");
                }
                else
                {
                    s.Filmid = Convert.ToInt32(txtFilmID2.Text);
                    s.Seansid = Convert.ToInt32(txtSeansID.Text);
                    if (s.FilmSeansEkle(s))
                    {
                        s.FilmSeansGetir(lvFilmSeansGetir);
                        MessageBox.Show("Filme Seans Başarıyla Eklenmiştir");

                    }
                    else
                    {
                        MessageBox.Show("FilmeSeans Eklenememiştir");
                    }
                }
            
            
        }

        private void btnseanssil_Click(object sender, EventArgs e)
        {
            seans s = new seans();
            if (s.SeansSil(txtSeanssil.Text))
            {
             
                MessageBox.Show("Seans Başarıyla Silinmiştir");
                s.senaslarigetir(lvseanslar);
                txtSeanssil.Clear();
                txtSeanssil.Visible = false;
                txtSeansSaati.Clear();
                txtSeansID.Clear();
            }
            else
            {
                MessageBox.Show("Filme eklenen Seansı silmeye çalışıyorsunuz","Önce Filme Eklenen Seansı Siliniz!!!");
                txtSeanssil.Clear();
                txtSeansSaati.Clear();
                txtSeansID.Clear();

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnFilmSeansSil_Click(object sender, EventArgs e)
        {
            seans s = new seans();
            if (s.FilmSeansSil(Convert.ToInt32(txtFilmID2.Text), Convert.ToInt32(txtSeansID.Text)))
            {
                MessageBox.Show("Silme işlemi Başarıyla Tamamlanmıştır!");
                s.FilmSeansGetir(lvFilmSeansGetir);
            }
            else
            {
                MessageBox.Show("Silinme başarız!");
            }
        }

        private void lvFilmSeansGetir_DoubleClick(object sender, EventArgs e)
        {
            txtSeansID.Text = lvFilmSeansGetir.SelectedItems[0].SubItems[4].Text;
            txtFilmID2.Text=lvFilmSeansGetir.SelectedItems[0].SubItems[3].Text;
        }

        private void btnSalonEkle_Click(object sender, EventArgs e)
        {
            if (txtSalonAdi.Text.Trim() == "" || txtkoltukadedi.Text.Trim() == "")
            {
                MessageBox.Show("tüm değerleri gir");
            }
            else
            {
                Salon sa = new Salon();
                if (sa.salonvarmi(txtSalonAdi.Text, Convert.ToInt32(txtkoltukadedi.Text)))
                {
                    MessageBox.Show("aynı salon var");
                }
                else
                {
                    sa.Salonad = txtSalonAdi.Text;
                    sa.Koltukadedi = Convert.ToInt32(txtkoltukadedi.Text);
                    if (sa.salonekle(sa))
                    {

                        MessageBox.Show("salon eklenmiştir");
                        sa.salonlariGetir(lvsalonlarigetir);
                        txtkoltukadedi.Clear();
                        txtSalonAdi.Clear();
                    }
                    else
                    {
                        MessageBox.Show("salon eklenemedi");
                    }
                }
            }
        }

        private void lvsalonlarigetir_DoubleClick(object sender, EventArgs e)
        {
            txtsalonID.Text = lvsalonlarigetir.SelectedItems[0].Text;
            txtSalonAdi.Text = lvsalonlarigetir.SelectedItems[0].SubItems[1].Text;
            txtkoltukadedi.Text = lvsalonlarigetir.SelectedItems[0].SubItems[2].Text;
            txtSalonID2.Text = lvsalonlarigetir.SelectedItems[0].Text;
            txtSalonad2.Text = lvsalonlarigetir.SelectedItems[0].SubItems[1].Text;


        }

        private void btnSalonSil_Click(object sender, EventArgs e)
        {
            Salon sa = new Salon();
            if (sa.SalonSil(Convert.ToInt32(txtsalonID.Text)))
            {
                MessageBox.Show("Salon başarıyla silindi!");
                sa.salonlariGetir(lvsalonlarigetir);
                txtsalonID.Clear();
                txtSalonAdi.Clear();
                txtkoltukadedi.Clear();
            }
            else
            {
                MessageBox.Show("Silinecek Salon Filmlere Eklenmiş","Salon Silinemedi!!!");

            }

        }

        private void cbFilmAdiGetir2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilmAdiGetir2.SelectedItem != null)
            {
                film f = (film)cbFilmAdiGetir2.SelectedItem;
                txtFilmID3.Text = f.Filmid.ToString();
            }
        }

        private void btnFilmeSalonEkle_Click(object sender, EventArgs e)
        {
            
            Salon sa = new Salon();
            if (sa.FilmSalonVarmi(Convert.ToInt32(txtFilmID3.Text), Convert.ToInt32(txtSalonID2.Text)))
            {
                MessageBox.Show("Aynı Salon ve Film Ekli");

            }
            else
            {

                sa.Salonıd = Convert.ToInt32(txtSalonID2.Text);
                sa.Filmid = Convert.ToInt32(txtFilmID3.Text);
                if (sa.FilmSalonEkle(sa))
                {
                    MessageBox.Show("Seçilem Salona Film Eklendi!!");
                    lvFilmSalonGetir.Items.Clear();
                    sa.FilmSalonGetir(lvFilmSalonGetir);
                    txtFilmID3.Clear();
                    txtSalonID2.Clear();
                    cbFilmAdiGetir2.SelectedItem = null;
                    txtSalonad2.Clear();
                    

                }
                else
                {
                    MessageBox.Show("Salona film Eklenemedi!!!!!");

                }
            }
            
        }

        private void btnFilmSalonSil_Click(object sender, EventArgs e)
        {
            Salon sa = new Salon();
            if (sa.FilmSalonSil(Convert.ToInt32(txtFilmID3.Text), Convert.ToInt32(txtSalonID2.Text)))
            {
                MessageBox.Show("başarıyla silindi");
                sa.FilmSalonGetir(lvFilmSalonGetir);
                txtFilmID3.Clear();
                txtSalonID2.Clear();
                cbFilmAdiGetir2.SelectedItem = null;
                txtSalonad2.Clear();
                btnFilmSalonSil.Visible = false;

            }
            else
            {
                MessageBox.Show("Silinemedi!!");

            }
        }

        private void lvFilmSalonGetir_DoubleClick(object sender, EventArgs e)
        {
            txtFilmID3.Text = lvFilmSalonGetir.SelectedItems[0].SubItems[2].Text;
            txtSalonID2.Text = lvFilmSalonGetir.SelectedItems[0].SubItems[3].Text;
            txtSalonad2.Text = lvFilmSalonGetir.SelectedItems[0].SubItems[1].Text;
            cbFilmAdiGetir2.Text = lvFilmSalonGetir.SelectedItems[0].Text;
            btnFilmSalonSil.Visible = true;
            
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtAdaGore_TextChanged(object sender, EventArgs e)
        {
            Sorgulama so = new Sorgulama();
            so.AdaGoreSorgu(txtAdaGore.Text, lvDetayliListe);
        }

        private void cbSeansaGore_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sorgulama so = new Sorgulama();
            so.SeansaGoreSorgu(cbSeansaGore.SelectedItem.ToString(), lvDetayliListe);
        }

        private void cbSalonaGore_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sorgulama so = new Sorgulama();
            so.SalonaGoreSorgulama(cbSalonaGore.SelectedItem.ToString(), lvDetayliListe);
        }

        private void txtSorguyuSifirla_Click(object sender, EventArgs e)
        {
            txtAdaGore.Clear();
            cbSalonaGore.SelectedIndex = 0;
            cbSeansaGore.SelectedIndex = 0;
            Sorgulama so = new Sorgulama();
            so.FilmleriGetir(lvDetayliListe);
        }

        


    }

}

