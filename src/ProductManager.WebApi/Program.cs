
using Microsoft.OpenApi.Models;
using ProductManager.Application.UseCases;
using ProductManager.Domain.Entities;
using ProductManager.Persistence;
using ProductManager.Persistence.Contexts;
using ProductManager.WebApi.Extensions.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigurePersistenceContexts(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add authentication
builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);

//add authorization
builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<AppUser>()
    .AddEntityFrameworkStores<ProductDbContext>()
    .AddApiEndpoints();

//Add methods Extensions
builder.Services.AddInjectionPersistence();
builder.Services.AddInjectionApplication();

//this is for swagger authentication
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                          Enter 'Bearer' [space] and then your token in the text input below.
                          \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement(){
            {
                new OpenApiSecurityScheme{
                    Reference = new OpenApiReference{
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        });

});
builder.Services.AddScoped<DataSeeder>();

var app = builder.Build();
app.MapIdentityApi<AppUser>();


//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<ProductDbContext>();     

        await dbContext.Database.MigrateAsync();
        var dataSeeder = services.GetRequiredService<DataSeeder>();
        await dataSeeder.CreateDefaultProductsAsync();
    }

    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API Demo v1");
        c.RoutePrefix = "swagger";
    });

}
app.UseHttpsRedirection();

// Use Authentication and Authorization middlewares
app.UseAuthentication();
app.UseAuthorization();

app.AddMiddleware();

app.MapControllers();

app.Run();

public partial class Program { } //this is for testing with WebApplicationFactory and IClassFixture