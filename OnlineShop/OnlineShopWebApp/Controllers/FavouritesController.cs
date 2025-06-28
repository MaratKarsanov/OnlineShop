using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;
using Serilog;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class FavouritesController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IFavouritesRepository _favouritesRepository;
        private readonly IMapper _mapper;

        public FavouritesController(IProductRepository productRepository,
            IFavouritesRepository favouritesRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _favouritesRepository = favouritesRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var favourites = await _favouritesRepository.TryGetByUserNameAsync(User.Identity.Name);
                if (favourites is null)
                {
                    favourites = await _favouritesRepository.AddFavouritesAsync(User.Identity.Name);
                }
                return View(_mapper.Map<List<ProductViewModel>>(favourites.Items));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        public async Task<IActionResult> Add(
            Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            try
            {
                var product = await _productRepository.TryGetByIdAsync(productId);
                await _favouritesRepository.AddProductAsync(product, User.Identity.Name);
                return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        public async Task<IActionResult> Remove(
            Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            try
            {
                var product = await _productRepository.TryGetByIdAsync(productId);
                await _favouritesRepository.RemoveProductAsync(product, User.Identity.Name);
                return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }
    }
}