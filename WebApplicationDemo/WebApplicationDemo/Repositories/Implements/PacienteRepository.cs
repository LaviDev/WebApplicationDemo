using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.DataContext;
using WebApplicationDemo.Modelo.Entities;
using WebApplicationDemo.Repositories.Interfaces;

namespace WebApplicationDemo.Repositories.Implements
{
    public class PacienteRepository : IGenericRepository<Paciente>
    {
        private DemoContext context;
        private DbSet<Paciente> table = null;
        private readonly IMapper mapper;


        public PacienteRepository(DemoContext context)
        {
            this.context = context;
            table = context.Set<Paciente>();
        }


        public void Delete(Paciente paciente)
        {
            //Usuario? usuario = context.Usuarios.Find(usuarioID);

            table.Remove(paciente);
        }

        public Paciente GetByID(int paciente)
        {
            return table.Find(paciente);

        }

        public List<Paciente> Get()
        {
            return table.ToList();
        }

        public void Insert(Paciente paciente)
        {
            //    Paciente paciente = mapper.Map<Paciente>(paciente);
            //    paciente.Id = 0;
            table.Add(paciente);

        }


        public Paciente Update(Paciente paciente)
        {

            return table.Update(paciente).Entity;

        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
