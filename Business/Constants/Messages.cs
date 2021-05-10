using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string KayitOlundu = "kayit olundu";

        public static string BasariliGiris = "giris yapildi";

        public static string ParolaHatasi = "Parola Hatalı";
        public static string BulunamayanKullanici = "kullanici Bulunamadi";
        public static string TokenOlusturuldu = "Token Olusturuldu";
        public static string MevcutKullanici = "Kullanici Mevcut";

        public static string Listelendi { get; internal set; }
        public static string UrunEklendi { get; internal set; }
    }
}
