using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
   public  class KullaniciGirisDto:IDtos
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
