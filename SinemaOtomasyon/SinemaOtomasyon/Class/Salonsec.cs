using SinemaOtomasyon.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaOtomasyon.Class
{
    class Salonsec
    {
        SqlConnection conn = new SqlConnection(Genel.connstr);

        public void koltukgetir(Button dinamikbuton, int salonid, int KoltukNo,string BaslangicSaati)
        {
           
            SqlCommand comm = new SqlCommand("select KoltukBosmu from Koltuklar where SalonID=@SalonID and KoltukNo=@KoltukNo and BaslangicSaati=@BaslangicSaati", conn);
            comm.Parameters.Add("@SalonID", SqlDbType.Int).Value = salonid;
            comm.Parameters.Add("@KoltukNo", SqlDbType.Int).Value = KoltukNo;
            comm.Parameters.Add("@BaslangicSaati", SqlDbType.VarChar).Value = BaslangicSaati;
         
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        if (Convert.ToBoolean(dr["KoltukBosmu"].ToString()) == true)
                        {
                            dinamikbuton.BackColor = Color.Green;
                            dinamikbuton.Enabled = true;
                         


                       
                            
                        }
                        else if (Convert.ToBoolean(dr["KoltukBosmu"].ToString()) == false)
                        {
                            dinamikbuton.BackColor = Color.Red;
                            dinamikbuton.Enabled = false;
                          


                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
               


            finally { conn.Close(); }


        }


        public bool koltuklarikaydet(ListBox liste, int sonlanma, int salonid,string BaslangicSaati)
        {
            bool sonuc = false;
            for (int i = 0; i < sonlanma; i++)
            {
                SqlCommand comm = new SqlCommand("insert into Koltuklar(KoltukNo,KoltukBosmu,SalonID,BaslangicSaati) values(@KoltukNo,@KoltukBosmu,@SalonID,@BaslangicSaati)", conn);
                comm.Parameters.Add("@KoltukNo", SqlDbType.VarChar).Value = liste.Items[i].ToString();
                comm.Parameters.Add("@KoltukBosmu", SqlDbType.Bit).Value = 1;
                comm.Parameters.Add("@SalonID", SqlDbType.Int).Value = salonid;
                comm.Parameters.Add("@BaslangicSaati", SqlDbType.VarChar).Value = BaslangicSaati;
                if (conn.State == ConnectionState.Closed) conn.Open();

                try
                {
                    sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
                }
                catch (SqlException ex)
                {

                    string hata = ex.Message;
                }

                finally { conn.Close(); }

            }
            return sonuc;
        }





        public bool KoltuklariDegistir(ListBox liste, int sonlanma, int salonid,string BaslangicSaati)
        {
            bool sonuc = false;
            for (int i = 0; i < sonlanma; i++)
            {
                SqlCommand comm = new SqlCommand("update Koltuklar set KoltukBosmu=@KoltukBosmu where KoltukNo=@KoltukNo and SalonID=@SalonID and BaslangicSaati=@BaslangicSaati", conn);
                comm.Parameters.Add("@KoltukNo", SqlDbType.VarChar).Value = liste.Items[i].ToString();
                comm.Parameters.Add("@KoltukBosmu", SqlDbType.Bit).Value = 0;
                comm.Parameters.Add("@SalonID", SqlDbType.Int).Value = salonid;
                comm.Parameters.Add("@BaslangicSaati", SqlDbType.VarChar).Value = BaslangicSaati;
                if (conn.State == ConnectionState.Closed) conn.Open();

                try
                {
                    sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
                }
                catch (SqlException ex)
                {

                    string hata = ex.Message;
                }

                finally { conn.Close(); }

            }
            return sonuc;
        }

        public bool KoltukVarmi( int salonid, string BaslangicSaati)
        {
                bool sonuc = false;
              

                    SqlCommand comm = new SqlCommand("select * from Koltuklar where SalonID=@SalonID and BaslangicSaati=@BaslangicSaati", conn);
                    comm.Parameters.Add("@BaslangicSaati", SqlDbType.VarChar).Value = BaslangicSaati;
                    comm.Parameters.Add("@SalonID", SqlDbType.Int).Value = salonid;
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlDataReader dr = comm.ExecuteReader();
                    try
                    {
                        if (dr.HasRows)
                        {
                          
                            sonuc = true;

                            
                        }
                    }
                    catch (SqlException ex)
                    {
                        string hata = ex.Message;
                    }

                    finally { conn.Close(); }

                
            return sonuc;
        }

        public bool KoltuklariBosalt(int salonid,string Baslangicsaati)
        {
            bool sonuc = false;
            
                SqlCommand comm = new SqlCommand("update Koltuklar set KoltukBosmu=1 where SalonID=@SalonID and BaslangicSaati=@BaslangicSaati", conn);
                comm.Parameters.Add("@SalonID", SqlDbType.Int).Value = salonid;
                comm.Parameters.Add("@BaslangicSaati", SqlDbType.VarChar).Value = Baslangicsaati;
                if (conn.State == ConnectionState.Closed) conn.Open();

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
        public void say(TextBox bos, TextBox dolu, int salonid, string BaslangicSaati)
        {
            int bostopla = 0;
            int dolutopla = 0;
            SqlCommand comm = new SqlCommand("select KoltukBosmu from Koltuklar where BaslangicSaati=@BaslangicSaati and SalonID=@SalonID", conn);
            comm.Parameters.Add("@SalonID", SqlDbType.Int).Value = salonid;
            comm.Parameters.Add("@BaslangicSaati", SqlDbType.VarChar).Value = BaslangicSaati;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        if (Convert.ToBoolean(dr["KoltukBosmu"].ToString()) ==true)
                        {
                            bostopla++;
                            bos.Text = bostopla.ToString();
                            
                        }
                        else if (Convert.ToBoolean(dr["KoltukBosmu"].ToString()) == false)
                        {
                            dolutopla++;
                            dolu.Text = dolutopla.ToString();
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

              

            finally 
            {
                 conn.Close();
            }

        }

            
    }
}
