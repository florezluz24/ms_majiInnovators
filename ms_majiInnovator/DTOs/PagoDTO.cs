namespace ms_majiInnovator.DTOs
{
    public class PagoDTO
    {
        public int UsuarioId { get; set; }

        public decimal Valor { get; set; }

        public string UltimosCuatroDigitosTarjeta { get; set; } = string.Empty;

        public string Estado { get; set; } = "Completado";
    }
}

