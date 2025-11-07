namespace ms_majiInnovator.Modelos
{
    public class Pago
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public decimal Valor { get; set; }

        public string UltimosCuatroDigitosTarjeta { get; set; } = string.Empty;

        public DateTime FechaPago { get; set; } = DateTime.Now;

        public string Estado { get; set; } = "Completado";

        public virtual Usuario Usuario { get; set; } = null!;

        public Pago(int usuarioId, decimal valor, string ultimosCuatroDigitosTarjeta, string estado = "Completado")
        {
            UsuarioId = usuarioId;
            Valor = valor;
            UltimosCuatroDigitosTarjeta = ultimosCuatroDigitosTarjeta;
            Estado = estado;
            FechaPago = DateTime.Now;
        }

        public Pago()
        {
        }
    }
}

