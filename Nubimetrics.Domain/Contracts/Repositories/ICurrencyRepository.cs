using Nubimetrics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nubimetrics.Domain.Contracts.Repositories
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetAllAsync();
    }
}
