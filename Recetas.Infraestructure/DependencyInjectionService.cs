using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recetas.Application;
using Recetas.Domain.Services.Interfaces.Recetas;
using Recetas.Infraestructure.Database;
using Recetas.Infraestructure.Respositories.Recetas;

namespace Recetas.Infraestructure
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DataBaseService>(options =>
            options.UseSqlServer(configuration["sqlconnectionstrings"]));

            services.AddScoped<IDataBaseService, DataBaseService>();
            services.AddScoped<IRecertaRepository, RecetasRepository>();
            //GetToken
            //services.AddTransient<IGettokenJwt, GetTokenJwtService.GetTokenJwtService>();

            return services;
        }

    }
}
