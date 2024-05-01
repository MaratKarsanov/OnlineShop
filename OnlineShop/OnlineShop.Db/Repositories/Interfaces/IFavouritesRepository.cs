﻿using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IFavouritesRepository
    {
        void Add(Product product, string userId);
        void Clear(string userId);
        void Remove(Product product, string userId);
        Favourites TryGetByUserId(string userId);
    }
}