using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class FavouritesController : Controller
    {
        private IProductRepository productRepository;
        private readonly IFavouritesRepository favouritesRepository;

        public FavouritesController(IProductRepository productRepository,
            IFavouritesRepository favouritesRepository)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
        }

        public IActionResult Index()
        {
            var favourites = favouritesRepository.TryGetByUserName(User.Identity.Name);
            if (favourites is null)
                favourites = favouritesRepository.AddFavourites(User.Identity.Name);
            return View(Helpers.MappingHelper.ToProductViewModels(favourites.Items));
        }

        public IActionResult Add(Guid productId,
            string controllerName = "Home", 
            int pageNumber = 1)
        {
            var product = productRepository.TryGetById(productId);
            favouritesRepository.AddProduct(product, User.Identity.Name);
            return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
        }

        public IActionResult Remove(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var product = productRepository.TryGetById(productId);
            favouritesRepository.RemoveProduct(product, User.Identity.Name);
            return RedirectToAction(nameof(Index), controllerName, new {pageNumber, id = productId});
        }
    }
}