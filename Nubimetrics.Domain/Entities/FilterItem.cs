using System.Collections.Generic;

namespace Nubimetrics.Domain.Entities
{
    public class FilterItem:Entity<string>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public IEnumerable<ValueItemFilter> Values { get; set; }

        public FilterItem():base(null)
        {

        }
    }
}
