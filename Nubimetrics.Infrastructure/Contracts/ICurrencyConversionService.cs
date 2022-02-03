using Nubimetrics.Infrastructure.Dtos;
using System.Threading.Tasks;

namespace Nubimetrics.Infrastructure.Contracts
{
    public interface ICurrencyConversionService
    {
        Task<CurrencyConversionDto> GetRate(string from, string to);
    }
}
