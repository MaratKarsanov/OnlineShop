namespace OnlineShopWebApp.Services.Cache
{
    public interface ICacheService
    {
        Task SetAsync(string key, string value);
        Task<string> TryGetAsync(string key);
        Task RemoveAsync(string key);
    }
}
