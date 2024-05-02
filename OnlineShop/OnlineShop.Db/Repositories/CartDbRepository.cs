using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShop.Db.Repositories
{
    public class CartDbRepository : ICartRepository
    {
        private readonly DatabaseContext databaseContext;

        public CartDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Cart TryGetByUserId(string userId)
        {
            return databaseContext.Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var cart = TryGetByUserId(userId);
            if (cart is null)
            {
                var newCart = new Cart()
                {
                    UserId = userId
                };
                newCart.Items.Add(new CartItem()
                {
                    Amount = 1,
                    Product = product
                });
                databaseContext.Carts.Add(newCart);
                databaseContext.SaveChanges();
                return;
            }
            var cartItem = cart.Items.FirstOrDefault(ci => ci.Product.Id == product.Id);
            if (cartItem is not null)
            {
                ++cartItem.Amount;
            }
            else
            {
                cart.Items.Add(new CartItem
                {
                    Amount = 1,
                    Product = product
                });
            }
            databaseContext.SaveChanges();
        }

        public void DecreaseAmount(Guid productId, string userId)
        {
            var cart = TryGetByUserId(userId);
            var cartItem = cart?.Items?.FirstOrDefault(ci => ci.Product.Id == productId);
            if (cartItem is null)
                return;
            if (--cartItem.Amount == 0)
                cart.Items.Remove(cartItem);
            databaseContext.SaveChanges();
        }

        public void Remove(string userId)
        {
            var cart = TryGetByUserId(userId);
            databaseContext.Carts.Remove(cart);
            databaseContext.SaveChanges();
        }
    }
}
