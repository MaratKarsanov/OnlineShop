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

        public async Task<Cart> TryGetByLoginAsync(string login)
        {
            return await databaseContext.Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == login);
        }

        public async Task AddProductAsync(Product product, string userId)
        {
            var cart = await TryGetByLoginAsync(userId);
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
                await databaseContext.Carts.AddAsync(newCart);
                await databaseContext.SaveChangesAsync();
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
            await databaseContext.SaveChangesAsync();
        }

        public async Task DecreaseAmountAsync(Guid productId, string userId)
        {
            var cart = await TryGetByLoginAsync(userId);
            var cartItem = cart?.Items?.FirstOrDefault(ci => ci.Product.Id == productId);
            if (cartItem is null)
                return;
            if (--cartItem.Amount == 0)
                cart.Items.Remove(cartItem);
            await databaseContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(string userId)
        {
            var cart = await TryGetByLoginAsync(userId);
            if (cart is not null)
            {
                databaseContext.Carts.Remove(cart);
                await databaseContext.SaveChangesAsync();
            }
        }

        public async Task<Cart> AddCartAsync(string login)
        {
            var cart = await TryGetByLoginAsync(login);
            if (cart is null)
            {
                cart = new Cart()
                {
                    UserId = login,
                    Items = new List<CartItem>()
                };
                await databaseContext.Carts.AddAsync(cart);
                await databaseContext.SaveChangesAsync();
            }
            return cart;
        }
    }
}
