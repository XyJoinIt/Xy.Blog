using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Application.Dtos.Sys.SysFileManage;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    public interface ISysFileService : IScopedDependency
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<OutSysFileDto> UploadFile(IFormFile file);
    }
}
