using SITRAEN.DTOs.Persona;
using SITRAEN.UseCasesPorts.Persona;

namespace SITRAEN.Presenter.Persona
{
    public class CrearPersonaPresenter : ICrearPersonaOutPutPort, IPresenter<PersonaDTO>
    {
        public PersonaDTO Content { get;private set; }   

        public Task Handle(PersonaDTO Persona)
        {
            Content = Persona;
            return Task.CompletedTask;
        }
    }
}
