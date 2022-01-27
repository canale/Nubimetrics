using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Nubimetrics.Domain.Exceptions;
using System;
using System.Net;
using System.Text.Json;

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
            _logger.LogError(context.Exception, context.Exception.Message, context.Exception.StackTrace);
            context.Result = GetContentResult(context.Exception);
        }


        #region PRIVATE METHODS

        private ContentResult GetContentResult(Exception exception)
        {
            int statusCode = (int)GetHttpStatusCode(exception);
            ErrorResponse errorResponse = GetErrorResponse(exception, statusCode);

            return new ContentResult
            {
                Content = JsonSerializer.Serialize(errorResponse),
                StatusCode = statusCode,
                ContentType = "application/json"
            };
        }

        private ErrorResponse GetErrorResponse(Exception exception, int statusCode)
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

            return new ErrorResponse { Message = message, Code = statusCode };
        }

        private HttpStatusCode GetHttpStatusCode(Exception exception)
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

        #endregion
    }
}
