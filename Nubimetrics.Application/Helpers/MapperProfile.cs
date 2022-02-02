using AutoMapper;
using Nubimetrics.Application.Dtos.Responses;
using Nubimetrics.Domain.Entities;

namespace Nubimetrics.Application.Helpers
{
    public class MapperProfile : Profile 
    {
        public MapperProfile()
        {
            CreateMap<Pais, PaisResponse>();
        }
    }
}
