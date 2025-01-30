namespace WebApplicationDemo.Modelo.Entities
{
    public class Cita
    {
        public int Id { get; set; }//CP:Id
        //public Cita cita { get; set; }
        public DateTime fehcaHora { get; set; }
        public string motivo { get; set; }


        //La lista de pacientes y medicos que tienen una cita
        public virtual Paciente Pacientes { get; set; }
        public virtual Medico Medicos { get; set; }
        public virtual Diagnostico Diagnosticos { get; set; }


        //Propagacion de claves
        public int MedicoId { get; set; }//CAj:MedicoId->MEDICO(Id)
        public int PacienteId { get; set; }//CAj:PacienteID->PACIENTE(Id)
        public int DiagnosticoId { get; set; }//CAj:DiagnostioID->DIAGNOSTICO(id)
    }
}
