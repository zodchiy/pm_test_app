using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Entities.UserAggregade;

namespace TestApp.Infrastructure.Data
{
    public class AppDbContexttSeed
    {
        public static async Task SeedAsync(AppDbContext appContext,
        ILogger logger,
        int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (appContext.Database.IsSqlServer())
                {
                    appContext.Database.Migrate();
                }

                if (!await appContext.Countries.AnyAsync())
                {
                    await appContext.Countries.AddRangeAsync(
                        GetPreconfiguredCountries());

                    await appContext.SaveChangesAsync();
                }

                if (!await appContext.Provinces.AnyAsync())
                {
                    await appContext.Provinces.AddRangeAsync(
                        GetPreconfiguredProvinces());

                    await appContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;

                logger.LogError(ex.Message);
                await SeedAsync(appContext, logger, retryForAvailability);
                throw;
            }
        }

        public static IEnumerable<Country> GetPreconfiguredCountries()
        {
            return new List<Country>
            {
                new("Country 1"),
                new("Country 2")
            };
        }

        static IEnumerable<Province> GetPreconfiguredProvinces()
        {
            return new List<Province>
            {
                new(1, "Province 1.1"),
                new(1, "Province 1.2"),
                new(1, "Province 1.3"),
                new(2, "Province 2.1"),
                new(2, "Province 2.2")
            };
        }
    }

}
