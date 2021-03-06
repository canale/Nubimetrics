using Nubimetrics.Infrastructure.Dtos;
using System.Threading.Tasks;

namespace Nubimetrics.Infrastructure.Contracts
{
    public interface IClassifiedLocationService
    {
        Task<ClassifiedLocationDto> GetCountryByIdAsync(string id);
    }
}
