using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ms_majiInnovator.Persistencia
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ModeladoTablas>
    {
        public ModeladoTablas CreateDbContext(string[] args)
        {
            var opcionesBuilder = new DbContextOptionsBuilder<ModeladoTablas>();
            opcionesBuilder.UseSqlServer(ConfiguracionConexion.CadenaConexion);

            return new ModeladoTablas(opcionesBuilder.Options);
        }
    }
}
