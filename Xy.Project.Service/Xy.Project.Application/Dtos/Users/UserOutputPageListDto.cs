namespace Xy.Project.Application.Dtos.Users
{
    [AutoMap(typeof(SysUser), ReverseMap = true)]
    public class UserOutputPageListDto : UserBaseDto
    {
        public long Id { get; set; }
    }
}
