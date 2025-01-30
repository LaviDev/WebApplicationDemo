using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo.Modelo.DTOs;
using WebApplicationDemo.Service.Interface;

namespace WebApplicationDemo.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class DiagnosticoController : ControllerBase
    {



        //        private readonly IGenericRepository<Usuario> usuarioRepository;
        private readonly IMapper mapper;
        private readonly IGenericService<DiagnosticoDTO> service;

        public DiagnosticoController(IMapper mapper, IGenericService<DiagnosticoDTO> service)
        {
            // this.usuarioRepository = usuarioRepositor;
            this.mapper = mapper;
            this.service = service;
        }


        /// <summary>
        /// Devuelve todos los Usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<DiagnosticoDTO>> GetUsuarios()
        {
            return service.GetAll();
            //return mapper.Map<List<Usuario>, List<UsuarioDTO>>(usuarioRepository.GetUsuarios());

            // return Ok(usuarioRepository.GetUsuarios());
        }

        /// <summary>
        ///// Crea Usuarios
        ///// </summary>
        ///// <param name="addContactRequest"></param>
        ///// <returns></returns>
        [HttpPost]
        public ActionResult<DiagnosticoDTO> InsertUsuario(DiagnosticoDTO addUsuario)
        {

            service.Add(addUsuario);
            return addUsuario;

        }

        ///// <summary>
        ///// Actualiza datos de los Usuarios
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="updateContactRequest"></param>
        ///// <returns></returns>
        [HttpPut]
        public ActionResult<DiagnosticoDTO> UpdateUsuario(DiagnosticoDTO updateUsuario)
        {
            service.Update(updateUsuario);
            return Ok();

        }


        ///// <summary>
        ///// Devuelve un solo Usuarios
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<DiagnosticoDTO> GetUsuario([FromRoute] int id)
        {

            return service.GetById(id);

        }

        ///// <summary>
        ///// Borrar un Usuario
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        [HttpDelete("id")]
        public ActionResult DeleteContact(int id)
        {
            service.Delete(id);
            return Ok();
        }


    }
}
