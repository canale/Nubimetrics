using System.Collections.Generic;

namespace Nubimetrics.Shared.Models
{
    public class Value
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<KeyValue> PathFromRoot { get; set; }

    }
}
