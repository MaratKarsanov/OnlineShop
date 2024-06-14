using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> TryGetByIdAsync(Guid id);
        Task AddAsync(Product product);
        Task RemoveAsync(Guid id);
        Task EditProductAsync(Product newProduct);
        Task RemoveImageAsync(Guid id, string imageUrl);
    }
}
