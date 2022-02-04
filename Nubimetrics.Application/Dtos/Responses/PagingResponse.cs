namespace Nubimetrics.Application.Dtos.Responses
{
    public class PagingResponse
    {
        public int Total { get; set; }
        public int PrimaryResults { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
