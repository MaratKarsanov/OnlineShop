using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private OnlineShop.Db.IRepository<Product> productRepository;
        private ICartRepository cartRepository;

        public CartController(OnlineShop.Db.IRepository<Product> productRepository,
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
            var product = productRepository.TryGetElementById(productId);
            cartRepository.Add(product, Constants.UserId);
            return RedirectToAction(nameof(Index), new { userId = Constants.UserId });
        }

        public IActionResult DecreaseAmount(Guid productId)
        {
            cartRepository.DecreaseAmount(productId, Constants.UserId);
            return RedirectToAction(nameof(Index), new { userId = Constants.UserId });
        }
    }
}