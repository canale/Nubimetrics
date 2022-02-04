using System;
using System.Collections.Generic;
using System.Text;

namespace Nubimetrics.Domain.ValueObjects
{
    public class Paging : ValueObject
    {
        public int Total { get; private set; }
        public int PrimaryResults { get; private set; }
        public int Offset { get; private set; }
        public int Limit { get; private set; }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Total;
            yield return PrimaryResults;
            yield return Offset;
            yield return Limit;
        }
    }
}
