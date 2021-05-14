using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concert
{
  public  class Urun:IEntity
    {
        public int UrunId { get; set; }
        public int KullaniciId { get; set; }
        public int KategoriId { get; set; }
        public int UrunMiktari { get; set; }
        public decimal UrunFiyati { get; set; }
        public string UrunAdi { get; set; }
        
    }
}
