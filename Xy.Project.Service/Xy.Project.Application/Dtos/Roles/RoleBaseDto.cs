namespace Xy.Project.Application.Dtos.Roles
{
    public class RoleBaseDto
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Description("角色名称")]
        public string? Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public CommonStatus Status { get; set; } = CommonStatus.正常;


    }
}
