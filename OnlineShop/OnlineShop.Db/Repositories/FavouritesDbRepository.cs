using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShop.Db.Repositories
{
    public class FavouritesDbRepository : IFavouritesRepository
    {
        private readonly DatabaseContext databaseContext;
        public FavouritesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Product product, string userId)
        {
            var favourites = TryGetByUserId(userId);
            if (favourites is null)
            {
                databaseContext.Favourites.Add(new Favourites()
                {
                    UserId = userId,
                    Items = new List<Product>()
                    {
                        product
                    }
                });
            }
            else
                favourites.Items.Add(product);
            product.IsInFavourites = true;
            databaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var favourites = TryGetByUserId(userId);
            if (favourites is null)
                return;
            favourites.Items = new List<Product>();
            databaseContext.SaveChanges();
        }

        public void Remove(Product product, string userId)
        {
            var favourites = TryGetByUserId(userId);
            if (favourites is null)
                return;
            favourites.Items.Remove(product);
            product.IsInFavourites = false;
            databaseContext.SaveChanges();
        }

        public Favourites TryGetByUserId(string userId)
        {
            return databaseContext.Favourites
                .Include(f => f.Items)
                .FirstOrDefault(f => f.UserId == userId);
        }
    }
}