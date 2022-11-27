using Xy.Project.Core.Base;
using Xy.Project.Core.Entity;

namespace Xy.Project.Application.Services.Contracts.Base
{
    public interface ICURDContract<TEntity, IAddInputDto, IUpdateInputDto, OutPageListDto>
        where TEntity : IEntity<long>
        where IUpdateInputDto : IDtoId
    {
        Task<AppResult> AddAsync(IAddInputDto dto);

        Task<AppResult> UpdateAsync(IUpdateInputDto dto);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AppResult> DeleteAsync(long id);

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<AppResult> PageAsync(PageParam page);


    }
}
