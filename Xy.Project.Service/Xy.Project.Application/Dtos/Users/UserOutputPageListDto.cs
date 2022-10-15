namespace Xy.Project.Application.Dtos.Users
{
    [AutoMap(typeof(User))]
    public class UserOutputPageListDto : UserBaseDto
    {
        public long Id { get; set; }
    }
}
