using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers
{
    public class MappingHelper
    {
        public static IEnumerable<ProductViewModel> ToProductViewModels(IEnumerable<Product> products)
        {
            return products
                .Select(ToProductViewModel);
        }

        public static ProductViewModel ToProductViewModel(Product dbProduct)
        {
            return new ProductViewModel()
            {
                Id = dbProduct.Id,
                Name = dbProduct.Name,
                Cost = dbProduct.Cost,
                Description = dbProduct.Description,
                ImageLink = dbProduct.ImageLink,
                IsInFavourites = dbProduct.IsInFavourites,
                IsInComparison = dbProduct.IsInComparison
            };
        }

        public static CartViewModel? ToCartViewModel(Cart cart)
        {
            if (cart is null)
                return null;
            return new CartViewModel()
            {
                Id = cart.Id,
                Items = ToCartViewModels(cart).ToList()
            };
        }

        public static IEnumerable<CartItemViewModel> ToCartViewModels(Cart cartDb)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach (var cartDbItem in cartDb.Items)
            {
                var cartItem = new CartItemViewModel()
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }

        public static FavouritesViewModel? ToFavouritesViewModel(Favourites favouritesDb)
        {
            if (favouritesDb is null)
                return null;
            return new FavouritesViewModel()
            {
                Id = favouritesDb.Id,
                Items = ToProductViewModels(favouritesDb.Items).ToList()
            };
        }

        public static IEnumerable<FavouritesViewModel> ToFavoutitesViewModels(
            IEnumerable<Favourites> favouritesDbCollection)
        {
            return favouritesDbCollection
                .Select(ToFavouritesViewModel);
        }

        public static ComparisonViewModel ToComparisonViewModel(Comparison comparison)
        {
            return new ComparisonViewModel()
            {
                Id = comparison.Id,
                UserId = comparison.UserId,
                Items = comparison.Items
                    .Select(ToProductViewModel)
                    .ToList()
            };
        }
    }
}
