using System.Collections.Generic;

namespace Nubimetrics.Infrastructure.Dtos
{
    public class ValueDto
        {
            public string Id{ get; set; }
            public string Name{ get; set; }
            public IEnumerable<KeyValueDto> PathFromRoot{ get; set; }
    }
}