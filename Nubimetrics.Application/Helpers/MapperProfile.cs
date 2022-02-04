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
               // .ForMember(dto => dto.Rate, opt => opt.MapFrom(src => src.));
            CreateMap<CurrencyRate, CurrencyRateResponse>();
            CreateMap<Search, SearchResponse>();
            CreateMap<Paging, PagingResponse>();
        }
    }
}
