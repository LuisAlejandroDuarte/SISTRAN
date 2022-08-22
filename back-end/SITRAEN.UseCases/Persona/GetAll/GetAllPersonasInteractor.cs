using SITRAEN.DTOs;
using SITRAEN.Entities.Interfaces;
using SITRAEN.UseCasesPorts.Persona;

namespace SITRAEN.UseCases.Personaes.GetAll
{
    public class GetAllPersonasInteractor : IGetAllPersonasInPutPort
    {

        readonly IPersonaRepository repository;
        readonly IGetAllPersonasOutPutPort outPutPort;

        public GetAllPersonasInteractor(IPersonaRepository repository, IGetAllPersonasOutPutPort outPutPort)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
        }

        public Task Handle()
        {
            var personas = this.repository.GetAll();

            this.outPutPort.Handle(personas);

            return Task.CompletedTask;
        }
    }
}
