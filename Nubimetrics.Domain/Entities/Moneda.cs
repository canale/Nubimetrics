using System;

namespace Nubimetrics.Domain.Entities
{
    public class Moneda : Entity<string>
    {
        public string Symbol { get; }
        public string Description  { get; }
        public int DecimalPlaces { get; }


        public Moneda(string id, string description, int decimalPlaces) : base(id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException($"'{nameof(id)}' cannot be null or empty.", nameof(id));
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException($"'{nameof(description)}' cannot be null or empty.", nameof(description));
            }

            Description = description;
            DecimalPlaces = decimalPlaces;
        }


    }
}
