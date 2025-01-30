using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.DataContext;
using WebApplicationDemo.Modelo.Entities;
using WebApplicationDemo.Repositories.Interfaces;

namespace WebApplicationDemo.Repositories.Implements
{
    public class MedicoRepository : IGenericRepository<Medico>
    {
        private DemoContext context;
        private DbSet<Medico> table = null;
        private bool disposedValue;

        public MedicoRepository(DemoContext context)
        {
            this.context = context;
            table = context.Set<Medico>();
        }


        public void Delete(Medico medico)
        {
            //Usuario? usuario = context.Usuarios.Find(usuarioID);

            table.Remove(medico);
        }

        public Medico GetByID(int medico)
        {
            return table.Find(medico);

        }

        public List<Medico> Get()
        {
            return table.ToList();
        }

        public void Insert(Medico medico)
        {
            //context.Usuarios.Add(usuario);
            table.Add(medico);

        }


        public Medico Update(Medico medico)
        {

            return table.Update(medico).Entity;

        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
