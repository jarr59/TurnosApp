using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> options) : base (options)
        {}
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<MedicoEspecialidad> MedicoEspecialidads { get; set; }
        public DbSet<Turno> Turno { get; set; }
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

            modelBuilder.Entity<Medico>(entity=>{

                entity.ToTable("Medico");

                entity.HasKey(x=>x.IdMedico);

                entity.Property(x=>x.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(x=>x.Apellido)
                .IsRequired()
                .HasMaxLength(50)
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
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(x=>x.HorarioAtencionDesde)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(x=>x.HorarioAtencionHasta)
                .IsRequired()
                .IsUnicode(false);

            });

            modelBuilder.Entity<MedicoEspecialidad>().HasKey(x => new {x.IdEspecialidad, x.IdMedico});

            modelBuilder.Entity<MedicoEspecialidad>()
                .HasOne(x=>x.Medico)
                .WithMany(p => p.MedicoEspecialidad)
                .HasForeignKey(p=>p.IdMedico);

            modelBuilder.Entity<MedicoEspecialidad>()
                .HasOne(x=>x.Especialidad)
                .WithMany(x=>x.MedicoEspecialidad)
                .HasForeignKey(x=>x.IdEspecialidad);
            
            modelBuilder.Entity<Turno>(entity=>{

                entity.ToTable("Turno");

                entity.HasKey(x=>x.IdTurno);

                entity.Property(x=>x.IdPaciente)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(x=>x.IdMedico)
                .IsRequired()
                .IsUnicode(false);
 
                entity.Property(x=>x.FechaHoraInicio)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(x=>x.FechaHoraFin)
                .IsRequired()
                .IsUnicode(false);
            });

            modelBuilder.Entity<Turno>().HasOne(x=>x.Paciente)
            .WithMany(p=>p.Turno)
            .HasForeignKey(p => p.IdPaciente);

            modelBuilder.Entity<Turno>().HasOne(x=>x.Medico)
            .WithMany(p=>p.Turno)
            .HasForeignKey(p => p.IdMedico);
            
        }
    }

}