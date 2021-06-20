using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface ISatisService
    {
        IDataResult<List<Satis>> GetByUserId(int KullaniciId);
    }
}
