using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Xy.Project.Core.Filter
{
    /// <summary>
    /// 自定义异常处理
    /// </summary>
    public class XyExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger _logger;

        /// <summary>
        /// 自定义异常处理
        /// </summary>
        /// <param name="logger"></param>
        public XyExceptionFilter(ILogger<XyExceptionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>

        public Task OnExceptionAsync(ExceptionContext context)
        {
            var type = context.Exception.GetType();
            if(type.Name == nameof(XyExceptionFilter))
            {
                if(context.ExceptionHandled == false)
                {
                    context.HttpContext.Response.StatusCode = 403;
                    context.HttpContext.Response.ContentType = "text/html; charset=UTF-8";
                    if (!string.IsNullOrEmpty(context.Exception.Message))
                    {
                        context.HttpContext.Response.Body.Write(Encoding.UTF8.GetBytes(context.Exception.Data.ToJson()));
                    }
                }
                context.ExceptionHandled= true;
            }
            else if(context.Exception is BadHttpRequestException && context.Exception.Message == "Unexpected end of request content.")
            {
                // https://github.com/dotnet/aspnetcore/issues/23949
                // 此问题将在.net8解决
                context.ExceptionHandled = true;
            }
            
            return Task.CompletedTask;
        }
    }
}
