using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concert.EntityFramework;
using Entities.Concert;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concert
{
    public class UrunManager : IUrunService
    {
        IUrunDal _urunDal;
        IParaDal _paraDal;
        ISatisDal _sat;
       


        public UrunManager(IUrunDal urunDal,IParaDal paraDal,ISatisDal satisDal)
        {
            _urunDal = urunDal;
            
            _paraDal = paraDal;
            _sat = satisDal;
           
        }
      
        

        //[SecuredOperation("urun.ekle,yonetici")]
        public IResult Add(Urun urun)
        {
            _urunDal.Add(urun);

            MiniBorsaContext context = new MiniBorsaContext();


            Teklif varMı = context.Teklifler.FirstOrDefault(p => p.Fiyat == urun.UrunFiyati);
            if (varMı != null)
            {
                if (varMı.Miktar == urun.UrunMiktari)
                {
                    decimal maliyet = urun.UrunMiktari * urun.UrunFiyati;
                    Para sahip = context.Paralar.FirstOrDefault(p => p.KullaniciId == urun.KullaniciId);
                    sahip.Miktar += maliyet;
                    _paraDal.Update(sahip);

                    Para alici = context.Paralar.FirstOrDefault(p => p.KullaniciId == varMı.KullaniciId);
                    alici.Miktar -= maliyet;
                    _paraDal.Update(alici);

                    Satis satis = new Satis();
                    satis.KullaniciId = varMı.KullaniciId;
                    satis.Miktar = urun.UrunMiktari;
                    satis.UrunId = urun.UrunId;
                    satis.Tarih = DateTime.Now;

                    _sat.Add(satis);
                    _urunDal.Delete(urun);
                    //_teklifDal.Delete(varMı);





                }

            }

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
