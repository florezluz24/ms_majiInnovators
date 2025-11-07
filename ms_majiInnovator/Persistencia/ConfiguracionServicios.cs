using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ms_majiInnovator.Repositorios;

namespace ms_majiInnovator.Persistencia
{
    public static class ConfiguracionServicios
    {
        public static void AgregarServiciosPersistencia(this IServiceCollection servicios, string connectionString)
        {
            servicios.AddDbContext<ModeladoTablas>(opciones =>
                opciones.UseSqlServer(connectionString));
            
            servicios.AddScoped<RepositorioUsuario>();
            servicios.AddScoped<RepositorioRespuestaEncuesta>();            
            servicios.AddScoped<RepositorioMarcaCelular>();
            servicios.AddScoped<RepositorioImagenCelular>();
            servicios.AddScoped<RepositorioPago>();            
        }
    }
}
