using Nubimetrics.Infrastructure.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nubimetrics.Infrastructure.Contracts
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrencyDto>> GetAllAsync();
    }
}
