using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestApp.Infrastructure.Data;
using TestApp.Infrastructure.Identity;

namespace TestApp.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            bool useOnlyInMemoryDatabase = true;          

            if (useOnlyInMemoryDatabase)
            {
                 services.AddDbContext<AppDbContext>(c =>
                    c.UseInMemoryDatabase("AppDb"));

                 services.AddDbContext<AppIdentityDbContext>(options =>
                     options.UseInMemoryDatabase("AppIdentityDb"));
                /*services.AddDbContext<AppDbContext>(c =>
                 c.UseSqlServer(configuration.GetConnectionString("string")));

                // Add Identity DbContext
                services.AddDbContext<AppIdentityDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("string")));*/

            }
            else
            {
                // use real database               
            }
        }
    }

}
