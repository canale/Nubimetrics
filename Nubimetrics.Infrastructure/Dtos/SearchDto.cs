namespace Nubimetrics.Infrastructure.Dtos
{
    public class SearchDto
    {
        public string SiteId { get; set; }
        public string CountryDefaultTimeZone { get; set; }
        public string Query { get; set; }
        public PagingDto Paging { get; set; }
        public dynamic Results { get; set; }
    }
}
