using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Numerics;

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
                Items = ToCartItemViewModels(cart.Items).ToList()
            };
        }

        public static IEnumerable<CartItemViewModel> ToCartItemViewModels(IEnumerable<CartItem> cartItems)
        {
            var cartItemsVm = new List<CartItemViewModel>();
            foreach (var cartItem in cartItems)
            {
                var cartItemVm = new CartItemViewModel()
                {
                    Id = cartItem.Id,
                    Amount = cartItem.Amount,
                    Product = ToProductViewModel(cartItem.Product)
                };
                cartItemsVm.Add(cartItemVm);
            }
            return cartItemsVm;
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

        public static DeliveryDataViewModel ToPersonalDataViewModel(DeliveryData personalData)
        {
            return new DeliveryDataViewModel()
            {
                Id = personalData.Id,
                Name = personalData.Name,
                Surname = personalData.Surname,
                Address = personalData.Address,
                EMail = personalData.EMail,
                PhoneNumber = personalData.PhoneNumber
            };
        }

        public static OrderViewModel ToOrderViewModel(Order order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                UserId = order.UserId,
                Items = ToCartItemViewModels(order.Items).ToList(),
                PersonalData = ToPersonalDataViewModel(order.PersonalData),
                CreationTime = order.CreationTime,
                Status = order.Status
            };
        }

        public static IEnumerable<OrderViewModel> ToOrderViewModels(IEnumerable<Order> orders)
        {
            return orders
                .Select(ToOrderViewModel);
        }
    }
}
