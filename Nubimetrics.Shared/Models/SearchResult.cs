
namespace Nubimetrics.Shared.Models
{
    public class SearchResult
    {
        public string Id { get; set; }
        public string SiteId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Seller Seller { get; set; }
        public string Permalink { get; set; }

    }
}
