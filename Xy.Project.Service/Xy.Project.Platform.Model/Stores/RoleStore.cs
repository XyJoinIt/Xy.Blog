namespace Xy.Project.Platform.Model.Stores
{
    public class RoleStore : RoleStoreBase<Role, long, RoleClaim, long>
    {
        public RoleStore(IRepository<Role, long> roleRepository, IRepository<RoleClaim, long> roleClaimRepository) : base(roleRepository, roleClaimRepository)
        {
        }
    }
}
