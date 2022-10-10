namespace Xy.Project.Application.Dtos.Users
{
    [Description("新增用户")]
    public class AddUserInputDto : UserBaseDto
    {
        public string? Password { get; set; }
    }
}
