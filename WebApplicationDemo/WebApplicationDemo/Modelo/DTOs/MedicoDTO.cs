namespace WebApplicationDemo.Modelo.DTOs
{
    public class MedicoDTO : UsuarioDTO
    {
        public string numColegiado { get; set; }
        public virtual List<CitaDTO> Citas { get; set; }

    }
}
