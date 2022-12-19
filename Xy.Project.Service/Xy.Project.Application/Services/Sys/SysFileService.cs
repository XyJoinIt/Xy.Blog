using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xy.Project.Core.GlobalConfigEntity;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Sys
{
    /// <summary>
    /// 文件服务
    /// </summary>
    public class SysFileService
    {

        public SysFileService()
        {

        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private async Task<SysFile> HandleUploadFile(IFormFile file)
        {
            if (file == null) throw new XyException("文件不存在");

            string path = XyGlobalConfig.uploadOptions.Path;
            var reg  = new Regex(@"(\{.+?})");

            var match = reg.Matches(path);
            match.ToList().ForEach(a =>
            {
                var str = DateTime.Now.ToString(a.ToString().Substring(1, a.Length - 2));
                path = path.Replace(a.ToString(), str);
            });

            if (!XyGlobalConfig.uploadOptions.ContentType.Contains(file.ContentType))
                throw new XyException("不允许文件类型");

            var sizeKb = (long)(file.Length / 1024.0); // 大小KB
            if (sizeKb > XyGlobalConfig.uploadOptions.MaxSize)
                throw new XyException("文件超过允许大小");

            var suffix = Path.GetExtension(file.FileName).ToLower(); // 后缀

            var newFile = new SysFile
            {
                BucketName = XyGlobalConfig.oSSProviderOptions.IsEnable ? XyGlobalConfig.oSSProviderOptions.Bucket : "Local",
                FileName = Path.GetFileNameWithoutExtension(file.FileName),
                Suffix = suffix,
                SizeKb = sizeKb.ToString(),
                FilePath = path,
            };

            return newFile;
        }
    }
}
