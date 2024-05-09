using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;
using System.Data;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
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
            var product = productRepository.TryGetById(productId);
            return View(Helpers.MappingHelper.ToProductViewModel(product));
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel newProduct)
        {
            if (!ModelState.IsValid)
                return View();
            productRepository.EditProduct(Helpers.MappingHelper.ToProduct(newProduct));
            return RedirectToAction(nameof(Index));
        }
    }
}
