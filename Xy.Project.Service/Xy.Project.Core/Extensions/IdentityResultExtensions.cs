
using Xy.Project.Core.Models;

namespace Xy.Project.Core.Extensions
{
    public static class IdentityResultExtensions
    {
        /// <summary>
        /// 返回失败结果
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static AppResult Failed(this IdentityResult result)
        {
            return AppResult.Problem(HttpCode.失败, string.Join(",", result.Errors.Select(o => $"{o.Description}")));
        }

        /// <summary>
        /// 返回结果数据
        /// </summary>
        /// <param name="result"></param>
        /// <param name="successMessage"></param>
        /// <returns></returns>
        public static AppResult ToResultData(this IdentityResult result, string? successMessage = null)
        {
            if (!result.Succeeded)
            {
                return result.Failed();
            }
            return AppResult.Problem(HttpCode.成功, successMessage);
        }

        public static IdentityResult Failed(this IdentityResult identityResult, params string[] errors)
        {
            return IdentityResult.Failed(identityResult.Errors.Union(errors.Select((string m) => new IdentityError
            {
                Description = m
            })).ToArray());
        }
    }
}
