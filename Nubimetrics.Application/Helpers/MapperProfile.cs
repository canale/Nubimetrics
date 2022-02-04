using AutoMapper;
using Nubimetrics.Application.Dtos.Responses;
using Nubimetrics.Domain.Entities;
using Nubimetrics.Domain.ValueObjects;

namespace Nubimetrics.Application.Helpers
{
    public class MapperProfile : Profile 
    {
        public MapperProfile()
        {
            CreateMap<Country, CountryResponse>();
            CreateMap<Currency, CurrencyItemResponse>();
            CreateMap<CurrencyRate, CurrencyRateResponse>();
        }
    }
}
