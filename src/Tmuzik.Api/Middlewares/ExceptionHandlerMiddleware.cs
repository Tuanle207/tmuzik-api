using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Tmuzik.Infrastructure.Models;

namespace Tmuzik.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try 
            {
                await _next.Invoke(context);
            }
            catch (CoreException exception)
            {
                var response = new {
                    message = exception.Message
                };
                context.Response.StatusCode = exception.StatusCode;
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception)
            {
                var exception = ExceptionBuilder.Exception(CoreExceptions.InternalError);
                var response = new {
                    message = exception.Message
                };
                context.Response.StatusCode = exception.StatusCode;
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }

    public static class ExceptionHandlerMiddlewareExtesions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}