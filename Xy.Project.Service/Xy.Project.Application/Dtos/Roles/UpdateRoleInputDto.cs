namespace Xy.Project.Application.Dtos.Roles
{
    [AutoMap(typeof(Role))]
    public class UpdateRoleInputDto : RoleBaseDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }
    }
}
