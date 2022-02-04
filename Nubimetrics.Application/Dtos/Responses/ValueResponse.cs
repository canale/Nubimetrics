using System.Collections.Generic;

namespace Nubimetrics.Application.Dtos.Responses
{
    public class ValueResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<KeyValueResponse> PathFromRoot { get; set; }

    }
}
