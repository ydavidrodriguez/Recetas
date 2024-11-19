using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Recetas.Application.Configuration;
using System.Reflection;

namespace Recetas.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());

            });
            services.AddSingleton(mapper.CreateMapper());

            return services;

        }

    }
}
