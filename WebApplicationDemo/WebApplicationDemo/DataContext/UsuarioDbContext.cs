using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Modelo.Entities;

namespace WebApplicationDemo.DataContext
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            ////Usuario
            //modelBuilder.Entity<Usuario>()
            //    .HasOne(c => c.Diagnosticos);

        }



    }
}
