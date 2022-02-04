using System.Collections.Generic;

namespace Nubimetrics.Shared.Models
{
    public class Search 
    {
        public string SiteId { get; set; }
        public string CountryDefaultTimeZone { get; set; }
        public string Query { get; set; }
        public Paging Paging { get; set; }
        public IEnumerable<SearchResult> Results { get; set; }
        public KeyValue Sort { get; set; }
        public IEnumerable<KeyValue> AvailableSorts { get; set; }
        public IEnumerable<Filter> Filters { get; set; }
        public IEnumerable<FilterItem> AvailableFilters { get; set; }

    }
}
