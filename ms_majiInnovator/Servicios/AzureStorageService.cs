using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ms_majiInnovator.Configuracion;
using Microsoft.Extensions.Options;

namespace ms_majiInnovator.Servicios
{
    /// <summary>
    /// Servicio para operaciones con Azure Storage Account
    /// Proporciona funcionalidades para subir archivos y gestionar contenedores
    /// </summary>
    public class AzureStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly AzureStorageConfig _configuracion;

        /// <summary>
        /// Inicializa una nueva instancia del servicio de Azure Storage
        /// </summary>
        /// <param name="configuracion">Configuración de Azure Storage</param>
        public AzureStorageService(IOptions<AzureStorageConfig> configuracion)
        {
            _configuracion = configuracion.Value;
            _blobServiceClient = new BlobServiceClient(_configuracion.ConnectionString);
        }

        /// <summary>
        /// Verifica si un contenedor existe y lo crea si no existe
        /// </summary>
        /// <param name="nombreContenedor">Nombre del contenedor a verificar/crear</param>
        /// <returns>True si el contenedor existe o se creó exitosamente</returns>
        public async Task<bool> AsegurarContenedorExisteAsync(string nombreContenedor)
        {
            try
            {
                BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(nombreContenedor);
                
                bool existe = await containerClient.ExistsAsync();
                
                if (!existe)
                {
                    await containerClient.CreateAsync(PublicAccessType.Blob);
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Sube un archivo al contenedor especificado
        /// </summary>
        /// <param name="archivo">Stream del archivo a subir</param>
        /// <param name="nombreArchivo">Nombre del archivo en el storage</param>
        /// <param name="nombreContenedor">Nombre del contenedor (opcional, usa el por defecto si no se especifica)</param>
        /// <param name="tipoContenido">Tipo de contenido del archivo</param>
        /// <returns>URL completa del archivo subido o null si falló</returns>
        public async Task<string?> SubirArchivoAsync(Stream archivo, string nombreArchivo, string? nombreContenedor = null, string? tipoContenido = null)
        {
            try
            {
                string contenedor = nombreContenedor ?? _configuracion.ContainerName;
                
                // Asegurar que el contenedor existe
                bool contenedorExiste = await AsegurarContenedorExisteAsync(contenedor);
                if (!contenedorExiste)
                {
                    return null;
                }

                BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(contenedor);
                BlobClient blobClient = containerClient.GetBlobClient(nombreArchivo);

                BlobUploadOptions opciones = new()
                {
                    HttpHeaders = new BlobHttpHeaders
                    {
                        ContentType = tipoContenido ?? "application/octet-stream"
                    }
                };

                await blobClient.UploadAsync(archivo, opciones);
                
                string urlCompleta = $"{_configuracion.BaseUrl.TrimEnd('/')}/{contenedor}/{nombreArchivo}";
                return urlCompleta;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Sube un archivo desde un array de bytes
        /// </summary>
        /// <param name="datosArchivo">Datos del archivo como array de bytes</param>
        /// <param name="nombreArchivo">Nombre del archivo en el storage</param>
        /// <param name="nombreContenedor">Nombre del contenedor (opcional)</param>
        /// <param name="tipoContenido">Tipo de contenido del archivo</param>
        /// <returns>URL completa del archivo subido o null si falló</returns>
        public async Task<string?> SubirArchivoAsync(byte[] datosArchivo, string nombreArchivo, string? nombreContenedor = null, string? tipoContenido = null)
        {
            using MemoryStream stream = new(datosArchivo);
            return await SubirArchivoAsync(stream, nombreArchivo, nombreContenedor, tipoContenido);
        }

        /// <summary>
        /// Elimina un archivo del storage
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo a eliminar</param>
        /// <param name="nombreContenedor">Nombre del contenedor (opcional)</param>
        /// <returns>True si se eliminó exitosamente</returns>
        public async Task<bool> EliminarArchivoAsync(string nombreArchivo, string? nombreContenedor = null)
        {
            try
            {
                string contenedor = nombreContenedor ?? _configuracion.ContainerName;
                BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(contenedor);
                BlobClient blobClient = containerClient.GetBlobClient(nombreArchivo);

                bool eliminado = await blobClient.DeleteIfExistsAsync();
                return eliminado;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Obtiene la URL completa de un archivo
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo</param>
        /// <param name="nombreContenedor">Nombre del contenedor (opcional)</param>
        /// <returns>URL completa del archivo</returns>
        public string ObtenerUrlArchivo(string nombreArchivo, string? nombreContenedor = null)
        {
            string contenedor = nombreContenedor ?? _configuracion.ContainerName;
            return $"{_configuracion.BaseUrl.TrimEnd('/')}/{contenedor}/{nombreArchivo}";
        }
    }
}
