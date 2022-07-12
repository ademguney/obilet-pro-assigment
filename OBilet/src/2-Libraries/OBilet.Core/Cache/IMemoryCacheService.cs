namespace OBilet.Core.Cache
{
    public interface IMemoryCacheService
    {
        Task<T> GetAsync<T>(string cacheKey);
        void Set<T>(string cacheKey, T value);
        void Remove(string cacheKey);   
    }
}
