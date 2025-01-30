using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Modelo.Entities;

namespace WebApplicationDemo.DataContext
{
    public class DemoContext : DbContext
    {

        public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }


        public DbSet<Cita> Citas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Atiende> Atendidos { get; set; }


        //https://www.learnentityframeworkcore.com/
        //https://www.learnentityframeworkcore.com/configuration/fluent-api/hasone-method

        //FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("citasmedicas");
            modelBuilder.Entity<Usuario>().ToTable("USUARIO");
            modelBuilder.Entity<Paciente>().ToTable("PACIENTE");
            modelBuilder.Entity<Medico>().ToTable("MEDICO");
            modelBuilder.Entity<Cita>().ToTable("CITA");
            modelBuilder.Entity<Diagnostico>().ToTable("DIAGNOSTICO");

            //HasOnese usa para configurar el lado de una relación de uno a muchos, o un extremo de una relación de uno a uno.
            //Para configurar completamente una relación válida, es necesario seguir el patrón Has / With y vincular el uso de 
            //HasOnecon el método WithOneo WithMany, dependiendo de si la relación que se está configurando es una relación uno a uno o uno a - relación de muchos.

            modelBuilder.Entity<Atiende>().HasKey(x => new { x.MedicoIdFK, x.PacienteIdFK });
            modelBuilder.Entity<Cita>().HasKey(x => new { x.Id });


            modelBuilder.Entity<Atiende>()
                .HasOne<Paciente>(p => p.Paciente)
                .WithMany(a => a.Atendidos)
                .HasForeignKey(p => p.PacienteIdFK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            //para evitar podrían producirse ciclos o múltiples rutas en cascada


            modelBuilder.Entity<Atiende>()
                .HasOne<Medico>(m => m.Medico)
                .WithMany(a => a.Atendidos)
                .HasForeignKey(m => m.MedicoIdFK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);



            //Relacion uno a uno:diagnostico-cita
            modelBuilder.Entity<Cita>()
                .HasOne(a => a.Diagnosticos)
                .WithOne(b => b.cita);

            //Relacion uno a muchos:medico-cita
            modelBuilder.Entity<Cita>()
                .HasOne(a => a.Medicos)
                .WithMany(b => b.Citas);

            //Relacion unoa muchos:paciente-cita
            modelBuilder.Entity<Cita>()
               .HasOne(a => a.Medicos)
               .WithMany(b => b.Citas);

            //modelBuilder.Entity<Paciente>()
            //    .HasOne(a => a.Usuario)
            //    .WithOne(b => b.Pacientes),
            //    .Has



        }

    }
}
