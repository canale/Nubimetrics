using Nubimetrics.Infrastructure.Helpers;
using Nubimetrics.Infrastructure.Settings;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nubimetrics.Infrastructure.Services.Integrations
{
    public abstract class BaseIntegrationService
    {
        protected readonly ApiIntegrationSettings settings;

        public BaseIntegrationService(ApiIntegrationSettings settings)
        {
            this.settings = settings;
        }

        protected async Task<TResult> RequestData<TResult>()
        {
            TResult result = default;
            RestResponse<TResult> response = await RequestAsync<TResult>($"{settings.Resource}");
            JsonSerializerOptions options = GetSerializationOptionsForTitleCase();

            response
                .OnSucces((response) => result = JsonSerializer.Deserialize<TResult>(response.Content, options))
                .OnError((response) =>
                {
                    if (response.StatusCode != HttpStatusCode.NotFound)
                    {
                        throw new Exception($"An Error ocurred when attempting to get data from ClassifiedLocationService. {response.ErrorMessage }");
                    }
                });

            return result;
        }

        protected async Task<TResult> RequestData<TResult>(object value)
        {
            TResult result = default;
            RestResponse<TResult> response = await RequestAsync<TResult>($"{settings.Resource}/{value}");
            JsonSerializerOptions options = GetSerializationOptionsForTitleCase();

            response
                .OnSucces((response) => result = JsonSerializer.Deserialize<TResult>(response.Content, options))
                .OnError((response) =>
                {
                    if (response.StatusCode != HttpStatusCode.NotFound)
                    {
                        throw new Exception($"An Error ocurred when attempting to get data from ClassifiedLocationService. {response.ErrorMessage }");
                    }
                });

            return result;
        }


        protected async Task<TResult> RequestDataByParam<TResult>(string value)
        {
            TResult result = default;         
            RestResponse<TResult> response = await RequestAsync<TResult>($"{settings.Resource}?{value}");
            JsonSerializerOptions options = GetSerializationOptionsForTitleCase();

            response
                .OnSucces((response) => result = JsonSerializer.Deserialize<TResult>(response.Content, options))
                .OnError((response) =>
                {
                    if (response.StatusCode != HttpStatusCode.NotFound)
                    {
                        throw new Exception($"An Error ocurred when attempting to get data from ClassifiedLocationService. {response.ErrorMessage }");
                    }
                });

            return result;
        }

        private async Task<RestResponse<TResult>> RequestAsync<TResult>(string resource)
        {
            var client = new RestClient(settings.UriService);
            var request = new RestRequest(resource, Method.Get);
            RestResponse<TResult> response = await client.ExecuteAsync<TResult>(request);
            return response;
        }

        protected JsonSerializerOptions GetSerializationOptionsForTitleCase()
            => new JsonSerializerOptions {  PropertyNamingPolicy = new CamelCaseNamingPolicy(),  WriteIndented = true };
    }
}
