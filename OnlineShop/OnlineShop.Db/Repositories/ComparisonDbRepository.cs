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

        public Comparison AddComparison(string userId)
        {
            var comparison = TryGetByUserId(userId);
            if (comparison is null)
            {
                comparison = new Comparison()
                {
                    UserId = userId,
                    Items = new List<Product>()
                };
                databaseContext.Comparisons.Add(comparison);
            }
            return comparison;
        }

        public void AddProduct(Product product, string userId)
        {
            var comparison = TryGetByUserId(userId);
            if (comparison is null)
            {
                databaseContext.Comparisons.Add(new Comparison()
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
            databaseContext.SaveChanges();
        }

        public void RemoveComparison(string userId)
        {
            var comparison = TryGetByUserId(userId);
            if (comparison is not null)
            {
                databaseContext.Comparisons.Remove(comparison);
                databaseContext.SaveChanges();
            }
        }

        public void RemoveProduct(Product product, string userId)
        {
            var comparison = TryGetByUserId(userId);
            comparison.Items = comparison.Items
                .Where(p => p.Id != product.Id)
                .ToList();
            databaseContext.SaveChanges();
        }

        public Comparison TryGetByUserId(string userId)
        {
            return databaseContext.Comparisons
                .Include(c => c.Items)
                .FirstOrDefault(f => f.UserId == userId);
        }
    }
}
