using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index(Guid userId)
        {
            var cart = Repositories.CartRepository.TryGetElementById(userId);
            if (cart is null)
                AddCart(cart, userId);
            return View(cart);
        }

        public IActionResult Add(Guid productId)
        {
            var product = Repositories.ProductRepository.TryGetElementById(productId);
            var cart = Repositories.CartRepository.TryGetElementById(Constants.UserId);
            if (cart is null)
                AddCart(cart, Constants.UserId);
            cart.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid productId)
        {
            var product = Repositories.ProductRepository.TryGetElementById(productId);
            var cart = Repositories.CartRepository.TryGetElementById(Constants.UserId);
            if (cart is null)
                throw new NullReferenceException("Корзина пользователя не найдена!");
            cart.Remove(product);
            return RedirectToAction("Index");
        }

        private static void AddCart(Cart cart, Guid userId)
        {
            cart = new Cart(userId);
            Repositories.CartRepository.Add(cart);
        }
    }
}