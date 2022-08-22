using Microsoft.Extensions.DependencyInjection;
using SITRAEN.Presenter.Persona;
using SITRAEN.UseCasesPorts.Persona;

namespace SITRAEN.Presenter
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            


            //Persona
            services.AddScoped<ICrearPersonaOutPutPort, CrearPersonaPresenter>();            
            services.AddScoped<IGetPersonaOutPutPort, GetSuscriptorPresenter>();
            services.AddScoped<IGetAllPersonasOutPutPort, GetAllSuscriptoresPresenter>();
            services.AddScoped<IEliminarContactoOutPutPort, EliminarContactoPresenter>();


            return services;
        }
    }
}
