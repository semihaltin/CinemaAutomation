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
    class Kampanya
    { public int _kampanyaID { get; set; }
        public string _kampanyaAdi { get; set; }
        public int _kampanyaFiyat { get; set; }


        DataTable dt = new DataTable();

        SqlConnection conn = new SqlConnection(Genel.connstr);
        internal bool KampanyaBilgileriGuncelle(Kampanya k)
        {
            dt.Clear();
            bool sonuc = false;
            SqlCommand cmd = new SqlCommand("Update BiletTuru set BiletTurAd=@kampanyaadi , Fiyat=@fiyat where BiletTurNo=@turno", conn);
            cmd.Parameters.Add("@kampanyaadi", SqlDbType.VarChar).Value = k._kampanyaAdi;
            cmd.Parameters.Add("@fiyat", SqlDbType.Int).Value = k._kampanyaFiyat;
            cmd.Parameters.Add("@turno", SqlDbType.Int).Value = k._kampanyaID;
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

        internal bool KampanyaSil(int KampanyaId)
        {
            dt.Clear();
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update BiletTuru Set Silindi=1 where BiletTurNo=@id", conn);
            comm.Parameters.Add("@id", SqlDbType.Int).Value = KampanyaId;
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

        internal DataTable KampanyaGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from BiletTuru where Silindi=0",conn);
            try
            {
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return dt;





        
    }

        internal void KampanyaGetir(ComboBox liste)
        {

            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select * from BiletTuru", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Kampanya k = new Kampanya();
                    k._kampanyaFiyat = Convert.ToInt32(dr["Fiyat"]);
                    k._kampanyaAdi = dr["BiletTurAd"].ToString();
                    liste.Items.Add(k);
                }
            }
            dr.Close();
            conn.Close();
        }
        public override string ToString()
        {
            return _kampanyaAdi;
        }
    }
}
