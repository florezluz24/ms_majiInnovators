namespace ms_majiInnovator.DTOs
{
    /// <summary>
    /// DTO para la creación de respuestas de encuestas
    /// Contiene los datos necesarios para almacenar una respuesta
    /// </summary>
    /// <remarks>
    /// Este DTO se utiliza para recibir respuestas de encuestas desde el frontend.
    /// El ID se genera automáticamente en el backend.
    /// </remarks>
    public class RespuestaEncuestaDTO
    {
        /// <summary>
        /// ID del usuario que responde la encuesta
        /// </summary>
        public int UsuarioId { get; set; }
        
        /// <summary>
        /// Pregunta de la encuesta que se está respondiendo
        /// </summary>
        public string Pregunta { get; set; } = string.Empty;
        
        /// <summary>
        /// Respuesta seleccionada por el usuario
        /// </summary>
        public string Respuesta { get; set; } = string.Empty;
    }
}
