using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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

        public void EditProduct(Product newProduct)
        {
            var product = TryGetById(newProduct.Id);
            if (product is null)
                return;
            product.Name = newProduct.Name;
            product.Cost = newProduct.Cost;
            product.Description = newProduct.Description;
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

        public void UpdateInComparisonCondition(HashSet<Product> products)
        {
            foreach (var product in databaseContext.Products)
                product.IsInComparison = products.Contains(product);
            databaseContext.SaveChanges();
        }

        public void UpdateInFavouritesCondition(HashSet<Product> products)
        {
            foreach (var product in databaseContext.Products)
                product.IsInFavourites = products.Contains(product);
            databaseContext.SaveChanges();
        }
    }
}
