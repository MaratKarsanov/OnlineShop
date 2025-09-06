
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace OnlineShopWebApp.Services.Cache
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task RemoveAsync(string key)
        {
            try
            {
                _memoryCache.Remove(key);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return null;
            }
        }

        public Task SetAsync(string key, string value)
        {
            try
            {
                _memoryCache.Set(key, value);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return null;
            }
        }

        public Task<string> TryGetAsync(string key)
        {
            try
            {
                _memoryCache.TryGetValue(key, out var value);
                if (value is null)
                {
                    return Task.FromResult("");
                }
                return Task.FromResult(value.ToString());
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return Task.FromResult("");
            }
        }
    }
}
