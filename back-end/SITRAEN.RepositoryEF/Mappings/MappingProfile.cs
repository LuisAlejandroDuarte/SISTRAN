using AutoMapper;
using SITRAEN.DTOs.Persona;
using SITRAEN.Entities.POCOs;

namespace SITRAEN.RepositoryEF.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Persona,PersonaDTO>().ReverseMap();
            CreateMap<Contacto, ContactoDTO>().ReverseMap();

        }
    }
}
