using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xy.Project.Application.Services.Contracts.Sys;

namespace Xy.Project.Platform.Modular.Sys
{
    /// <summary>
    /// 文件控制器
    /// </summary>
    public class SysFileController : ApiControllerBase
    {
        private readonly ISysFileService _sysFileService;
        public SysFileController(ISysFileService sysFileService)
        {
            _sysFileService = sysFileService;
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AppResult> Up(IFormFile formFile) => AppResult.Success(await _sysFileService.UploadFile(formFile));
    }
}
