using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SatisManager : ISatisService
    {
        ISatisDal _satisDal;
        public SatisManager(ISatisDal satisDal)
        {
            _satisDal = satisDal;

        }
        public IDataResult<List<Satis>> GetByUserId(int KullaniciId)
        {
            return new SuccessDataResult<List<Satis>>(_satisDal.GetAll(p => p.KullaniciId == KullaniciId));
        }
    }
}
