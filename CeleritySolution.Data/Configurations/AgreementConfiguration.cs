using CeleritySolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeleritySolution.Data.Configurations
{
    public class AgreementConfiguration : IEntityTypeConfiguration<Agreement>
    {
        public void Configure(EntityTypeBuilder<Agreement> builder)
        {
            builder.ToTable("Agreements");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.QuoteNumber).IsRequired();
            builder.Property(x => x.AgreementName).IsRequired();
            builder.Property(x => x.AgreementType).IsRequired();
            builder.Property(x => x.EffectiveDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ExpirationDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.DaysUntilExplation).IsRequired();

            builder.HasOne(x => x.Distributor).WithMany(x => x.Agreements).HasForeignKey(x => x.DistributorId);
        }
    }
}
