using Microsoft.Extensions.Options;
using Nubimetrics.Infrastructure.Contracts;
using Nubimetrics.Infrastructure.Dtos;
using Nubimetrics.Infrastructure.Helpers;
using Nubimetrics.Infrastructure.Settings;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nubimetrics.Infrastructure.Services.Integrations
{

    public class CurrencyService : ICurrencyService
    {
        private readonly CurrencySettings settings;

        public CurrencyService(IOptions<CurrencySettings> settings)
        {
            this.settings = settings.Value;
        }

        public async Task<IEnumerable<CurrencyDto>> GetAllAsync()
        {
            IEnumerable<CurrencyDto> result = default;
            var client = new RestClient(settings.UriService);
            var request = new RestRequest($"{settings.Resource}", Method.Get);
            RestResponse<IEnumerable<CurrencyDto>> response = await client.ExecuteAsync<IEnumerable<CurrencyDto>>(request);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new UpperCaseNamingPolicy(),
            };

            response
                .OnSucces((response) => result = JsonSerializer.Deserialize<IEnumerable<CurrencyDto>>(response.Content, options))
                .OnError((response) =>
                {
                    if (response.StatusCode != HttpStatusCode.NotFound)
                    {
                        throw new Exception($"An Error ocurred when attempting to get data from {this.GetType()}. {response.ErrorMessage }");
                    }
                });


            return result;
        }
    }

}
