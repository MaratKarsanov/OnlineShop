using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Data;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ProductController : Controller
    {
        private OnlineShop.Db.IRepository<Product> productRepository;

        public ProductController(OnlineShop.Db.IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View(Helpers.MappingHelper.
                ToProductViewModels(productRepository.
                GetAll()).
                OrderBy(p => p.Name));
        }

        public IActionResult Remove(Guid productId)
        {
            productRepository.Remove(productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            if (!ModelState.IsValid)
                return View();
            newProduct.Id = Guid.NewGuid();
            newProduct.ImageLink = Constants.ImageLink;
            productRepository.Add(newProduct);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(Guid productId)
        {
            var product = productRepository.TryGetElementById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel newProduct)
        {
            if (!ModelState.IsValid)
                return View();
            var product = productRepository.TryGetElementById(newProduct.Id);
            product.Name = newProduct.Name;
            product.Cost = newProduct.Cost;
            product.Description = newProduct.Description;
            product.ImageLink = Constants.ImageLink;
            return RedirectToAction(nameof(Index));
        }
    }
}
