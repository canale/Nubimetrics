using Nubimetrics.Shared.Models;
using System.Threading.Tasks;

namespace Nubimetrics.Infrastructure.Contracts
{
    public interface ISearchService
    {
        Task<Search> GetFilteredAsync(string term);
    }
}
