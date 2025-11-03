namespace ms_majiInnovator.DTOs
{
    /// <summary>
    /// DTO para la respuesta completa de características de celulares
    /// Incluye todos los campos de la característica para consultas
    /// </summary>
    public class CaracteristicaCompletaDTO
    {
        /// <summary>
        /// Identificador único de la característica
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Nombre de la característica (ej: "RAM", "Almacenamiento", "Cámara")
        /// </summary>
        public string Nombre { get; set; } = string.Empty;
        
        /// <summary>
        /// Valor de la característica (ej: "8GB", "256GB", "108MP")
        /// </summary>
        public string Valor { get; set; } = string.Empty;
        
        /// <summary>
        /// Unidad de medida de la característica (ej: "GB", "MP", "pulgadas")
        /// </summary>
        public string? Unidad { get; set; }
    }
}

