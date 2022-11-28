using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Application.Dtos.Sys.AuthManage;
using Xy.Project.Application.Dtos.Sys.SysRoleManage;
using Xy.Project.Application.Services.Base;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Sys
{
    public class SysRoleService : CURDService<SysRole, AddSysRoleDto, EditSysRoleDto, OutSysRolePageDto>, ISysRoleService
    {
        private readonly IValidator<AddSysRoleDto> _addValidator;
        private readonly IValidator<EditSysRoleDto> _editValidator;

        public SysRoleService(IRepository<SysRole, long> repository, IValidator<AddSysRoleDto> addValidator, IValidator<EditSysRoleDto> editValidator) : base(repository, addValidator, editValidator)
        {
            _editValidator = editValidator;
            _addValidator = addValidator;
        }
    }
}
