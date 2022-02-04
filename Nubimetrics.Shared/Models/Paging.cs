using System.Collections.Generic;

namespace Nubimetrics.Shared.Models
{
    public class Paging
    {
        public int Total { get;  set; }
        public int PrimaryResults { get;  set; }
        public int Offset { get;  set; }
        public int Limit { get;  set; }

    }
}
