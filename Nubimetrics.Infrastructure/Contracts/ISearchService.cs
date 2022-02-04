using Nubimetrics.Infrastructure.Dtos;
using System.Threading.Tasks;

namespace Nubimetrics.Infrastructure.Contracts
{
    public interface ISearchService
    {
        Task<SearchDto> GetFilteredAsync(string term);
    }
}
