using System.Collections.Generic;

namespace Nubimetrics.Domain.Entities
{
    public class Value: Entity<string>
    {
        public string Name { get; set; }
        public IEnumerable<KeyValue> PathFromRoot { get; set; }

        public Value():base(null)
        {

        }
    }
}
