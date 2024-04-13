using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Immutable;
using System.Data;

namespace OnlineShopWebApp.Controllers
{
    public class AdministratorController : Controller
    {
        private IRepository<Product> productRepository;
        private IRepository<Role> roleRepository;
        private IRepository<Order> orderRepository;

        public AdministratorController(
            IEnumerable<IRepository<Product>> productRepositories,
            IRepository<Order> orderRepository,
            IRepository<Role> roleRepository)
        {
            productRepository = productRepositories.First();
            this.roleRepository = roleRepository;
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
            return View(roleRepository);
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
        public IActionResult AddProduct()
        {
            return View();
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

        public IActionResult RemoveRole(Guid roleId)
        {
            roleRepository.Remove(roleId);
            return RedirectToAction("Roles");
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role newRole)
        {
            if (roleRepository.Where(r => r.Name == newRole.Name).Count() > 0)
                ModelState.AddModelError("", "Такая роль уже существует");
            if (!ModelState.IsValid)
                return View();
            newRole.Id = Guid.NewGuid();
            roleRepository.Add(newRole);
            return RedirectToAction("Roles");
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
