namespace WebApplicationDemo.Modelo.Entities
{
    public class Usuario
    {
        public int Id { get; set; }//CP:Id
        public string? nombre { get; set; }
        public string? apellidos { get; set; }

        //Propiedades para autenticacion en la API
        public string? usuario { get; set; }
        public string clave { get; set; }



    }
}
