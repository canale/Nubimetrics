using Nubimetrics.Infrastructure.Dtos;
using System.Threading.Tasks;

namespace Nubimetrics.Infrastructure.Contracts
{
    public interface IClassifiedLocationService
    {
        Task<ClassifiedLocation> GetCountryByIdAsync(string id);
    }
}
