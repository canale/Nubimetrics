namespace Nubimetrics.Infrastructure.Dtos
{
    public class PagingDto
    {
        public int Total { get;  set; }
        public int PrimaryResults { get;  set; }
        public int Offset { get;  set; }
        public int Limit { get;  set; }
    }
}
