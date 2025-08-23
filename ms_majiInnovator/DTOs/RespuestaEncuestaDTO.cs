namespace ms_majiInnovator.DTOs
{
    public class RespuestaEncuestaDTO
    {
        public int UsuarioId { get; set; }
        public string Pregunta { get; set; } = string.Empty;
        public string Respuesta { get; set; } = string.Empty;
    }
}
