using Xy.Project.Core.GlobalConfigEntity;

namespace Xy.Project.Platform.Extensions
{
    /// <summary>
    /// 跨域配置
    /// </summary>
    public static class CorsSetup
    {
        public static void AddCorsSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddCors(options =>
            {
                if (!XyGlobalConfig.corsOption!.IsAll)
                {
                    var urls = XyGlobalConfig.corsOption.Url?.Split(";");
                    options.AddPolicy(XyGlobalConfig.corsOption.Name,builder =>
                            builder
                            .WithOrigins(urls)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
                }
                else
                {
                    //允许任意跨域请求
                    options.AddPolicy(XyGlobalConfig.corsOption.Name, policy =>
                    {
                        policy.SetIsOriginAllowed((host) => true)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
                }
            });
        }
    }
}
