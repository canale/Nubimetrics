using System.Collections.Generic;

namespace Nubimetrics.Shared.Models
{
    public class Filter 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IEnumerable<Value> Values { get; set; }

    }
}
