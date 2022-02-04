using Nubimetrics.Application.Dtos.Responses;
using System.Threading.Tasks;

namespace Nubimetrics.Application.Contracts
{
    public interface ISearchApplicationService
    {
        Task<SearchResponse> GetFilteredAsync(string term);
    }
}
