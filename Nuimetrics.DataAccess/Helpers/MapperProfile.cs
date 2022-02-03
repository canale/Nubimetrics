using AutoMapper;
using Nubimetrics.Domain.Entities;
using Nubimetrics.Domain.ValueObjects;
using Nubimetrics.Infrastructure.Dtos;

namespace Nubimetrics.DataAccess.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ClassifiedLocation, Country>();
            CreateMap<CurrencyDto, Currency>();
            CreateMap<CurrencyConversionDto, CurrencyRate>();
        }
    }
}
