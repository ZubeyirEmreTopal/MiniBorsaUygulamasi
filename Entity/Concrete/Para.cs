using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concert
{
   public class Para:IEntity
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public decimal Miktar { get; set; }
    }
}
