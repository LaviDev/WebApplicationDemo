using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo.Modelo.DTOs;
using WebApplicationDemo.Service.Interface;

namespace WebApplicationDemo.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {



        //        private readonly IGenericRepository<Usuario> usuarioRepository;
        private readonly IMapper mapper;
        private readonly IGenericService<UsuarioDTO> service;

        public UsuarioController(IMapper mapper, IGenericService<UsuarioDTO> service)
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
        public ActionResult<List<UsuarioDTO>> GetUsuarios()
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
        public ActionResult<UsuarioDTO> InsertUsuario(UsuarioDTO addUsuario)
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
        public ActionResult<UsuarioDTO> UpdateUsuario(int id, UsuarioDTO updateUsuario)
        {
            try
            {
                service.Update(updateUsuario);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }

            return Ok();
        }


        ///// <summary>
        ///// Devuelve un solo Usuarios
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<UsuarioDTO> GetUsuario([FromRoute] int id)
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
