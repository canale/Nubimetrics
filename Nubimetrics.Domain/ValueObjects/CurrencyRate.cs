using System;
using System.Collections.Generic;

namespace Nubimetrics.Domain.ValueObjects
{
    public class CurrencyRate : ValueObject
    {
        public string CurrencyBase { get; set; }
        public string CurrencyQuote { get; set; }
        public decimal Ratio { get; set; }
        public decimal Rate { get; set; }
        public decimal InvRate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ValidUntil { get; set; }

        public CurrencyRate()
        {

        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CurrencyBase;
            yield return CurrencyQuote;
            yield return Ratio;
            yield return Rate ;
            yield return InvRate;
            yield return CreationDate;
            yield return ValidUntil;
        }
    }
}
