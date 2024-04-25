using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers
{
    public class MappingHelper
    {
        public static IEnumerable<ProductViewModel> ToProductViewModels(IEnumerable<Product> products)
        {
            var productViewModels = new List<ProductViewModel>();
            foreach (var product in products)
                productViewModels.Add(ToProductViewModel(product));
            return productViewModels;
        }

        public static ProductViewModel ToProductViewModel(Product dbProduct)
        {
            return new ProductViewModel()
            {
                Id = dbProduct.Id,
                Name = dbProduct.Name,
                Cost = dbProduct.Cost,
                Description = dbProduct.Description,
                ImageLink = dbProduct.ImageLink
            };
        }

        public static CartViewModel? ToCartViewModel(Cart cart)
        {
            if (cart is null)
                return null;
            return new CartViewModel()
            {
                Id = cart.Id,
                Items = ToCartViewModels(cart.Items).ToList()
            };
        }
        public static IEnumerable<CartItemViewModel> ToCartViewModels(IEnumerable<CartItem> cartDbItems)
        {
            var carItems = new List<CartItemViewModel>();
            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemViewModel()
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
                carItems.Add(cartItem);
            }
            return carItems;
        }
    }
}
