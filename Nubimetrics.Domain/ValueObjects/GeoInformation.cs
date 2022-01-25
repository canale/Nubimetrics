using System;
using System.Collections.Generic;

namespace Nubimetrics.Domain.ValueObjects
{
    public class GeoInformation : ValueObject
    {
        public Location Location { get; }

        public GeoInformation(Location location)
        {
            if (location is null)
            {
                throw new ArgumentNullException(nameof(location));
            }
            Location = location;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Location;
        }
    }
}
