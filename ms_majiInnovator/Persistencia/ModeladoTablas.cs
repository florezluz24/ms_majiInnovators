using Microsoft.EntityFrameworkCore;
using ms_majiInnovator.Modelos;

namespace ms_majiInnovator.Persistencia
{
    public class ModeladoTablas : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RespuestaEncuesta> RespuestasEncuesta { get; set; }
        public DbSet<CatalogoTelefono> CatalogoTelefono { get; set; }


        public ModeladoTablas(DbContextOptions<ModeladoTablas> opciones) : base(opciones)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn();

                entity.Property(e => e.Nombre).IsRequired();

                entity.Property(e => e.Cedula).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Rol)
                    .HasDefaultValue("Cliente")
                    .IsRequired();
            });

            modelBuilder.Entity<RespuestaEncuesta>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn();

                entity.Property(e => e.Pregunta).IsRequired();

                entity.Property(e => e.Respuesta).IsRequired();

                entity.HasOne(e => e.Usuario)
                      .WithMany()
                      .HasForeignKey(e => e.UsuarioId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CatalogoTelefono>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn();

                entity.Property(e => e.Marca).IsRequired();
                entity.Property(e => e.Camara).IsRequired();
                entity.Property(e => e.Ram).IsRequired();
                entity.Property(e => e.Precio).IsRequired();
            });


        }

    }
}
