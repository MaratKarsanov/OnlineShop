using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index(Guid userId)
        {
            if (Repositories.CartRepository.TryGetElementById(userId) is null)
                Repositories.CartRepository.Add(new Cart(userId));
            var cart = Repositories.CartRepository.TryGetElementById(userId);
            return View(cart);
        }

        public IActionResult Add(Guid productId)
        {
            var product = Repositories.ProductRepository.TryGetElementById(productId);
            if (Repositories.CartRepository.TryGetElementById(Constants.UserId) is null)
                Repositories.CartRepository.Add(new Cart(Constants.UserId));
            var cart = Repositories.CartRepository.TryGetElementById(Constants.UserId);
            cart.Add(product);
            return RedirectToAction("Index");
        }
    }
}