using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.DataBase.GlobalConfigEntity;

namespace Xy.Project.Application.Services.Sys
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class SysUserService : ISysUserContract
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtOption _jwtOption;

        public SysUserService(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<JwtOption> jwtOption)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtOption = jwtOption.Value;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AppResult> AddAsync(AddUserInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var user = ObjectMap.MapTo<User>(dto);
            var result = dto.Password!.IsNullOrWhiteSpace()
                ? await _userManager.CreateAsync(user) : await _userManager.CreateAsync(user, dto.Password);
            return result.ToResultData("保存成功");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AppResult> DeleteAsync(long id)
        {
            var user = await _userManager.FindByIdAsync(id.AsTo<string>());
            var result = await _userManager.DeleteAsync(user);
            return result.ToResultData($"删除【{user.NickName}】成功");
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<AppResult> PageAsync(PageParam page)
        {
            page.NotNull(nameof(page));
            //排序
            page.AddOrderCondition(new OrderCondition<User>(o => o.Id, OrderDirection.Ascending));
            //条件过滤
            var exp = FilterBuilder.GetExpression<User>(page.FilterGroup);
            var list = await _userManager.Users.AsNoTracking()
                .Where(exp)
                .ToPageAsync<User, UserOutputPageListDto>(page.PageCondition);
            return AppResult.Problem(HttpCode.成功, "得到分页数据", list);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AppResult> UpdateAsync(UpdateUserInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var user = await _userManager.FindByIdAsync(dto.Id.ToString());
            user = ObjectMap.MapTo(dto, user);
            var result = await _userManager.UpdateAsync(user);
            return result.ToResultData("保存成功");
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<AppResult> Login(LoginDto dto)
        {
            ////Sm2私钥
            //string _privateKey = "";
            //string _publicKey = "";
            //#region 解密
            //Sm2CryptoHelper sm2 = new Sm2CryptoHelper(_publicKey, _privateKey);
            //param.UserName = sm2.Decrypt(param.UserName);
            //param.Password = sm2.Decrypt(param.Password);
            //param.Captcha = sm2.Decrypt(param.Captcha);
            //param.CaptchaId = sm2.Decrypt(param.CaptchaId);
            //#endregion

            ////验证码是否正确...

            ////删除验证码

            ////AES加密
            //string _AesKey = "";
            //param.Password = AesCryptoHelper.Encrypt(param.Password, _AesKey);
            ////验证用户信息
            //var user = await _userManager.FindByNameAsync(param.UserName);
            //if (user == null)
            //    return await AppResult.Error("用户不存在");
            //if (user.PasswordHash != param.Password)
            //    return await AppResult.Error("密码错误");

            ////生成token

            ////记录登录日志

            //return null;

            dto.NotNull(nameof(dto));
            var user = await _userManager.FindByNameAsync(dto.UserName);
            if (user == null)
            {
                return AppResult.Error("用户不存在");
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, true);
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
            var token = new JwtSecurityToken(
                issuer,     //Issuer
                audience,   //Audience
                claims,                          //Claims,
                DateTime.Now,                    //notBefore
                DateTime.Now.AddDays(365), //expires
                signingCredentials               //Credentials
            );


            //SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
            //{
            //    Subject = new ClaimsIdentity(claims),
            //    Audience = issuer,
            //    Issuer = audience,
            //    SigningCredentials = signingCredentials,
            //    NotBefore = now,
            //    IssuedAt = now,
            //    Expires = now.AddDays(365)
            //};

            //var token1 = tokenHandler.CreateToken(descriptor);
            string accessToken = tokenHandler.WriteToken(token);

            return AppResult.Problem(HttpCode.成功, "登录成功", new
            {

                AccessToken = accessToken,
                NickName = "admin",
                UserId = "1",

            });
        }
    }
}
