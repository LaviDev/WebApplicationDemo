
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.DataContext;
using WebApplicationDemo.Modelo.Entities;
using WebApplicationDemo.Repositories.Interfaces;
namespace WebApplicationDemo.Repositories.Implements
{
    public class CitaRepository : IGenericRepository<Cita>
    {
        private DemoContext context;
        private DbSet<Cita> table = null;
        private bool disposedValue;

        public CitaRepository(DemoContext context)
        {
            this.context = context;
            table = context.Set<Cita>();
        }


        public void Delete(Cita cita)
        {
            //Usuario? usuario = context.Usuarios.Find(usuarioID);

            table.Remove(cita);
        }

        public Cita GetByID(int citaId)
        {
            return table.Find(citaId);

        }

        public List<Cita> Get()
        {
            return table.ToList();
        }

        public void Insert(Cita cita)
        {
            //context.Usuarios.Add(usuario);
            table.Add(cita);

        }


        public Cita Update(Cita cita)
        {

            return table.Update(cita).Entity;

        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
