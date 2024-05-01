using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private OnlineShop.Db.Repositories.Interfaces.IRepository<Product> productRepository;

        public ProductController(OnlineShop.Db.Repositories.Interfaces.IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index(Guid id)
        {
            var product = productRepository.TryGetElementById(id);
            if (product is null)
                throw new NullReferenceException("Товара с такиим id нет в репозитории!");
            return View(Helpers.MappingHelper.ToProductViewModel(product));
        }
    }
}