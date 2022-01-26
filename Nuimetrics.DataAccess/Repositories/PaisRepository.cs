using AutoMapper;
using Nubimetrics.DataAccess.Contracts;
using Nubimetrics.DataAccess.Records;
using Nubimetrics.Domain.Contracts.Repositories;
using Nubimetrics.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Nubimetrics.DataAccess.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly IClassifiedLocationService _locationService;
        private readonly IMapper _mapper;

        public PaisRepository(IClassifiedLocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        public async Task<Pais> GetByIdAsync(string id)
        {
            ClassifiedLocation Location = await _locationService.GetCountryByIdAsync(id);
            return (Location == null) ? null : _mapper.Map<Pais>(Location);
        }
    }
}
