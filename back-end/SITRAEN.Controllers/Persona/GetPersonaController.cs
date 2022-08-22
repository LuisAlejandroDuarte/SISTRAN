using Microsoft.AspNetCore.Mvc;
using SITRAEN.DTOs.Persona;
using SITRAEN.Presenter;
using SITRAEN.UseCasesPorts.Persona;

namespace SITRAEN.Controllers.Suscriptores
{

    [Route("api/[controller]")]
    [ApiController]
    public class GetPersonaController
    {
        readonly IGetPersonaInPutPort inPutPort;
        readonly IGetPersonaOutPutPort outPutPort;

        public GetPersonaController(IGetPersonaInPutPort inPutPort, IGetPersonaOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }

        [HttpGet("{Id}")]
        
        public async Task<PersonaDTO> GetPersona(long Id)
        {
            await this.inPutPort.Handle(Id);
            return ((IPresenter<PersonaDTO>)outPutPort).Content;
        }
    }
}
