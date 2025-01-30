using WebApplicationDemo.Modelo.Entities;

namespace WebApplicationDemo.Modelo.DTOs
{
    public class AtiendeDTO
    {
        public int Id { get; set; }//CP:)Id
        public virtual Paciente Paciente { get; set; }
        public virtual Medico Medico { get; set; }
    }
}
