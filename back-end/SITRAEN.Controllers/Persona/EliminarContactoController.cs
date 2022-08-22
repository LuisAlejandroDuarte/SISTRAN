using Microsoft.AspNetCore.Mvc;
using SITRAEN.DTOs.Persona;
using SITRAEN.Presenter;
using SITRAEN.UseCasesPorts.Persona;


namespace SITRAEN.Controllers.Persona
{
    [Route("api/[controller]")]
    [ApiController]
    public class EliminarContactoController
    {

        readonly IEliminarContactoInPutPort inPutPort;
        readonly IEliminarContactoOutPutPort outPutPort;

        public EliminarContactoController(IEliminarContactoInPutPort inPutPort, IEliminarContactoOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }

        [HttpDelete("{Id}")]

        public async Task<ContactoDTO> EliminarContacto(long Id)
        {
            await this.inPutPort.Handle(Id);
            return ((IPresenter<ContactoDTO>)outPutPort).Content;
        }
    }
}
