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
public class SysOrgService : CURDService<SysOrg, AddSysOrgDto, EditSysOrgDto, OutSysOrgPageDto>, ISysOrgService
{
    private readonly IValidator<AddSysOrgDto> _addValidator;
    private readonly IValidator<EditSysOrgDto> _editValidator;
    private readonly IRepository<SysOrg, long> _repository;
    public SysOrgService(IRepository<SysOrg, long> repository, IValidator<AddSysOrgDto> addValidator, IValidator<EditSysOrgDto> editValidator) : base(repository, addValidator, editValidator)
    {
        _repository = repository;
    }

    /// <summary>
    /// 得到分页数据
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    public override Task<AppResult> PageAsync(PageParam page)
    {
        page.AddOrderCondition(new OrderCondition(nameof(SysOrg.Order), OrderDirection.Ascending));
        return base.PageAsync(page);
    }

    /// <summary>
    /// 得到数据
    /// </summary>
    /// <returns></returns>
    public async Task<AppResult> ListTree()
    {
        var list = await ObjectMap.ToOutput<OutSysOrgTreeDto>(_repository.QueryList().OrderBy(x=>x.Order)).ToListAsync();
        var root = list.Where(x=>x.Id== 0).FirstOrDefault();
        if (root == null)
            throw new Exception("顶级菜单栏丢失，请联系管理员");
        this.GetChildern(root, list);

        return AppResult.Success(new OutSysOrgTreeDto[] { root });
    }

    /// <summary>
    /// 递归部门机构树
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="outs"></param>
    private void GetChildern(OutSysOrgTreeDto dto, List<OutSysOrgTreeDto> outs)
    {
        var list = outs.Where(x => x.Pid == dto.Id).ToList();
        if (list.Count > 0)
        {
            dto.Children = new List<OutSysOrgTreeDto>();
            dto.Children.AddRange(list.OrderBy(z=>z.Order).ToList());

            foreach (var item in list)
            {
                this.GetChildern(item, outs);
            }
        }
    }
}
