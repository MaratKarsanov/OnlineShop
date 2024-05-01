using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IComparisonRepository
    {
        void Add(Product product, string userId);
        void Remove(Product product, string userId);
        Comparison TryGetByUserId(string userId);
    }
}
