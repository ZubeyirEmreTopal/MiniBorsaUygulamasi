using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concert;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concert
{
  public  class ParaManager:IParaService
    {
        IParaDal _paraDal;
        public ParaManager(IParaDal paraDal)
        {
            _paraDal = paraDal;

        }

       public void Add(Para para)
        {
            _paraDal.Add(para);

        }
    }
}
