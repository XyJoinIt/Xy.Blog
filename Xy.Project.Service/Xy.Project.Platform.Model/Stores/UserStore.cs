namespace Xy.Project.Platform.Model.Stores
{
    public class UserStore : UserStoreBase<User, long, UserClaim, long, UserLogin, long, UserToken, long, Role, long, UserRole, long>
    {
        public UserStore(IRepository<User, long> userRepository, IRepository<UserLogin, long> userLoginRepository, IRepository<UserClaim, long> userClaimRepository, IRepository<UserToken, long> userTokenRepository, IRepository<Role, long> roleRepository, IRepository<UserRole, long> userRoleRepository) : base(userRepository, userLoginRepository, userClaimRepository, userTokenRepository, roleRepository, userRoleRepository)
        {
        }
    }
}
