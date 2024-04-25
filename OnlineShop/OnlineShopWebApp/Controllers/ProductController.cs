using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private OnlineShop.Db.IRepository<Product> productRepository;
        private IRepository<Favourities> favouritiesRepository;

        public ProductController(OnlineShop.Db.IRepository<Product> productRepository,
            IRepository<Favourities> favouritiesRepository)
        {
            this.productRepository = productRepository;
            this.favouritiesRepository = favouritiesRepository;
        }

        public IActionResult Index(Guid id)
        {
            var product = productRepository.TryGetElementById(id);
            if (product is null)
                throw new NullReferenceException("Товара с такиим id нет в репозитории!");
            var favourities = favouritiesRepository.TryGetElementById(default);
            if (favourities is null)
                favourities = favouritiesRepository.Add(new Favourities(default));
            ViewBag.isInFavourities = favourities.Contains(Helpers.MappingHelper.ToProductViewModel(product));
            return View(Helpers.MappingHelper.ToProductViewModel(product));
        }
    }
}