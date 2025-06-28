using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;
using Serilog;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartController(
            IProductRepository productRepository,
            ICartRepository cartRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var cart = await _cartRepository.TryGetByLoginAsync(User.Identity.Name);
                if (cart is null)
                {
                    cart = await _cartRepository.AddCartAsync(User.Identity.Name);
                }
                return View(_mapper.Map<CartViewModel>(cart));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        public async Task<IActionResult> Add(Guid productId)
        {
            try
            {
                var userLogin = User.Identity.Name;
                var product = await _productRepository.TryGetByIdAsync(productId);
                await _cartRepository.AddProductAsync(product, userLogin);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        public async Task<IActionResult> DecreaseAmount(Guid productId)
        {
            try
            {
                var userLogin = User.Identity.Name;
                await _cartRepository.DecreaseAmountAsync(productId, userLogin);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }
    }
}