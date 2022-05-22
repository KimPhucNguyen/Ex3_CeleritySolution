using CeleritySolution.Data.Configurations;
using CeleritySolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeleritySolution.Data.EF
{
    public class CelerityDbContext : DbContext
    {
        public CelerityDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DistributorConfiguration());
            modelBuilder.ApplyConfiguration(new AgreementConfiguration());

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
    }
}
