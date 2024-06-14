using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class FavouritesController : Controller
    {
        private IProductRepository productRepository;
        private readonly IFavouritesRepository favouritesRepository;
        private IMapper mapper;

        public FavouritesController(IProductRepository productRepository,
            IFavouritesRepository favouritesRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var favourites = await favouritesRepository.TryGetByUserNameAsync(User.Identity.Name);
            if (favourites is null)
                favourites = await favouritesRepository.AddFavouritesAsync(User.Identity.Name);
            return View(mapper.Map<List<ProductViewModel>>(favourites.Items));
        }

        public async Task<IActionResult> Add(Guid productId,
            string controllerName = "Home", 
            int pageNumber = 1)
        {
            var product = await productRepository.TryGetByIdAsync(productId);
            await favouritesRepository.AddProductAsync(product, User.Identity.Name);
            return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
        }

        public async Task<IActionResult> Remove(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var product = await productRepository.TryGetByIdAsync(productId);
            await favouritesRepository.RemoveProductAsync(product, User.Identity.Name);
            return RedirectToAction(nameof(Index), controllerName, new {pageNumber, id = productId});
        }
    }
}