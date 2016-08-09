using SinemaOtomasyon.Class;
using SinemaOtomasyon.model;
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

namespace SinemaOtomasyon
{
    public partial class frmYoneticiGirisi : Form
    {
        public frmYoneticiGirisi()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        Calisan c = new Calisan();
        Kampanya k = new Kampanya();
        //SqlConnection conn = new SqlConnection("Data Source=.\\MSSQL2012; Initial Catalog=SinemaOtomasyon;uid=sa;pwd=12345");

        SqlConnection conn = new SqlConnection("Data Source=.; Initial Catalog=SinemaOtomasyon;integrated security=SSPI");
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            lvCalisanBilgi.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_CalisanEkle";
            if (conn.State == ConnectionState.Closed) conn.Open();

            try
            {
                cmd.Parameters.Add("@Ad", SqlDbType.VarChar).Value = txtad.Text;
                cmd.Parameters.Add("@Soyad", SqlDbType.VarChar).Value = txtsoyad.Text;
                cmd.Parameters.Add("@TCNo", SqlDbType.VarChar).Value = txttc.Text;
                cmd.Parameters.Add("@Telefon", SqlDbType.VarChar).Value = txttelefon.Text;
                cmd.Parameters.Add("@Mail", SqlDbType.VarChar).Value = txtmail.Text;
                cmd.Parameters.Add("@Adres", SqlDbType.VarChar).Value = txtadres.Text;
                cmd.Parameters.Add("@KullaniciAdi", SqlDbType.VarChar).Value = txtkullaniciadi.Text;
                cmd.Parameters.Add("@GuvenlikSorusu", SqlDbType.VarChar).Value = cbGuvenlikSorusu.SelectedItem;
                cmd.Parameters.Add("@Sifre", SqlDbType.VarChar).Value = txtsifre.Text;
                cmd.Parameters.Add("@Cevap", SqlDbType.VarChar).Value = txtcevap.Text;
                int ekle = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (ekle > 0)
                {
                    MessageBox.Show("Eklendi");
                    c.CalisanBilgileriniGetir(lvCalisanBilgi);
                }

            }
            catch (SqlException ex)
            {
                string mesaj = ex.Message;
            }

            finally { conn.Close(); }

        }

        private void frmYoneticiGirisi_Load(object sender, EventArgs e)
        {
            tslKullaniciAdi.Text = Genel.kullaniciadi2;
            c.CalisanBilgileriniGetir(lvCalisanBilgi);
            dt = k.KampanyaGetir();
            dgvKampanyalar.DataSource = dt;
        }

        private void lvCalisanBilgi_DoubleClick(object sender, EventArgs e)
        {

            txtcalisanid.Text = lvCalisanBilgi.SelectedItems[0].SubItems[0].Text;
            txtad.Text = lvCalisanBilgi.SelectedItems[0].SubItems[1].Text;
            txtsoyad.Text = lvCalisanBilgi.SelectedItems[0].SubItems[2].Text;
            txttc.Text = lvCalisanBilgi.SelectedItems[0].SubItems[3].Text;
            txttelefon.Text = lvCalisanBilgi.SelectedItems[0].SubItems[4].Text;
            txtmail.Text = lvCalisanBilgi.SelectedItems[0].SubItems[5].Text;
            txtadres.Text = lvCalisanBilgi.SelectedItems[0].SubItems[6].Text;
            txtkullaniciadi.Text = lvCalisanBilgi.SelectedItems[0].SubItems[7].Text;
            txtsifre.Text = lvCalisanBilgi.SelectedItems[0].SubItems[8].Text;
            cbGuvenlikSorusu.Text = lvCalisanBilgi.SelectedItems[0].SubItems[9].Text;
            txtcevap.Text = lvCalisanBilgi.SelectedItems[0].SubItems[10].Text;

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            c.CalisanId =Convert.ToInt32(txtcalisanid.Text);
            c.Telefon = txttelefon.Text;
            c.Mail = txtmail.Text;
            c.Adres = txtadres.Text;
            c.GuvenlikSorusu = cbGuvenlikSorusu.Text;
            c.Cevap = txtcevap.Text;
            c.KullaniciAdi = txtkullaniciadi.Text;
            c.Sifre = txtsifre.Text;
            if (c.CalisanBilgileriGuncelle(c))
            {
                MessageBox.Show("Çalışanın Yeni Bilgileri Kaydedildi");

                c.CalisanBilgileriniGetir(lvCalisanBilgi);
            }
            else
            {
                MessageBox.Show("Hata");


            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Calisan c = new Calisan();
                bool Sonuc = c.Calisansil(Convert.ToInt32(txtcalisanid.Text));
                if (Sonuc)
                {
                    MessageBox.Show("Çalışan bilgileri silindi.");
                    c.CalisanBilgileriniGetir(lvCalisanBilgi);
                }
                else
                {

                    MessageBox.Show("Çalışan Bilgileri Silinirken Bir Hata Oluştu.");
                }
            }
        }

        private void btnKekle_Click(object sender, EventArgs e)
        {

            dt.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_KampanyaEkle";
            if (conn.State == ConnectionState.Closed) conn.Open();

            try
            {
                cmd.Parameters.Add("@KampanyaAdi", SqlDbType.VarChar).Value = txtKampanyaAdi.Text;
                cmd.Parameters.Add("@KampanyaFiyat", SqlDbType.Int).Value = txtFiyat.Text;
                int ekle = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (ekle > 0)
                {
                    MessageBox.Show("Yeni Kampanya Eklendi");

                    dt = k.KampanyaGetir();
                    dgvKampanyalar.DataSource = dt;
                    Temizle();

                    txtKampanyaAdi.Focus();
                }

            }
            catch (SqlException ex)
            {
                string mesaj = ex.Message;
            }

            finally { conn.Close(); }
        }

        private void btnKGuncelle_Click(object sender, EventArgs e)
        {
            dt.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_KampanyaGuncelle";
            if (conn.State == ConnectionState.Closed) conn.Open();

            try
            {
                cmd.Parameters.Add("@KampanyaAdi", SqlDbType.VarChar).Value = txtKampanyaAdi.Text;
                cmd.Parameters.Add("@KampanyaFiyat", SqlDbType.Int).Value = txtFiyat.Text;
                cmd.Parameters.Add("@BiletTurNo", SqlDbType.Int).Value = txtkampanyaID.Text;
                int ekle = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (ekle > 0)
                {
                    MessageBox.Show("Yeni Kampanya Eklendi");

                    dt = k.KampanyaGetir();
                    dgvKampanyalar.DataSource = dt;
                    Temizle();

                    txtKampanyaAdi.Focus();
                }

            }
            catch (SqlException ex)
            {
                string mesaj = ex.Message;
            }

            finally { conn.Close(); }
        }

        private void btnKSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool Sonuc = k.KampanyaSil(Convert.ToInt32(txtkampanyaID.Text));
                if (Sonuc)
                {
                    MessageBox.Show("Seçilen Kampamya Silindi.");

                    dt = k.KampanyaGetir();
                    dgvKampanyalar.DataSource = dt;
                    Temizle();
                    txtKampanyaAdi.Focus();

                }
                else
                {

                    MessageBox.Show("Kampanya Silinirken Bir Hata Oluştu.");
                }
            }
        }

        private void dgvKampanyalar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKampanyaAdi.Text = dgvKampanyalar.SelectedRows[0].Cells[1].Value.ToString();
            txtFiyat.Text = dgvKampanyalar.SelectedRows[0].Cells[2].Value.ToString();
            txtkampanyaID.Text = dgvKampanyalar.SelectedRows[0].Cells[0].Value.ToString();


        }
        public void Temizle()
        {
            txtKampanyaAdi.Clear();
            txtFiyat.Clear();
            txtkampanyaID.Clear();


        }

    }

}
