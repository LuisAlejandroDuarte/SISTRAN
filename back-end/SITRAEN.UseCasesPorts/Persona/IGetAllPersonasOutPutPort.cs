
using SITRAEN.DTOs.Persona;

namespace SITRAEN.UseCasesPorts.Persona
{
    public interface IGetAllPersonasOutPutPort
    {
        Task Handle(IEnumerable<PersonaDTO> personas);
    }
}
