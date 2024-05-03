using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class ComparisonController : Controller
    {
        private IProductRepository productRepository;
        private IComparisonRepository comparisonRepository;

        public ComparisonController(IComparisonRepository productRepositories,
            IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            comparisonRepository = productRepositories;
        }

        public IActionResult Index(string userId)
        {
            var comparison = comparisonRepository.TryGetByUserId(userId);
            if (comparison is null)
                return View(null);
            return View(Helpers.MappingHelper.ToComparisonViewModel(comparison));
        }

        public IActionResult Add(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var product = productRepository.TryGetById(productId);
            comparisonRepository.Add(product, Constants.Login);
            return RedirectToAction(nameof(Index), controllerName, new {pageNumber, id = productId, userId = Constants.Login});
        }

        public IActionResult Remove(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var product = productRepository.TryGetById(productId);
            comparisonRepository.Remove(product, Constants.Login);
            return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId, userId = Constants.Login });
        }
    }
}
