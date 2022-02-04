using System.Collections.Generic;

namespace Nubimetrics.Application.Dtos.Responses
{
    public class FilterItemResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IEnumerable<ValueItemFilterResponse> Values { get; set; }
    }
}
