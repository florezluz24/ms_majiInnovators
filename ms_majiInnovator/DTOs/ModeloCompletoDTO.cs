namespace ms_majiInnovator.DTOs
{
    /// <summary>
    /// DTO para la respuesta completa de modelos de celulares
    /// Incluye el modelo con todas sus características e imágenes relacionadas
    /// </summary>
    public class ModeloCompletoDTO
    {
        /// <summary>
        /// Identificador único del modelo
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Nombre del modelo del celular
        /// </summary>
        public string Nombre { get; set; } = string.Empty;
        
        /// <summary>
        /// Descripción del modelo
        /// </summary>
        public string? Descripcion { get; set; }
        
        /// <summary>
        /// Precio del modelo
        /// </summary>
        public decimal Precio { get; set; }
        
        /// <summary>
        /// Indica si el modelo está disponible en el catálogo
        /// </summary>
        public bool Disponible { get; set; }
        
        /// <summary>
        /// Lista de características asociadas a este modelo
        /// </summary>
        public List<CaracteristicaCompletaDTO> Caracteristicas { get; set; } = new List<CaracteristicaCompletaDTO>();
        
        /// <summary>
        /// Lista de imágenes asociadas a este modelo
        /// </summary>
        public List<ImagenCompletaDTO> Imagenes { get; set; } = new List<ImagenCompletaDTO>();
        
        /// <summary>
        /// Primera imagen del modelo para mostrar en la lista principal
        /// </summary>
        public string? PrimeraImagen { get; set; }
    }
}

