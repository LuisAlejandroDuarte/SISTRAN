using SITRAEN.Entities.Interfaces;
using SITRAEN.UseCasesPorts.Persona;

namespace SITRAEN.UseCases.Persona.Get
{
    public class GetPersonaInteractor : IGetPersonaInPutPort
    {

        readonly IPersonaRepository repository;
        readonly IGetPersonaOutPutPort outPutPort;

        public GetPersonaInteractor(IPersonaRepository repository, IGetPersonaOutPutPort outPutPort)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
        }

        public Task Handle(long Id)
        {
            var persona = this.repository.Get(Id);
            this.outPutPort.Handle(persona);

            return Task.CompletedTask;
        }
    }
}
