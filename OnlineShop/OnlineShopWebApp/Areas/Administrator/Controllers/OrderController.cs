using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class OrderController : Controller
    {
        private IRepository<Order> orderRepository;

        public OrderController(IRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            return View(orderRepository.ToList());
        }

        [HttpGet]
        public IActionResult Edit(Guid orderId)
        {
            var order = orderRepository.TryGetElementById(orderId);
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid orderId, OrderStatus status)
        {
            var order = orderRepository.TryGetElementById(orderId);
            order.UpdateStatus(status);
            return RedirectToAction("Index");
        }
    }
}
