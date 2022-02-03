namespace Nubimetrics.Application.Dtos.Responses
{
    public class CurrencyItemResponse
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public int DecimalPlaces { get; set; }
        public CurrencyRateResponse Rate { get; set; }
    }
}
