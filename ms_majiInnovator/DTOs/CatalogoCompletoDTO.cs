namespace ms_majiInnovator.DTOs
{
    /// <summary>
    /// DTO para la respuesta completa del catálogo de marcas
    /// Incluye la marca con todos sus modelos relacionados
    /// </summary>
    public class CatalogoCompletoDTO
    {
        /// <summary>
        /// Identificador único de la marca
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Nombre de la marca del celular
        /// </summary>
        public string Nombre { get; set; } = string.Empty;
        
        /// <summary>
        /// Descripción de la marca
        /// </summary>
        public string? Descripcion { get; set; }
        
        /// <summary>
        /// Lista de modelos asociados a esta marca
        /// </summary>
        public List<ModeloCompletoDTO> Modelos { get; set; } = new List<ModeloCompletoDTO>();
    }
}

