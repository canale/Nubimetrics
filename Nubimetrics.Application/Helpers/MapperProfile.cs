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
            CreateMap<Search, SearchResponse>();
            CreateMap<Paging, PagingResponse>();
            CreateMap<KeyValue, KeyValueResponse>();
            CreateMap<Value, ValueResponse>();
            CreateMap<Filter, FilterResponse>();
            CreateMap<FilterItem, FilterItemResponse>();
            CreateMap<ValueItemFilter, ValueItemFilterResponse>();
            CreateMap<SearchResult, SearchResultResponse>();
        }
    }
}
