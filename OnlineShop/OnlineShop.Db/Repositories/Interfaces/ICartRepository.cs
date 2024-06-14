using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task AddProductAsync(Product product, string userId);
        Task<Cart> AddCartAsync(string userId);
        Task RemoveAsync(string userId);
        Task DecreaseAmountAsync(Guid productId, string userId);
        Task<Cart> TryGetByLoginAsync(string login);
    }
}
