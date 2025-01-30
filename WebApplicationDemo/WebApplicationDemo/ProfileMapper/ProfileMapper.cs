using AutoMapper;
using WebApplicationDemo.Modelo.DTOs;
using WebApplicationDemo.Modelo.Entities;

namespace WebApplicationDemo.ProfileMapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<PacienteDTO, Paciente>();
            CreateMap<Paciente, PacienteDTO>();
            CreateMap<Medico, MedicoDTO>();
            CreateMap<MedicoDTO, Medico>();
            //CreateMap<PacienteChildDTO, Paciente>();
            // CreateMap<Medico, MedicoChildDTO>();
            //CreateMap<MedicoChildDTO, Medico>();
            CreateMap<Cita, CitaDTO>();
            CreateMap<CitaDTO, Cita>();
            CreateMap<Diagnostico, DiagnosticoDTO>();
            CreateMap<DiagnosticoDTO, Diagnostico>();
            // CreateMap<Diagnostico, DiagnosticoChildDTO>();
            //CreateMap<DiagnosticoChildDTO, Diagnostico>();

            //Para tablas intermedias


            //CreateMap<Paciente, PacienteDTO>().ForMember(dto => dto.Medicos,
            //    opt => opt.MapFrom(
            //        p => p.MedicosPacientes.Select(mp => mp.Medico).ToList()
            //    )
            //);

            //CreateMap<PacienteDTO, Paciente>().ForMember(dto => dto.MedicosPacientes,
            //    opt => opt.MapFrom(
            //        p => p.Medicos.Select(m => new MedicoPaciente { MedicoId = m.Id, PacienteId = p.Id })
            //    )
            //);


            //CreateMap<Medico, MedicoDTO>().ForMember(dto => dto.Pacientes,
            //    opt => opt.MapFrom(
            //        m => m.MedicosPacientes.Select(mp => mp.Paciente).ToList()
            //    )
            //);

            //CreateMap<MedicoDTO, Medico>().ForMember(dto => dto.MedicosPacientes,
            //    opt => opt.MapFrom(
            //        m => m.Pacientes.Select(p => new MedicoPaciente { MedicoId = m.Id, PacienteId = p.Id })
            //    )
            //);
        }
    }
}
