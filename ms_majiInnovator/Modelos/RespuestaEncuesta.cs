namespace ms_majiInnovator.Modelos
{
    public class RespuestaEncuesta
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string Pregunta { get; set; }

        public string Respuesta { get; set; } = string.Empty;

        public virtual Usuario Usuario { get; set; } = default!;
    }
}
