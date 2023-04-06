using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Entities.UserAggregade;
using TestApp.Core.Entities;

namespace TestApp.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();
            builder.HasOne(p => p.Country)
               .WithMany()
               .HasForeignKey(p => p.CountrydId);
            builder.HasOne(p => p.Province)
               .WithMany()
               .HasForeignKey(p => p.ProvinceId);
        }
    }
}
