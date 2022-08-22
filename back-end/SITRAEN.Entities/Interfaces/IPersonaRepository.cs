

using SITRAEN.DTOs.Persona;

namespace SITRAEN.Entities.Interfaces
{
    public interface IPersonaRepository
    {
        IEnumerable<PersonaDTO> GetAll();
        PersonaDTO Crear(PersonaDTO suscriptor);        
        PersonaDTO Get(long Id);        
        ContactoDTO EliminarContacto(long id);
    }
}
