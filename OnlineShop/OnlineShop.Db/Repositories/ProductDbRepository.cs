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

        public async Task AddAsync(Product product)
        {
            await databaseContext.Products.AddAsync(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task EditProductAsync(Product newProduct)
        {
            var product = await TryGetByIdAsync(newProduct.Id);
            if (product is null)
                return;
            product.Name = newProduct.Name;
            product.Cost = newProduct.Cost;
            product.Description = newProduct.Description;
            foreach (var image in newProduct.ProductImages)
            {
                image.ProductId = product.Id;
                product.ProductImages.Add(image);
                databaseContext.Images.Add(image);
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await databaseContext.Products
                .Include(p => p.ProductImages)
                .ToListAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var product = await TryGetByIdAsync(id);
            if (product is null)
                return;
            databaseContext.Products.Remove(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task RemoveImageAsync(Guid id, string imageUrl)
        {
            var product = await TryGetByIdAsync(id);
            if (product is null)
                return;
            var image = await databaseContext.Images.FirstOrDefaultAsync(i => i.Url == imageUrl);
            if (image is null)
                return;
            product.ProductImages.Remove(image);
            databaseContext.Images.Remove(image);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<Product> TryGetByIdAsync(Guid id)
        {
            return await databaseContext.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
