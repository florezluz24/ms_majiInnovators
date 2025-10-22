namespace ms_majiInnovator.Modelos
{
    /// <summary>
    /// Modelo que representa un modelo de celular en el catálogo
    /// </summary>
    public class ModeloCelular
    {
        /// <summary>
        /// Identificador único del modelo
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del modelo del celular
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Descripción del modelo
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Precio del modelo
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Indica si el modelo está disponible en el catálogo
        /// </summary>
        public bool Disponible { get; set; } = true;

        /// <summary>
        /// Fecha de lanzamiento del modelo
        /// </summary>
        public DateTime? FechaLanzamiento { get; set; }

        /// <summary>
        /// Fecha de creación del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        /// <summary>
        /// Fecha de última modificación del registro
        /// </summary>
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// Identificador de la marca a la que pertenece este modelo
        /// </summary>
        public int MarcaId { get; set; }

        /// <summary>
        /// Navegación a la marca asociada
        /// </summary>
        public virtual MarcaCelular Marca { get; set; } = null!;

        /// <summary>
        /// Colección de características asociadas a este modelo
        /// </summary>
        public virtual ICollection<CaracteristicaCelular> Caracteristicas { get; set; } = new List<CaracteristicaCelular>();

        /// <summary>
        /// Colección de imágenes asociadas a este modelo
        /// </summary>
        public virtual ICollection<ImagenCelular> Imagenes { get; set; } = new List<ImagenCelular>();

        /// <summary>
        /// Constructor con parámetros para crear un nuevo modelo
        /// </summary>
        /// <param name="nombre">Nombre del modelo</param>
        /// <param name="marcaId">Identificador de la marca</param>
        /// <param name="precio">Precio del modelo</param>
        /// <param name="descripcion">Descripción del modelo</param>
        public ModeloCelular(string nombre, int marcaId, decimal precio, string? descripcion = null)
        {
            Nombre = nombre;
            MarcaId = marcaId;
            Precio = precio;
            Descripcion = descripcion;
        }

        /// <summary>
        /// Constructor sin parámetros para Entity Framework
        /// </summary>
        public ModeloCelular()
        {
        }
    }
}
