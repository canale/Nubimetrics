using System.Collections.Generic;

namespace Nubimetrics.Infrastructure.Dtos
{
    public class SearchDto
    {
        public string SiteId { get; set; }
        public string CountryDefaultTimeZone { get; set; }
        public string Query { get; set; }
        public PagingDto Paging { get; set; }
        public IEnumerable<SearchResultDto> Results { get; set; }
        public KeyValueDto Sort{ get; set; }
        public IEnumerable<KeyValueDto> AvailableSorts { get; set; }
        public IEnumerable<FilterDto> Filters { get; set; }
        public IEnumerable<FilterItemDto> AvailableFilters { get; set; }

    }
}
