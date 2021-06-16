using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ITeklifService
    {
        IResult Add(Teklif teklif);
        IDataResult<List<Teklif>> GetAll();
    }
}
