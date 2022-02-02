using AutoMapper;
using Nubimetrics.Application.Contracts;
using Nubimetrics.Application.Dtos.Responses;
using Nubimetrics.Domain.Contracts.Repositories;
using Nubimetrics.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nubimetrics.Application.Services
{
    public  class MonedaApplicationService: IMonedaApplicationService
    {
        private readonly IMapper mapper;
        private readonly IMonedaRepository monedaRepository;

        public MonedaApplicationService(IMapper mapper, IMonedaRepository monedaRepository)
        {
            this.mapper = mapper;
            this.monedaRepository = monedaRepository;
        }

        public async Task<IEnumerable<MonedaItemResponse>> GetAllAsync()
        {
            IEnumerable<Moneda> monedas = await monedaRepository.GetAllAsync();
            IEnumerable<MonedaItemResponse> response = mapper.Map<IEnumerable<MonedaItemResponse>>(monedas);
            return response;
        }
    }
}
