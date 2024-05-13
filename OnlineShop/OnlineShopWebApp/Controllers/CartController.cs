using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
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

        public IActionResult Index()
        {
            var cart = cartRepository.TryGetByLogin(Request.Cookies["userLogin"]);
            if (cart is null)
                return View(null);
            return View(Helpers.MappingHelper.ToCartViewModel(cart));
        }

        public IActionResult Add(Guid productId)
        {
            var userLogin = Request.Cookies["userLogin"];
            if (userLogin is null || userLogin == string.Empty)
                return RedirectToAction(nameof(Index));
            var product = productRepository.TryGetById(productId);
            cartRepository.AddProduct(product, userLogin);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DecreaseAmount(Guid productId)
        {
            var userLogin = Request.Cookies["userLogin"];
            if (userLogin is null || userLogin == string.Empty)
                return RedirectToAction(nameof(Index));
            cartRepository.DecreaseAmount(productId, userLogin);
            return RedirectToAction(nameof(Index));
        }
    }
}