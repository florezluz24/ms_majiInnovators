namespace ms_majiInnovator.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Rol { get; set; } = "Cliente";


        public Usuario(string nombre, string cedula, string password)
        {
            Nombre = nombre;
            Cedula = cedula;
            this.Password = password;
        }

        public Usuario()
        {
        }
    }
}
