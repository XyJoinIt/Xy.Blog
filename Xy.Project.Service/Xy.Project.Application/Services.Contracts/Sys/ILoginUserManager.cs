using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    public interface ILoginUserManager
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; }

        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <returns></returns>
        public Task<SysUser> GetUserInfo();
    }
}
