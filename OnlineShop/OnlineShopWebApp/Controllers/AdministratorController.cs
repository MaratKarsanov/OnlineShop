using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Immutable;

namespace OnlineShopWebApp.Controllers
{
    public class AdministratorController : Controller
    {
        private IRepository<Product> productRepository;
        private IRepository<Order> orderRepository;

        public AdministratorController(
            IEnumerable<IRepository<Product>> productRepositories,
            IRepository<Order> orderRepository)
        {
            productRepository = productRepositories.First();
            this.orderRepository = orderRepository;
        }

        public IActionResult Orders()
        {
            return View(orderRepository.ToList());
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View(productRepository.OrderBy(p => p.Name));
        }

        [HttpGet]
        public IActionResult EditProduct(Guid productId)
        {
            if (!ModelState.IsValid)
                return View();
            var product = productRepository.TryGetElementById(productId);
            return View(product);
        }

        [HttpGet]
        public IActionResult AddProduct(Guid productId)
        {
            if (!ModelState.IsValid)
                return View();
            var product = productRepository.TryGetElementById(productId);
            return View(product);
        }

        public IActionResult RemoveProduct(Guid productId)
        {
            productRepository.Remove(productId);
            return RedirectToAction("Products");
        }

        [HttpPost]
        public IActionResult EditProduct(Guid productId, Product newProduct)
        {
            var product = productRepository.TryGetElementById(productId);  
            product.Name = newProduct.Name;
            product.Cost = newProduct.Cost;
            product.Description = newProduct.Description;
            product.ImageLink = Constants.ImageLink;
            return RedirectToAction("Products");
        }

        [HttpPost]
        public IActionResult AddProduct(Product newProduct)
        {
            newProduct.Id = Guid.NewGuid();
            newProduct.ImageLink = Constants.ImageLink;
            productRepository.Add(newProduct);
            return RedirectToAction("Products");
        }

        [HttpGet]
        public IActionResult EditOrder(Guid orderId)
        {
            var order = orderRepository.TryGetElementById(orderId);
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            var order = orderRepository.TryGetElementById(orderId);
            order.UpdateStatus(status);
            return RedirectToAction("Orders");
        }
    }
}
