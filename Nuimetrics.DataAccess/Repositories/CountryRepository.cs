using AutoMapper;
using Nubimetrics.Domain.Contracts.Repositories;
using Nubimetrics.Domain.Entities;
using Nubimetrics.Infrastructure.Contracts;
using Nubimetrics.Infrastructure.Dtos;
using System.Threading.Tasks;

namespace Nubimetrics.DataAccess.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IClassifiedLocationService locationService;
        private readonly IMapper mapper;

        public CountryRepository(IClassifiedLocationService locationService, IMapper mapper)
        {
            this.locationService = locationService;
            this.mapper = mapper;
        }

        public async Task<Country> GetByIdAsync(string id)
        {
            ClassifiedLocation Location = await locationService.GetCountryByIdAsync(id);
            return (Location == null) ? null : mapper.Map<Country>(Location);
        }
    }
}
