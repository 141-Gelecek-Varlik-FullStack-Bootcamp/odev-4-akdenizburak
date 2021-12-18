using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MovieList.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MovieList.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            string message = "[Request] HTTP "+context.Request.Method+ " - "+context.Request.Path;
            _loggerService.Write(message);

            await _next(context);
            watch.Stop();

            message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " +watch.ElapsedMilliseconds+ "ms";
            _loggerService.Write(message);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
