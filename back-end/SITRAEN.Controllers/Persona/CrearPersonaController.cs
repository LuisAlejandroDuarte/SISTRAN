
using Microsoft.AspNetCore.Mvc;
using SITRAEN.DTOs.Persona;
using SITRAEN.Presenter;
using SITRAEN.UseCasesPorts.Persona;


namespace SITRAEN.Controllers.Personaes
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrearPersonaController
    {
        readonly ICrearPersonaInPutPort inPutPort;
        readonly ICrearPersonaOutPutPort outPutPort;

        public CrearPersonaController(ICrearPersonaInPutPort inPutPort, ICrearPersonaOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }


        [HttpPost]        
        public async Task<PersonaDTO> CrearPersona(PersonaDTO Persona)
        {
            await this.inPutPort.Handle(Persona);
            return ((IPresenter<PersonaDTO>)outPutPort).Content;
        }
    }
}
