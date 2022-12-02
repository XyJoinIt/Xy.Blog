using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Dtos.Sys.SysMenuManage
{
    [AutoMap(typeof(SysMenu), ReverseMap = true)]
    public class AddSysMenuDto:BaseSysMenu
    {
    }
}
