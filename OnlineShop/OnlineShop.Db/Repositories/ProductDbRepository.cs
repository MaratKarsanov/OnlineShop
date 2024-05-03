using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using System.Data;

namespace OnlineShop.Db.Repositories
{
    public class ProductDbRepository : IProductRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }

        public void Remove(Guid id)
        {
            var product = TryGetById(id);
            if (product is null)
                return;
            databaseContext.Products.Remove(product);
            databaseContext.SaveChanges();
        }

        public Product TryGetById(Guid id)
        {
            return databaseContext.Products
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
