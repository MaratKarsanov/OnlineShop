using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ComparisonController : Controller
    {
        private IRepository<Product> productRepository;
        private IRepository<Product> comparisonProducts;

        public ComparisonController(IEnumerable<IRepository<Product>> productRepositories)
        {
            var productRepositoriesList = productRepositories.ToList();
            productRepository = productRepositoriesList[0];
            comparisonProducts = productRepositoriesList[1];
            foreach (var product in productRepository.Take(5))
                comparisonProducts.Add(product);
        }

        public IActionResult Index()
        {
            return View(comparisonProducts);
        }

        public IActionResult Add(Guid productId)
        {
            var product = productRepository.TryGetElementById(productId);
            comparisonProducts.Add(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
