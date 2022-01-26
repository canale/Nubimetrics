using AutoMapper;
using Nubimetrics.DataAccess.Records;
using Nubimetrics.Domain.Entities;

namespace Nubimetrics.DataAccess.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ClassifiedLocation, Pais>();
        }
    }
}
