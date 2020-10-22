using System;
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (UnAuthorizedExceptions unAuthorizedException)
            {
                _logger.LogError($"UnAuthorized exception occured!");
                httpContext.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                await HandleExceptionAsync(httpContext, unAuthorizedException);
            }
            catch (InValidInputException inValidInputException)
            {
                _logger.LogError($"An user input related exception occured");
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await HandleExceptionAsync(httpContext, inValidInputException);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }

        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
           
            return context.Response.WriteAsync(new ErrorDetails
            {
                ErrorMessage = exception.Message
            }.ToString());
        }
    }
}
