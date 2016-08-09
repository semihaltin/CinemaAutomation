using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinemaOtomasyon.model;

namespace SinemaOtomasyon.Class
{
    class BiletSatis
    {
    //    private int _biletsatisID;
    //    private int _biletsatisadet;
    //    private int _biletturno;
    //    private double _tutar;
    //    private int _filmID;
    //    private string _satistarihi;
    //    private int _salonno;
    //    private string _aciklama;
    //    private int _calisanID;
    //    private int _seansID;
    //    private string _koltukno;

    //    private string _filmadi;

    //    public string Filmadi
    //    {
    //        get { return _filmadi; }
    //        set { _filmadi = value; }
    //    }
    //    private string _calisanadi;

    //    public string Calisanadi
    //    {
    //        get { return _calisanadi; }
    //        set { _calisanadi = value; }
    //    }
    //    private string _seans;

    //    public string Seans
    //    {
    //        get { return _seans; }
    //        set { _seans = value; }
    //    }

    //    public string Koltukno
    //    {
    //        get { return _koltukno; }
    //        set { _koltukno = value; }
    //    }

    //    #region Properties

    //    public int BiletsatisID
    //    {
    //        get { return _biletsatisID; }
    //        set { _biletsatisID = value; }
    //    }

    //    public int Biletsatisadet
    //    {
    //        get { return _biletsatisadet; }
    //        set { _biletsatisadet = value; }
    //    }

    //    public int Biletturno
    //    {
    //        get { return _biletturno; }
    //        set { _biletturno = value; }
    //    }

    //    public double Tutar
    //    {
    //        get { return _tutar; }
    //        set { _tutar = value; }
    //    }

    //    public int FilmID
    //    {
    //        get { return _filmID; }
    //        set { _filmID = value; }
    //    }

    //    public string Satistarihi
    //    {
    //        get { return _satistarihi; }
    //        set { _satistarihi = value; }
    //    }

    //    public int Salonno
    //    {
    //        get { return _salonno; }
    //        set { _salonno = value; }
    //    }

    //    public string Aciklama
    //    {
    //        get { return _aciklama; }
    //        set { _aciklama = value; }
    //    }

    //    public int CalisanID
    //    {
    //        get { return _calisanID; }
    //        set { _calisanID = value; }
    //    }


    //    public int SeansID
    //    {
    //        get { return _seansID; }
    //        set { _seansID = value; }
    //    }
    //    #endregion


    //    SqlConnection conn = new SqlConnection(Genel.connstr);

    //    //internal DataTable TarihlerarasiBiletSatisGetir(DateTime Tarih1, DateTime Tarih2)
    //    //{
    //    //    DataTable dt = new DataTable();
    //    //    SqlDataAdapter da = new SqlDataAdapter("Select Convert(Date, SatisTarihi, 104) as İşlemTarihi, BiletSatisAdet, BiletTurNo, FilmID, CalisanID,SalonNo,SeansID from BiletSatis where Convert(Date, SatisTarihi, 104) between Convert(Date, @Tarih1, 104) and Convert(Date, @Tarih2, 104)", conn);

    //    //    da.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = Tarih1;
    //    //    da.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = Tarih2;
    //    //    try
    //    //    {
    //    //        da.Fill(dt);
    //    //    }
    //    //    catch (SqlException ex)
    //    //    {
    //    //        string hata = ex.Message;
    //    //    }
    //    //    return dt;
    //    //}

    //    public bool BiletSatisEkle(BiletSatis bs)
    //    {
    //        bool Sonuc = false;
    //        SqlCommand comm = new SqlCommand("Insert into BiletSatis (Tutar, SatisTarihi, SalonNo, CalisanAdi, Seans, FilmAdi, KoltukNo) values (@Tutar,@SatisTarihi, @SalonNo, @CalisanAdi, @Seans, @FilmAdi,@KoltukNo)", conn);
    //        //comm.Parameters.Add("@BiletSatisAdet", SqlDbType.Int).Value = bs._biletsatisadet;
    //        comm.Parameters.Add("@SatisTarihi", SqlDbType.VarChar).Value = bs._satistarihi;
    //        comm.Parameters.Add("@Tutar", SqlDbType.Money).Value = bs._tutar;
    //        comm.Parameters.Add("@SalonNo", SqlDbType.Int).Value = bs._salonno;
    //        comm.Parameters.Add("@CalisanAdi", SqlDbType.VarChar).Value = bs._calisanadi;
    //        comm.Parameters.Add("@Seans", SqlDbType.VarChar).Value = bs._seans;
    //        comm.Parameters.Add("@FilmAdi", SqlDbType.VarChar).Value = bs._filmadi;
    //        comm.Parameters.Add("@KoltukNo", SqlDbType.VarChar).Value = bs._koltukno;
    //        if (conn.State == ConnectionState.Closed) conn.Open();
    //        try
    //        {
    //            Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
    //        }
    //        catch (SqlException ex)
    //        {
    //            string hata = ex.Message;
    //        }
    //        finally { conn.Close(); }
    //        return Sonuc;
    //    }
    }
}
