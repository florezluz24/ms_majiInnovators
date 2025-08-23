using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ms_majiInnovator.Repositorios;

namespace ms_majiInnovator.Persistencia
{
    public static class ConfiguracionServicios
    {
        public static void AgregarServiciosPersistencia(this IServiceCollection servicios)
        {
            servicios.AddDbContext<ModeladoTablas>(opciones =>
                opciones.UseSqlServer(ConfiguracionConexion.CadenaConexion));
            
            servicios.AddScoped<RepositorioUsuario>();
            servicios.AddScoped<RepositorioRespuestaEncuesta>();
            servicios.AddScoped<RepositorioCatalogoTelefono>();
        }
    }
}
