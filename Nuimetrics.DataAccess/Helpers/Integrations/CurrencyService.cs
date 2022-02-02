using Microsoft.Extensions.Options;
using Nubimetrics.DataAccess.Contracts;
using Nubimetrics.DataAccess.Exceptions;
using Nubimetrics.DataAccess.Records;
using Nubimetrics.DataAccess.Settings;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nubimetrics.DataAccess.Helpers
{

    public class CurrencyService : ICurrencyService
    {
        private readonly ApiIntegrationSettings settings;

        public CurrencyService(IOptions<ApiIntegrationSettings> settings)
        {
            this.settings = settings.Value;
        }

        public async Task<IEnumerable<Currency>> GetAll()
        {
            IEnumerable<Currency> result = default;
            var client = new RestClient(settings.UriService);
            var request = new RestRequest($"{settings.Resource}", Method.Get);
            RestResponse<IEnumerable<Currency>> response = await client.ExecuteAsync<IEnumerable<Currency>>(request);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new UpperCaseNamingPolicy(),
            };

            response
                .OnSucces((response) => result = JsonSerializer.Deserialize<IEnumerable<Currency>>(response.Content, options))
                .OnError((response) =>
                {
                    if (response.StatusCode != HttpStatusCode.NotFound)
                    {
                        throw new IntegrationServiceException($"An Error ocurred when attempting to get data from {this.GetType()}. {response.ErrorMessage }");
                    }
                });


            return result;
        }

        public async Task<ClassifiedLocation> GetCountryByIdAsync(string id)
        {
            ClassifiedLocation result = default;
            var client = new RestClient(settings.UriService);
            var request = new RestRequest($"{settings.Resource}/{id}", Method.Get);
            RestResponse< ClassifiedLocation> response = await client.ExecuteAsync<ClassifiedLocation>(request);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new UpperCaseNamingPolicy(),
            };

            response
                .OnSucces((response) => result = JsonSerializer.Deserialize<ClassifiedLocation>(response.Content, options))
                .OnError((response) =>
                {
                    if (response.StatusCode != HttpStatusCode.NotFound)
                    {
                        throw new IntegrationServiceException($"An Error ocurred when attempting to get data from ClassifiedLocationService. {response.ErrorMessage }");
                    }
                });
          

            return result;
        }
    }

}
