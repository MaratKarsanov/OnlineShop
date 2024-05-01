using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class FavouritesController : Controller
    {
        private OnlineShop.Db.Repositories.Interfaces.IRepository<Product> productRepository;
        private readonly IFavouritesRepository favouritesRepository;

        public FavouritesController(OnlineShop.Db.Repositories.Interfaces.IRepository<Product> productRepository,
            IFavouritesRepository favouritesRepository)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
        }

        public IActionResult Index(string userId)
        {
            var favourites = favouritesRepository.TryGetByUserId(userId);
            if (favourites is null)
                return View(null);
            return View(Helpers.MappingHelper.ToProductViewModels(favourites.Items));
        }

        public IActionResult Add(Guid productId,
            string controllerName = "Home", 
            int pageNumber = 1)
        {
            var product = productRepository.TryGetElementById(productId);
            favouritesRepository.Add(product, Constants.UserId);
            return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
        }

        public IActionResult Remove(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var product = productRepository.TryGetElementById(productId);
            favouritesRepository.Remove(product, Constants.UserId);
            return RedirectToAction(nameof(Index), controllerName, new {pageNumber, id = productId});
        }
    }
}