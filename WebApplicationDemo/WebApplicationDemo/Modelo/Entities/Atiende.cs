namespace WebApplicationDemo.Modelo.Entities
{
    public class Atiende
    {
        public int Id { get; set; }//CP:)Id

        //Foregin Key For Medico
        public int MedicoIdFK { get; set; }//CAj:MedicoId->MEDICO(Id)

        //Foregin Key For Paciente
        public int PacienteIdFK { get; set; }//CAj:PacienteId->PACIENTE(Id)
        public virtual Paciente Paciente { get; set; }
        public virtual Medico Medico { get; set; }


    }
}
