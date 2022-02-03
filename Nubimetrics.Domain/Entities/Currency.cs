using Nubimetrics.Domain.ValueObjects;
using System;

namespace Nubimetrics.Domain.Entities
{
    public class Currency : Entity<string>
    {
        public string Symbol { get; private set; }
        public string Description { get; private set; }
        public int DecimalPlaces { get; private set; }
        public CurrencyRate Rate { get; private set; }


        private Currency():base(null)
        {

        }

        public Currency(string id, string description, int decimalPlaces, CurrencyRate currencyRate) : base(id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException($"'{nameof(id)}' cannot be null or empty.", nameof(id));
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException($"'{nameof(description)}' cannot be null or empty.", nameof(description));
            }

            if (currencyRate == null)
            {
                throw new ArgumentException($"'{nameof(currencyRate)}' cannot be null.", nameof(currencyRate));
            }

            Description = description;
            DecimalPlaces = decimalPlaces;
            Rate = currencyRate;
        }

        public void ChangeRate(CurrencyRate currencyRate)
        {
            if (currencyRate is null)
            {
                throw new ArgumentNullException(nameof(currencyRate));
            }

            Rate = currencyRate;    
        }
    }
}
