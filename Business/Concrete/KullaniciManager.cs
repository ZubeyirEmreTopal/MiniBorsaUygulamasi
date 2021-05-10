using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class KullaniciManager : IKullaniciService
    {
        IKullaniciDal _kullaniciDal;
        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;

        }
        public void Add(Kullanici kullanici)
        {
            _kullaniciDal.Add(kullanici);
        }

        public List<OperationClaim> GetClaims(Kullanici kullanici)
        {
            return _kullaniciDal.GetClaims(kullanici);
        }

        public Kullanici GetByEmail(string email)
        {
            return _kullaniciDal.Get(u => u.Email == email);
        }
    }
}
