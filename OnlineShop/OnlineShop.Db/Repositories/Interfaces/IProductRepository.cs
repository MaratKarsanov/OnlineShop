using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetAll();
        public Product TryGetById(Guid id);
        public void Add(Product product);
        public void Remove(Guid id);
    }
}
