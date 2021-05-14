using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concert;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concert
{
    public class UrunManager : IUrunService
    {
         IUrunDal _urunDal;

        public UrunManager(IUrunDal urunDal)
        {
            _urunDal = urunDal;
        }
        public IResult Add(Urun urun)
        {
            _urunDal.Add(urun);

                return new SuccessResult(Messages.UrunEklendi);
        }

        public IDataResult<List<Urun>> GetAll()
        {
            return new SuccessDataResult<List<Urun>>(_urunDal.GetAll(), Messages.Listelendi);
        }

        public IDataResult<List<Urun>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Urun>>(_urunDal.GetAll(p => p.KategoriId == id));
        }
    }
}
