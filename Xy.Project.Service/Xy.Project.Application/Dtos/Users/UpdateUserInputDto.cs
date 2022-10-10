
using Xy.Project.Core.Base;
namespace Xy.Project.Application.Dtos.Users
{
    [Description("更新用户DTO")]
    public class UpdateUserInputDto : UserBaseDto, IBaseInputId
    {
        public long Id { get; set; } = default!;
    }
}
