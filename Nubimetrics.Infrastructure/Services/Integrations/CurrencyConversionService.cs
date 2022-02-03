using Microsoft.Extensions.Options;
using Nubimetrics.Infrastructure.Contracts;
using Nubimetrics.Infrastructure.Dtos;
using Nubimetrics.Infrastructure.Helpers;
using Nubimetrics.Infrastructure.Settings;
using RestSharp;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nubimetrics.Infrastructure.Services.Integrations
{
    public class CurrencyConversionService : ICurrencyConversionService
    {
        private readonly CurrencyConversionSettings settings;

        public CurrencyConversionService(IOptions<CurrencyConversionSettings> settings)
        {
            this.settings = settings.Value;
        }

        public async Task<CurrencyConversionDto> GetRate(string from, string to)
        {

            CurrencyConversionDto result = default;
            var client = new RestClient(settings.UriService);
            var request = new RestRequest($"{settings.Resource}?from={from}&to={to}", Method.Get);
            RestResponse<CurrencyConversionDto> response = await client.ExecuteAsync<CurrencyConversionDto>(request);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new UpperCaseNamingPolicy(),
            };

            response
                .OnSucces(response => result = JsonSerializer.Deserialize<CurrencyConversionDto>(response.Content, options))
                .OnError(response =>
                {
                    if (response.StatusCode != HttpStatusCode.NotFound)
                    {
                        throw new Exception($"An Error ocurred when attempting to get data from ClassifiedLocationService. {response.ErrorMessage }");
                    }
                })
                .OnException(response => 
                throw new Exception($"An Exception ocurred when attempting to get data from ClassifiedLocationService. {response.ErrorMessage }", response.ErrorException));

            return result;
        }
    }
}
