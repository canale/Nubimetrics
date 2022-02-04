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
            CreateMap<ClassifiedLocationDto, Country>();
            CreateMap<CurrencyDto, Currency>();
            CreateMap<CurrencyConversionDto, CurrencyRate>();
            CreateMap<PagingDto, Paging>();
            CreateMap<Search, Search>();


            CreateMap<KeyValueDto, KeyValue>();
            CreateMap<ValueDto, Value>();
            CreateMap<FilterDto, Filter>();
            CreateMap<FilterItemDto, FilterItem>();
            CreateMap<ValueItemFilterDto, ValueItemFilter>();
            CreateMap<SearchResultDto, SearchResult>()
                .ForMember(dto => dto.SellerId, opt => opt.MapFrom(src => src.Seller.Id));
        }
    }
}
