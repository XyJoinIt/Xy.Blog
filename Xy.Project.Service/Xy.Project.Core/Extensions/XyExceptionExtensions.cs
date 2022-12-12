

namespace Xy.Project.Core.Extensions;

/// <summary>
/// 异常扩展 
/// </summary>
public class XyException : Exception
{
    /// <summary>
    /// 错误信息Dto
    /// </summary>
    public ErrorDto Error { get; set; }
    /// <summary>
    /// XyException
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="code"></param>
    public XyException(string msg, HttpCode code = HttpCode.失败) : base(msg)
    {
        Error = new ErrorDto(msg, code);
        base.Data.Add("error", Error);
    }
}

/// <summary>
/// 错误信息Dto
/// </summary>
public class ErrorDto
{
    /// <summary>
    /// ErrorDto
    /// </summary>
    /// <param name="message"></param>
    /// <param name="code"></param>
    public ErrorDto(string message, HttpCode code)
    {
        Code = code;
        Msg = message;
    }
    /// <summary>
    /// 错误代码
    /// </summary>
    [JsonProperty(PropertyName = "code")]
    public HttpCode Code { get; set; }
    /// <summary>
    /// 错误信息
    /// </summary>
    [JsonProperty(PropertyName = "msg")]
    public string Msg { get; set; }
}
