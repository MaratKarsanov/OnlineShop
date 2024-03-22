using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private IRepository<Product> productRepository;
        private IRepository<Cart> cartRepository;

        public CartController(IEnumerable<IRepository<Product>> productRepositories, IRepository<Cart> cartRepository)
        {
            productRepository = productRepositories.First();
            this.cartRepository = cartRepository;
        }

        public IActionResult Index(Guid userId)
        {
            var cart = cartRepository.TryGetElementById(userId);
            if (cart is null)
                cart = cartRepository.Add(new Cart(userId));
            return View(cart);
        }

        public IActionResult Add(Guid productId)
        {
            var product = productRepository.TryGetElementById(productId);
            var cart = cartRepository.TryGetElementById(Constants.UserId);
            if (cart is null)
                cart = cartRepository.Add(new Cart(Constants.UserId));
            cart.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid productId)
        {
            var product = productRepository.TryGetElementById(productId);
            var cart = cartRepository.TryGetElementById(Constants.UserId);
            if (cart is null)
                throw new NullReferenceException("Не найдена корзина пользователя!");
            cart.Remove(product);
            return RedirectToAction("Index");
        }
    }
}