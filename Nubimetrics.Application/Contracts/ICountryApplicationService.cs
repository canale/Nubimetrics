using Nubimetrics.Application.Dtos.Responses;
using System.Threading.Tasks;

namespace Nubimetrics.Application.Contracts
{
    public interface ICountryApplicationService
    {
        Task<CountryResponse> GetByIdAsync(string id);
    }
}
