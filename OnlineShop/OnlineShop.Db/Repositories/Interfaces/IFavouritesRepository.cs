using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IFavouritesRepository
    {
        void AddProduct(Product product, string userId);
        Favourites AddFavourites(string userId);
        void Clear(string userId);
        void RemoveProduct(Product product, string userId);
        void RemoveFavourites(string userId);
        Favourites TryGetByUserId(string userId);
    }
}