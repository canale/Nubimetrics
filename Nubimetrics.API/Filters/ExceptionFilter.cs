using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Nubimetrics.Domain.Exceptions;
using System;
using System.Net;

namespace Nubimetrics.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            JsonErrorResponse json = GetErrorResponse(context.Exception);

            _logger.LogError(context.Exception, context.Exception.Message, context.Exception.StackTrace);

            context.Result = new ObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)GetHttpStatusCode(context.HttpContext, context.Exception);
        }

        private JsonErrorResponse GetErrorResponse(Exception exception)
        {
            string message = "";

            switch (exception)
            {
                case DomainException ae:
                    message = exception.Message;
                    break;
                case ArgumentException e:
                default:
                    message = "An error occurred. Try it again.";
                    break;
            }

            return new JsonErrorResponse { Message = message };
        }


        private HttpStatusCode GetHttpStatusCode(HttpContext httpContext, Exception exception)
        {
            HttpStatusCode statusCode;

            switch (exception)
            {
                case NotFoundException e:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case UnauthorizedException e:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                /*  case DataInvalidException die:
                      statusCode = HttpStatusCode.BadRequest;
                      break;*/
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            return statusCode;
        }
    }
}
