using Core.Utilities.Results;
using Entities.Concert;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IParaService
    {
        IResult Add(Para para);
        IResult Update(Para para);
    }
}
