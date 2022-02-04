using System.Collections.Generic;

namespace Nubimetrics.Domain.Entities
{
    public class Filter : Entity<string>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public IEnumerable<Value> Values { get; set; }

        public Filter() : base(null)
        {
        }
    }
}
