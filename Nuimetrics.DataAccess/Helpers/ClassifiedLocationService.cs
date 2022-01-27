using Microsoft.Extensions.Options;
using Nubimetrics.DataAccess.Contracts;
using Nubimetrics.DataAccess.Exceptions;
using Nubimetrics.DataAccess.Records;
using Nubimetrics.DataAccess.Settings;
using RestSharp;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nubimetrics.DataAccess.Helpers
{
    public class ClassifiedLocationService : IClassifiedLocationService
    {
        private readonly ClassifiedLocationSettings settings;

        public ClassifiedLocationService(IOptions<ClassifiedLocationSettings> settings)
        {
            this.settings = settings.Value;
        }

        public async Task<ClassifiedLocation> GetCountryByIdAsync(string id)
        {
            ClassifiedLocation result = default;
            var client = new RestClient(settings.UriService);
            var request = new RestRequest($"{settings.CountryResource}/{id}", Method.Get);
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
