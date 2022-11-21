using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using Xy.Project.Application.Dtos.Identitys;
using Xy.Project.Application.Services.Contracts.Identity;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.DataBase.GlobalConfigEntity;

namespace Xy.Project.Application.Services.Identity
{
    /// <summary>
    /// 
    /// </summary>
    public class IdentityService : IdentityContaract
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtOption _jwtOption;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="jwtOption"></param>
        /// <param name="signInManager"></param>
        /// <param name="httpContextAccessor"></param>
        public IdentityService(UserManager<User> userManager, IOptions<JwtOption> jwtOption, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _signInManager = signInManager;
            _jwtOption = jwtOption.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AppResult> LoginAsync(LoginDto dto)
        {
            dto.NotNull(nameof(dto));
            var user = await _userManager.FindByNameAsync(dto.UserName).ConfigureAwait(false);
            if (user == null)
            {
                return AppResult.Error("用户不存在");
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, true).ConfigureAwait(false);
            if (!signInResult.Succeeded)
            {
                //锁定
                if (signInResult.IsLockedOut)
                {
                    return AppResult.Error($"用户因密码错误次数过多而被锁定 {_userManager.Options.Lockout.DefaultLockoutTimeSpan.TotalMinutes} 分钟，请稍后重试");
                }
                if (signInResult.IsNotAllowed)
                {
                    return AppResult.Error("不允许登录");
                }
                return AppResult.Error("登录失败，用户名或账号无效。");
            }


            var issuer = _jwtOption.Issuer;
            var audience = _jwtOption.Audience;
            // 1. 定义需要使用到的Claims
            var claims = new List<Claim>() {
             new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
             new Claim(ClaimTypes.Name,user.UserName),
             new Claim(ClaimTypes.GivenName,user.NickName)
            };
            // 2. 从 appsettings.json 中读取SecretKey
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.SecretKey));
            // 3. 选择加密算法
            var algorithm = SecurityAlgorithms.HmacSha256;
            // 4. 生成Credentials
            var signingCredentials = new SigningCredentials(secretKey, algorithm);
            var now = DateTime.Now;
            var tokenHandler = new JwtSecurityTokenHandler();
            // 5. 根据以上，生成token
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Audience = issuer,
                Issuer = audience,
                SigningCredentials = signingCredentials,
                NotBefore = now,
                IssuedAt = now,
                Expires = now.AddDays(365)
            };
            var token = tokenHandler.CreateToken(descriptor);
            string accessToken = tokenHandler.WriteToken(token);

            // 设置响应报文头
            _httpContextAccessor.HttpContext.Response.Headers["access-token"] = accessToken;
            //if (!string.IsNullOrWhiteSpace(refreshToken))
            //{
            //    httpContext.Response.Headers["x-access-token"] = refreshToken;
            //}
            return AppResult.Problem(HttpCode.成功, "登录成功", new
            {
                token = accessToken,
                user.NickName,
                user.UserName,
                UserId = user.Id,
                Type = "Bearer"
            });
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public async Task<AppResult> LoginOut()
        {
            return await Task.FromResult(AppResult.Success());
        }
    }
}
