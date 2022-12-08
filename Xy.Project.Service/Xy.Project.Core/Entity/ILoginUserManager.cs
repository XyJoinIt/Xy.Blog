using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// 姓名
        /// </summary>
        public string Name { get; }

    }
}
