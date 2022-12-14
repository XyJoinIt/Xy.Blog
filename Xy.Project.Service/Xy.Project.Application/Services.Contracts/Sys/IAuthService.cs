using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Application.Dtos.Sys.AuthManage;


namespace Xy.Project.Application.Services.Contracts.Sys
{
    /// <summary>
    /// 授权接口
    /// </summary>
    public interface IAuthService: IScopedDependency
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        Task<AppResult> Login(AddAuthDto dto);
        Task<AppResult> Logout();

        /// <summary>
        /// 刷新口令
        /// </summary>
        /// <returns></returns>
        Task<AppResult> RefreshToken();
    }
}
