using FluentValidation;
using Xy.Project.Application.Dtos.Sys.SysOrgManage;
using Xy.Project.Application.Dtos.Sys.SysRoleManage;
using Xy.Project.Application.Services.Base;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Sys;

/// <summary>
/// 部门机构
/// </summary>
public class SysOrgService: CURDService<SysOrg, AddSysOrgDto, EditSysOrgDto, OutSysOrgPageDto>, ISysOrgService
{
    private readonly IValidator<AddSysOrgDto> _addValidator;
    private readonly IValidator<EditSysOrgDto> _editValidator;
    private readonly IRepository<SysOrg, long> _repository;
    public SysOrgService(IRepository<SysOrg, long> repository, IValidator<AddSysOrgDto> addValidator, IValidator<EditSysOrgDto> editValidator) : base(repository, addValidator, editValidator)
    {

    }
}
