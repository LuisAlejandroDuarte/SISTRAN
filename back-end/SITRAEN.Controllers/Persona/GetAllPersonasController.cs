using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SITRAEN.DTOs;
using SITRAEN.DTOs.Persona;
using SITRAEN.Presenter;
using SITRAEN.UseCasesPorts.Persona;


namespace SITRAEN.Controllers.Personaes
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllPersonasController
    {

        readonly IGetAllPersonasInPutPort inPutPort;
        readonly IGetAllPersonasOutPutPort outPutPort;
        readonly IHttpContextAccessor Context;

        public GetAllPersonasController(IGetAllPersonasInPutPort inPutPort, IGetAllPersonasOutPutPort outPutPort, IHttpContextAccessor context)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
            Context = context;
        }

        [HttpGet]        
        public async Task<IEnumerable<PersonaDTO>> GetAllPersonas()
        {            

            await inPutPort.Handle();
            return ((IPresenter<IEnumerable<PersonaDTO>>)outPutPort).Content;
        }
    }
}
