using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private IRepository<Product> productRepository;

        public ProductController(IEnumerable<IRepository<Product>> productRepositories)
        {
            productRepository = productRepositories.First();
        }

        public IActionResult Index(Guid id)
        {
            var product = productRepository.TryGetElementById(id);
            if (product is null)
                throw new NullReferenceException("Товара с такиим id нет в репозитории!");
            return View(product);
        }
    }
}