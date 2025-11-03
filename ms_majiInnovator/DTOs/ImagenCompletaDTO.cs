namespace ms_majiInnovator.DTOs
{
    /// <summary>
    /// DTO para la respuesta completa de imágenes de celulares
    /// Incluye todos los campos de la imagen para consultas
    /// </summary>
    public class ImagenCompletaDTO
    {
        /// <summary>
        /// Identificador único de la imagen
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Ruta de la imagen en el sistema de archivos
        /// </summary>
        public string RutaImagen { get; set; } = string.Empty;
    }
}

