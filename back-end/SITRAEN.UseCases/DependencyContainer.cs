
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SITRAEN.UseCases.Persona.Crear;
using SITRAEN.UseCases.Persona.EliminarContacto;
using SITRAEN.UseCases.Persona.Get;
using SITRAEN.UseCases.Personaes.GetAll;
using SITRAEN.UseCasesPorts.Persona;


namespace SITRAEN.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services, IConfiguration configuration)
        {          
            //Personas                        
            services.AddTransient<ICrearPersonaInPutPort, CrearPersonaInteractor>();                        
            services.AddTransient<IGetPersonaInPutPort, GetPersonaInteractor>();
            services.AddTransient<IGetAllPersonasInPutPort, GetAllPersonasInteractor>();
            services.AddTransient<IEliminarContactoInPutPort, EliminarContactoInteractor>();

            return services;
        }
    }
}
