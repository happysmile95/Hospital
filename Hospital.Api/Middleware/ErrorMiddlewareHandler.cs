using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public class ErrorMiddlewareHandler
    {
        private readonly NLog.ILogger _logger = LogManager.GetCurrentClassLogger();
        private readonly RequestDelegate _next;
        public ErrorMiddlewareHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex);
                await HandleExceptionAsync(context);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new { error = "Unexpected internal server error." });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
