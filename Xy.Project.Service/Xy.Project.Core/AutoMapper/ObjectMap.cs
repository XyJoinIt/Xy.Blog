﻿using AutoMapper;

namespace Xy.Project.Core.AutoMapper
{
    /// <summary>
    /// AutoMapper
    /// </summary>
    public static class ObjectMap
    {
        private static IMapper _mapper = null!;

        /// <summary>
        /// 
        /// </summary>
        public static void SetMapper(IMapper mapper)
        {
            mapper.NotNull(nameof(mapper));
            _mapper = mapper;
        }

        /// <summary>
        /// 检查
        /// </summary>
        internal static void CheckMapper()
        {
            _mapper.NotNull(nameof(_mapper));
        }

        /// <summary>
        /// 将对象映射为指定类型
        /// </summary>
        /// <typeparam name="TTarget">要映射的目标类型</typeparam>
        /// <param name="source">源对象</param>
        /// <returns>目标类型的对象</returns>
        public static TTarget MapTo<TTarget>(object source)
        {
            CheckMapper();
            source.NotNull(nameof(source));
            return _mapper.Map<TTarget>(source);
        }

        /// <summary>
        /// 使用源类型的对象更新目标类型的对象
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <param name="source">源对象</param>
        /// <param name="target">待更新的目标对象</param>
        /// <returns>更新后的目标类型对象</returns>
        public static TTarget MapTo<TSource, TTarget>(TSource source, TTarget target)
        {
            CheckMapper();
            source.NotNull(nameof(source));
            target.NotNull(nameof(target));
            return _mapper.Map(source, target);
        }

        /// <summary>
        ///  将数据源映射为指定<typeparamref name="TTarget"/>的集合
        /// </summary>
        /// <typeparam name="TTarget">动态实体</typeparam>
        /// <param name="sources">数据源</param>
        /// <returns></returns>

        public static IEnumerable<TTarget> MapToList<TTarget>(IEnumerable<object> sources)
        {
            CheckMapper();
            sources.NotNull(nameof(sources));
            return _mapper.Map<IEnumerable<TTarget>>(sources);
        }

        /// <summary>
        /// 将数据源映射为指定<typeparamref name="TOutputDto"/>的集合
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="membersToExpand">成员展开</param>
        public static IQueryable<TOutputDto> ToOutput<TOutputDto>(IQueryable source,
            params Expression<Func<TOutputDto, object>>[] membersToExpand)
        {
            CheckMapper();
            return _mapper.ProjectTo<TOutputDto>(source, membersToExpand);
        }
    }
}
