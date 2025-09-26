using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ms_majiInnovator.DTOs;
using ms_majiInnovator.Modelos;
using ms_majiInnovator.Repositorios;

namespace ms_majiInnovator.Controladores
{
    /// <summary>
    /// Controlador para la gestión de usuarios del sistema MajiInnovator
    /// Proporciona operaciones CRUD completas y validación de acceso
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Repositorio para operaciones de usuarios
        /// </summary>
        private readonly RepositorioUsuario _repositorioUsuario;

        /// <summary>
        /// Inicializa una nueva instancia del controlador de usuarios
        /// </summary>
        /// <param name="repositorioUsuario">Repositorio para operaciones de usuarios</param>
        public UsuarioController(RepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados en el sistema
        /// </summary>
        /// <returns>Lista completa de usuarios</returns>
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ObtenerTodos()
        {
            List<Usuario> usuarios = await _repositorioUsuario.ObtenerTodosAsync();
            return Ok(usuarios);
        }

        /// <summary>
        /// Obtiene un usuario específico por su ID
        /// </summary>
        /// <param name="id">ID único del usuario</param>
        /// <returns>Usuario encontrado o NotFound si no existe</returns>
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

        /// <summary>
        /// Crea un nuevo usuario en el sistema con validaciones completas
        /// </summary>
        /// <param name="usuarioDTO">Datos del usuario a crear</param>
        /// <returns>Usuario creado con ID generado automáticamente</returns>
        /// <remarks>
        /// Este método realiza validaciones exhaustivas incluyendo:
        /// - Verificación de campos obligatorios
        /// - Validación de formato de cédula (debe ser numérica)
        /// - Validación de longitud mínima de contraseña
        /// - Verificación de unicidad de cédula
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Usuario>> Crear(UsuarioDTO usuarioDTO)
        {
            // Limpiar espacios en blanco de los datos de entrada
            usuarioDTO.Cedula = usuarioDTO.Cedula.Trim();
            usuarioDTO.Nombre = usuarioDTO.Nombre.Trim();
            usuarioDTO.Password = usuarioDTO.Password.Trim();            

            // Validaciones de campos obligatorios
            if (usuarioDTO.Cedula == string.Empty)
            {
                return BadRequest("Cedula obligatoria");
            }

            // Validar que la cédula sea numérica
            bool esNumero = decimal.TryParse(usuarioDTO.Cedula, out decimal resultado);
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

            // Validar longitud mínima de contraseña
            if (usuarioDTO.Password.Length <= 4)
            {
                return BadRequest("Contraseña es demasiado corta");
            }

            // Validar que no exista un usuario con la misma cédula
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

        /// <summary>
        /// Valida las credenciales de acceso de un usuario
        /// </summary>
        /// <param name="validarAccesoDTO">Credenciales de acceso (cédula y contraseña)</param>
        /// <returns>Datos del usuario sin contraseña si las credenciales son válidas</returns>
        /// <remarks>
        /// Este método valida las credenciales del usuario y devuelve sus datos sin la contraseña por seguridad.
        /// Si las credenciales son inválidas, devuelve Unauthorized.
        /// </remarks>
        [HttpPost("validar-acceso")]
        public async Task<ActionResult<Usuario>> ValidarAcceso(ValidarAccesoDTO validarAccesoDTO)
        {
            // Validar que los datos no estén vacíos
            if (string.IsNullOrWhiteSpace(validarAccesoDTO.Cedula))
            {
                return BadRequest("Cédula es obligatoria");
            }

            if (string.IsNullOrWhiteSpace(validarAccesoDTO.Password))
            {
                return BadRequest("Contraseña es obligatoria");
            }

            // Limpiar espacios en blanco
            validarAccesoDTO.Cedula = validarAccesoDTO.Cedula.Trim();
            validarAccesoDTO.Password = validarAccesoDTO.Password.Trim();

            // Validar que la cédula sea numérica
            if (!int.TryParse(validarAccesoDTO.Cedula, out int cedulaNumerica))
            {
                return BadRequest("Cédula debe ser numérica");
            }

            try
            {
                // Buscar usuario por cédula
                List<Usuario> usuarios = await _repositorioUsuario.ObtenerConFiltroAsync(usuario => 
                    usuario.Cedula == validarAccesoDTO.Cedula
                );

                Usuario? usuario = usuarios.FirstOrDefault();

                // Si no existe el usuario, devolver 401
                if (usuario == null)
                {
                    return Unauthorized("Credenciales inválidas");
                }

                // Validar contraseña
                if (usuario.Password != validarAccesoDTO.Password)
                {
                    return Unauthorized("Credenciales inválidas");
                }

                // Si las credenciales son válidas, devolver el usuario (sin la contraseña por seguridad)
                var usuarioRespuesta = new
                {
                    usuario.Id,
                    usuario.Nombre,
                    usuario.Cedula,
                    usuario.Telefono,
                    usuario.Rol
                };

                return Ok(usuarioRespuesta);
            }
            catch (Exception ex)
            {
                // Log del error para debugging
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /// <summary>
        /// Modifica un usuario existente en el sistema
        /// </summary>
        /// <param name="id">ID del usuario a modificar</param>
        /// <param name="usuario">Datos actualizados del usuario</param>
        /// <returns>Usuario modificado o BadRequest si hay inconsistencias</returns>
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

        /// <summary>
        /// Elimina un usuario del sistema por su ID
        /// </summary>
        /// <param name="id">ID del usuario a eliminar</param>
        /// <returns>NoContent si se elimina correctamente o NotFound si no existe</returns>
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
