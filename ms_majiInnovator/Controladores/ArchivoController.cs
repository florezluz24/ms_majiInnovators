using Microsoft.AspNetCore.Mvc;
using ms_majiInnovator.Servicios;

namespace ms_majiInnovator.Controladores
{
    /// <summary>
    /// Controlador para la gestión de archivos en Azure Storage
    /// Proporciona operaciones para subir, eliminar y obtener archivos
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ArchivoController : ControllerBase
    {
        private readonly AzureStorageService _azureStorageService;
        private readonly ILogger<ArchivoController> _logger;

        /// <summary>
        /// Inicializa una nueva instancia del controlador de archivos
        /// </summary>
        /// <param name="azureStorageService">Servicio de Azure Storage</param>
        /// <param name="logger">Logger para registro de eventos</param>
        public ArchivoController(AzureStorageService azureStorageService, ILogger<ArchivoController> logger)
        {
            _azureStorageService = azureStorageService;
            _logger = logger;
        }

        /// <summary>
        /// Sube un archivo al contenedor de catálogo
        /// </summary>
        /// <param name="archivo">Archivo a subir</param>
        /// <param name="carpeta">Carpeta opcional dentro del contenedor</param>
        /// <returns>URL del archivo subido o error</returns>
        /// <remarks>
        /// Este endpoint permite subir archivos al contenedor "catalogo" de Azure Storage.
        /// El archivo se almacena con un nombre único basado en timestamp y nombre original.
        /// </remarks>
        [HttpPost("subir")]
        public async Task<ActionResult<object>> SubirArchivo(IFormFile archivo, string? carpeta = null)
        {
            try
            {
                // Validar que se haya enviado un archivo
                if (archivo == null || archivo.Length == 0)
                {
                    return BadRequest("No se ha enviado ningún archivo");
                }

                // Validar tamaño del archivo (máximo 10MB)
                if (archivo.Length > 10 * 1024 * 1024)
                {
                    return BadRequest("El archivo es demasiado grande. Tamaño máximo: 10MB");
                }

                // Generar nombre único para el archivo
                string extension = Path.GetExtension(archivo.FileName);
                string nombreBase = Path.GetFileNameWithoutExtension(archivo.FileName);
                string nombreArchivo = $"{nombreBase}_{DateTime.Now:yyyyMMdd_HHmmss}{extension}";
                
                // Agregar carpeta si se especifica
                if (!string.IsNullOrEmpty(carpeta))
                {
                    nombreArchivo = $"{carpeta.Trim('/')}/{nombreArchivo}";
                }

                // Obtener tipo de contenido
                string tipoContenido = archivo.ContentType ?? "application/octet-stream";

                // Subir archivo
                using Stream stream = archivo.OpenReadStream();
                string? urlArchivo = await _azureStorageService.SubirArchivoAsync(
                    stream, 
                    nombreArchivo, 
                    "catalogo", 
                    tipoContenido
                );

                if (string.IsNullOrEmpty(urlArchivo))
                {
                    _logger.LogError("Error al subir archivo: {NombreArchivo}", archivo.FileName);
                    return StatusCode(500, "Error al subir el archivo");
                }

                _logger.LogInformation("Archivo subido exitosamente: {UrlArchivo}", urlArchivo);

                // Respuesta con información del archivo
                object respuesta = new
                {
                    nombreOriginal = archivo.FileName,
                    nombreArchivo = nombreArchivo,
                    url = urlArchivo,
                    tamaño = archivo.Length,
                    tipoContenido = tipoContenido,
                    fechaSubida = DateTime.Now
                };

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al subir archivo: {NombreArchivo}", archivo?.FileName);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /// <summary>
        /// Sube múltiples archivos al contenedor de catálogo
        /// </summary>
        /// <param name="archivos">Lista de archivos a subir</param>
        /// <param name="carpeta">Carpeta opcional dentro del contenedor</param>
        /// <returns>Lista de URLs de archivos subidos</returns>
        [HttpPost("subir-multiples")]
        public async Task<ActionResult<object>> SubirMultiplesArchivos(List<IFormFile> archivos, string? carpeta = null)
        {
            try
            {
                // Validar que se hayan enviado archivos
                if (archivos == null || archivos.Count == 0)
                {
                    return BadRequest("No se han enviado archivos");
                }

                // Validar cantidad máxima de archivos
                if (archivos.Count > 10)
                {
                    return BadRequest("Máximo 10 archivos por solicitud");
                }

                List<object> archivosSubidos = new();
                List<string> errores = new();

                foreach (IFormFile archivo in archivos)
                {
                    try
                    {
                        // Validar tamaño del archivo
                        if (archivo.Length > 10 * 1024 * 1024)
                        {
                            errores.Add($"Archivo {archivo.FileName} es demasiado grande");
                            continue;
                        }

                        // Generar nombre único
                        string extension = Path.GetExtension(archivo.FileName);
                        string nombreBase = Path.GetFileNameWithoutExtension(archivo.FileName);
                        string nombreArchivo = $"{nombreBase}_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid():N}{extension}";
                        
                        if (!string.IsNullOrEmpty(carpeta))
                        {
                            nombreArchivo = $"{carpeta.Trim('/')}/{nombreArchivo}";
                        }

                        // Subir archivo
                        using Stream stream = archivo.OpenReadStream();
                        string? urlArchivo = await _azureStorageService.SubirArchivoAsync(
                            stream, 
                            nombreArchivo, 
                            "catalogo", 
                            archivo.ContentType
                        );

                        if (!string.IsNullOrEmpty(urlArchivo))
                        {
                            archivosSubidos.Add(new
                            {
                                nombreOriginal = archivo.FileName,
                                nombreArchivo = nombreArchivo,
                                url = urlArchivo,
                                tamaño = archivo.Length,
                                tipoContenido = archivo.ContentType
                            });
                        }
                        else
                        {
                            errores.Add($"Error al subir archivo {archivo.FileName}");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error al subir archivo individual: {NombreArchivo}", archivo.FileName);
                        errores.Add($"Error al subir archivo {archivo.FileName}");
                    }
                }

                object respuesta = new
                {
                    archivosSubidos = archivosSubidos,
                    totalSubidos = archivosSubidos.Count,
                    totalErrores = errores.Count,
                    errores = errores,
                    fechaSubida = DateTime.Now
                };

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al subir múltiples archivos");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /// <summary>
        /// Elimina un archivo del storage
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo a eliminar</param>
        /// <returns>Resultado de la eliminación</returns>
        [HttpDelete("{nombreArchivo}")]
        public async Task<ActionResult<object>> EliminarArchivo(string nombreArchivo)
        {
            try
            {
                if (string.IsNullOrEmpty(nombreArchivo))
                {
                    return BadRequest("Nombre de archivo es requerido");
                }

                bool eliminado = await _azureStorageService.EliminarArchivoAsync(nombreArchivo, "catalogo");

                if (eliminado)
                {
                    _logger.LogInformation("Archivo eliminado exitosamente: {NombreArchivo}", nombreArchivo);
                    return Ok(new { mensaje = "Archivo eliminado exitosamente", nombreArchivo = nombreArchivo });
                }
                else
                {
                    return NotFound(new { mensaje = "Archivo no encontrado", nombreArchivo = nombreArchivo });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar archivo: {NombreArchivo}", nombreArchivo);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /// <summary>
        /// Obtiene la URL de un archivo
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo</param>
        /// <returns>URL del archivo</returns>
        [HttpGet("url/{nombreArchivo}")]
        public ActionResult<object> ObtenerUrlArchivo(string nombreArchivo)
        {
            try
            {
                if (string.IsNullOrEmpty(nombreArchivo))
                {
                    return BadRequest("Nombre de archivo es requerido");
                }

                string url = _azureStorageService.ObtenerUrlArchivo(nombreArchivo, "catalogo");

                object respuesta = new
                {
                    nombreArchivo = nombreArchivo,
                    url = url
                };

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener URL del archivo: {NombreArchivo}", nombreArchivo);
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
