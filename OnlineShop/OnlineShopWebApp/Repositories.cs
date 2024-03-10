﻿using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public static class Repositories
    {
        public static Repository<Product> ProductRepository = new Repository<Product>(
            new List<Product>()
            {
                new Product("Name1", 100),
                new Product("Name2", 200),
                new Product("Name3", 300),
                new Product("Name1", 400),
                new Product("Name2", 500),
                new Product("Name3", 600)
            }
        );
    }
}
