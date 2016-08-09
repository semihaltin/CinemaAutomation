using SinemaOtomasyon.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaOtomasyon.Class
{
    class Sorgulama
    {
        SqlConnection conn = new SqlConnection(Genel.connstr);

        public void FilmSeansGetir(ComboBox cbSeanslar)
        {
            SqlCommand comm = new SqlCommand("select BaslangicSaati from Seanslar where Silindi=0", conn);
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            try
            {
                cbSeanslar.Items.Add("Tüm Seanslar");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbSeanslar.Items.Add(dr["BaslangicSaati"].ToString());
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
        public void FilmSalonGetir(ComboBox cbSalonlar)
        {
            SqlCommand comm = new SqlCommand("select SalonAd from Salonlar where FilmVarmi=1", conn);
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            try
            {
                cbSalonlar.Items.Add("Tüm Salonlar");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbSalonlar.Items.Add(dr["SalonAd"].ToString());
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

        public void FilmleriGetir(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select Filmler.FilmID,FilmAd,BaslangicSaati,Salonlar.SalonAd,FilmTuru.TurAd,Konu, Oyuncular,Yonetmen,FilmSuresi from Filmler inner join FilmTuru on Filmler.FilmTurNo = FilmTuru.FilmTurNo inner join Seans_Filmler on Filmler.FilmID = Seans_Filmler.FilmID inner join Seanslar on Seans_Filmler.SeansID = Seanslar.SeansID inner join Salon_Seans on Seans_Filmler.SeansID = Salon_Seans.SeansID inner join Salonlar on Salon_Seans.SalonID = Salonlar.SalonID where Filmler.Vizyonda = 1 and Filmler.Silindi = 0 and Seanslar.Silindi = 0 and FilmTuru.Silindi = 0 and Salonlar.FilmVarmi = 1 ", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                int i = 0;
                while (dr.Read())
                {
                    liste.Items.Add(dr[0].ToString());
                    liste.Items[i].SubItems.Add(dr[1].ToString());
                    liste.Items[i].SubItems.Add(dr[2].ToString());
                    liste.Items[i].SubItems.Add(dr[3].ToString());
                    liste.Items[i].SubItems.Add(dr[4].ToString());
                    liste.Items[i].SubItems.Add(dr[5].ToString());
                    liste.Items[i].SubItems.Add(dr[6].ToString());
                    liste.Items[i].SubItems.Add(dr[7].ToString());
                    liste.Items[i].SubItems.Add(dr[8].ToString());

                    i++;
                }
            }
            dr.Close();
            conn.Close();
        }
        public void AdaGoreSorgu(string FilmAdi, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select Filmler.FilmID,FilmAd,BaslangicSaati,Salonlar.SalonAd,FilmTuru.TurAd,Konu, Oyuncular,Yonetmen,FilmSuresi from Filmler inner join FilmTuru on Filmler.FilmTurNo = FilmTuru.FilmTurNo inner join Seans_Filmler on Filmler.FilmID = Seans_Filmler.FilmID inner join Seanslar on Seans_Filmler.SeansID = Seanslar.SeansID inner join Salon_Seans on Seans_Filmler.SeansID = Salon_Seans.SeansID inner join Salonlar on Salon_Seans.SalonID = Salonlar.SalonID where Filmler.Vizyonda = 1 and Filmler.Silindi = 0 and Seanslar.Silindi = 0 and FilmTuru.Silindi = 0 and Salonlar.FilmVarmi = 1 and FilmAd like @AdaGore + '%'", conn);
            comm.Parameters.Add("@AdaGore", SqlDbType.VarChar).Value = FilmAdi;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                int i = 0;
                while (dr.Read())
                {
                    liste.Items.Add(dr[0].ToString());
                    liste.Items[i].SubItems.Add(dr[1].ToString());
                    liste.Items[i].SubItems.Add(dr[2].ToString());
                    liste.Items[i].SubItems.Add(dr[3].ToString());
                    liste.Items[i].SubItems.Add(dr[4].ToString());
                    liste.Items[i].SubItems.Add(dr[5].ToString());
                    liste.Items[i].SubItems.Add(dr[6].ToString());
                    liste.Items[i].SubItems.Add(dr[7].ToString());
                    liste.Items[i].SubItems.Add(dr[8].ToString());
                    i++;
                }
            }
            dr.Close();
            conn.Close();
        }

        public void SeansaGoreSorgu(string Seans, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select Filmler.FilmID,FilmAd,BaslangicSaati,Salonlar.SalonAd,FilmTuru.TurAd,Konu, Oyuncular,Yonetmen,FilmSuresi from Filmler inner join FilmTuru on Filmler.FilmTurNo = FilmTuru.FilmTurNo inner join Seans_Filmler on Filmler.FilmID = Seans_Filmler.FilmID inner join Seanslar on Seans_Filmler.SeansID = Seanslar.SeansID inner join Salon_Seans on Seans_Filmler.SeansID = Salon_Seans.SeansID inner join Salonlar on Salon_Seans.SalonID = Salonlar.SalonID where Filmler.Vizyonda = 1 and Filmler.Silindi = 0 and Seanslar.Silindi = 0 and FilmTuru.Silindi = 0 and Salonlar.FilmVarmi = 1 and BaslangicSaati=@BaslangicSaati", conn);
            comm.Parameters.Add("@BaslangicSaati", SqlDbType.VarChar).Value = Seans;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                int i = 0;
                while (dr.Read())
                {
                    liste.Items.Add(dr[0].ToString());
                    liste.Items[i].SubItems.Add(dr[1].ToString());
                    liste.Items[i].SubItems.Add(dr[2].ToString());
                    liste.Items[i].SubItems.Add(dr[3].ToString());
                    liste.Items[i].SubItems.Add(dr[4].ToString());
                    liste.Items[i].SubItems.Add(dr[5].ToString());
                    liste.Items[i].SubItems.Add(dr[6].ToString());
                    liste.Items[i].SubItems.Add(dr[7].ToString());
                    liste.Items[i].SubItems.Add(dr[8].ToString());
                    i++;
                }
            }
            dr.Close();
            conn.Close();
        }

        internal void SalonaGoreSorgulama(string Salon, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select Filmler.FilmID,FilmAd,BaslangicSaati,Salonlar.SalonAd,FilmTuru.TurAd,Konu, Oyuncular,Yonetmen,FilmSuresi from Filmler inner join FilmTuru on Filmler.FilmTurNo = FilmTuru.FilmTurNo inner join Seans_Filmler on Filmler.FilmID = Seans_Filmler.FilmID inner join Seanslar on Seans_Filmler.SeansID = Seanslar.SeansID inner join Salon_Seans on Seans_Filmler.SeansID = Salon_Seans.SeansID inner join Salonlar on Salon_Seans.SalonID = Salonlar.SalonID where Filmler.Vizyonda = 1 and Filmler.Silindi = 0 and Seanslar.Silindi = 0 and FilmTuru.Silindi = 0 and Salonlar.FilmVarmi = 1 and Salonlar.SalonAd=@SalonAd", conn);
            comm.Parameters.Add("@SalonAd", SqlDbType.VarChar).Value = Salon;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                int i = 0;
                while (dr.Read())
                {
                    liste.Items.Add(dr[0].ToString());
                    liste.Items[i].SubItems.Add(dr[1].ToString());
                    liste.Items[i].SubItems.Add(dr[2].ToString());
                    liste.Items[i].SubItems.Add(dr[3].ToString());
                    liste.Items[i].SubItems.Add(dr[4].ToString());
                    liste.Items[i].SubItems.Add(dr[5].ToString());
                    liste.Items[i].SubItems.Add(dr[6].ToString());
                    liste.Items[i].SubItems.Add(dr[7].ToString());
                    liste.Items[i].SubItems.Add(dr[8].ToString());
                    i++;
                }
            }
            dr.Close();
            conn.Close();
        }
    }
}
