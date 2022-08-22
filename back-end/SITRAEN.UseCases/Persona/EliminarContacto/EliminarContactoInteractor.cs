using SITRAEN.DTOs.Persona;
using SITRAEN.Entities.Interfaces;
using SITRAEN.Entities.POCOs;
using SITRAEN.UseCasesPorts.Persona;

namespace SITRAEN.UseCases.Persona.EliminarContacto
{
    public class EliminarContactoInteractor : IEliminarContactoInPutPort
    {
        readonly IPersonaRepository repository;
        readonly IEliminarContactoOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public EliminarContactoInteractor(IPersonaRepository repository, IEliminarContactoOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(long id)
        {
            var rcontacto = this.repository.EliminarContacto(id);
            await this.unitOfWork.SaveChanges();
            await this.outPutPort.Handle(rcontacto);
        }
    }
}
