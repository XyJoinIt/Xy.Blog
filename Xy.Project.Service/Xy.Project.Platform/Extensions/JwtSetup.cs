using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Application.Services.Sys;
using Xy.Project.Core.GlobalConfigEntity;

namespace Xy.Project.Platform.Extensions
{
    /// <summary>
    /// jwt注入
    /// </summary>
    public static class JwtSetup
    {
        public static void AddJwtSetup(this IServiceCollection services)
        {
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true, //是否验证Issuer
                    ValidateAudience = true, //是否验证Audience
                    ValidateIssuerSigningKey = true, //是否验证SecurityKey
                    ValidateLifetime = true, //是否验证失效时间
                    ValidIssuer = XyGlobalConfig.JwtOption!.Issuer, //发行人Issuer
                    ValidAudience = XyGlobalConfig.JwtOption!.Audience, //订阅人Audience
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(XyGlobalConfig.JwtOption!.SecretKey)), //SecurityKey
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddScoped<ILoginUserManager, LoginUserManager>();
        }
    }
}
