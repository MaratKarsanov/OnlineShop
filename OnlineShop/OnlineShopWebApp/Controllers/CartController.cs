using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index(Guid userId)
        {
            if (!Repositories.CartIdByUserId.ContainsKey(userId))
                AddCart(userId);
            var cart = Repositories.CartRepository.TryGetElementById(Repositories.CartIdByUserId[userId]);
            return View(cart);
        }

        public IActionResult Add(Guid productId)
        {
            var product = Repositories.ProductRepository.TryGetElementById(productId);
            if (!Repositories.CartIdByUserId.ContainsKey(Constants.UserId))
                AddCart(Constants.UserId);
            var cart = Repositories.CartRepository.TryGetElementById(Repositories.CartIdByUserId[Constants.UserId]);
            cart.Add(product);
            return RedirectToAction("Index");
        }

        private static void AddCart(Guid userId)
        {
            var newCart = new Cart(userId);
            if (!Repositories.CartRepository.Contains(newCart))
                Repositories.CartRepository.Add(newCart);
            Repositories.CartIdByUserId.Add(userId, newCart.Id);
        }
    }
}