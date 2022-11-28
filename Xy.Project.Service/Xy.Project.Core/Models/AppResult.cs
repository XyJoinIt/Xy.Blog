using System.Text;

namespace Xy.Project.Core.Models
{
    [Serializable]
    public sealed class AppResult : IResult<object>
    {
        public AppResult()
        {

        }
        public string? Msg { get; set; }
        public bool Succeeded => Code == (int)HttpCode.成功;
        public int Code { get; set; }
        public object? Data { get; set; }
        public static AppResult Problem(HttpCode status, string? message = default, object? data = default)
        {
            return new AppResult() { Code = (int)status, Msg = message, Data = data };
        }

        public static async Task<AppResult> ProblemAsync(HttpCode status, string? message = default, object? data = default)
        {
            return await Task.FromResult(Problem(status, message, data));
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public static AppResult Error(string msg = "操作失败")
        {
            return Problem(HttpCode.失败, msg);
        }

        public static AppResult Error(FluentValidation.Results.ValidationResult validationResult)
        {
            var errorBuilder = new StringBuilder();
            validationResult.Errors.ForEach(o => errorBuilder.AppendLine(o.ErrorMessage));
            return AppResult.Error(errorBuilder.ToString());

        }
        public static Task<AppResult> ErrorAsync(string msg = "操作失败")
        {
            return ProblemAsync(HttpCode.失败, msg);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public static Task<AppResult> SuccessAsync()
        {
            return ProblemAsync(HttpCode.成功, "操作成功");
        }
        public static Task<AppResult> SuccessAsync(object? data = default)
        {
            return ProblemAsync(HttpCode.成功, "操作成功", data);
        }
        public static Task<AppResult> SuccessAsync(string msg = "操作成功", object? data = default)
        {
            return ProblemAsync(HttpCode.成功, msg, data);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public static AppResult Success()
        {
            return Problem(HttpCode.成功, "操作成功");
        }
        public static AppResult Success(object? data = default)
        {
            return Problem(HttpCode.成功, "操作成功", data);
        }
        public static AppResult Success(string msg = "操作成功", object? data = default)
        {
            return Problem(HttpCode.成功, msg, data);
        }
    }

    [Serializable]
    public class AppResult<T> : IResult<T>
    {
        public AppResult()
        {
        }
        public string? Msg { get; set; }
        public bool Succeeded => Code == (int)HttpCode.成功;
        public int Code { get; set; }
        public T? Data { get; set; }
        public static AppResult<T> Problem(HttpCode status, string? message = default, T? data = default)
        {
            return new AppResult<T>() { Code = (int)status, Msg = message, Data = data };
        }
    }
}
