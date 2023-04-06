using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Entities.UserAggregade;

namespace TestApp.Infrastructure.Data.Configuration
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.HasOne(p => p.Country)
               .WithMany()
               .HasForeignKey(p => p.CountrydId);
        }
    }
}
