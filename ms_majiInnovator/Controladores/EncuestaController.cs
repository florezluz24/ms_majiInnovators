using Microsoft.AspNetCore.Mvc;
using ms_majiInnovator.Encuestas;

namespace ms_majiInnovator.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncuestaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Encuesta>> ObtenerEncuestas()
        {
            var modelado = new ModeladoEncuesta();
            List<Encuesta> encuestas = modelado.Modelado;
            return Ok(encuestas);
        }
    }
}
