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

        public async Task<Favourites> AddFavouritesAsync(string userId)
        {
            var favourites = await TryGetByUserNameAsync(userId);
            if (favourites is null)
            {
                favourites = new Favourites()
                {
                    UserId = userId,
                    Items = new List<Product>()
                };
                await databaseContext.Favourites.AddAsync(favourites);
            }
            return favourites;
        }

        public async Task AddProductAsync(Product product, string userId)
        {
            var favourites = await TryGetByUserNameAsync(userId);
            if (favourites is null)
            {
                await databaseContext.Favourites.AddAsync(new Favourites()
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
            await databaseContext.SaveChangesAsync();
        }

        public async Task ClearAsync(string userId)
        {
            var favourites = await TryGetByUserNameAsync(userId);
            if (favourites is null)
                return;
            favourites.Items = new List<Product>();
            await databaseContext.SaveChangesAsync();
        }

        public async Task RemoveFavouritesAsync(string userId)
        {
            var favourites = await TryGetByUserNameAsync(userId);
            if (favourites is not null)
            {
                databaseContext.Favourites.Remove(favourites);
                await databaseContext.SaveChangesAsync();
            }
        }

        public async Task RemoveProductAsync(Product product, string userId)
        {
            var favourites = await TryGetByUserNameAsync(userId);
            if (favourites is null)
                return;
            favourites.Items.Remove(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<Favourites> TryGetByUserNameAsync(string userName)
        {
            return await databaseContext.Favourites
                .Include(f => f.Items)
                .FirstOrDefaultAsync(f => f.UserId == userName);
        }
    }
}