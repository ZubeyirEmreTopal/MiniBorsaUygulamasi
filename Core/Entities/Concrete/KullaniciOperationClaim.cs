using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
   public class KullaniciOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
