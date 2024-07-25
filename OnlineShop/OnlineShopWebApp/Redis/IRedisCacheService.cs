namespace OnlineShopWebApp.Redis
{
    public interface IRedisCacheService
    {
        Task SetAsync(string key, string value);
        Task<string> TryGetAsync(string key);
        Task RemoveAsync(string key);
    }
}
