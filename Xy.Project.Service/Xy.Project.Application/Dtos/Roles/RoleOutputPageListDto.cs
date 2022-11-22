namespace Xy.Project.Application.Dtos.Roles
{
    [AutoMap(typeof(SysRole), ReverseMap = true)]
    public class RoleOutputPageListDto : RoleBaseDto
    {
        public long Id { get; set; }
    }
}
