﻿using Nubimetrics.Application.Dtos.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nubimetrics.Application.Contracts
{
    public interface IMonedaApplicationService
    {
        Task<IEnumerable<MonedaItemResponse>> GetAllAsync();
    }
}
