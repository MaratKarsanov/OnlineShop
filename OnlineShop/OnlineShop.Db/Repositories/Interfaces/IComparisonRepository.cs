using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IComparisonRepository
    {
        Task AddProductAsync(Product product, string userId);
        Task<Comparison> AddComparisonAsync(string userId);
        Task RemoveProductAsync(Product product, string userId);
        Task RemoveComparisonAsync(string userId);
        Task<Comparison> TryGetByUserIdAsync(string userId);
    }
}
