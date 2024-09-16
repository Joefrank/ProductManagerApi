using ProductManager.Application.Interface.Persistence;
using ProductManager.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;

namespace ProductManager.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            //services.AddSingleton<DapperContext>();
            services.AddDbContext<ProductDbContext>();
            return services;
        }       

    }
}
