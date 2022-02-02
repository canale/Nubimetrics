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
    public class PaisApplicationService : IPaisApplicationService
    {
        private readonly IPaisRepository _repository;
        private readonly IMapper _mapper;
        private static readonly string[] _unauthorizedPaisIds = { "BR", "CO" };


        public PaisApplicationService(IPaisRepository repository, IMapper mapper)
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

            Pais pais = await _repository.GetByIdAsync(id) ?? throw new NotFoundException($"Couln't find the resource with id: {id}.");
            PaisResponse paisDto = _mapper.Map<PaisResponse>(pais);

            return paisDto;
        }
    }
}
