namespace ms_majiInnovator.Modelos
{
    /// <summary>
    /// Modelo que representa una marca de celular en el catálogo
    /// </summary>
    public class MarcaCelular
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
        /// Indica si la marca está activa en el catálogo
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
        /// Colección de modelos asociados a esta marca
        /// </summary>
        public virtual ICollection<ModeloCelular> Modelos { get; set; } = new List<ModeloCelular>();

        /// <summary>
        /// Constructor con parámetros para crear una nueva marca
        /// </summary>
        /// <param name="nombre">Nombre de la marca</param>
        /// <param name="descripcion">Descripción de la marca</param>
        public MarcaCelular(string nombre, string? descripcion = null)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        /// <summary>
        /// Constructor sin parámetros para Entity Framework
        /// </summary>
        public MarcaCelular()
        {
        }
    }
}
