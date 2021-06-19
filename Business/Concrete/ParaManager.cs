using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concert.EntityFramework;
using Entities.Concert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Business.Concert
{
  public  class ParaManager:IParaService
    {
        IParaDal _paraDal;
        public ParaManager(IParaDal paraDal)
        {
            _paraDal = paraDal;

        }

       public IResult Add(Para para)
        {
            string Bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(Bugun);
            string dolarAlis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@kod='USD']/BanknoteBuying").InnerXml;


            if (para.DovizKodu == "USD")
            {
                para.Miktar = Convert.ToInt32(dolarAlis) * para.Miktar;
                para.DovizKodu = "TRY";
            }
            MiniBorsaContext context = new MiniBorsaContext();
            Para varMı = context.Paralar.FirstOrDefault(p => p.Id == para.KullaniciId);
           

            if (varMı != null)
            {
                varMı.Miktar += para.Miktar;
                _paraDal.Update(varMı);
                
            }
            else
            {
                _paraDal.Add(para);
            }
           


            //if (para.dovizkodu != "TRY")
            //    para.Miktar = tldegerinial(para);
            //_paraDal.Add(para);



            return new SuccessResult(Messages.ParaEklendi);
        }

        public IResult Update(Para para)
        {
            throw new NotImplementedException();
            
        }
        //decimal tldegerinial(Para para)
        // {

        // }
    }
}
