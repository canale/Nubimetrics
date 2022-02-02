using Nubimetrics.DataAccess.Records;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nubimetrics.DataAccess.Contracts
{
    public interface ICurrencyService
    {
        Task<IEnumerable<Currency>> GetAll();
    }
}
