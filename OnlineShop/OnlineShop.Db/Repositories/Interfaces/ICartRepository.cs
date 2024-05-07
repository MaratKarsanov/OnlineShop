using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface ICartRepository
    {
        void AddProduct(Product product, string userId);
        void AddCart(string userId);
        void Remove(string userId);
        void DecreaseAmount(Guid productId, string userId);
        Cart TryGetByLogin(string login);
    }
}
