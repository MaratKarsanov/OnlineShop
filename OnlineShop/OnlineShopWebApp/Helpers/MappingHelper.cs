using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Administrator.Models;
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

        public static DeliveryDataViewModel ToDeliveryDataViewModel(DeliveryData deliveryData)
        {
            return new DeliveryDataViewModel()
            {
                Id = deliveryData.Id,
                Name = deliveryData.Name,
                Surname = deliveryData.Surname,
                Address = deliveryData.Address,
                EMail = deliveryData.EMail,
                PhoneNumber = deliveryData.PhoneNumber
            };
        }

        public static DeliveryData ToDeliveryData(DeliveryDataViewModel deliveryDataVm)
        {
            return new DeliveryData()
            {
                Id = deliveryDataVm.Id,
                Name = deliveryDataVm.Name,
                Surname = deliveryDataVm.Surname,
                Address = deliveryDataVm.Address,
                EMail = deliveryDataVm.EMail,
                PhoneNumber = deliveryDataVm.PhoneNumber
            };
        }

        public static OrderViewModel ToOrderViewModel(Order order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                UserId = order.Login,
                Items = ToCartItemViewModels(order.Items).ToList(),
                DeliveryData = ToDeliveryDataViewModel(order.DeliveryData),
                CreationTime = order.CreationTime,
                Status = order.Status
            };
        }

        public static IEnumerable<OrderViewModel> ToOrderViewModels(IEnumerable<Order> orders)
        {
            return orders
                .Select(ToOrderViewModel);
        }

        public static UserViewModel ToUserViewModel(User user)
        {
            return new UserViewModel()
            {
                Login = user.Login,
                Password = user.Password,
                Name = user.Name,
                Surname = user.Surname,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Role = ToRoleViewModel(user.Role),
                RememberMe = user.RememberMe
            };
        }

        public static IEnumerable<UserViewModel> ToUserViewModels(IEnumerable<User> users)
        {
            return users
                .Select(ToUserViewModel);
        }

        public static RoleViewModel ToRoleViewModel(Role role)
        {
            return new RoleViewModel()
            {
                Name = role.Name
            };
        }

        public static IEnumerable<RoleViewModel> ToRoleViewModels(IEnumerable<Role> roles)
        {
            return roles
                .Select(ToRoleViewModel);
        }
    }
}
