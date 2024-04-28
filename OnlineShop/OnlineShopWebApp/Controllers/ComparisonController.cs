using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ComparisonController : Controller
    {
        private OnlineShop.Db.IRepository<Product> productRepository;
        private IComparisonRepository comparisonRepository;

        public ComparisonController(IComparisonRepository productRepositories,
            OnlineShop.Db.IRepository<Product> productRepository)
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
            var product = productRepository.TryGetElementById(productId);
            comparisonRepository.Add(product, Constants.UserId);
            return RedirectToAction(nameof(Index), controllerName, new {pageNumber, id = productId, userId = Constants.UserId});
        }

        public IActionResult Remove(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var product = productRepository.TryGetElementById(productId);
            comparisonRepository.Remove(product, Constants.UserId);
            return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId, userId = Constants.UserId });
        }
    }
}
