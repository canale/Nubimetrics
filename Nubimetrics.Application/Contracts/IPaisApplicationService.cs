using Nubimetrics.Application.Dtos.Responses;
using System.Threading.Tasks;

namespace Nubimetrics.Application.Contracts
{
    public interface IPaisApplicationService
    {
        Task<PaisResponse> GetByIdAsync(string id);
    }
}
