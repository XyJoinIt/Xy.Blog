using Xy.Project.Application.Dtos.Roles;

namespace Xy.Project.Application.Profiles.Roles
{
    /// <summary>
    /// 可以使用自动映射，就不用每个DTO都要在这里修改
    /// </summary>
    internal class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<AddRoleInputDto, Role>().ReverseMap();
            CreateMap<UpdateRoleInputDto, Role>().ReverseMap();
            CreateMap<RoleOutputPageListDto, Role>().ReverseMap();
        }
    }
}
