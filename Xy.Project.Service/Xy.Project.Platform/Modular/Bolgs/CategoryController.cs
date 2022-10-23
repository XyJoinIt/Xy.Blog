using Xy.Project.Application.Dtos.Blogs.Categorys;
using Xy.Project.Application.Services.Contracts.Blogs;
using Xy.Project.Core.Filter;

namespace Xy.Project.Platform.Modular.Bolgs
{
    /// <summary>
    /// 分类管理
    /// </summary>

    [Description("分类管理")]
    public class CategoryController : AdminControllerBase
    {
        private readonly ICategoryContract _categoryContract;

        public CategoryController(ICategoryContract categoryContract)
        {
            _categoryContract = categoryContract;
        }

        /// <summary>
        /// 得到分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("得到分页数据")]
        public async Task<ActionResult<AppResult>> PateList([FromBody] PageParam page)
        {
            return await _categoryContract.PageAsync(page);
        }

        /// <summary>
        /// 新增分类
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("新增分类")]
        public async Task<ActionResult<AppResult>> Add([FromBody] AddCategoryInputDto dto)
        {
            return await _categoryContract.AddAsync(dto);
        }

        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Description("更新分类")]
        public async Task<ActionResult<AppResult>> Update([FromBody] UpdateCategoryInputDto dto)
        {
            return await _categoryContract.UpdateAsync(dto);
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Description("删除分类")]
        public async Task<ActionResult<AppResult>> Delete(long id)
        {
            return await _categoryContract.DeleteAsync(id);
        }
    }
}
