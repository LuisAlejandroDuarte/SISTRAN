
using SITRAEN.DTOs.Persona;

namespace SITRAEN.UseCasesPorts.Persona
{
    public interface IGetPersonaOutPutPort
    {
        Task Handle(PersonaDTO persona);
    }
}
