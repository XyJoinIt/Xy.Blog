namespace Xy.Project.Core.Caches
{
    /// <summary>
    /// 缓存提供者
    /// </summary>
    public interface ICacheProvide
    {


        Task<T> GetAsync<T>(string key);
    }
}
