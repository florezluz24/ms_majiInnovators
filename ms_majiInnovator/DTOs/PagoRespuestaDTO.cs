namespace ms_majiInnovator.DTOs
{
    public class PagoRespuestaDTO
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public decimal Valor { get; set; }

        public string UltimosCuatroDigitosTarjeta { get; set; } = string.Empty;

        public DateTime FechaPago { get; set; }

        public string Estado { get; set; } = string.Empty;
    }
}

