
using Xy.Project.Core.Base;
namespace Xy.Project.Application.Dtos.Users
{
    [Description("更新用户DTO")]
    [AutoMap(typeof(SysUser), ReverseMap = true)]
    public class UpdateUserInputDto : UserBaseDto, IDtoId
    {
        public long Id { get; set; } = default!;
    }
}
