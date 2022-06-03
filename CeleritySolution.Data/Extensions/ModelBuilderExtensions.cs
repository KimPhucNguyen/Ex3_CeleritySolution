using CeleritySolution.Data.Entities;
using Microsoft.AspNetCore.Identity;
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

            // any guid
            var roleId = new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3301");
            var adminId = new Guid("A2934FA2-6F7E-4AC9-8210-681814AC86C4");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin.celerity@gmail.com",
                NormalizedEmail = "admin.celerity@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@1234"),
                SecurityStamp = string.Empty,
                FirstName = "Phuc",
                LastName = "Nguyen",
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
