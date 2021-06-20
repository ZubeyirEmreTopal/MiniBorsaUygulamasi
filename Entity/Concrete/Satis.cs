using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public  class Satis:IEntity
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int UrunId { get; set; }
        public int Miktar { get; set; }
        public DateTime Tarih { get; set; }
    }
}
