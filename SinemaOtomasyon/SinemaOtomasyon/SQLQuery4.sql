USE [SinemaOtomasyon]
GO
/****** Object:  StoredProcedure [dbo].[SP_CalisanEkle]    Script Date: 8.5.2016 14:06:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[SP_CalisanEkle]
@Ad varchar(50),
@Soyad varchar(50),
@TCNo varchar(11),
@Telefon varchar(50),
@Mail varchar(50),
@Adres varchar(200),
@Cevap varchar(50),
@KullaniciAdi varchar(50),
@Sifre varchar(50)
as
Insert Into CalisanTablosu(KullaniciAdi ,Sifre) values (@KullaniciAdi,@Sifre)
Insert Into CalisanBilgi(Ad,Soyad,TcNo,Telefon,Mail,Adres,Cevap)values(@Ad,@Soyad,@TCNo,@Telefon,@Mail,@Adres,@Cevap)
go