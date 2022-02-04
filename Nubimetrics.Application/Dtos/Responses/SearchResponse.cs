
using System.Collections.Generic;

namespace Nubimetrics.Application.Dtos.Responses
{
    public class SearchResponse
    {
        public string SiteId { get; set; }
        public string CountryDefaultTimeZone { get; set; }
        public string Query { get; set; }
        public PagingResponse Paging { get; set; }
        public IEnumerable<SearchResultResponse> Results { get; set; }
        public KeyValueResponse Sort { get; set; }
        public IEnumerable<KeyValueResponse> AvailableSorts { get; set; }
        public IEnumerable<FilterResponse> Filters { get; set; }
        public IEnumerable<FilterItemResponse> AvailableFilters { get; set; }
    }
}
