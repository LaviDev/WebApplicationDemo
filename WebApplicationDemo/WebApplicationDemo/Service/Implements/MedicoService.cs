using AutoMapper;
using WebApplicationDemo.Modelo.DTOs;
using WebApplicationDemo.Modelo.Entities;
using WebApplicationDemo.Repositories.Interfaces;
using WebApplicationDemo.Service.Interface;

namespace WebApplicationDemo.Service.Implements
{
    public class MedicoService : IGenericService<MedicoDTO>
    {

        private readonly IMapper mapper;
        private readonly IGenericRepository<Medico> _repository;

        public MedicoService(IMapper mapper, IGenericRepository<Medico> repository)
        {
            this.mapper = mapper;
            _repository = repository;
        }

        public void Add(MedicoDTO obj)
        {

            _repository.Insert(mapper.Map<MedicoDTO, Medico>(obj));
            _repository.Save();
        }

        public void Delete(int id)
        {
            Medico medico = _repository.GetByID((id));
            if (medico != null)
            {
                _repository.Delete(medico);
                _repository.Save();
            }
            else
            {
                throw new Exception("Cita noto Found");
            }
        }

        public List<MedicoDTO> GetAll()
        {

            return mapper.Map<List<Medico>, List<MedicoDTO>>(_repository.Get());
        }


        public MedicoDTO GetById(int id)
        {
            return mapper.Map<Medico, MedicoDTO>(_repository.GetByID(id));
        }

        public void Update(MedicoDTO obj)
        {
            //Usuario usuario = _repository.GetUsuariosByID((obj.Id));
            //if (usuario != null)
            //{
            //    usuario = _repository.UpdateUsuario(mapper.Map<UsuarioDTO, Usuario>(obj));
            //    return mapper.Map<Usuario, UsuarioDTO>(usuario);
            //}
            //else
            //{
            //    return null;

            //    //Lanzamos excepcion de que el usuario no exite
            //}

            Medico medico = _repository.Update(mapper.Map<MedicoDTO, Medico>(obj));
            // return mapper.Map<Medico, MedicoDTO>(medico);



            if (_repository.GetByID(obj.Id) != null)
            {
                mapper.Map<MedicoDTO, Medico>(obj, _repository.GetByID(obj.Id));
                _repository.Save();


            }

        }
    }
}
