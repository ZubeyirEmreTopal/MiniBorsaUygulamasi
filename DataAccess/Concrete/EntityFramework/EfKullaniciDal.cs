using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concert.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfKullaniciDal : EfEntityRepositoryBase<Kullanici, MiniBorsaContext>, IKullaniciDal
    {
        public List<OperationClaim> GetClaims(Kullanici kullanici)
        {
            using (var context=new MiniBorsaContext())
            {
                var sonuc = from operationClaim in context.OperationClaims
                            join kullaniciOperationClaim in context.KullaniciOperationClaims
                            on operationClaim.Id equals kullaniciOperationClaim.OperationClaimId
                            where kullaniciOperationClaim.KullaniciId == kullanici.Id
                            select new OperationClaim { Id = operationClaim.Id, Isim = operationClaim.Isim };
                return sonuc.ToList();
            }
        }
    }
}
