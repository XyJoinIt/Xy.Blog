using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using Xy.Project.Core.GlobalConfigEntity;
using Xy.Project.Platform.Model.Entities.Sys;
using Microsoft.AspNetCore.Hosting;
using OnceMi.AspNetCore.OSS;
using Masuit.Tools.Files.FileDetector;
using Xy.Project.Application.Dtos.Sys.SysFileManage;
using Xy.Project.Application.Services.Contracts.Sys;

namespace Xy.Project.Application.Services.Sys
{
    /// <summary>
    /// 文件服务
    /// </summary>
    public class SysFileService : ISysFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IOSSService _OSSService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<SysFile, long> _repository;

        public SysFileService(IWebHostEnvironment webHostEnvironment, IOSSService oSSService, IHttpContextAccessor httpContextAccessor, IRepository<SysFile, long> repository)
        {
            _webHostEnvironment = webHostEnvironment;
            _OSSService = oSSService;
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<OutSysFileDto> UploadFile(IFormFile file)
        {
            var sysFile = await HandleUploadFile(file);
            return new OutSysFileDto
            {
                Id = sysFile.Id,
                Url = sysFile.Url,  // string.IsNullOrWhiteSpace(sysFile.Url) ? _commonService.GetFileUrl(sysFile) : sysFile.Url,
                SizeKb = sysFile.SizeKb,
                Suffix = sysFile.Suffix,
                FilePath = sysFile.FilePath,
            };
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
            var reg = new Regex(@"(\{.+?})");

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

            var finalName = newFile.Id + suffix; // 文件最终名称
            if (XyGlobalConfig.oSSProviderOptions.IsEnable)
            {
                newFile.Provider = Enum.GetName(XyGlobalConfig.oSSProviderOptions.Provider)!;
                var filePath = string.Concat(path, "/", finalName);
                var a = file.OpenReadStream();
                await _OSSService.PutObjectAsync(newFile.BucketName, filePath, file.OpenReadStream());
                //  http://<你的bucket名字>.oss.aliyuncs.com/<你的object名字>
                //  生成外链地址 方便前端预览
                switch (XyGlobalConfig.oSSProviderOptions.Provider)
                {
                    case OSSProvider.Aliyun:
                        newFile.Url = $"{(XyGlobalConfig.oSSProviderOptions.IsEnableHttps ? "https" : "http")}://{newFile.BucketName}.{XyGlobalConfig.oSSProviderOptions.Endpoint}/{filePath}";
                        break;

                    case OSSProvider.Minio:
                        // 获取Minio文件的下载或者预览地址
                        newFile.Url = await GetMinioPreviewFileUrl(newFile.BucketName, filePath); ;
                        break;
                    case OSSProvider.QCloud:
                        newFile.Url = $"https://{newFile.BucketName}-{XyGlobalConfig.oSSProviderOptions.Endpoint}.cos.{XyGlobalConfig.oSSProviderOptions.Region}.myqcloud.com/{filePath}";
                        break;
                }
            }
            else
            {
                newFile.Provider = ""; // 本地存储 Provider 显示为空
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, path);
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                var realFile = Path.Combine(filePath, finalName);
                using var stream = File.Create(realFile);

                await file.CopyToAsync(stream);
                var detector = stream.DetectFiletype();
                var realExt = detector.Extension; // 真实扩展名
                                                  // 二次校验扩展名
                if (!string.Equals(realExt, suffix.Replace(".", ""), StringComparison.OrdinalIgnoreCase))
                {
                    var delFilePath = Path.Combine(_webHostEnvironment.WebRootPath, realFile);
                    if (File.Exists(delFilePath))
                        File.Delete(delFilePath);
                    throw new XyException("不允许文件的类型");
                }

                // 生成外链
                newFile.Url = GetFileUrl(newFile);
            }
            await _repository.InsertAsync(newFile);
            return newFile;
        }

        /// <summary>
        /// 获取Minio文件的下载或者预览地址
        /// </summary>
        /// <param name="bucketName">桶名</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        private async Task<string> GetMinioPreviewFileUrl(string bucketName, string fileName)
        {
            return await _OSSService.PresignedGetObjectAsync(bucketName, fileName, 7);
        }

        /// <summary>
        /// 获取Host
        /// </summary>
        /// <returns></returns>
        private string GetHost()
        {
            return $"{_httpContextAccessor.HttpContext?.Request.Scheme}://{_httpContextAccessor.HttpContext?.Request.Host.Value}";
        }

        /// <summary>
        /// 获取文件URL
        /// </summary>
        /// <param name="sysFile"></param>
        /// <returns></returns>
        private string GetFileUrl(SysFile sysFile)
        {
            return $"{GetHost()}/{sysFile.FilePath}/{sysFile.Id + sysFile.Suffix}";
        }
    }
}
