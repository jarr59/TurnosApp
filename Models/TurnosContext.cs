using Microsoft.EntityFrameworkCore;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> options) : base (options)
        {}
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Especialidad>(entidad =>{
                
                entidad.ToTable("Especialidad");
                
                entidad.HasKey(e=>e.IdEspecialidad);

                entidad.Property(e=>e.Descripcion)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(200);
            });

            modelBuilder.Entity<Paciente>(entity =>{
                
                entity.ToTable("Paciente");

                entity.HasKey(x=>x.IdPaciente);

                entity.Property(x=>x.Nombre)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

                entity.Property(x=>x.Apellido)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

                entity.Property(x=>x.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entity.Property(x=>x.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entity.Property(x=>x.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });
        }
    }

}