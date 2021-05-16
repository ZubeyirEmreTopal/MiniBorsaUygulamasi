using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IKullaniciService
    {
        List<OperationClaim> GetClaims(Kullanici user);
        void Add(Kullanici user);
        Kullanici GetByMail(string email);

    }
}
