namespace Xy.Project.Platform.Model.Stores
{
    public class RoleStore : RoleStoreBase<SysRole, long, SysRoleClaim, long>
    {
        public RoleStore(IRepository<SysRole, long> roleRepository, IRepository<SysRoleClaim, long> roleClaimRepository) : base(roleRepository, roleClaimRepository)
        {
        }
    }
}
