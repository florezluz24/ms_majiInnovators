namespace ms_majiInnovator.DTOs
{
    /// <summary>
    /// DTO para la respuesta de imágenes de celulares
    /// Contiene la información básica de una imagen para el frontend
    /// </summary>
    public class ImagenDTO
    {
        /// <summary>
        /// Identificador único de la imagen
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// URL completa de la imagen en Azure Storage
        /// </summary>
        public string RutaImagen { get; set; } = string.Empty;
        
        /// <summary>
        /// Identificador del modelo al que pertenece la imagen
        /// </summary>
        public int ModeloId { get; set; }
        
        /// <summary>
        /// Nombre del modelo (opcional, para información adicional)
        /// </summary>
        public string? NombreModelo { get; set; }
    }
}
