namespace Xy.Project.Application.Dtos.Roles
{
    [AutoMap(typeof(Role))]
    public class RoleOutputPageListDto : RoleBaseDto
    {
        public long Id { get; set; }
    }
}
