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
        public string DecimalSeparator { get; }
        public string ThousandSeparator { get; }
        public string ThousandsSeparator { get; }
        public string TimeZone { get;  }
        public GeoInformation GeoInformation { get; }
        public IEnumerable<State> States { get; }


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

        public Pais(string id, string name, string locale, string currencyId, string decimalSeparator, string thousandSeparator, GeoInformation geoInformation, IEnumerable<State> states)
            : this(id, name, locale, currencyId)
        {
            if (string.IsNullOrEmpty(decimalSeparator))
            {
                throw new ArgumentException($"'{nameof(decimalSeparator)}' can't be null nor empty.", nameof(decimalSeparator));
            }

            if (string.IsNullOrEmpty(thousandSeparator))
            {
                throw new ArgumentException($"'{nameof(thousandSeparator)}' can't be null nor empty.", nameof(thousandSeparator));
            }

            if (geoInformation is null)
            {
                throw new ArgumentNullException(nameof(geoInformation));
            }

            if (states is null)
            {
                throw new ArgumentNullException(nameof(states));
            }

            DecimalSeparator = decimalSeparator;
            ThousandSeparator = thousandSeparator;
            GeoInformation = geoInformation;
            States = states;
        }
    }
}
