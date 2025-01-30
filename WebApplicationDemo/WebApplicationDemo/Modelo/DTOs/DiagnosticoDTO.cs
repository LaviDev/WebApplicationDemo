namespace WebApplicationDemo.Modelo.DTOs
{
    public class DiagnosticoDTO
    {
        public int Id { get; set; }//CP:Id
        public string valoracionEspecialista { get; set; }
        public string enfermedad { get; set; }
        public CitaDTO Cita { get; set; }

    }
}
