﻿using Nubimetrics.Domain.Entities;
using System.Collections.Generic;

namespace Nubimetrics.Domain.ValueObjects
{
    public class Search : ValueObject
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

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return SiteId;
            yield return CountryDefaultTimeZone;
            yield return Query;
            yield return Paging;
            yield return Results;
        }
    }
}
