using Microsoft.AspNetCore.Mvc;
using ms_majiInnovator.Encuestas;

namespace ms_majiInnovator.Controladores
{
    /// <summary>
    /// Controlador para la gestión de encuestas del sistema MajiInnovator
    /// Proporciona acceso a las preguntas y opciones de respuesta predefinidas
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EncuestaController : ControllerBase
    {
        /// <summary>
        /// Obtiene todas las encuestas disponibles en el sistema
        /// </summary>
        /// <returns>Lista de encuestas con preguntas y opciones de respuesta</returns>
        [HttpGet]
        public ActionResult<List<Encuesta>> ObtenerEncuestas()
        {
            var modelado = new ModeladoEncuesta();
            List<Encuesta> encuestas = modelado.Modelado;
            return Ok(encuestas);
        }
    }
}
