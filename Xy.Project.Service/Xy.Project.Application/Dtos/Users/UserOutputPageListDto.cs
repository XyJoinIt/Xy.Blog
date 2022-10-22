namespace Xy.Project.Application.Dtos.Users
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class UserOutputPageListDto : UserBaseDto
    {
        public long Id { get; set; }
    }
}
