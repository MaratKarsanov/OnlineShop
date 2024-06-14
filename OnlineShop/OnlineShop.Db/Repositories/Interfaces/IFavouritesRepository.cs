using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IFavouritesRepository
    {
        Task AddProductAsync(Product product, string userId);
        Task<Favourites> AddFavouritesAsync(string userId);
        Task ClearAsync(string userId);
        Task RemoveProductAsync(Product product, string userId);
        Task RemoveFavouritesAsync(string userId);
        Task<Favourites> TryGetByUserNameAsync(string userId);
    }
}