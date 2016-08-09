﻿using System;
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
        private string _filmad;
        private int _filmturno;
        private string _oyuncular;
        private string _yonetmen;
        private int _filmsuresi;
        private string _vizyondami;
        private string _konu;
        private string _baslangicSaati;
        private DateTime _vizyonTarihi;
        private int _salonNo;
        public string Konu
        {
            get { return _konu; }
            set { _konu = value; }
        }
        private int _seansID;

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

        public string BaslangicSaati
        {
            get
            {
                return BaslangicSaati1;
            }

            set
            {
                BaslangicSaati1 = value;
            }
        }

        public string BaslangicSaati1
        {
            get
            {
                return _baslangicSaati;
            }

            set
            {
                _baslangicSaati = value;
            }
        }

        public DateTime VizyonTarihi
        {
            get
            {
                return _vizyonTarihi;
            }

            set
            {
                _vizyonTarihi = value;
            }
        }

        public int SalonNo
        {
            get
            {
                return _salonNo;
            }

            set
            {
                _salonNo = value;
            }
        }

       

        public int SeansID1
        {
            get
            {
                return _seansID;
            }

            set
            {
                _seansID = value;
            }
        }
        #endregion



        SqlConnection conn = new SqlConnection(genel.connstr);
        
        internal void filmturugetir(ComboBox liste)
        {
            SqlCommand comm = new SqlCommand("select TurAd,FilmTurno from FilmTuru where Silindi=0",conn);
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
            catch(SqlException ex)
            {

                string hata = ex.Message;

            }

            finally { conn.Close(); }

        }
        
        internal void filmturnogetir(string p, TextBox txtfilmturno)
        {
            
            SqlCommand comm = new SqlCommand("select FilmTurno from FilmTuru where Silindi=0 and TurAd=@TurAd",conn);
            comm.Parameters.Add("@TurAd",SqlDbType.VarChar).Value=p;
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                       txtfilmturno.Text=dr["FilmTurNo"].ToString();
                      
                    }
                }

                dr.Close();
            }
            catch(SqlException ex)
            {

                string hata = ex.Message;

            }

            finally { conn.Close(); }

        }


        internal bool filmekle(film f)
        {
            bool Sonuc = false;
            FileStream fs = new FileStream(genel.ResimPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] foto = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            SqlCommand comm = new SqlCommand("Insert into Filmler (FilmAd,FilmTurNo,Konu,Oyuncular,Yonetmen,FilmSuresi,Vizyonda,Resim) Values (@FilmAd,@FilmTurNo,@Konu,@Oyuncular,@Yonetmen,@FilmSuresi,@Vizyonda,@Resim)", conn);
            
            comm.Parameters.Add("@FilmAd", SqlDbType.VarChar).Value =f._filmad;
            comm.Parameters.Add("@FilmTurNo", SqlDbType.Int).Value =f._filmturno;
            comm.Parameters.Add("@Konu", SqlDbType.VarChar).Value = f._konu;
            comm.Parameters.Add("@Oyuncular", SqlDbType.VarChar).Value = f._oyuncular;
            comm.Parameters.Add("@Yonetmen", SqlDbType.VarChar).Value = f.Yonetmen;
            comm.Parameters.Add("@FilmSuresi", SqlDbType.Int).Value = f._filmsuresi;
            comm.Parameters.Add("@Vizyonda", SqlDbType.Bit).Value = f._vizyondami;
            comm.Parameters.Add("@Resim", SqlDbType.Image,foto.Length).Value = foto;

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
            int i=0;
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
            finally{ conn.Close();}
        }

        public bool SeansEkle(film f)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Insert into Seanslar (BaslangicSaati,VizyonTarihi) Values (@BaslangicSaati,@VizyonTarihi)", conn);
           comm.Parameters.Add("@BaslangicSaati", SqlDbType.VarChar).Value = f._baslangicSaati;
            comm.Parameters.Add("@VizyonTarihi", SqlDbType.Date).Value = f._vizyonTarihi;
            SqlCommand comm2 = new SqlCommand("Insert into Salon_Seans (SeansID, SalonID) Values(@SeansID=select IDENT_CURRENT('Seanslar'), @SalonID", conn);
            comm2.Parameters.Add("@SalonID",SqlDbType.Int).Value=f._salonNo;
            comm2.Parameters.Add("@SeansID", SqlDbType.Int).Value = f._seansID;
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
    }
 }

