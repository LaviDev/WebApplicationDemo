using AutoMapper;
using WebApplicationDemo.Modelo.DTOs;
using WebApplicationDemo.Modelo.Entities;
using WebApplicationDemo.Repositories.Interfaces;
using WebApplicationDemo.Service.Interface;

namespace WebApplicationDemo.Service.Implements
{
    public class PacienteService : IGenericService<PacienteDTO>
    {

        private readonly IMapper mapper;
        private readonly IGenericRepository<Paciente> _repository;

        public PacienteService(IMapper mapper, IGenericRepository<Paciente> repository)
        {
            this.mapper = mapper;
            _repository = repository;
        }

        public void Add(PacienteDTO obj)
        {

            _repository.Insert(mapper.Map<PacienteDTO, Paciente>(obj));
            _repository.Save();
        }

        public void Delete(int id)
        {
            Paciente paciente = _repository.GetByID((id));
            if (paciente != null)
            {
                _repository.Delete(paciente);
                _repository.Save();
            }
            else
            {
                throw new Exception("Cita noto Found");
            }
        }

        public List<PacienteDTO> GetAll()
        {

            return mapper.Map<List<Paciente>, List<PacienteDTO>>(_repository.Get());
        }

        public PacienteDTO GetById(int id)
        {
            return mapper.Map<Paciente, PacienteDTO>(_repository.GetByID(id));
        }

        public void Update(PacienteDTO obj)
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

            //Paciente paciente = _repository.Update(mapper.Map<PacienteDTO, Paciente>(obj));
            //return mapper.Map<Paciente, PacienteDTO>(paciente);

            //Paciente paciente = _repository.Update(mapper.Map<PacienteDTO, Paciente>(obj));
            //return mapper.Map<Paciente, PacienteDTO>(paciente);


            //var paciente = _repository.GetByID(obj.Id);//devuelve un Paciente
            //if (paciente != null)
            //{
            //    Paciente paciente = _repository.Update(mapper.Map<PacienteDTO, Paciente>(obj));
            //}


            //Medico medico = _repository.Update(mapper.Map<MedicoDTO, Medico>(obj));



            if (_repository.GetByID(obj.Id) != null)
            {
                mapper.Map<PacienteDTO, Paciente>(obj, _repository.GetByID(obj.Id));
                _repository.Save();


            }



        }
    }
}
