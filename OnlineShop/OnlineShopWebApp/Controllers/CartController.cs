using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository productRepository;
        private ICartRepository cartRepository;

        public CartController(IProductRepository productRepository,
            ICartRepository cartRepository)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
        }

        public IActionResult Index(string userId)
        {
            var cart = cartRepository.TryGetByUserId(userId);
            if (cart is null)
                return View(null);
            return View(Helpers.MappingHelper.ToCartViewModel(cart));
        }

        public IActionResult Add(Guid productId)
        {
            var product = productRepository.TryGetById(productId);
            cartRepository.Add(product, Constants.Login);
            return RedirectToAction(nameof(Index), new { userId = Constants.Login });
        }

        public IActionResult DecreaseAmount(Guid productId)
        {
            cartRepository.DecreaseAmount(productId, Constants.Login);
            return RedirectToAction(nameof(Index), new { userId = Constants.Login });
        }
    }
}