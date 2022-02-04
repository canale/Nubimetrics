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
    public class ClassifiedLocationService : IClassifiedLocationService
    {
        private readonly ClassifiedLocationSettings settings;

        public ClassifiedLocationService(IOptions<ClassifiedLocationSettings> settings)
        {
            this.settings = settings.Value;
        }

        public async Task<ClassifiedLocationDto> GetCountryByIdAsync(string id)
        {
            ClassifiedLocationDto result = default;
            var client = new RestClient(settings.UriService);
            var request = new RestRequest($"{settings.Resource}/{id}", Method.Get);
            RestResponse< ClassifiedLocationDto> response = await client.ExecuteAsync<ClassifiedLocationDto>(request);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new CamelCaseNamingPolicy(),
            };

            response
                .OnSucces((response) => result = JsonSerializer.Deserialize<ClassifiedLocationDto>(response.Content, options))
                .OnError((response) =>
                {
                    if (response.StatusCode != HttpStatusCode.NotFound)
                    {
                        throw new Exception($"An Error ocurred when attempting to get data from ClassifiedLocationService. {response.ErrorMessage }");
                    }
                });
          

            return result;
        }
    }

}
