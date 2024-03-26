using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private IRepository<Cart> cartRepository;
        private IRepository<Order> orderRepository;

        public OrderController(IRepository<Cart> cartRepository, IRepository<Order> orderRepository)
        {
            this.cartRepository = cartRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Index(Guid orderId)
        {
            var order = orderRepository.TryGetElementById(orderId);
            if (order is null)
                return View("Index");
            return View("Success", order);
        }

        [HttpPost]
        public IActionResult AddOrder(Order newOrder)
        {
            var products = cartRepository.TryGetElementById(Constants.UserId).ToList();
            newOrder.Products = products;
            orderRepository.Add(newOrder);
            cartRepository.Remove(Constants.UserId);
            return RedirectToAction("Index", new {orderId = newOrder.Id});
        }
    }
}
