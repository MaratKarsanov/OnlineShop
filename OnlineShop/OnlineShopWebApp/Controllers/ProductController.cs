using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private IRepository<Product> productRepository;
        private IRepository<Favourities> favouritiesRepository;

        public ProductController(IEnumerable<IRepository<Product>> productRepositories,
            IRepository<Favourities> favouritiesRepository)
        {
            productRepository = productRepositories.First();
            this.favouritiesRepository = favouritiesRepository;
        }

        public IActionResult Index(Guid id)
        {
            var product = productRepository.TryGetElementById(id);
            if (product is null)
                throw new NullReferenceException("Товара с такиим id нет в репозитории!");
            var favourities = favouritiesRepository.TryGetElementById(Constants.UserId);
            if (favourities is null)
                favourities = favouritiesRepository.Add(new Favourities(Constants.UserId));
            ViewBag.isInFavourities = favourities.Contains(product);
            return View(product);
        }
    }
}