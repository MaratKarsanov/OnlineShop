using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;

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
            var userName = User.Identity.Name;
            var cart = cartRepository.TryGetByLogin(userName);
            var productsCount = cart?.Amount ?? 0;
            return View("Cart", productsCount);
        }
    }
}
