using Xy.Project.Core.Dependency;

namespace Xy.Project.Application.Services.Contracts.Sys;

/// <summary>
/// 用户上下文
/// </summary>
public interface IUserLogin: IScopedDependency
{
    /// <summary>
    /// 用户Id
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; }

    /// <summary>
    /// 昵称
    /// </summary>
    public string NickName { get; }
}
