using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Immutable;

namespace OnlineShopWebApp.Controllers
{
    public class AdministratorController : Controller
    {
        private IRepository<Product> productRepository;

        public AdministratorController(IEnumerable<IRepository<Product>> productRepositories)
        {
            productRepository = productRepositories.First();
        }

        public IActionResult ViewOrders()
        {
            return View("Orders");
        }

        public IActionResult ViewUsers()
        {
            return View("Users");
        }

        public IActionResult ViewRoles()
        {
            return View("Roles");
        }

        public IActionResult ViewProducts()
        {
            return View("Products", productRepository.OrderBy(p => p.Name));
        }

        public IActionResult RemoveProduct(Guid productId)
        {
            productRepository.Remove(productId);
            return RedirectToAction("ViewProducts");
        }

        public IActionResult ViewProductEdit(Guid productId)
        {
            var product = productRepository.TryGetElementById(productId);
            return View("ProductEdit", product);
        }

        public IActionResult ViewProductAdd(Guid productId)
        {
            var product = productRepository.TryGetElementById(productId);
            return View("ProductAdd", product);
        }

        public IActionResult EditProduct(Guid productId, Product newProduct)
        {
            var product = productRepository.TryGetElementById(productId);  
            product.Name = newProduct.Name;
            product.Cost = newProduct.Cost;
            product.Description = newProduct.Description;
            product.ImageLink = Constants.ImageLink;
            return RedirectToAction("ViewProducts");
        }

        public IActionResult AddProduct(Product newProduct)
        {
            newProduct.Id = Guid.NewGuid();
            newProduct.ImageLink = Constants.ImageLink;
            productRepository.Add(newProduct);
            return RedirectToAction("ViewProducts");
        }
    }
}
