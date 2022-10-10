
namespace Xy.Project.Core.Extensions;

/// <summary>
/// 验证扩展
/// </summary>
public static class VerificationExtensions
{
    /// <summary>
    /// 是否为空
    /// </summary>
    /// <param name="_this"></param>
    /// <returns></returns>
    public static bool IsEmpty(this object? _this)
    {
        if (_this == null) return true;
        return string.IsNullOrWhiteSpace(_this.ToString());
    }


    /// <summary>
    /// 判断数组是否为空
    /// </summary>
    /// <param name="_this"></param>
    /// <returns></returns>
    public static bool IsArrarEmpty(this object[]? _this)
    {
        if (_this == null) return true;
        return _this.Length == 0;
    }
}
