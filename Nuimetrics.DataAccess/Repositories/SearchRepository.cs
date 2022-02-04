using AutoMapper;
using Nubimetrics.Domain.Contracts.Repositories;
using Nubimetrics.Infrastructure.Contracts;
using Nubimetrics.Shared.Models;
using System.Threading.Tasks;

namespace Nubimetrics.DataAccess.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly ISearchService searchService;
        private readonly IMapper mapper;

        public SearchRepository(ISearchService searchService, IMapper mapper)
        {
            this.searchService = searchService;
            this.mapper = mapper;
        }

        public async Task<Search> GetFilteredAsync(string term)
        {
            Search dto = await searchService.GetFilteredAsync(term);
            return dto;
        }
    }
}
