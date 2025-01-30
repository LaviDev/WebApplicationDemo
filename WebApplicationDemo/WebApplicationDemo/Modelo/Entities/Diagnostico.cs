namespace WebApplicationDemo.Modelo.Entities
{
    public class Diagnostico
    {
        public int Id { get; set; }//CP:Id
        public string valoracionEspecialista { get; set; }
        public string enfermedad { get; set; }
        public virtual Cita cita { get; set; }
    }
}
