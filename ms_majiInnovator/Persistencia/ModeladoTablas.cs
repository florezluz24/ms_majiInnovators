using Microsoft.EntityFrameworkCore;
using ms_majiInnovator.Modelos;

namespace ms_majiInnovator.Persistencia
{
    public class ModeladoTablas : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RespuestaEncuesta> RespuestasEncuesta { get; set; }        
        public DbSet<MarcaCelular> MarcasCelular { get; set; }
        public DbSet<ModeloCelular> ModelosCelular { get; set; }
        public DbSet<CaracteristicaCelular> CaracteristicasCelular { get; set; }
        public DbSet<ImagenCelular> ImagenesCelular { get; set; }


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

            modelBuilder.Entity<MarcaCelular>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn();

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Descripcion)
                      .HasMaxLength(500);

                entity.Property(e => e.Activa)
                      .HasDefaultValue(true);

                entity.Property(e => e.FechaCreacion)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => e.Nombre)
                      .IsUnique();
            });

            modelBuilder.Entity<ModeloCelular>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn();

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(e => e.Descripcion)
                      .HasMaxLength(1000);

                entity.Property(e => e.Precio)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                entity.Property(e => e.Disponible)
                      .HasDefaultValue(true);

                entity.Property(e => e.FechaCreacion)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Marca)
                      .WithMany(m => m.Modelos)
                      .HasForeignKey(e => e.MarcaId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => new { e.Nombre, e.MarcaId })
                      .IsUnique();
            });

            modelBuilder.Entity<CaracteristicaCelular>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn();

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Valor)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Unidad)
                      .HasMaxLength(50);

                entity.Property(e => e.Descripcion)
                      .HasMaxLength(500);

                entity.Property(e => e.Activa)
                      .HasDefaultValue(true);

                entity.Property(e => e.FechaCreacion)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Modelo)
                      .WithMany(m => m.Caracteristicas)
                      .HasForeignKey(e => e.ModeloId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => new { e.Nombre, e.ModeloId })
                      .IsUnique();
            });

            modelBuilder.Entity<ImagenCelular>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn();

                entity.Property(e => e.RutaImagen)
                      .IsRequired()
                      .HasMaxLength(500);

                entity.HasOne(e => e.Modelo)
                      .WithMany(m => m.Imagenes)
                      .HasForeignKey(e => e.ModeloId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

        }

    }
}
