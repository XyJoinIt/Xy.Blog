using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Xy.Project.Application.Services.Contracts.Sys;

namespace Xy.Project.Application.Services.Sys;

/// <summary>
/// 用户上下文
/// </summary>
public class UserLogin : IUserLogin
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    public UserLogin(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Id
    /// </summary>
    public long Id => long.Parse(_httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

    /// <summary>
    /// 账户
    /// </summary>
    public string UserName => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value!;

    /// <summary>
    /// 昵称
    /// </summary>
    public string NickName => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.GivenName)?.Value!;
}
