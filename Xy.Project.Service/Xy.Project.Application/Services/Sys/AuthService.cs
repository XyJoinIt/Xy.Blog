using FluentValidation;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using NETCore.Encrypt;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xy.Project.Application.Dtos.Sys.AuthManage;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core;
using Xy.Project.Core.GlobalConfigEntity;
using Xy.Project.Core.Helpers;
using Xy.Project.Platform.Model.Entities.Blogs;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Sys
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<SysUser, long> _repSysUser;
        private readonly IEncryptionService _encryption;
        private readonly IValidator<AddAuthDto> _addValidator;
        /// <summary>
        /// 构造函数
        /// </summary>
        public AuthService(IRepository<SysUser, long> repSysUser, IEncryptionService encryption, IValidator<AddAuthDto> addValidator)
        {
            _repSysUser = repSysUser;
            _encryption = encryption;
            _addValidator = addValidator;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AppResult> Login(AddAuthDto dto)
        {
            dto.NotNull(nameof(dto));

            var validationResult = await _addValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                return AppResult.Error(validationResult);


            var model = await _repSysUser.QueryAsNoTracking(x => x.Account.Equals(dto.Account)).FirstOrDefaultAsync();
            if (model == null)
                return await AppResult.ErrorAsync("用户不存在！");
            else
                if (!_encryption.CheckPasswordAsync(passwordHash: model.Password, securityStamp: model.SecurityStamp, password: dto.PassWord))
                return await AppResult.ErrorAsync("密码错误！");
            //创建claim
            var authClaim = new[]
            {
                new Claim(nameof(model.Id),model.Id.ToString()),
                new Claim(nameof(model.AdminType),model.AdminType.ToString()),
                new Claim(nameof(model.Name),model.Name),
                new Claim(nameof(model.Account),model.Account)
            };
            IdentityModelEventSource.ShowPII = true;
            //签名
            var ecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(XyGlobalConfig.JwtOption.SecretKey));
            var token = new JwtSecurityToken(
                issuer: XyGlobalConfig.JwtOption.Issuer,
                audience: XyGlobalConfig.JwtOption.Audience,
                expires: DateTime.Now.AddMinutes(XyGlobalConfig.JwtOption.Exp),
                claims: authClaim,
                signingCredentials: new SigningCredentials(ecurityKey, SecurityAlgorithms.HmacSha256)
                );

            return AppResult.Success(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public Task<AppResult> RefreshToken()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public async Task<AppResult> Logout()
        {
            return await AppResult.SuccessAsync();
        }
    }
}
