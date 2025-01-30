using AutoMapper;
using WebApplicationDemo.Modelo.DTOs;
using WebApplicationDemo.Modelo.Entities;
using WebApplicationDemo.Repositories.Interfaces;
using WebApplicationDemo.Service.Interface;

namespace WebApplicationDemo.Service.Implements
{
    public class DiagnosticoService : IGenericService<DiagnosticoDTO>
    {

        private readonly IMapper mapper;
        private readonly IGenericRepository<Diagnostico> _repository;

        public DiagnosticoService(IMapper mapper, IGenericRepository<Diagnostico> repository)
        {
            this.mapper = mapper;
            _repository = repository;
        }

        public void Add(DiagnosticoDTO obj)
        {

            _repository.Insert(mapper.Map<DiagnosticoDTO, Diagnostico>(obj));
            _repository.Save();
        }

        public void Delete(int id)
        {
            Diagnostico diagnostico = _repository.GetByID((id));
            if (diagnostico != null)
            {
                _repository.Delete(diagnostico);
                _repository.Save();
            }
            else
            {
                throw new Exception("Cita noto Found");
            }
        }

        public List<DiagnosticoDTO> GetAll()
        {

            return mapper.Map<List<Diagnostico>, List<DiagnosticoDTO>>(_repository.Get());
        }


        public DiagnosticoDTO GetById(int id)
        {
            return mapper.Map<Diagnostico, DiagnosticoDTO>(_repository.GetByID(id));
        }

        public void Update(DiagnosticoDTO obj)
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

            Diagnostico diagnostico = _repository.Update(mapper.Map<DiagnosticoDTO, Diagnostico>(obj));
            // return mapper.Map<Medico, MedicoDTO>(medico);



            if (_repository.GetByID(obj.Id) != null)
            {
                mapper.Map<DiagnosticoDTO, Diagnostico>(obj, _repository.GetByID(obj.Id));
                _repository.Save();


            }
        }
    }
}
