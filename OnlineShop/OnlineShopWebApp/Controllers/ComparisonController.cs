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

        public IActionResult Index()
        {
            var comparison = comparisonRepository.TryGetByUserId(Request.Cookies["userLogin"]);
            if (comparison is null)
                return View(null);
            return View(Helpers.MappingHelper.ToComparisonViewModel(comparison));
        }

        public IActionResult Add(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var product = productRepository.TryGetById(productId);
            var userLogin = Request.Cookies["userLogin"];
            if (userLogin is null || userLogin == string.Empty)
                return RedirectToAction(nameof(Index));
            comparisonRepository.AddProduct(product, userLogin);
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
            comparisonRepository.Remove(product, userLogin);
            return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
        }
    }
}
