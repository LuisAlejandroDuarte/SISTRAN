using SITRAEN.DTOs.Persona;

namespace SITRAEN.UseCasesPorts.Persona
{
    public interface ICrearPersonaOutPutPort
    {
        Task Handle(PersonaDTO persona);
    }
}
