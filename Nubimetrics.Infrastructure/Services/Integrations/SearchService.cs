using Microsoft.Extensions.Options;
using Nubimetrics.Infrastructure.Contracts;
using Nubimetrics.Infrastructure.Dtos;
using Nubimetrics.Infrastructure.Settings;
using System.Threading.Tasks;

namespace Nubimetrics.Infrastructure.Services.Integrations
{
    public class SearchService : BaseIntegrationService, ISearchService
    {

        public SearchService(IOptions<SearchSettings> settings):base(settings.Value)
        {
        }

        public async Task<SearchDto> GetFilteredAsync(string term)
        {
            return await RequestDataByParam<SearchDto>($"q={term}");
        }
    }
}
