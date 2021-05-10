using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IKullaniciService
    {
        List<OperationClaim> GetClaims(Kullanici kullanici);
        void Add(Kullanici kullanici);
        Kullanici GetByEmail(string email);

    }
}
