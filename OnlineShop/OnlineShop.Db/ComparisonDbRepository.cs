using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class ComparisonDbRepository : IComparisonRepository
    {
        private readonly DatabaseContext databaseContext;
        public ComparisonDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Product product, string userId)
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
            product.IsInComparison = true;
            databaseContext.SaveChanges();
        }

        public void Remove(Product product, string userId)
        {
            var comparison = TryGetByUserId(userId);
            comparison.Items = comparison.Items
                .Where(p => p.Id != product.Id)
                .ToList();
            product.IsInComparison = false;
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
