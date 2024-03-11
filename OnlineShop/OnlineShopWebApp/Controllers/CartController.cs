using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index(Guid userId)
        {
            var cart = Repositories.CartRepository.First();
            if (cart is null)
                throw new NullReferenceException("Корзина пользователя не найдена");
            return View(cart);
        }

        public IActionResult Add(Guid productId)
        {
            var product = Repositories.ProductRepository.TryGetElementById(productId);
            var cart = Repositories.CartRepository.First();
            cart.Add(product);
            return RedirectToAction("Index", cart.UserId);
        }
    }
}