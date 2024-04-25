using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ComparisonController : Controller
    {
        private OnlineShop.Db.IRepository<Product> productRepository;
        private IRepository<ProductViewModel> comparisonProducts;

        public ComparisonController(IRepository<ProductViewModel> productRepositories,
            OnlineShop.Db.IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
            comparisonProducts = productRepositories;
        }

        public IActionResult Index()
        {
            return View(comparisonProducts);
        }

        public IActionResult Add(Guid productId)
        {
            var product = productRepository.TryGetElementById(productId);
            //comparisonProducts.Add(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
