using SITRAEN.DTOs.Persona;
using SITRAEN.UseCasesPorts.Persona;

namespace SITRAEN.Presenter.Persona
{
    public class GetSuscriptorPresenter : IGetPersonaOutPutPort, IPresenter<PersonaDTO>
    {
        public PersonaDTO Content { get; private set; }

        public Task Handle(PersonaDTO Persona)
        {
            Content = Persona;
            return Task.CompletedTask;
        }
    }
}
