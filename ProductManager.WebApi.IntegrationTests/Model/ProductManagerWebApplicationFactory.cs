using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProductManager.Persistence.Contexts;

namespace ProductManager.WebApi.IntegrationTests.Model;

public class ProductManagerWebApplicationFactory : WebApplicationFactory<Program>
{
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<ProductDbContext>));

            var connString = GetConnectionString();
            services.AddSqlServer<ProductDbContext>(connString);

            var dbContext = CreateDbContext(services);
            

        });
    }

    private static string? GetConnectionString()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<ProductManagerWebApplicationFactory>()
            .Build();

        return configuration.GetConnectionString("ProductTestConnectionString");
    }

    private static ProductDbContext CreateDbContext(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var scope = serviceProvider.CreateScope();
        return scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    }
}