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
    class seans
    {
        private int _seansid;

        public int Seansid
        {
            get { return _seansid; }
            set { _seansid = value; }
        }
        private int _filmid;

        public int Filmid
        {
            get { return _filmid; }
            set { _filmid = value; }
        }
        private string _seanssaati;
        private string _Seansdakikasi;
        #region Properties

        public string Seanssaati
        {
            get { return _seanssaati; }
            set { _seanssaati = value; }
        }

        public string Seansdakikasi
        {
            get { return _Seansdakikasi; }
            set { _Seansdakikasi = value; }
        }
        #endregion




        SqlConnection conn = new SqlConnection(Genel.connstr);
        public void senaslarigetir(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("select * from Seanslar where Silindi=0", conn);
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

        public bool seansvarmi(string saat, string dakika)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("select *from Seanslar where BaslangicSaati=@BaslangicSaati", conn);
            comm.Parameters.Add("BaslangicSaati", SqlDbType.VarChar).Value = saat + ":" + dakika;
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

        public bool seansekle(seans s)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("insert into Seanslar (BaslangicSaati) values (@BaslangicSaati)", conn);
            comm.Parameters.Add("BaslangicSaati", SqlDbType.VarChar).Value = s._seanssaati + ":" + s._Seansdakikasi;
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
        public bool SeansSil(string SeansSaat)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("Delete from Seanslar where BaslangicSaati=@BaslangicSaati", conn);
            comm.Parameters.Add("@BaslangicSaati", SqlDbType.VarChar).Value = SeansSaat;
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

        public bool FilmSeansEkle(seans s)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("insert into Seans_Filmler (SeansID,FilmID) values (@SeansID,@FilmID)", conn);
            comm.Parameters.Add("@SeansID", SqlDbType.Int).Value = s._seansid;
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
        public bool FilmSeansVarmi(int FilmID, int SeansID)
        {

            bool sonuc = false;
            SqlCommand comm = new SqlCommand("select * from Seans_Filmler where SeansID=@SeansID and FilmID=@FilmID", conn);
            comm.Parameters.Add("@SeansID", SqlDbType.Int).Value = SeansID;
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


        public bool FilmSeansSil(int filmid, int seansid)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("Delete from Seans_Filmler where FilmID=@FilmID and SeansID=@SeansID", conn);
            comm.Parameters.Add("@FilmID", SqlDbType.Int).Value = filmid;
            comm.Parameters.Add("@SeansID", SqlDbType.Int).Value = seansid;
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
        public bool FilmSeansSil(int filmid)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("Delete from Seans_Filmler where FilmID=@FilmID", conn);
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
        public void FilmSeansGetir(ListView liste)
        {
            seans s = new seans();
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("select FilmAd,TurAd,BaslangicSaati,Seans_Filmler.FilmID,Seans_Filmler.SeansID from Filmler inner join FilmTuru on Filmler.FilmTurNo=FilmTuru.FilmTurNo inner join Seans_Filmler on Filmler.FilmID=Seans_Filmler.FilmID inner join Seanslar on Seans_Filmler.SeansID=Seanslar.SeansID", conn);
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
                        liste.Items[i].SubItems.Add(dr[4].ToString());
                        s.Seansid = Convert.ToInt32(dr[4].ToString());
                       

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
        public void FilmSeansVizyonGetir(int FilmID,ListBox liste)
        {
            seans s = new seans();
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("select BaslangicSaati from Filmler inner join FilmTuru on Filmler.FilmTurNo=FilmTuru.FilmTurNo inner join Seans_Filmler on Filmler.FilmID=Seans_Filmler.FilmID inner join Seanslar on Seans_Filmler.SeansID=Seanslar.SeansID where Seans_Filmler.FilmID=@a", conn);
            comm.Parameters.Add("@a", SqlDbType.Int).Value = FilmID;
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr = comm.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                   

                    while (dr.Read())
                    {
                        liste.Items.Add(dr[0].ToString());
                    
                        
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
