using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public static class Repositories
    {
        public static Repository<Product> ProductRepository = new Repository<Product>();

        public static Repository<Cart> CartRepository = new Repository<Cart>();

        static Repositories()
        {
            for (var i = 0; i < 1000; i++)
                ProductRepository.Add(new Product($"Name{i + 1}", (i + 1) * 100));
        }
    }
}
