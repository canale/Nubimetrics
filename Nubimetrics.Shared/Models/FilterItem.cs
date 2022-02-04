using System.Collections.Generic;

namespace Nubimetrics.Shared.Models { 

    public class FilterItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IEnumerable<ValueItemFilter> Values { get; set; }

    }
}
