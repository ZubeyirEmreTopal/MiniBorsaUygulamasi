using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concert.EntityFramework;
using Entities.Concert;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    class TeklifManager:ITeklifService
    {
        ITeklifDal _teklifDal;
       
        public TeklifManager(ITeklifDal teklifDal)
        {

            _teklifDal = teklifDal;
            

        }

        public IResult Add(Teklif teklif)
        {

            _teklifDal.Add(teklif);

            return new SuccessResult(Messages.TeklifVerildi);
        }

        public IDataResult<List<Teklif>> GetAll()
        {
            return new SuccessDataResult<List<Teklif>>(_teklifDal.GetAll(),Messages.Listelendi);
        
        }

        

    }
}
