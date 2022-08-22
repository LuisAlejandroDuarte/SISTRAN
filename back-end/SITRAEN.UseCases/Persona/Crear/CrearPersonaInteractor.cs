
using SITRAEN.DTOs.Persona;
using SITRAEN.Entities.Interfaces;
using SITRAEN.UseCasesPorts.Persona;

namespace SITRAEN.UseCases.Persona.Crear
{
    public class CrearPersonaInteractor : ICrearPersonaInPutPort
    {

        readonly IPersonaRepository repository;
        readonly ICrearPersonaOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public CrearPersonaInteractor(IPersonaRepository repository, ICrearPersonaOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(PersonaDTO persona)
        {
            var nPersona= this.repository.Crear(persona);

            await this.unitOfWork.SaveChanges();
            await this.outPutPort.Handle(nPersona);
        }
    }
}
