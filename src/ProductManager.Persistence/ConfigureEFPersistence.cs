using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProductManager.Persistence.Contexts;

namespace ProductManager.Persistence
{
    public static class PersistenceSetup
    {
        const int defaultCommandTimeoutSeconds = 60;
        public static void ConfigurePersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var timeOut = int.TryParse(configuration["Database:CommandTimeout"], out int parsedValue) ?
              parsedValue : defaultCommandTimeoutSeconds;
            var productConnectionString = configuration["ConnectionStrings:ProductConnectionString"];

            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(productConnectionString, providerOptions =>
                {
                    providerOptions.MigrationsAssembly("ProductManager.Persistence");
                    providerOptions.CommandTimeout(timeOut);
                });
            }, ServiceLifetime.Scoped
            );

        }


    }
}
