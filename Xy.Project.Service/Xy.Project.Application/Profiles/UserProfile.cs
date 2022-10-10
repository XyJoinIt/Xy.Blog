namespace Xy.Project.Application.Profiles
{
    internal sealed class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserInputDto, User>().ReverseMap();
            CreateMap<UpdateUserInputDto, User>().ReverseMap();
            CreateMap<UserOutputPageListDto, User>().ReverseMap();
        }
    }
}
