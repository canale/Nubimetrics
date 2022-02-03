using AutoMapper;
using Microsoft.Extensions.Logging;
using Nubimetrics.DataAccess.Helpers;
using Nubimetrics.Domain.Contracts.Repositories;
using Nubimetrics.Domain.Entities;
using Nubimetrics.Domain.ValueObjects;
using Nubimetrics.Infrastructure.Contracts;
using Nubimetrics.Infrastructure.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nubimetrics.DataAccess.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private const string DOLAR_ID = "USD";

        private readonly ICurrencyService currencyService;
        private readonly ICurrencyConversionService currencyRateService;
        private readonly IMapper mapper;

        public CurrencyRepository(ICurrencyService currencyService, ICurrencyConversionService currencyRateService ,IMapper mapper)
        {
            this.currencyService = currencyService;
            this.currencyRateService = currencyRateService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Currency>> GetAllAsync()
        {
            IEnumerable<CurrencyDto> currencies = await currencyService.GetAllAsync();
            IEnumerable<Currency> result = mapper.Map<IEnumerable<Currency>>( currencies );

            CurrencyConversionDto rateDto;

            await result
            .ParallelForEachAsync(
                async currency =>
                {
                    try
                    {
                        rateDto = await currencyRateService.GetRate(currency.Id, DOLAR_ID);
                        currency.ChangeRate(mapper.Map<CurrencyRate>(rateDto));
                    }
                    catch (System.Exception ex)
                    {
                      //  logger.LogError(ex.Message, ex.StackTrace);
                     /*   if (ex.Message == )
                        {

                        }
                        throw ex;*/
                    }
                }
            );

          /*  foreach (Currency currency in result)
            {
                rateDto = await currencyRateService.GetRate(currency.Id, DOLAR_ID);
                currency.ChangeRate(mapper.Map<CurrencyRate>(rateDto));
            }*/
        
            return result; 
        }
    }
}
