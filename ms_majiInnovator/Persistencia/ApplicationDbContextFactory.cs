using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ms_majiInnovator.Persistencia
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ModeladoTablas>
    {
        public ModeladoTablas CreateDbContext(string[] args)
        {
            var opcionesBuilder = new DbContextOptionsBuilder<ModeladoTablas>();
            
            // Leer la cadena de conexión desde appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
                
            opcionesBuilder.UseSqlServer(connectionString);

            return new ModeladoTablas(opcionesBuilder.Options);
        }
    }
}
