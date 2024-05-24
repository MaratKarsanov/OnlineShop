using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

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
            foreach (var image in newProduct.Images)
            {
                image.ProductId = product.Id;
                product.Images.Add(image);
                databaseContext.Images.Add(image);
            }
            databaseContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products
                .Include(p => p.Images)
                .ToList();
        }

        public void Remove(Guid id)
        {
            var product = TryGetById(id);
            if (product is null)
                return;
            databaseContext.Products.Remove(product);
            databaseContext.SaveChanges();
        }

        public void RemoveImage(Guid id, string imageUrl)
        {
            var product = TryGetById(id);
            if (product is null)
                return;
            var image = databaseContext.Images.FirstOrDefault(i => i.Url == imageUrl);
            if (image is null)
                return;
            product.Images.Remove(image);
            databaseContext.Images.Remove(image);
            databaseContext.SaveChanges();
        }

        public Product TryGetById(Guid id)
        {
            return databaseContext.Products
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
