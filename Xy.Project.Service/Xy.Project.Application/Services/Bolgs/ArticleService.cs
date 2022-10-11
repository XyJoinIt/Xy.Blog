using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Application.Dtos.Blogs.Article;
using Xy.Project.Application.Services.Contracts.Blogs;
using Xy.Project.DataBase.Db;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Services.Bolgs
{
    /// <summary>
    /// 文章
    /// </summary>
    public class ArticleService: IArticleService
    {
        private readonly Repository<Article, long> _repository;
        public ArticleService(Repository<Article, long> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<AppResult> AddAsync(AddArticleDto dto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<AppResult> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<AppResult> PageAsync(PageParam page)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<AppResult> UpdateAsync(EditArticleDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
