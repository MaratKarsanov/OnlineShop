using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface ICartRepository
    {
        void Add(Product product, string userId);
        void Remove(string userId);
        void DecreaseAmount(Guid productId, string userId);
        Cart TryGetByUserId(string userId);
    }
}
