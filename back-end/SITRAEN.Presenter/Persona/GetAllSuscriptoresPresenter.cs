
using SITRAEN.DTOs.Persona;
using SITRAEN.UseCasesPorts.Persona;

namespace SITRAEN.Presenter.Persona
{
    public class GetAllSuscriptoresPresenter : IGetAllPersonasOutPutPort, IPresenter<IEnumerable<PersonaDTO>>
    {
        public IEnumerable<PersonaDTO> Content { get; private set; }

        public Task Handle(IEnumerable<PersonaDTO> personas)
        {
            Content = personas;
            return Task.CompletedTask;
        }
    }
}
