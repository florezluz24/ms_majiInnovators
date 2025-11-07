namespace ms_majiInnovator.Modelos
{
    /// <summary>
    /// Modelo que representa un usuario del sistema MajiInnovator
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador único del usuario
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Nombre completo del usuario
        /// </summary>
        public string Nombre { get; set; } = string.Empty;
        
        /// <summary>
        /// Número de cédula del usuario (debe ser numérico)
        /// </summary>
        public string Cedula { get; set; } = string.Empty;
        
        /// <summary>
        /// Número de teléfono del usuario
        /// </summary>
        public string Telefono { get; set; } = string.Empty;
        
        /// <summary>
        /// Contraseña del usuario (se almacena en texto plano)
        /// </summary>
        /// <remarks>
        /// NOTA: En un entorno de producción, las contraseñas deberían estar encriptadas.
        /// Este campo se mantiene en texto plano solo para fines de demostración.
        /// </remarks>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Rol del usuario en el sistema (por defecto "Cliente")
        /// </summary>
        /// <remarks>
        /// Valores posibles: "Cliente", "Administrador"
        /// </remarks>
        public string Rol { get; set; } = "Cliente";

        /// <summary>
        /// Colección de pagos realizados por el usuario
        /// </summary>
        public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

        /// <summary>
        /// Constructor con parámetros para crear un nuevo usuario
        /// </summary>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="cedula">Cédula del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        public Usuario(string nombre, string cedula, string password)
        {
            Nombre = nombre;
            Cedula = cedula;
            this.Password = password;
        }

        /// <summary>
        /// Constructor sin parámetros para Entity Framework
        /// </summary>
        public Usuario()
        {
        }
    }
}
