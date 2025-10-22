namespace ms_majiInnovator.Modelos
{
    /// <summary>
    /// Modelo que representa una característica de un celular en el catálogo
    /// </summary>
    public class CaracteristicaCelular
    {
        /// <summary>
        /// Identificador único de la característica
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la característica (ej: "RAM", "Almacenamiento", "Cámara", "Pantalla")
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Valor de la característica (ej: "8GB", "256GB", "108MP", "6.1 pulgadas")
        /// </summary>
        public string Valor { get; set; } = string.Empty;

        /// <summary>
        /// Unidad de medida de la característica (ej: "GB", "MP", "pulgadas", "mAh")
        /// </summary>
        public string? Unidad { get; set; }

        /// <summary>
        /// Descripción adicional de la característica
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Orden de visualización de la característica
        /// </summary>
        public int Orden { get; set; } = 0;

        /// <summary>
        /// Indica si la característica está activa
        /// </summary>
        public bool Activa { get; set; } = true;

        /// <summary>
        /// Fecha de creación del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        /// <summary>
        /// Fecha de última modificación del registro
        /// </summary>
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// Identificador del modelo al que pertenece esta característica
        /// </summary>
        public int ModeloId { get; set; }

        /// <summary>
        /// Navegación al modelo asociado
        /// </summary>
        public virtual ModeloCelular Modelo { get; set; } = null!;

        /// <summary>
        /// Constructor con parámetros para crear una nueva característica
        /// </summary>
        /// <param name="nombre">Nombre de la característica</param>
        /// <param name="valor">Valor de la característica</param>
        /// <param name="modeloId">Identificador del modelo</param>
        /// <param name="unidad">Unidad de medida</param>
        /// <param name="descripcion">Descripción adicional</param>
        public CaracteristicaCelular(string nombre, string valor, int modeloId, string? unidad = null, string? descripcion = null)
        {
            Nombre = nombre;
            Valor = valor;
            ModeloId = modeloId;
            Unidad = unidad;
            Descripcion = descripcion;
        }

        /// <summary>
        /// Constructor sin parámetros para Entity Framework
        /// </summary>
        public CaracteristicaCelular()
        {
        }
    }
}
