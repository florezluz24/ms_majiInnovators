using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ms_majiInnovator.DTOs;
using ms_majiInnovator.Modelos;
using ms_majiInnovator.Repositorios;

namespace ms_majiInnovator.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly RepositorioUsuario _repositorioUsuario;

        public UsuarioController(RepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ObtenerTodos()
        {
            List<Usuario> usuarios = await _repositorioUsuario.ObtenerTodosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> ObtenerPorId(int id)
        {
            var usuarios = await _repositorioUsuario.ObtenerConFiltroAsync(u => u.Id == id);
            Usuario? usuario = usuarios.FirstOrDefault();
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Crear(UsuarioDTO usuarioDTO)
        {

            usuarioDTO.Cedula = usuarioDTO.Cedula.Trim();
            usuarioDTO.Nombre = usuarioDTO.Nombre.Trim();
            usuarioDTO.Password = usuarioDTO.Password.Trim();            


            if (usuarioDTO.Cedula == string.Empty)
            {
                return BadRequest("Cedula obligatoria");
            }

            bool esNumero = int.TryParse(usuarioDTO.Cedula, out int resultado);

            if (!esNumero)
            {
                return BadRequest("Cedula debe ser numerica");
            }

            if (usuarioDTO.Nombre == string.Empty)
            {
                return BadRequest("Nombre obligatoria");
            }

            if (usuarioDTO.Password == string.Empty)
            {
                return BadRequest("Contraseña obligatoria");
            }

            if (usuarioDTO.Password.Length <= 4)
            {
                return BadRequest("Contraseña es demasiado corta");
            }

            // Validar si ya existe el usuario por cedula

            List<Usuario> usuarioExistente = await _repositorioUsuario.ObtenerConFiltroAsync(usuario => 
                usuario.Cedula == usuarioDTO.Cedula
            );

            if (usuarioExistente.Count > 0)
            {
                return BadRequest("Ya existe un usuario registrado con esta cedula");
            }


            // Crear la entidad Usuario desde el DTO (sin ID)
            Usuario usuario = new Usuario(usuarioDTO.Nombre, usuarioDTO.Cedula, usuarioDTO.Password);
            
            // El ID se genera automáticamente por la base de datos
            Usuario usuarioCreado = await _repositorioUsuario.AgregarAsync(usuario);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = usuarioCreado.Id }, usuarioCreado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            Usuario usuarioModificado = await _repositorioUsuario.ModificarAsync(usuario);
            return Ok(usuarioModificado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var usuarios = await _repositorioUsuario.ObtenerConFiltroAsync(u => u.Id == id);
            Usuario? usuario = usuarios.FirstOrDefault();
            if (usuario == null)
            {
                return NotFound();
            }

            bool eliminado = await _repositorioUsuario.EliminarAsync(usuario);
            if (eliminado)
            {
                return NoContent();
            }
            return BadRequest("No se pudo eliminar el usuario");
        }
    }
}
