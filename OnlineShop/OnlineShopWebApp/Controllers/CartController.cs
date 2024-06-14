using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private IProductRepository productRepository;
        private ICartRepository cartRepository;
        private IMapper mapper;

        public CartController(IProductRepository productRepository,
            ICartRepository cartRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var cart = await cartRepository.TryGetByLoginAsync(User.Identity.Name);
            if (cart is null)
                cart = await cartRepository.AddCartAsync(User.Identity.Name);
            return View(mapper.Map<CartViewModel>(cart));
        }

        public async Task<IActionResult> Add(Guid productId)
        {
            var userLogin = User.Identity.Name;
            var product = await productRepository.TryGetByIdAsync(productId);
            await cartRepository.AddProductAsync(product, userLogin);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DecreaseAmount(Guid productId)
        {
            var userLogin = User.Identity.Name;
            await cartRepository.DecreaseAmountAsync(productId, userLogin);
            return RedirectToAction(nameof(Index));
        }
    }
}