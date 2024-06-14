using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShop.Db.Repositories
{
    public class ComparisonDbRepository : IComparisonRepository
    {
        private readonly DatabaseContext databaseContext;
        public ComparisonDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Comparison> AddComparisonAsync(string userId)
        {
            var comparison = await TryGetByUserIdAsync(userId);
            if (comparison is null)
            {
                comparison = new Comparison()
                {
                    UserId = userId,
                    Items = new List<Product>()
                };
                await databaseContext.Comparisons.AddAsync(comparison);
            }
            return comparison;
        }

        public async Task AddProductAsync(Product product, string userId)
        {
            var comparison = await TryGetByUserIdAsync(userId);
            if (comparison is null)
            {
                await databaseContext.Comparisons.AddAsync(new Comparison()
                {
                    UserId = userId,
                    Items = new List<Product>()
                    {
                        product
                    }
                });
            }
            else
            {
                comparison.Items.Add(product);
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task RemoveComparisonAsync(string userId)
        {
            var comparison = await TryGetByUserIdAsync(userId);
            if (comparison is not null)
            {
                databaseContext.Comparisons.Remove(comparison);
                await databaseContext.SaveChangesAsync();
            }
        }

        public async Task RemoveProductAsync(Product product, string userId)
        {
            var comparison = await TryGetByUserIdAsync(userId);
            comparison.Items = comparison.Items
                .Where(p => p.Id != product.Id)
                .ToList();
            await databaseContext.SaveChangesAsync();
        }

        public async Task<Comparison> TryGetByUserIdAsync(string userId)
        {
            return await databaseContext.Comparisons
                .Include(c => c.Items)
                .FirstOrDefaultAsync(f => f.UserId == userId);
        }
    }
}
