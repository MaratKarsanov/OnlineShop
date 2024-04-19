using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Data;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ProductController : Controller
    {
        private IRepository<Product> productRepository;

        public ProductController(IEnumerable<IRepository<Product>> productRepositories)
        {
            productRepository = productRepositories.First();
        }

        public IActionResult Index()
        {
            return View(productRepository.OrderBy(p => p.Name));
        }

        public IActionResult Remove(Guid productId)
        {
            productRepository.Remove(productId);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid productId)
        {
            var product = productRepository.TryGetElementById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product newProduct)
        {
            if (!ModelState.IsValid)
                return View();
            var product = productRepository.TryGetElementById(newProduct.Id);
            product.Name = newProduct.Name;
            product.Cost = newProduct.Cost;
            product.Description = newProduct.Description;
            product.ImageLink = Constants.ImageLink;
            return RedirectToAction("Index");
        }
    }
}
