using RestSharp;
using System;

namespace Nubimetrics.DataAccess.Helpers
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
    }
}
