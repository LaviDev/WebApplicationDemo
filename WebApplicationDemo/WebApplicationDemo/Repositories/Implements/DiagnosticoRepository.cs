using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.DataContext;
using WebApplicationDemo.Modelo.Entities;
using WebApplicationDemo.Repositories.Interfaces;

namespace WebApplicationDemo.Repositories.Implements
{
    public class DiagnosticoRepository : IGenericRepository<Diagnostico>
    {
        private DemoContext context;
        private DbSet<Diagnostico> table = null;
        private bool disposedValue;

        public DiagnosticoRepository(DemoContext context)
        {
            this.context = context;
            table = context.Set<Diagnostico>();
        }


        public void Delete(Diagnostico diagnostico)
        {
            //Usuario? usuario = context.Usuarios.Find(usuarioID);

            table.Remove(diagnostico);
        }

        public Diagnostico GetByID(int diagnostico)
        {
            return table.Find(diagnostico);

        }

        public List<Diagnostico> Get()
        {
            return table.ToList();
        }

        public void Insert(Diagnostico diagnostico)
        {
            //context.Usuarios.Add(usuario);
            table.Add(diagnostico);

        }


        public Diagnostico Update(Diagnostico diagnostico)
        {

            return table.Update(diagnostico).Entity;

        }

        public void Save()
        {
            context.SaveChanges();
        }


    }
}
