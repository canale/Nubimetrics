using Nubimetrics.Application.Dtos;
using System.Threading.Tasks;

namespace Nubimetrics.Application.Contracts
{
    public interface IPaisApplicationService
    {
        Task<PaisDto> GetByIdAsync(string id);
    }
}
