using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IComparisonRepository
    {
        void AddProduct(Product product, string userId);
        Comparison AddComparison(string userId);
        void RemoveProduct(Product product, string userId);
        void RemoveComparison(string userId);
        Comparison TryGetByUserId(string userId);
    }
}
