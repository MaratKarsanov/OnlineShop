using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShopWebApp.Views.Shared.Components
{
    public class CartViewComponent : ViewComponent
    { 
        private readonly ICartRepository cartRepository;

        public CartViewComponent(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartRepository.TryGetByUserId(Constants.UserId);
            var productsCount = cart?.Amount ?? 0;
            return View("Cart", productsCount);
        }
    }
}
