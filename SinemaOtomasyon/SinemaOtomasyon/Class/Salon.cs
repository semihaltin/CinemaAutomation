using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaOtomasyon.model
{
    class Salon
    {
        private int _filmid;

        public int Filmid
        {
            get { return _filmid; }
            set { _filmid = value; }
        }
        private int _salonıd;
        private bool _bolkoltuk;
        private bool _filmvarmi;
        private string _salonad;
        private int _koltukadedi;

        #region Properties
        public int Salonıd
        {
            get { return _salonıd; }
            set { _salonıd = value; }
        }

        public bool Bolkoltuk
        {
            get { return _bolkoltuk; }
            set { _bolkoltuk = value; }
        }

        public bool Filmvarmi
        {
            get { return _filmvarmi; }
            set { _filmvarmi = value; }
        }

        public string Salonad
        {
            get { return _salonad; }
            set { _salonad = value; }
        }


        public int Koltukadedi
        {
            get { return _koltukadedi; }
            set { _koltukadedi = value; }
        }

        #endregion


        SqlConnection conn = new SqlConnection(Genel.connstr);
        public void salonlariGetir(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("select * from Salonlar where Silindi=0", conn);
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr = comm.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    int i = 0;

                    while (dr.Read())
                    {
                        liste.Items.Add(dr[0].ToString());
                        liste.Items[i].SubItems.Add(dr[1].ToString());
                        liste.Items[i].SubItems.Add(dr[2].ToString());
                        i++;
                    }

                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }


        }
        public bool salonvarmi(string salonad, int koltukadedi)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("select *from Salonlar where SalonAd=@SalonAd and KoltukAdedi=@KoltukAdedi", conn);
            comm.Parameters.Add("SalonAd", SqlDbType.VarChar).Value = salonad;
            comm.Parameters.Add("KoltukAdedi", SqlDbType.Int).Value = koltukadedi;
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr = comm.ExecuteReader();
            try
            {
                if (dr.HasRows)
                    sonuc = true;
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally { conn.Close(); }
            return sonuc;

        }
        public bool salonekle(Salon s)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("insert into Salonlar (SalonAd,KoltukAdedi) values (@SalonAd,@KoltukAdedi)", conn);
            comm.Parameters.Add("SalonAd", SqlDbType.VarChar).Value = s._salonad;
            comm.Parameters.Add("KoltukAdedi", SqlDbType.Int).Value = s._koltukadedi;

            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            try
            {
                sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return sonuc;

        }
        public bool SalonSil(int salonid)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("Delete from Salonlar where SalonID=@SalonID", conn);
            comm.Parameters.Add("@SalonID", SqlDbType.Int).Value = salonid;
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            try
            {
                sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            conn.Close();
            return sonuc;
        }
        public void FilmSalonGetir(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("select FilmAd,SalonAd,Film_Salon.FilmID,Film_Salon.SalonID from Filmler inner join Film_Salon on Film_Salon.FilmID=Filmler.FilmID inner join Salonlar on Salonlar.SalonID=Film_Salon.SalonID", conn);

            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr = comm.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    int i = 0;

                    while (dr.Read())
                    {
                        liste.Items.Add(dr[0].ToString());
                        liste.Items[i].SubItems.Add(dr[1].ToString());
                        liste.Items[i].SubItems.Add(dr[2].ToString());
                        liste.Items[i].SubItems.Add(dr[3].ToString());




                        i++;
                    }

                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }


        }
        public bool FilmSalonVarmi(int FilmID, int SalonID)
        {

            bool sonuc = false;
            SqlCommand comm = new SqlCommand("select * from Film_Salon where SalonID=@SalonID and FilmID=@FilmID", conn);
            comm.Parameters.Add("@SalonID", SqlDbType.Int).Value = SalonID;
            comm.Parameters.Add("@FilmID", SqlDbType.Int).Value = FilmID;
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr = comm.ExecuteReader();
            try
            {
                if (dr.HasRows)
                    sonuc = true;

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;


            }

            conn.Close();
            return sonuc;
        }
        public bool FilmSalonEkle(Salon s)
        {

            bool sonuc = false;
            SqlCommand comm = new SqlCommand("insert into Film_Salon (SalonID,FilmID) values (@SalonID,@FilmID)", conn);
            comm.Parameters.Add("@SalonID", SqlDbType.Int).Value = s._salonıd;
            comm.Parameters.Add("@FilmID", SqlDbType.Int).Value = s._filmid;
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            try
            {
                sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());


            }
            catch (SqlException ex)
            {
                string hata = ex.Message;


            }
            conn.Close();

            return sonuc;

        }
        public bool FilmSalonSil(int filmid, int salonid)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("Delete from Film_Salon  where FilmID=@FilmID and SalonID=@SalonID", conn);
            comm.Parameters.Add("@FilmID", SqlDbType.Int).Value = filmid;
            comm.Parameters.Add("@SalonID", SqlDbType.Int).Value = salonid;
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            try
            {
                sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }


            return sonuc;
            conn.Close();
        }
        public bool FilmSalonSil(int filmid)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("Delete from Film_Salon  where FilmID=@FilmID", conn);
            comm.Parameters.Add("@FilmID", SqlDbType.Int).Value = filmid;
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            try
            {
                sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }


            return sonuc;
            conn.Close();
        }
        public void FilmSalonVizyonGetir(int id)
        {
            SqlCommand comm = new SqlCommand("select SalonAd,KoltukAdedi from Filmler inner join Film_Salon on Film_Salon.FilmID=Filmler.FilmID inner join Salonlar on Salonlar.SalonID=Film_Salon.SalonID  where Film_Salon.FilmID=@a", conn);
            comm.Parameters.Add("@a", SqlDbType.Int).Value = id;

            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr = comm.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
               

                    while (dr.Read())
                    {
       
                       
                    }

                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }


        }

        public void FilmSalonVizyonGetir(int FilmID, ListView liste)
        {
            seans s = new seans();
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("select SalonAd,Salonlar.SalonID from Film_Salon inner join Salonlar on Film_Salon.SalonID=Salonlar.SalonID where Film_Salon.FilmID=@a", conn);
            comm.Parameters.Add("@a", SqlDbType.Int).Value = FilmID;
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr = comm.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    int i=0;

                    while (dr.Read())
                    {
                        liste.Items.Add(dr[0].ToString());
                        liste.Items[i].SubItems.Add(dr[1].ToString());
                        i++;
                    }

                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }


        }



    }
}
