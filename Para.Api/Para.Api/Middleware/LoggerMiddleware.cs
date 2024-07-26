using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Para.Api.Middleware
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggerMiddleware> _logger;

        public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Gelen isteði logla
            _logger.LogInformation($"Incoming Request: {context.Request.Method} {context.Request.Path} {context.Request.QueryString}");

            var originalResponseBodyStream = context.Response.Body;

            // Response'u hafýzada tutmak için geçici bir MemoryStream oluþtur
            using (var temporaryResponseBodyStream = new MemoryStream())
            {
                context.Response.Body = temporaryResponseBodyStream;

                // Bir sonraki middleware'i çalýþtýr
                await _next(context);

                // Response'un baþýna dön ve tüm içeriði oku
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                string responseBodyContent = await new StreamReader(context.Response.Body).ReadToEndAsync();

                // Response'u logla
                _logger.LogInformation($"Outgoing Response: Status Code {context.Response.StatusCode}, Content Type {context.Response.ContentType}, Body {responseBodyContent}");

                // Response'un baþýna dön ve orijinal ResponseBodyStream'e yaz
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                await temporaryResponseBodyStream.CopyToAsync(originalResponseBodyStream);
            }
        }
    }
}
