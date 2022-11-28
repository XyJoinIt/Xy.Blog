using NETCore.Encrypt;
using Xy.Project.Application.Services.Contracts.Sys;

namespace Xy.Project.Application.Services.Sys
{
    /// <summary>
    /// 加密解密
    /// </summary>
    public class EncryptionService : IEncryptionService
    {

        /// <summary>
        /// 加密哈希
        /// </summary>
        /// <param name="password"></param>
        /// <param name="securityStamp"></param>
        /// <returns></returns>
        public string GeneratePassword(string password, string securityStamp)
        {
            return EncryptProvider.HMACSHA256(password, securityStamp);
        }

        /// <summary>
        /// 解密是否匹配
        /// </summary>
        /// <param name="passwordHash"></param>
        /// <param name="securityStamp"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckPasswordAsync(string passwordHash, string securityStamp, string password)
        {
            return EncryptProvider.HMACSHA256(password, securityStamp).Equals(passwordHash, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
