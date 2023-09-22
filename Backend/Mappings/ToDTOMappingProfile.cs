using AutoMapper;
using Backend.DTOs;
using beckend.Models;

namespace Backend.Mappings
{
    public class ToDTOMappingProfile : Profile
    {
        public ToDTOMappingProfile()
        {
            CreateMap<Marcacao, MarcacaoDTO>().ReverseMap();
        }
    }
}