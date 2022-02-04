namespace Nubimetrics.Application.Dtos.Responses
{
    public class SearchResponse
    {
        public string SiteId { get; set; }
        public string CountryDefaultTimeZone { get; set; }
        public string Query { get; set; }
        public PagingResponse Paging { get; set; }
        public dynamic Results { get; set; } 
    }
}
