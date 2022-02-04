using System.Collections.Generic;

namespace Nubimetrics.Infrastructure.Dtos
{
    public class FilterItemDto
    {
        public string Id{ get; set; }
        public string Name{ get; set; }
        public string Type{ get; set; }
        public IEnumerable<ValueItemFilterDto> Values{ get; set; }
    }
}