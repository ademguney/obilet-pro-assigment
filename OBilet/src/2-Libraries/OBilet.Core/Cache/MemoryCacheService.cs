using Microsoft.Extensions.Caching.Memory;

namespace OBilet.Core.Cache
{
    public class MemoryCacheService : IMemoryCacheService
    {
        protected readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache _memoryCache)
        {
            this._memoryCache = _memoryCache;
        }

        public Task<T> GetAsync<T>(string cacheKey)
        {
            _memoryCache.TryGetValue(cacheKey, out T entry);
            return Task.FromResult(entry);
        }

        public void Remove(string cacheKey)
        {
            _memoryCache?.Remove(cacheKey);
        }

        public void Set<T>(string cacheKey, T value)
        {
            var options = new MemoryCacheEntryOptions() { AbsoluteExpiration = DateTime.Now.AddMinutes(30), Size = 1024 };
            _memoryCache.Set(cacheKey, value, options);
        }
    }
}
