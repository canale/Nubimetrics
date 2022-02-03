using AutoMapper;
using Nubimetrics.Application.Contracts;
using Nubimetrics.Application.Dtos.Responses;
using Nubimetrics.Domain.Contracts.Repositories;
using Nubimetrics.Domain.Entities;
using Nubimetrics.Domain.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nubimetrics.Application.Services
{
    public class CountryApplicationService : ICountryApplicationService
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;
        private static readonly string[] _unauthorizedPaisIds = { "BR", "CO" };


        public CountryApplicationService(ICountryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaisResponse> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException($"'{nameof(id)}' can´t be null or empty.", nameof(id));
            }

            if(_unauthorizedPaisIds.Any(unauthorized => unauthorized == id) )
            {
                throw new UnauthorizedException("Unauthorized request.");
            }

            Country country = await _repository.GetByIdAsync(id) ?? throw new NotFoundException($"Couln't find the resource with id: {id}.");
            PaisResponse countryDto = _mapper.Map<PaisResponse>(country);

            return countryDto;
        }
    }
}
