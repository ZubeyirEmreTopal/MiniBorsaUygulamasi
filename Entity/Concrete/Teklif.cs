using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Teklif : IEntity
    {
        public int TeklifId { get; set; }
        public int KullaniciId { get; set; }
        public int UrunId { get; set; }
        public int Miktar { get; set; }
        public decimal Fiyat { get; set; }
    }
}
