namespace Xy.Project.Application.Dtos.Users
{
    [Description("新增用户")]
    [AutoMap(typeof(SysUser), ReverseMap = true)]
    public class AddUserInputDto : UserBaseDto
    {
        public string? Password { get; set; }
    }
}
