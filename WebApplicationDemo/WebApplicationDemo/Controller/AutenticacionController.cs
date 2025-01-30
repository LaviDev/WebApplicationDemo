using Microsoft.AspNetCore.Mvc;

namespace WebApplicationDemo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        //Aqui creamos el metodo para que el usuario pueda autenticarse y validarse

        private readonly string secretKey;

        public AutenticacionController(IConfiguration config)
        {
            this.secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
        }

        //[HttpPost]
        //[Route("Validar")]
        //public IActionResult Validar([FromBody] UsuarioDTO request)
        //{
        //    if (request.usuario == "usuario" && request.clave == "1234")
        //    {
        //        //Implementacion de Json web tokens

        //    }

        //}

    }
}
