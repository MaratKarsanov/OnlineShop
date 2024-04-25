using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class FavouritiesController : Controller
    {
        private OnlineShop.Db.IRepository<Product> productRepository;
        private readonly IRepository<Favourities> favouritiesRepository;

        public FavouritiesController(OnlineShop.Db.IRepository<Product> productRepository,
            IRepository<Favourities> favouritiesRepository)
        {
            this.productRepository = productRepository;
            this.favouritiesRepository = favouritiesRepository;
        }

        public IActionResult Index(Guid userId)
        {
            var favourities = favouritiesRepository.TryGetElementById(userId);
            if (favourities is null)
                favourities = favouritiesRepository.Add(new Favourities(userId));
            return View(favourities);
        }

        public IActionResult Add(Guid productId,
            string controllerName = "Home", 
            int pageNumber = 1)
        {
            var product = productRepository.TryGetElementById(productId);
            var favourities = favouritiesRepository.TryGetElementById(default);
            if (favourities is null)
                favourities = favouritiesRepository.Add(new Favourities(default));
            //favourities.Add(product);
            product.IsInFavourities = true;
            return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
        }

        public IActionResult Remove(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var favourities = favouritiesRepository.TryGetElementById(default);
            if (favourities is null)
                favourities = favouritiesRepository.Add(new Favourities(default));
            var product = productRepository.TryGetElementById(productId);
            favourities.Remove(productId);
            product.IsInFavourities = false;
            return RedirectToAction(nameof(Index), controllerName, new {pageNumber, id = productId});
        }
    }
}
