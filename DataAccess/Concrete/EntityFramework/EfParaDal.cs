using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concert;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concert.EntityFramework
{
    public class EfParaDal :EfEntityRepositoryBase<Para,MiniBorsaContext>,IParaDal
    {
       
    }
}
