using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SITRAEN.Entities.Interfaces;
using SITRAEN.RepositoryEF.DataContext;
using SITRAEN.RepositoryEF.Repositories;
using System.Reflection;


namespace SITRAEN.RepositoryEF
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SitraenContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConectionString")));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());            
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;

        }
    }
}
