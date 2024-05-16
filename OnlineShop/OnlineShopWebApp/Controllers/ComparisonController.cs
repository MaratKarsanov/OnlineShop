using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
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
            var comparison = comparisonRepository.TryGetByUserId(User.Identity.Name);
            if (comparison is null)
                comparison = comparisonRepository.AddComparison(User.Identity.Name);
            return View(Helpers.MappingHelper.ToComparisonViewModel(comparison));
        }

        public IActionResult Add(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var product = productRepository.TryGetById(productId);
            var userLogin = User.Identity.Name;
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
            var userLogin = User.Identity.Name;
            if (userLogin is null || userLogin == string.Empty)
                return RedirectToAction(nameof(Index));
            comparisonRepository.RemoveProduct(product, userLogin);
            return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
        }
    }
}
