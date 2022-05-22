using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeleritySolution.Data.EF
{
    public class CelerityDbContextFactory : IDesignTimeDbContextFactory<CelerityDbContext>
    {
        public CelerityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("CeleritySolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<CelerityDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CelerityDbContext(optionsBuilder.Options);
        }
    }
}
