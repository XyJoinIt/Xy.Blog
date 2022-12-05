namespace Xy.Project.Core.Models
{
    /// <summary>
    /// 统一返回
    /// </summary>
    public interface IResult
    {
        string? Message { get; set; }
        bool Succeeded { get; }
        int Code { get; set; }
    }
    public interface IResult<out T> : IResult
    {

        T? Result { get; }
    }
}
