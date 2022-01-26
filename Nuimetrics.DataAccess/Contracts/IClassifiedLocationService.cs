using Nubimetrics.DataAccess.Records;
using System.Threading.Tasks;

namespace Nubimetrics.DataAccess.Contracts
{
    public interface IClassifiedLocationService
    {
        Task<ClassifiedLocation> GetCountryByIdAsync(string id);
    }
}
