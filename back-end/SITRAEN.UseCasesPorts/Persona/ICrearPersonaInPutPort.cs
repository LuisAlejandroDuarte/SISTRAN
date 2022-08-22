

using SITRAEN.DTOs.Persona;

namespace SITRAEN.UseCasesPorts.Persona
{
    public interface ICrearPersonaInPutPort
    {
        Task Handle(PersonaDTO persona);
    }
}
