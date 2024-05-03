using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index(Guid id)
        {
            var product = productRepository.TryGetById(id);
            if (product is null)
                throw new NullReferenceException("Товара с такиим id нет в репозитории!");
            return View(Helpers.MappingHelper.ToProductViewModel(product));
        }
    }
}