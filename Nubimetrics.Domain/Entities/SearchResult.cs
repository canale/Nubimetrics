namespace Nubimetrics.Domain.Entities
{
    public class SearchResult:Entity<string>
    {
        public string SiteId { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public int SellerId { get; set; }
        public string Permalink { get; set; }

        public SearchResult():base(null)
        {
                
        }
    }
}
