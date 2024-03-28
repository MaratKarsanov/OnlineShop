using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

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
            return View("Products", productRepository);
        }

        public IActionResult RemoveProduct(Guid productId)
        {
            productRepository.Remove(productId);
            return View("Products", productRepository);
        }

        public IActionResult ViewProductEdit(Guid productId)
        {
            var product = productRepository.TryGetElementById(productId);
            return View("ProductEdit", product);
        }

        public IActionResult EditProduct(Guid productId, Product newProduct)
        {
            var product = productRepository.TryGetElementById(productId);  
            product.Name = newProduct.Name;
            product.Cost = newProduct.Cost;
            product.Description = newProduct.Description;
            return View("Products", productRepository);
        }
    }
}
