namespace ms_majiInnovator.DTOs
{
    /// <summary>
    /// DTO para la creación de usuarios en el sistema
    /// Contiene solo los campos necesarios para el registro
    /// </summary>
    /// <remarks>
    /// Este DTO se utiliza para recibir datos del frontend durante el proceso de registro.
    /// No incluye campos como ID, Teléfono o Rol que se manejan internamente.
    /// </remarks>
    public class UsuarioDTO
    {
        /// <summary>
        /// Nombre completo del usuario
        /// </summary>
        public string Nombre { get; set; } = string.Empty;
        
        /// <summary>
        /// Número de cédula del usuario (debe ser numérico)
        /// </summary>
        public string Cedula { get; set; } = string.Empty;
        
        /// <summary>
        /// Contraseña del usuario (mínimo 5 caracteres)
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
