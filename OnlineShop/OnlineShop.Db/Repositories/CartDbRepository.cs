using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using System.Runtime.CompilerServices;

namespace OnlineShop.Db.Repositories
{
    public class CartDbRepository : ICartRepository
    {
        private readonly DatabaseContext databaseContext;

        public CartDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Cart TryGetByLogin(string login)
        {
            return databaseContext.Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.UserId == login);
        }

        public void AddProduct(Product product, string userId)
        {
            var cart = TryGetByLogin(userId);
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
            var cart = TryGetByLogin(userId);
            var cartItem = cart?.Items?.FirstOrDefault(ci => ci.Product.Id == productId);
            if (cartItem is null)
                return;
            if (--cartItem.Amount == 0)
                cart.Items.Remove(cartItem);
            databaseContext.SaveChanges();
        }

        public void Remove(string userId)
        {
            var cart = TryGetByLogin(userId);
            if (cart is not null)
            {
                databaseContext.Carts.Remove(cart);
                databaseContext.SaveChanges();
            }
        }

        public Cart AddCart(string login)
        {
            var cart = TryGetByLogin(login);
            if (cart is null)
            {
                cart = new Cart()
                {
                    UserId = login,
                    Items = new List<CartItem>()
                };
                databaseContext.Carts.Add(cart);
                databaseContext.SaveChanges();
            }
            return cart;
        }
    }
}
