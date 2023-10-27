using AutoMapper;
using Backend.DTOs;
using Backend.Models;

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