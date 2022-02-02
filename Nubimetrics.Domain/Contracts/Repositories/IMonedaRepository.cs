﻿using Nubimetrics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nubimetrics.Domain.Contracts.Repositories
{
    public interface IMonedaRepository
    {
        Task<IEnumerable<Moneda>> GetAllAsync();
    }
}
