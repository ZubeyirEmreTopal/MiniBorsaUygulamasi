using Core.DataAccess;
using Entities.Concert;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IUrunDal:IEntityRepository<Urun>
    {
        List<UrunDetayi> GetCarDetails(Expression<Func<UrunDetayi, bool>> filter = null);
    }
}
