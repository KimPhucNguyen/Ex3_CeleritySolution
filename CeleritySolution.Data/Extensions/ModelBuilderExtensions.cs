using CeleritySolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeleritySolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Distributor>().HasData(
              new Distributor() { Id = 1, DistributorName = "Werner" }
              );

            modelBuilder.Entity<Agreement>().HasData(
              new Agreement() { 
                Id = 1,
                Status = "Invalid",
                QuoteNumber = "02776A3",
                AgreementName = "HP PACK AIR INC",
                AgreementType = "SPA",
                EffectiveDate = DateTime.Now,
                ExpirationDate = DateTime.Now,
                CreatedDate = DateTime.Now,
                DaysUntilExplation = 1,
                DistributorId = 1,
              });
        }
    }
}
