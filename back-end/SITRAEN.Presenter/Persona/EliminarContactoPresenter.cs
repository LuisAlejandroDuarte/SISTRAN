
using SITRAEN.DTOs.Persona;
using SITRAEN.UseCasesPorts.Persona;

namespace SITRAEN.Presenter.Persona
{
    public class EliminarContactoPresenter : IEliminarContactoOutPutPort, IPresenter<ContactoDTO>
    {
        public ContactoDTO Content { get;private set; }

        public Task Handle(ContactoDTO contacto)
        {
            Content = contacto;
            return Task.CompletedTask;
        }
    }
}
