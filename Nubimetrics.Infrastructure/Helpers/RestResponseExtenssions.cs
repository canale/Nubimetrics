using RestSharp;
using System;
using System.Net;
namespace Nubimetrics.Infrastructure.Helpers
{
    public static class RestResponseExtenssions
    {
        public static RestResponse<TData>OnSucces<TData>(this RestResponse<TData> response, Action<RestResponse<TData>> callback)
        {
            if (response.IsSuccessful)
            {
                callback(response);
            }
            return response;
        }

        public static RestResponse<TData> OnException<TData>(this RestResponse<TData> response, Action<RestResponse<TData>> callback)
        {
            if (response.ErrorException != null)
            {
                callback(response);
            }
            return response;
        }

        public static RestResponse<TData> OnError<TData>(this RestResponse<TData> response, Action<RestResponse<TData>> callback)
        {
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                callback(response);
            }
            return response;
        }

        public static RestResponse<TData> When<TData>(this RestResponse<TData> response, Func<bool> predicate, Action<RestResponse<TData>> callback)
        {
            if (predicate())
            {
                callback(response);
            }
            return response;
        }

        public static RestResponse<TData> OnStatusCode<TData>(this RestResponse<TData> response, HttpStatusCode statusCode, Action<RestResponse<TData>> callback)
        {
            if (response.StatusCode == statusCode)
            {
                callback(response);
            }
            return response;
        }
    }
}
