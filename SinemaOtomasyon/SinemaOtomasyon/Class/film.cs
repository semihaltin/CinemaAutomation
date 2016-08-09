using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinemaOtomasyon.model;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing;
namespace SinemaOtomasyon.model
{
    class film
    {
        private int _filmid;
        private string _filmad;
        private int _filmturno;
        private string _oyuncular;
        private string _yonetmen;
        private int _filmsuresi;
        private string _vizyondami;
        private string _konu;

        public int Filmid
        {
            get { return _filmid; }
            set { _filmid = value; }
        }

        public string Konu
        {
            get { return _konu; }
            set { _konu = value; }
        }

        #region Properties

        public string Filmad
        {
            get { return _filmad; }
            set { _filmad = value; }
        }

        public int Filmturno
        {
            get { return _filmturno; }
            set { _filmturno = value; }
        }


        public string Oyuncular
        {
            get { return _oyuncular; }
            set { _oyuncular = value; }
        }

        public string Yonetmen
        {
            get { return _yonetmen; }
            set { _yonetmen = value; }
        }

        public int Filmsuresi
        {
            get { return _filmsuresi; }
            set { _filmsuresi = value; }
        }


        public string Vizyondami
        {
            get { return _vizyondami; }
            set { _vizyondami = value; }
        }
        #endregion



        SqlConnection conn = new SqlConnection(Genel.connstr);






        internal void filmturugetir(ComboBox liste)
        {
            SqlCommand comm = new SqlCommand("select TurAd,FilmTurno from FilmTuru where Silindi=0", conn);
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        liste.Items.Add(dr["TurAd"].ToString());

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




        internal void filmturnogetir(string p, TextBox txtfilmturno)
        {

            SqlCommand comm = new SqlCommand("select FilmTurno from FilmTuru where Silindi=0 and TurAd=@TurAd", conn);
            comm.Parameters.Add("@TurAd", SqlDbType.VarChar).Value = p;
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtfilmturno.Text = dr["FilmTurNo"].ToString();

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


        internal bool filmekle(film f)
        {
            bool Sonuc = false;
            FileStream fs = new FileStream(Genel.ResimPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] foto = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            SqlCommand comm = new SqlCommand("Insert into Filmler (FilmAd,FilmTurNo,Konu,Oyuncular,Yonetmen,FilmSuresi,Vizyonda,Resim) Values (@FilmAd,@FilmTurNo,@Konu,@Oyuncular,@Yonetmen,@FilmSuresi,@Vizyonda,@Resim)", conn);


            comm.Parameters.Add("@FilmAd", SqlDbType.VarChar).Value = f._filmad;
            comm.Parameters.Add("@FilmTurNo", SqlDbType.Int).Value = f._filmturno;
            comm.Parameters.Add("@Konu", SqlDbType.VarChar).Value = f._konu;
            comm.Parameters.Add("@Oyuncular", SqlDbType.VarChar).Value = f._oyuncular;
            comm.Parameters.Add("@Yonetmen", SqlDbType.VarChar).Value = f.Yonetmen;
            comm.Parameters.Add("@FilmSuresi", SqlDbType.Int).Value = f._filmsuresi;
            comm.Parameters.Add("@Vizyonda", SqlDbType.Bit).Value = f._vizyondami;
            comm.Parameters.Add("@Resim", SqlDbType.Image, foto.Length).Value = foto;

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;

        }


        internal void filmlerigetir(ListView liste)
        {

            SqlCommand comm = new SqlCommand("select FilmID,FilmAd,TurAd,Konu,Oyuncular,Yonetmen,Resim,Filmsuresi,Vizyonda,Filmler.FilmTurNo,Filmler.Silindi from Filmler inner join FilmTuru on Filmler.FilmTurNo=FilmTuru.FilmTurNo where Filmler.Silindi=0 ", conn);

            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            int i = 0;
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        liste.Items.Add(dr[0].ToString());
                        liste.Items[i].SubItems.Add(dr[1].ToString());
                        liste.Items[i].SubItems.Add(dr[2].ToString());
                        liste.Items[i].SubItems.Add(dr[3].ToString());
                        liste.Items[i].SubItems.Add(dr[4].ToString());
                        liste.Items[i].SubItems.Add(dr[5].ToString());
                        liste.Items[i].SubItems.Add(dr[7].ToString());
                        liste.Items[i].SubItems.Add(dr[6].ToString());
                        liste.Items[i].SubItems.Add(dr[8].ToString());
                        liste.Items[i].SubItems.Add(dr[9].ToString());



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
        public bool FilmSil(int ID)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update Filmler Set Silindi=1 where FilmID=@FilmID", conn);
            comm.Parameters.Add("@FilmID", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }
        internal void filmadigetir(ComboBox liste)
        {

            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select * from Filmler where Silindi=0 and Vizyonda=1", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    film f = new film();
                    f.Filmid = Convert.ToInt32(dr[0].ToString());
                    f.Filmad = dr[1].ToString();
                    liste.Items.Add(f);
                }
            }
            dr.Close();
            conn.Close();

        }

        public override string ToString()
        {
            return Filmad;
        }

        internal void filmadigetir(int FilmID, ComboBox liste)
        {

            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select * from Filmler where Silindi=0 and Vizyonda=1 and FilmID=@FilmID", conn);
            comm.Parameters.Add("@FilmID", SqlDbType.Int).Value = FilmID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    film f = new film();
                    f.Filmid = Convert.ToInt32(dr[0].ToString());
                    f.Filmad = dr[1].ToString();
                    liste.Items.Add(f);
                }
            }
            dr.Close();
            conn.Close();

        }



    }
}

