namespace Xy.Project.Platform.Model.Stores
{
    public class UserStore : UserStoreBase<SysUser, long, SysUserClaim, long, SysUserLogin, long, SysUserToken, long, SysRole, long, SysUserRole, long>
    {
        public UserStore(IRepository<SysUser, long> userRepository, IRepository<SysUserLogin, long> userLoginRepository, IRepository<SysUserClaim, long> userClaimRepository, IRepository<SysUserToken, long> userTokenRepository, IRepository<SysRole, long> roleRepository, IRepository<SysUserRole, long> userRoleRepository) : base(userRepository, userLoginRepository, userClaimRepository, userTokenRepository, roleRepository, userRoleRepository)
        {
        }
    }
}
