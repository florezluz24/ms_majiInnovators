using Microsoft.AspNetCore.Mvc;
using ms_majiInnovator.DTOs;
using ms_majiInnovator.Modelos;
using ms_majiInnovator.Repositorios;

namespace ms_majiInnovator.Controladores
{
    /// <summary>
    /// Controlador para la gestión de respuestas de encuestas del sistema MajiInnovator
    /// Proporciona operaciones CRUD para almacenar y consultar respuestas de usuarios
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RespuestaEncuestaController : ControllerBase
    {
        /// <summary>
        /// Repositorio para operaciones de respuestas de encuestas
        /// </summary>
        private readonly RepositorioRespuestaEncuesta _repositorioRespuesta;

        /// <summary>
        /// Inicializa una nueva instancia del controlador de respuestas de encuestas
        /// </summary>
        /// <param name="repositorioRespuesta">Repositorio para operaciones de respuestas de encuestas</param>
        public RespuestaEncuestaController(RepositorioRespuestaEncuesta repositorioRespuesta)
        {
            _repositorioRespuesta = repositorioRespuesta;
        }

        /// <summary>
        /// Obtiene todas las respuestas de encuestas almacenadas en el sistema
        /// </summary>
        /// <returns>Lista completa de respuestas de encuestas</returns>
        [HttpGet]
        public async Task<ActionResult<List<RespuestaEncuesta>>> ObtenerTodas()
        {
            List<RespuestaEncuesta> respuestas = await _repositorioRespuesta.ObtenerTodosAsync();
            return Ok(respuestas);
        }

        /// <summary>
        /// Obtiene una respuesta de encuesta específica por su ID
        /// </summary>
        /// <param name="id">ID único de la respuesta</param>
        /// <returns>Respuesta encontrada o NotFound si no existe</returns>
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

        /// <summary>
        /// Crea una nueva respuesta de encuesta en el sistema
        /// </summary>
        /// <param name="respuestaDTO">Datos de la respuesta a crear</param>
        /// <returns>Respuesta creada con ID generado automáticamente</returns>
        /// <remarks>
        /// Este método almacena la respuesta de un usuario a una pregunta específica de la encuesta.
        /// El ID se genera automáticamente por la base de datos.
        /// </remarks>
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

        /// <summary>
        /// Modifica una respuesta de encuesta existente en el sistema
        /// </summary>
        /// <param name="id">ID de la respuesta a modificar</param>
        /// <param name="respuesta">Datos actualizados de la respuesta</param>
        /// <returns>Respuesta modificada o BadRequest si hay inconsistencias</returns>
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

        /// <summary>
        /// Elimina una respuesta de encuesta del sistema por su ID
        /// </summary>
        /// <param name="id">ID de la respuesta a eliminar</param>
        /// <returns>NoContent si se elimina correctamente o NotFound si no existe</returns>
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
