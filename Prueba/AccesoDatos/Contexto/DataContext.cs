using AccesoDatos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Contexto
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProgramasTv> ProgramasTv { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramasTv>(entity =>
            {
                entity.ToTable("ProgramasTV");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Programa).IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("ROLES");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Identificacion);

                entity.ToTable("USUARIOS");

                entity.Property(e => e.Identificacion).ValueGeneratedNever();

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_USUARIOS");
            });
        }
    }
}
