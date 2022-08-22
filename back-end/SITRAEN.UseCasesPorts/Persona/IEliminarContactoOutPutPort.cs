using SITRAEN.DTOs.Persona;

namespace SITRAEN.UseCasesPorts.Persona
{
    public interface IEliminarContactoOutPutPort
    {
        Task Handle(ContactoDTO contacto);
    }
}
