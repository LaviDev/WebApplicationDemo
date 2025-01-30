namespace WebApplicationDemo.Modelo.Entities
{
    public class Medico : Usuario
    {
        // public int Id { get; set; }//CP:Id
        public string numColegiado { get; set; }

        public int UsuarioId { get; set; }//CAj:UsuarioId->USUARIO(Id)

        public virtual List<Cita> Citas { get; set; }

        public virtual List<Atiende> Atendidos { get; set; }
    }
}
