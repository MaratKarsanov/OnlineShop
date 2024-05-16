using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product TryGetById(Guid id);
        void Add(Product product);
        void Remove(Guid id);
        void EditProduct(Product newProduct);
    }
}
