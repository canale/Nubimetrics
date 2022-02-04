using AutoMapper;
using Microsoft.Extensions.Logging;
using Nubimetrics.DataAccess.Helpers;
using Nubimetrics.Domain.Contracts.Repositories;
using Nubimetrics.Domain.Entities;
using Nubimetrics.Domain.ValueObjects;
using Nubimetrics.Infrastructure.Contracts;
using Nubimetrics.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            SearchDto dto = await searchService.GetFilteredAsync(term);
            Search result = mapper.Map<Search>(dto);
            return result;
        }
    }
}
