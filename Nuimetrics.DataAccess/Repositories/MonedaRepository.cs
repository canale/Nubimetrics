using Nubimetrics.Domain.Contracts.Repositories;
using Nubimetrics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nubimetrics.DataAccess.Repositories
{
    public class MonedaRepository : IMonedaRepository
    {
        public Task<IEnumerable<Moneda>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
