
using Nubimetrics.Shared.Models;
using System.Threading.Tasks;

namespace Nubimetrics.Application.Contracts
{
    public interface ISearchApplicationService
    {
        Task<Search> GetFilteredAsync(string term);
    }
}
