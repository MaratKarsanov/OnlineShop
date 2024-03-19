using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private Repository<Product> productRepository;
        private Repository<Cart> cartRepository;

        public CartController(Repository<Product> productRepository, Repository<Cart> cartRepository)
        {
            this.productRepository = productRepository;
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

        private static void AddCart(ref Cart cart, Guid userId)
        {
            cart = new Cart(userId);
            Repositories.CartRepository.Add(cart);
        }
    }
}