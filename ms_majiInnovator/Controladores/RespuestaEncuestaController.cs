using Microsoft.AspNetCore.Mvc;
using ms_majiInnovator.DTOs;
using ms_majiInnovator.Modelos;
using ms_majiInnovator.Repositorios;

namespace ms_majiInnovator.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class RespuestaEncuestaController : ControllerBase
    {
        private readonly RepositorioRespuestaEncuesta _repositorioRespuesta;

        public RespuestaEncuestaController(RepositorioRespuestaEncuesta repositorioRespuesta)
        {
            _repositorioRespuesta = repositorioRespuesta;
        }

        [HttpGet]
        public async Task<ActionResult<List<RespuestaEncuesta>>> ObtenerTodas()
        {
            List<RespuestaEncuesta> respuestas = await _repositorioRespuesta.ObtenerTodosAsync();
            return Ok(respuestas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RespuestaEncuesta>> ObtenerPorId(int id)
        {
            var respuestas = await _repositorioRespuesta.ObtenerConFiltroAsync(r => r.Id == id);
            RespuestaEncuesta? respuesta = respuestas.FirstOrDefault();
            if (respuesta == null)
            {
                return NotFound();
            }
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<ActionResult<RespuestaEncuesta>> Crear(RespuestaEncuestaDTO respuestaDTO)
        {
            // Crear la entidad RespuestaEncuesta desde el DTO (sin ID)
            RespuestaEncuesta respuesta = new RespuestaEncuesta
            {
                UsuarioId = respuestaDTO.UsuarioId,
                Pregunta = respuestaDTO.Pregunta,
                Respuesta = respuestaDTO.Respuesta
            };
            
            // El ID se genera automáticamente por la base de datos
            RespuestaEncuesta respuestaCreada = await _repositorioRespuesta.AgregarAsync(respuesta);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = respuestaCreada.Id }, respuestaCreada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(int id, RespuestaEncuesta respuesta)
        {
            if (id != respuesta.Id)
            {
                return BadRequest();
            }

            RespuestaEncuesta respuestaModificada = await _repositorioRespuesta.ModificarAsync(respuesta);
            return Ok(respuestaModificada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respuestas = await _repositorioRespuesta.ObtenerConFiltroAsync(r => r.Id == id);
            RespuestaEncuesta? respuesta = respuestas.FirstOrDefault();
            if (respuesta == null)
            {
                return NotFound();
            }

            bool eliminado = await _repositorioRespuesta.EliminarAsync(respuesta);
            if (eliminado)
            {
                return NoContent();
            }
            return BadRequest("No se pudo eliminar la respuesta");
        }
    }
}
