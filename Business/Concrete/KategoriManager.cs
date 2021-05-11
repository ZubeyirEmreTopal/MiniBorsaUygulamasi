using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public  class KategoriManager:IKategoriService

    {
        IKategoriDal _kategoriDal;
        public KategoriManager(IKategoriDal kategoriDal)
        {
            _kategoriDal = kategoriDal;

        }

        public IResult Add(Kategori kategori)
        {
            _kategoriDal.Add(kategori);
            return new SuccessResult(Messages.KategoriEklendi);
            
        }

        public IDataResult<List<Kategori>> GetAll()
        {
            return new SuccessDataResult<List<Kategori>>(_kategoriDal.GetAll(), Messages.Listelendi);
        }
    }
}
