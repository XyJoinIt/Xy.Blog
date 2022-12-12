using Xy.Project.Application.Dtos.Blogs.Categorys;
using Xy.Project.Application.Services.Contracts.Blogs;
using Xy.Project.Core.Filter;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Platform.Modular.Bolgs
{
    /// <summary>
    /// 分类管理
    /// </summary>
    [Description("分类管理")]
    public class CategoryController : OpControllerBase<ICategoryService,Category, AddInputDto, UpdateInputDto, OutPageList>
    {
        private readonly ICategoryService _categoryContract;

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryContract"></param>
        public CategoryController(ICategoryService categoryContract):base(categoryContract)
        {
            _categoryContract = categoryContract;
        }
    }
}
