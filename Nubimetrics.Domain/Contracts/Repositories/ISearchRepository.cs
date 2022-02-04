using Nubimetrics.Domain.ValueObjects;
using System.Threading.Tasks;

namespace Nubimetrics.Domain.Contracts.Repositories
{
    public interface ISearchRepository
    {
        Task<Search> GetFilteredAsync(string term);
    }
}