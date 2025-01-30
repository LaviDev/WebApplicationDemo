using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo.Modelo.DTOs;
using WebApplicationDemo.Service.Interface;

namespace WebApplicationDemo.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {



        //        private readonly IGenericRepository<Usuario> usuarioRepository;
        private readonly IMapper mapper;
        private readonly IGenericService<MedicoDTO> service;

        public MedicoController(IMapper mapper, IGenericService<MedicoDTO> service)
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
        public ActionResult<List<MedicoDTO>> GetUsuarios()
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
        public ActionResult<MedicoDTO> InsertUsuario(MedicoDTO addUsuario)
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
        public ActionResult<MedicoDTO> UpdateUsuario(MedicoDTO updateUsuario)
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
        public ActionResult<MedicoDTO> GetUsuario([FromRoute] int id)
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
