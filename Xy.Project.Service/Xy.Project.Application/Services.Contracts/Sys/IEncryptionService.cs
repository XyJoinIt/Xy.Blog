namespace Xy.Project.Application.Services.Contracts.Sys
{
    /// <summary>
    /// 加密解密接口
    /// </summary>
    public interface IEncryptionService:IScopedDependency
    {
        /// <summary>
        /// 用户密码加密
        /// </summary>
        /// <param name="password"></param>
        /// <param name="securityStamp"></param>
        /// <returns></returns>
        string GeneratePassword(string password, string securityStamp);


        /// <summary>
        /// 用户密码是否匹配
        /// </summary>
        /// <param name="passwordHash"></param>
        /// <param name="securityStamp"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool CheckPasswordAsync(string passwordHash, string securityStamp, string password);
    }
}
