namespace ms_majiInnovator.Modelos
{
    /// <summary>
    /// Modelo que representa una respuesta de encuesta de un usuario
    /// </summary>
    public class RespuestaEncuesta
    {
        /// <summary>
        /// Identificador único de la respuesta
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID del usuario que respondió la encuesta
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Pregunta de la encuesta que se respondió
        /// </summary>
        public string Pregunta { get; set; }

        /// <summary>
        /// Respuesta seleccionada por el usuario
        /// </summary>
        public string Respuesta { get; set; } = string.Empty;

        /// <summary>
        /// Navegación hacia el usuario que respondió
        /// </summary>
        public virtual Usuario Usuario { get; set; } = default!;
    }
}
