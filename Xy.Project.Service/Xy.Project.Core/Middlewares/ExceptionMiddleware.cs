using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
namespace Xy.Project.Core.Middlewares
{
    /// <summary>
    /// 全局异常中间件
    /// </summary>
    internal class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                if (exception.InnerException != null)
                {
                    while (exception.InnerException != null)
                    {
                        exception = exception.InnerException;
                    }
                }
                _logger.LogError(exception.Message);
            }
        }
    }
}
