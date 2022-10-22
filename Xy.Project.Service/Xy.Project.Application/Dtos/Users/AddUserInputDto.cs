namespace Xy.Project.Application.Dtos.Users
{
    [Description("新增用户")]
    [AutoMap(typeof(User), ReverseMap = true)]
    public class AddUserInputDto : UserBaseDto
    {
        public string? Password { get; set; }
    }
}
