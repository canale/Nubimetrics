using System.Collections.Generic;

namespace Nubimetrics.Domain.ValueObjects
{
    public class Location : ValueObject
    {
        public decimal Latitude { get;}
        public decimal Longitude { get;}

        public Location(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
        }
    }
}
