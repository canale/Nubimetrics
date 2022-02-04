using AutoMapper;
using Nubimetrics.Application.Contracts;
using Nubimetrics.Domain.Contracts.Repositories;
using Nubimetrics.Shared.Models;
using System.Threading.Tasks;

namespace Nubimetrics.Application.Services
{
    public class SearchApplicationService : ISearchApplicationService
    {
        private readonly ISearchRepository searchRepository;
        private readonly IMapper mapper;

        public SearchApplicationService(ISearchRepository searchRepository, IMapper mapper)
        {
            this.searchRepository = searchRepository;
            this.mapper = mapper;
        }

        public async Task<Search> GetFilteredAsync(string term)
        {
            Search searchResult = await searchRepository.GetFilteredAsync(term);
            return searchResult;
        }
    }
}
