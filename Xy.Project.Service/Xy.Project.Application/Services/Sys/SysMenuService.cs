using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Application.Dtos.Sys.SysMenuManage;
using Xy.Project.Application.Dtos.Sys.SysRoleManage;
using Xy.Project.Application.Services.Base;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Sys
{
    public class SysMenuService: CURDService<SysMenu, AddSysMenuDto, EditSysMenuDto, OutSysMenuPageDto>, ISysMenuService
    {
        private readonly IValidator<AddSysMenuDto> _addValidator;
        private readonly IValidator<EditSysMenuDto> _editValidator;

        public SysMenuService(IRepository<SysMenu, long> repository, IValidator<AddSysMenuDto> addValidator, IValidator<EditSysMenuDto> editValidator) : base(repository, addValidator, editValidator)
        {
            
        }
    }
}
