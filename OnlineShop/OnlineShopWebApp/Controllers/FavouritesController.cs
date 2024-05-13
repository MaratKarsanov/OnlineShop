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
            var favourites = favouritesRepository.TryGetByUserId(Request.Cookies["userLogin"]);
            if (favourites is null)
                return View(null);
            return View(Helpers.MappingHelper.ToProductViewModels(favourites.Items));
        }

        public IActionResult Add(Guid productId,
            string controllerName = "Home", 
            int pageNumber = 1)
        {
            var product = productRepository.TryGetById(productId);
            var userLogin = Request.Cookies["userLogin"];
            if (userLogin is null || userLogin == string.Empty)
                return RedirectToAction(nameof(Index));
            favouritesRepository.AddProduct(product, userLogin);
            return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
        }

        public IActionResult Remove(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var product = productRepository.TryGetById(productId);
            var userLogin = Request.Cookies["userLogin"];
            if (userLogin is null || userLogin == string.Empty)
                return RedirectToAction(nameof(Index));
            favouritesRepository.RemoveProduct(product, userLogin);
            return RedirectToAction(nameof(Index), controllerName, new {pageNumber, id = productId});
        }
    }
}