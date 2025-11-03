namespace ms_majiInnovator.Configuracion
{
    /// <summary>
    /// Configuración para Azure Storage Account
    /// </summary>
    public class AzureStorageConfig
    {
        /// <summary>
        /// Cadena de conexión para Azure Storage Account
        /// </summary>
        public string ConnectionString { get; set; } = string.Empty;
        
        /// <summary>
        /// URL base del Storage Account
        /// </summary>
        public string BaseUrl { get; set; } = string.Empty;
        
        /// <summary>
        /// Nombre del contenedor por defecto
        /// </summary>
        public string ContainerName { get; set; } = string.Empty;
    }
}
