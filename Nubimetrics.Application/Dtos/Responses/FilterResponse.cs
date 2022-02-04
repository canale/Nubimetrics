using System.Collections.Generic;

namespace Nubimetrics.Application.Dtos.Responses
{
    public class FilterResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IEnumerable<ValueResponse> Values { get; set; }
    }
}
