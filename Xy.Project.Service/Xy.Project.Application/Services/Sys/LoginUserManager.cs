using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Sys
{
    public class LoginUserManager : ILoginUserManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginUserManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 用户id
        /// </summary>
        public long Id => long.Parse(_httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value);

        /// <summary>
        /// 账户
        /// </summary>
        public string Account => _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value!;

        /// <summary>
        /// 昵称
        /// </summary>
        public string Name => _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Name)?.Value!;
      
    }
}
