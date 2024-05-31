using AutoMapper;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            return products.Select(ToProductViewModel).ToList();
        }

        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagesPaths = product.ProductImages.Select(x => x.Url).ToArray()
            };
        }

        public static Product ToProduct(this AddProductViewModel addProductViewModel, List<string> imagesPaths)
        {
            return new Product
            {
                Name = addProductViewModel.Name,
                Cost = addProductViewModel.Cost,
                Description = addProductViewModel.Description,
                ProductImages = ToImages(imagesPaths)
            };
        }

        public static List<Image> ToImages(this List<string> paths)
        {
            return paths.Select(p => new Image { Url = p }).ToList();
        }

        public static List<string> ToPaths(this List<Image> paths)
        {
            return paths.Select(i => i.Url).ToList();
        }


        public static EditProductViewModel ToEditProductViewModel(this Product product)
        {
            return new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagesPaths = product.ProductImages.ToPaths()
            };
        }

        public static Product ToProduct(this EditProductViewModel editProduct)
        {
            return new Product
            {
                Id = editProduct.Id,
                Name = editProduct.Name,
                Cost = editProduct.Cost,
                Description = editProduct.Description,
                ProductImages = editProduct.ImagesPaths.ToImages()
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

        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                UserName = user.UserName,
                Password = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,
                LockoutEnabled = user.LockoutEnabled,
                //Orders = user.Orders.Select(ToOrderViewModel).ToList(),
                ImagePath = user.ProfileImagePath
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                CreationTime = order.CreationTime,
                DeliveryData = ToDeliveryDataViewModel(order.DeliveryData),
                Status = order.Status,
                Items = ToCartItemViewModels(order.Items),
                //UserId = order.UserId
            };
        }

        public static CartItemViewModel ToCartItemViewModel(this CartItem cartItem)
        {
            return new CartItemViewModel()
            {
                Id = cartItem.Id,
                Amount = cartItem.Amount,
                Product = ToProductViewModel(cartItem.Product)
            };
        }

        public static List<CartItemViewModel> ToCartItemViewModels(this List<CartItem> cartItems)
        {
            return cartItems
                .Select(ToCartItemViewModel)
                .ToList();
        }
    }
}
