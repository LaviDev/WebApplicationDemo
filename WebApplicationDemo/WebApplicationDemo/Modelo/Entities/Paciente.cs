namespace WebApplicationDemo.Modelo.Entities
{
    public class Paciente : Usuario
    {

        public string NSS { get; set; }
        public string numTarjeta { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }

        // public int UsuarioId { get; set; }//CAj:UsuarioId->ÚSUARIO(Id)

        // public virtual List<Medico> Medicos { get; set; }
        // public Usuario Usuario { get; set; }
        public virtual List<Cita> Citas { get; set; }
        public virtual List<Atiende> Atendidos { get; set; }
    }
}
