create proc SP_CalisanEkle
@Ad varchar(50),
@Soyad varchar(50),
@TCNo varchar(11),
@Telefon varchar(50),
@Mail varchar(50),
@Adres varchar(200),
@GuvenlikSorusu varchar(50),
@Cevap varchar(50),
@KullaniciAdi varchar(50),
@Sifre varchar(50)
as
Insert Into CalisanTablosu(KullaniciAdi ,Sifre) values (@KullaniciAdi,@Sifre)

Insert into CalisanBilgi (Ad, Soyad, TcNo, Telefon,Mail,Adres,GuvenlikSorusu,Cevap) values(@Ad, @Soyad, @TCNo, @Telefon,@Mail ,@Adres,@GuvenlikSorusu ,@Cevap )
go