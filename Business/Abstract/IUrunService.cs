using Core.Utilities.Results;
using Entities.Concert;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUrunService
    {
        IResult Add(Urun urun);
        IDataResult<List<Urun>> GetAll();
        IDataResult<List<Urun>> GetAllByCategoryId(int kategoriId);
        IDataResult<List<UrunDetayi>> GetProductDetails();
    }
}
