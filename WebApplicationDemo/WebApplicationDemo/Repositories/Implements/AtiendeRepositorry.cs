using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.DataContext;
using WebApplicationDemo.Modelo.Entities;
using WebApplicationDemo.Repositories.Interfaces;

namespace WebApplicationDemo.Repositories.Implements
{
    public class AtiendeRepository : IGenericRepository<Atiende>
    {
        private DemoContext context;
        private DbSet<Atiende> table = null;
        private bool disposedValue;

        public AtiendeRepository(DemoContext context)
        {
            this.context = context;
            table = context.Set<Atiende>();
        }


        public void Delete(Atiende atiende)
        {
            //Usuario? usuario = context.Usuarios.Find(usuarioID);

            table.Remove(atiende);
        }

        public Atiende GetByID(int atiende)
        {
            return table.Find(atiende);

        }

        public List<Atiende> Get()
        {
            return table.ToList();
        }

        public void Insert(Atiende atiende)
        {
            //context.Usuarios.Add(usuario);
            table.Add(atiende);

        }


        public Atiende Update(Atiende atiende)
        {

            return table.Update(atiende).Entity;

        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
