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
            DateTime tarih = Convert.ToDateTime(xmldosya.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
           decimal dolarAlis =Convert.ToDecimal(xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerText.Replace(".",","));
            decimal euroAlis = Convert.ToDecimal(xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerText.Replace(".", ","));


            if (para.DovizKodu == "USD")
            {
                
                para.Miktar = dolarAlis * para.Miktar;
                para.DovizKodu = "TRY";
            }
            else if (para.DovizKodu == "EUR")
            {
                para.Miktar = euroAlis * para.Miktar;
                para.DovizKodu = "TRY";
            }



            MiniBorsaContext context = new MiniBorsaContext();
            Para varMı = context.Paralar.FirstOrDefault(p => p.Id == para.KullaniciId);
            Para muhabse = context.Paralar.FirstOrDefault(p => p.KullaniciId == 1003);

            if (muhabse != null)
            {
                muhabse.Miktar += para.Miktar * 1 / 100;

                _paraDal.Update(muhabse);
                para.Miktar = para.Miktar - (para.Miktar * 1 / 100);

            }


            if (varMı != null)
            {
                varMı.Miktar += para.Miktar;
                _paraDal.Update(varMı);
                
            }
            else
            {
                _paraDal.Add(para);
            }
           


           



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
