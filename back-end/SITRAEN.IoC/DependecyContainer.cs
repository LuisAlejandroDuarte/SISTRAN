using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SITRAEN.Controllers;
using SITRAEN.Presenter;
using SITRAEN.RepositoryEF;
using SITRAEN.UseCases;

namespace SITRAEN.IoC
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddServicioPublicoDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddUseCasesServices(configuration);
            services.AddPresenters();
            services.AddHttpContext();

            return services;
        }
    }
}
