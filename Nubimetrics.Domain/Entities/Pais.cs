using Nubimetrics.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Nubimetrics.Domain.Entities
{
    public class Pais: Entity<string>
    {
        public string Id { get; }
        public string Name { get; }
        public string Locale { get; }
        public string CurrencyId { get; }


        public Pais(string id, string name, string locale, string currencyId):base(id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException($"'{nameof(id)}' can't be null nor empty.", nameof(id));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' can't be null nor empty.", nameof(name));
            }

            if (string.IsNullOrEmpty(locale))
            {
                throw new ArgumentException($"'{nameof(locale)}' can't be null nor empty.", nameof(locale));
            }

            if (string.IsNullOrEmpty(currencyId))
            {
                throw new ArgumentException($"'{nameof(currencyId)}' can't be null nor empty.", nameof(currencyId));
            }

            Name = name;
            Locale = locale;
            CurrencyId = currencyId;
        }
    }
}
