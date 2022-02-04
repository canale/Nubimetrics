using Microsoft.Extensions.Options;
using Nubimetrics.Infrastructure.Contracts;
using Nubimetrics.Infrastructure.Settings;
using Nubimetrics.Shared.Models;
using System.Threading.Tasks;

namespace Nubimetrics.Infrastructure.Services.Integrations
{
    public class SearchService : BaseIntegrationService, ISearchService
    {

        public SearchService(IOptions<SearchSettings> settings):base(settings.Value)
        {
        }

        public async Task<Search> GetFilteredAsync(string term)
        {
            return await RequestDataByParam<Search>($"q={term}");
        }
    }
}
