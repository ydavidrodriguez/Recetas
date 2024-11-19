using AutoMapper;
using Recetas.Domain.Dto;

namespace Recetas.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Domain.Entitites.Recetas, CreateRecetasRequest>().ReverseMap();
          
        }

    }
}
