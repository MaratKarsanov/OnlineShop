using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.Components
{
    public class CartViewComponent : ViewComponent
    { 
        private readonly IRepository<Cart> cartRepository;

        public CartViewComponent(IRepository<Cart> cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartRepository.TryGetElementById(Constants.UserId);
            var productsCount = cart?.Amount ?? 0;

            return View("Cart", productsCount);
        }
    }
}
