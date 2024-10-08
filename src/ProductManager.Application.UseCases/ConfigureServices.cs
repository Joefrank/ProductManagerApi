﻿using ProductManager.Application.UseCases.Commons.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ProductManager.Domain.Repositories;
using ProductManager.Persistence.Repositories;


namespace ProductManager.Application.UseCases
{
    public static class ConfigureServices
    {
        public static void AddInjectionApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
        }

    }
}
