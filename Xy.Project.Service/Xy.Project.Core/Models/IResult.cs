namespace Xy.Project.Core.Models
{
    /// <summary>
    /// 统一返回
    /// </summary>
    public interface IResult
    {
        string? Msg { get; set; }
        bool Succeeded { get; }
        int Code { get; set; }
    }
    public interface IResult<out T> : IResult
    {

        T? Data { get; }
    }
}
