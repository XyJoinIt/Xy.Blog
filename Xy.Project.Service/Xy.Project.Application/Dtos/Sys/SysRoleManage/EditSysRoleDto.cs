using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Core.Base;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Dtos.Sys.SysRoleManage
{
    [AutoMap(typeof(SysRole), ReverseMap = true)]
    public class EditSysRoleDto : BaseSysRole, IDtoId
    {
        public long Id { get; set; }
    }
}
