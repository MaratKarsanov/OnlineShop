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
                    Items = new List<ComparisonItem>()
                    {
                        new ComparisonItem()
                        {
                            Product = product
                        }
                    }
                });
            }
            else
            {
                comparison.Items.Add(new ComparisonItem()
                {
                    Product = product
                });
            }
            product.IsInComparison = true;
            databaseContext.SaveChanges();
        }

        public void Remove(Product product, string userId)
        {
            var comparison = TryGetByUserId(userId);
            comparison.Items = comparison.Items
                .Where(ci => ci.Product.Id != product.Id)
                .ToList();
            product.IsInComparison = false;
            databaseContext.SaveChanges();
        }

        public Comparison TryGetByUserId(string userId)
        {
            return databaseContext.Comparisons
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(f => f.UserId == userId);
        }
    }
}
