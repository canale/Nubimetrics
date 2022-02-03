using System;

namespace Nubimetrics.Infrastructure.Dtos
{
    public class CurrencyConversionDto
    {
        public string CurrencyBase { get;set; }
        public string CurrencyQuote { get;set; }
        public decimal Ratio { get;set; }
        public decimal Rate { get;set; }
        public decimal InvRate { get;set; }
        public DateTime CreationDate { get;set; }
        public DateTime ValidUntil { get;set; }
    }
}
