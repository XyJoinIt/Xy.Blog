using Xy.Project.Core.Base;
using Xy.Project.Platform.Model.Entities.Blogs;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Dtos.Sys.SysUserManage;

[AutoMap(typeof(SysUser), ReverseMap = true)]
public class UpdateInputDto : BaseDto, IDtoId
{
    public long Id { get; set; }

}

