using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SinemaOtomasyon.model;

namespace SinemaOtomasyon.Class
{
    class Calisan
    {
        private string _ad;
        private string _soyad;
        private string _tc;
        private string _telefon;
        private string _mail;
        private string _adres;
        private string _guvenlikSorusu;
        private string _cevap;
        private string _kullaniciAdi;
        private string _sifre;
        private int _calisanId;

        public int CalisanId
        {
            get { return _calisanId; }
            set { _calisanId = value; }
        }
        #region Özellikler


        public string Sifre
        {
            get { return _sifre; }
            set { _sifre = value; }
        }

        public string KullaniciAdi
        {
            get { return _kullaniciAdi; }
            set { _kullaniciAdi = value; }
        }

        public string Cevap
        {
            get { return _cevap; }
            set { _cevap = value; }
        }



        public string GuvenlikSorusu
        {
            get { return _guvenlikSorusu; }
            set { _guvenlikSorusu = value; }
        }



        public string Adres
        {
            get { return _adres; }
            set { _adres = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }



        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
        }
        public string Ad
        {
            get { return _ad; }
            set { _ad = value; }
        }

        public string Soyad
        {
            get { return _soyad; }
            set { _soyad = value; }
        }

        public string Tc
        {
            get { return _tc; }
            set { _tc = value; }
        }

        #endregion
        SqlConnection conn = new SqlConnection(Genel.connstr);



        internal bool CalisanSifreUnuttum(Calisan c)
        {
            bool sonuc = false;
            SqlCommand cmd = new SqlCommand("Select * from CalisanBilgileri where  KullaniciAdi=@kullaniciadi  and Cevap=@cevap  ", conn);
            cmd.Parameters.Add("@kullaniciadi", SqlDbType.VarChar).Value = c.KullaniciAdi;
            cmd.Parameters.Add("@cevap", SqlDbType.VarChar).Value = c.Cevap;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {

                while (dr.Read())
                {
                    sonuc = Convert.ToBoolean(KullaniciAdi == dr["KullaniciAdi"].ToString() && Cevap == dr["Cevap"].ToString());
                    {
                        if (sonuc)
                        {
                            frmYeniSifreOluştur frm = new frmYeniSifreOluştur();
                            frm.Show();
                        }
                    }


                }
            }

            catch (SqlException ex)
            {
                string mesaj = ex.Message;
            }
            conn.Close();
            return sonuc;
        }

        internal void CalisanBilgileriniGetir(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand cmd = new SqlCommand("select CalisanID,Ad, Soyad, TcNo,Telefon,Mail,Adres,KullaniciAdi,Sifre,GuvenlikSorusu,Cevap from CalisanBilgileri ", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
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
                        liste.Items[i].SubItems.Add(dr[5].ToString());
                        liste.Items[i].SubItems.Add(dr[6].ToString());
                        liste.Items[i].SubItems.Add(dr[7].ToString());
                        liste.Items[i].SubItems.Add(dr[8].ToString());
                        liste.Items[i].SubItems.Add(dr[9].ToString());
                        liste.Items[i].SubItems.Add(dr[10].ToString());
                        i++;
                    }
                }

            }
            catch (SqlException ex)
            {
                string mesaj = ex.Message;
            }


            dr.Close();
            conn.Close();
        }

        internal bool CalisanBilgileriGuncelle(Calisan c)
        {
            bool sonuc = false;
            SqlCommand cmd = new SqlCommand("Update CalisanBilgileri set Telefon=@telefon , Mail=@mail, Adres=@adres, KullaniciAdi=@kadi,Sifre=@sifre,GuvenlikSorusu=@gsoru,Cevap=@cevap where CalisanID=@calisanid",conn);
            cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = c._telefon;
            cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = c._mail;
            cmd.Parameters.Add("@adres", SqlDbType.VarChar).Value = c._adres;
            cmd.Parameters.Add("@kadi", SqlDbType.VarChar).Value = c._kullaniciAdi;
            cmd.Parameters.Add("@sifre", SqlDbType.VarChar).Value = c._sifre;
            cmd.Parameters.Add("@gsoru", SqlDbType.VarChar).Value = c._guvenlikSorusu;
            cmd.Parameters.Add("@cevap", SqlDbType.VarChar).Value = c._cevap;
            cmd.Parameters.Add("@calisanid", SqlDbType.Int).Value = c._calisanId;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                 sonuc=Convert.ToBoolean(cmd.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            return sonuc;
        }

        internal bool Calisansil(int Calisanid)
        {bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update CalisanBilgileri Set Silindi=1 where CalisanID=@id", conn);
            comm.Parameters.Add("@id", SqlDbType.Int).Value = Calisanid;
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


        internal bool SifreYenile(string KullaniciAdi, string YeniSifre)
        {
            bool sonuc = false;
            SqlCommand cmd = new SqlCommand("Update CalisanBilgileri set Sifre=@sifre  where KullaniciAdi=@kadi", conn);
            cmd.Parameters.Add("@kadi", SqlDbType.VarChar).Value = KullaniciAdi;
            cmd.Parameters.Add("@sifre", SqlDbType.VarChar).Value = YeniSifre;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            return sonuc;
        }
    }
    

}
