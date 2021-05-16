using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
   public class KullaniciKayitDto:IDtos
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int TC { get; set; }
        public string Adres { get; set; }
    }
}
