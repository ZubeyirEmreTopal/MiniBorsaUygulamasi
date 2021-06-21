using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concert;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Core.Entities.Concrete;

namespace DataAccess.Concert.EntityFramework
{
    public class EfUrunDal : EfEntityRepositoryBase<Urun, MiniBorsaContext>, IUrunDal
    {
        public List<UrunDetayi> GetCarDetails(Expression<Func<UrunDetayi, bool>> filter = null)
        {
            using (MiniBorsaContext context = new MiniBorsaContext())
            {
                var result = from u in context.Urunler
                             join k in context.Kullanicilar
                             on u.KullaniciId equals k.Id
                              join ka in context.Kategoriler
                             on u.KategoriId equals ka.KategoriId
                             select new UrunDetayi
                             {
                                 Id = k.Id,
                                 KategoriId=ka.KategoriId,
                                 KullaniciAdi = k.Adi,
                                 UrunAdi = u.UrunAdi,
                                 UrunMiktari = u.UrunMiktari,
                                 UrunFiyati = u.UrunFiyati
                             };
                             return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }

        //public void Sat(int kullaniciId, int urunId)
        //{
        //    using (MiniBorsaContext context=new MiniBorsaContext())
        //    {
        //        var result = context.Find<Urun>();

        //        if (result.UrunId == urunId)
        //        {
        //            if (result.KullaniciId != kullaniciId)
        //            {
                        
        //            }

        //        }


        //    }
        //}
    }
}
