using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IKategoriService
    {
        IResult Add(Kategori kategori);
        IDataResult<List<Kategori>> GetAll();
    }
}
