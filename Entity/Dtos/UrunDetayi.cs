using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
   public class UrunDetayi:IDtos
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public string KullaniciAdi { get; set; }
        
        public string UrunAdi { get; set; }
        public decimal UrunFiyati { get; set; }
        public int UrunMiktari { get; set; }
    }
}
