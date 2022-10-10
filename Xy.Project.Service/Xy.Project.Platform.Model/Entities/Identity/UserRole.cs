namespace Xy.Project.Platform.Model.Entities.Identity
{
    public class UserRole : UserRoleBase<long, long, long>
    {
        public UserRole()
        {
            Id = YitIdHelper.NextId();
        }
    }
}
