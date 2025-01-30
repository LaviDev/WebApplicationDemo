using WebApplicationDemo.Modelo.Entities;

namespace WebApplicationDemo.Modelo.DTOs
{
    public class CitaDTO
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string motivoCita { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public DiagnosticoDTO Diagnostico { get; set; }
    }
}
