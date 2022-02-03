using AutoMapper;
using Nubimetrics.Application.Contracts;
using Nubimetrics.Application.Dtos.Responses;
using Nubimetrics.Domain.Contracts.Repositories;
using Nubimetrics.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nubimetrics.Application.Services
{
    public  class CurrencyApplicationService: ICurrencyApplicationService
    {
        private readonly IMapper mapper;
        private readonly ICurrencyRepository monedaRepository;

        public CurrencyApplicationService(IMapper mapper, ICurrencyRepository monedaRepository)
        {
            this.mapper = mapper;
            this.monedaRepository = monedaRepository;
        }

        public async Task<IEnumerable<CurrencyItemResponse>> GetAllAsync()
        {
            IEnumerable<Currency> monedas = await monedaRepository.GetAllAsync();
            IEnumerable<CurrencyItemResponse> response = mapper.Map<IEnumerable<CurrencyItemResponse>>(monedas);
            return response;
        }
    }
}
