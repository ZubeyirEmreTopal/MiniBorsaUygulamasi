using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concert;
using Entities.Dtos;
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

        //[SecuredOperation("urun.ekle,yonetici")]
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

        public IDataResult<List<UrunDetayi>> GetProductDetails()
        {
            return new SuccessDataResult<List<UrunDetayi>>(_urunDal.GetCarDetails());
        }
    }
}
