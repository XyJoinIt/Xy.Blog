using Xy.Project.Application.Dtos.Blogs.Categorys;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Core.Dependency;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Services.Contracts.Blogs
{
    public interface ICategoryContract : ICURDContract<Category, AddInputDto, UpdateInputDto, OutPageList>, IScopedDependency  //自动注入
    {

    }
}
