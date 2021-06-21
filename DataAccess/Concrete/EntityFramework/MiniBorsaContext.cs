
using Core.Entities.Concrete;
using Entities.Concert;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concert.EntityFramework
{
  public  class MiniBorsaContext:DbContext
    {
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MiniBorsa;Trusted_Connection=true");
        }

       public DbSet<Urun> Urunler { get; set; }
       public DbSet<Para> Paralar { get; set; }
       public DbSet<Kullanici> Kullanicilar { get; set; }
       public DbSet<OperationClaim> OperationClaims { get; set; }
       public DbSet<KullaniciOperationClaim> KullaniciOperationClaims { get; set; }
       public DbSet<Kategori> Kategoriler { get; set; }

        public DbSet<Teklif> Teklifler { get; set; }
        public DbSet<Satis> Satislar { get; set; }
       
    

    }
}
